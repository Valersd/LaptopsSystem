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
        private readonly User _currentUser;

        public BaseController(ILaptopsSystemData data)
        {
            _data = data;
            _currentUser = User == null ? default(User) : _data.Users.GetById(User.Identity.GetUserId());
        }

        public ILaptopsSystemData Data
        {
            get { return this._data; }
        }

        public User CurrentUser
        {
            get { return this._currentUser; }
        }
    }
}