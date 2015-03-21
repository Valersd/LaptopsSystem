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
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Infrastructure.Cache;
using System.Data.Entity.Infrastructure;

namespace LaptopsSystem.Web.Areas.Admin.Controllers
{
    public class LaptopsController : AdminController
    {
        private ICacheService _cacheService;
        public LaptopsController(ILaptopsSystemData data, ICacheService cacheService)
            : base(data)
        {
            _cacheService = cacheService;
        }

        // GET: Admin/Laptops
        public ActionResult Index()
        {
            var laptops = Data.Laptops
                .All()
                .Include(l => l.Manufacturer)
                .Include(l => l.Monitor)
                .OrderBy(l => l.Manufacturer.Name)
                .ThenBy(l => l.Model)
                .Project()
                .To<LaptopAdminIndex>()
                .ToList();
            return View(laptops);
        }

        // GET: Admin/Laptops/Create
        public ActionResult Create()
        {
            ViewBag.Manufacturers = _cacheService.Manufacturers;
            ViewBag.MonitorSizes = _cacheService.MonitorSizes;
            return View(new LaptopInput());
        }

        // POST: Admin/Laptops/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LaptopInput input)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var laptop = Mapper.Map<Laptop>(input);
                    Data.Laptops.Add(laptop);
                    Data.SaveChanges();
                    TempData["Message"] = laptop.Model + " successfully added";

                    return RedirectToAction("Index");
                }

                ViewBag.Manufacturers = _cacheService.Manufacturers;
                ViewBag.MonitorSizes = _cacheService.MonitorSizes;
                return View(input);
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred. Try again");
                ViewBag.Manufacturers = _cacheService.Manufacturers;
                ViewBag.MonitorSizes = _cacheService.MonitorSizes;
                return View(input);
            }
        }

        // GET: Admin/Laptops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var laptop = Data.Laptops
                .All()
                .Include(l => l.Manufacturer)
                .Include(l => l.Monitor)
                .Where(l => l.Id == id.Value)
                .Project()
                .To<LaptopEdit>()
                .FirstOrDefault();

            if (laptop == null)
            {
                return HttpNotFound();
            }

            PopulateMonitorSizesInEdit(laptop);

            return View(laptop);
        }

        // POST: Admin/Laptops/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LaptopEdit edited)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var laptop = Mapper.Map<Laptop>(edited);
                    Data.Laptops.Update(laptop, "ManufacturerId", "MonitorId", "Model");
                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            Data.SaveChanges();
                            
                        }
                        catch (DbUpdateConcurrencyException dbex )
                        {
                            saveFailed = true;
                            dbex.Entries.Single().Reload();
                        }
                    } while (saveFailed);
                    TempData["Message"] = "Laptop successfully updated";
                    return RedirectToAction("Index");
                }
                PopulateMonitorSizesInEdit(edited);
                return View(edited);
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred.Try again");
                PopulateMonitorSizesInEdit(edited);
                return View(edited);
            }
        }

        // POST: Admin/Laptops/Delete/5
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
                Data.Laptops.Delete(id.Value);
                Data.SaveChanges();
                TempData["Message"] = "Laptop successfully deleted";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        private void PopulateMonitorSizesInEdit(LaptopEdit laptop)
        {
            ViewBag.MonitorSizes = _cacheService.MonitorSizes
                .Select(s => new SelectListItem
                {
                    Value = s.Value,
                    Text = s.Text,
                    Selected = s.Value.Equals(laptop.MonitorSizeId.ToString())
                });
        }
    }
}
