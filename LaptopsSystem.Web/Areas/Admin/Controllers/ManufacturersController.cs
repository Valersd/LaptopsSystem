using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

using System.Data.Entity;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using LaptopsSystem.Data;
using LaptopsSystem.Models;
using LaptopsSystem.Web.Areas.Admin.Models;


namespace LaptopsSystem.Web.Areas.Admin.Controllers
{
    public class ManufacturersController : AdminController
    {
        public ManufacturersController(ILaptopsSystemData data)
            :base(data)
        {
        }

        // GET: Admin/Manufacturers
        public ActionResult Index()
        {
            var manufacturers = Data.Manufacturers
                .All()
                .Include(m => m.Laptops)
                .OrderBy(m=>m.Name)
                .Project()
                .To<ManufacturerIndex>()
                .ToList();

            return View(manufacturers);
        }

        // GET: Admin/Manufacturers/Create
        public ActionResult Create()
        {
            return View(new ManufacturerInput());
        }

        // POST: Admin/Manufacturers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManufacturerInput model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Name = model.Name.ToUpper();
                    var manufacturer = Mapper.Map<Manufacturer>(model);
                    Data.Manufacturers.Add(manufacturer);
                    Data.SaveChanges();
                    HttpContext.Cache.Remove("Manufacturers");
                    TempData["Message"] = "Manufacturer successfully added";
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred. Maybe manufacturer with that name already exists");
                return View(model);
            }
        }

        // GET: Admin/Manufacturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var manufacturer = Data.Manufacturers.GetById(id.Value);

            if (manufacturer == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<ManufacturerEdit>(manufacturer);

            return View(model);
        }

        // POST: Admin/Manufacturers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManufacturerEdit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Name = model.Name.ToUpper();

                    var edited = Mapper.Map<Manufacturer>(model);
                    Data.Manufacturers.Update(edited);
                    Data.SaveChanges();
                    HttpContext.Cache.Remove("Manufacturers");
                    TempData["Message"] = "Manufacturer successfully updated";

                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred. Maybe manufacturer with that name already exists");
                return View(model);
            }
        }

        // POST: Admin/Manufacturers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Data.Manufacturers.Delete(id.Value);
                Data.SaveChanges();
                HttpContext.Cache.Remove("Manufacturers");
                TempData["Message"] = "Manufacturer successfully deleted";
                
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { area="" });
            }
        }
    }
}
