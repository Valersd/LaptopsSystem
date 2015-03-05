using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Microsoft.AspNet.Identity;

using LaptopsSystem.Data;
using LaptopsSystem.Models;


namespace LaptopsSystem.Web.Controllers
{
    [Authorize]
    public abstract class BaseController : Controller
    {
        private readonly ILaptopsSystemData _data;

        public BaseController(ILaptopsSystemData data)
        {
            _data = data;
        }

        public ILaptopsSystemData Data
        {
            get { return _data; }
        }

        public User CurrentUser
        {
            get { return User.Identity.IsAuthenticated ? _data.Users.GetById(User.Identity.GetUserId()) : default(User); }
        }

        public string CurrentUserId
        {
            get { return User.Identity.IsAuthenticated ? User.Identity.GetUserId() : default(string); }
        }
    }
}