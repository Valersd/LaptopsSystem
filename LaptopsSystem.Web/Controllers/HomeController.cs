using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using AutoMapper.QueryableExtensions;

using LaptopsSystem.Data;
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Infrastructure.Cache;

namespace LaptopsSystem.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private ICacheService _cacheService;

        public HomeController(ILaptopsSystemData data, ICacheService cacheService)
            :base(data)
        {
            _cacheService = cacheService;
        }

        public ICacheService CacheService
        {
            get { return _cacheService; }
        }

        public ActionResult Index()
        {
            var laptops = CacheService.Laptops;

            return View(laptops);
        }

        

    }
}