using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LaptopsSystem.Web.Controllers;
using LaptopsSystem.Data;
using LaptopsSystem.Common;


namespace LaptopsSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles=GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public AdminController(ILaptopsSystemData data)
            :base(data)
        {
        }
    }
}