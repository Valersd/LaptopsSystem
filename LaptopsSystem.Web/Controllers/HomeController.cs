using LaptopsSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaptopsSystem.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        public HomeController(ILaptopsSystemData data)
            :base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}