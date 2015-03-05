using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using LaptopsSystem.Data;
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Infrastructure.Cache;

namespace LaptopsSystem.Web.Controllers
{
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

        [AllowAnonymous]
        public ActionResult Index()
        {
            var laptops = CacheService.Laptops;

            return View(laptops);
        }

        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var laptop = Data.Laptops
                .All()
                .Include(l => l.Manufacturer)
                .Include(l => l.Monitor)
                .Include(l => l.Comments.Select(c=>c.Author))
                .Include(l => l.Votes)
                .FirstOrDefault(l => l.Id == id.Value);

            if (laptop == null)
            {
                return HttpNotFound();
            }

            var model = Mapper.Map<LaptopDetails>(laptop);
            if (User.Identity.IsAuthenticated)
            {
                model.HasVoted = laptop.Votes.Any(v => v.UserId == CurrentUserId);
            }

            return View(model);
        }

    }
}