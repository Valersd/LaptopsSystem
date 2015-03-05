using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using PagedList;
using PagedList.Mvc;

using LaptopsSystem.Data;
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Infrastructure.Cache;
using LaptopsSystem.Models;

namespace LaptopsSystem.Web.Controllers
{
    public class LaptopsController : BaseController
    {
        private ICacheService _cacheService;

        public LaptopsController(ILaptopsSystemData data, ICacheService cacheService)
            :base(data)
        {
            _cacheService = cacheService;
        }

        public ICacheService CacheService
        {
            get { return _cacheService; }
        }

        public ActionResult Index(int? page, string model = "", int manufacturer = 0, decimal from = 0m, decimal to = 10000m)
        {
            var laptops = Data.Laptops.All().Include(l=>l.Manufacturer);
            if (manufacturer != 0)
            {
                laptops = laptops.Where(l => l.ManufacturerId == manufacturer);
            }
            if (!string.IsNullOrEmpty(model))
            {
                laptops = laptops.Where(l => l.Model.Contains(model));
            }
            var result = laptops.Where(l => l.Price >= from && l.Price <= to)
                .OrderBy(l => l.Price)
                .Project<Laptop>().To<LaptopIndex>()
                .ToPagedList(page ?? 1, 5);

            ViewBag.Manufacturers = CacheService.Manufacturers;
            ViewBag.LaptopModel = model;
            ViewBag.From = from;
            ViewBag.To = to;
            

            return View(result);
        }
    }
}