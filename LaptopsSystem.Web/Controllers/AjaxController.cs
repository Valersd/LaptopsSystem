using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using LaptopsSystem.Data;
using LaptopsSystem.Models;
using LaptopsSystem.Common;
using LaptopsSystem.Web.Models;
using LaptopsSystem.Web.ViewModels;
using LaptopsSystem.Web.Areas.Admin.Models;

namespace LaptopsSystem.Web.Controllers
{
    [Authorize]
    public class AjaxController : BaseController
    {
        public AjaxController(ILaptopsSystemData data)
            : base(data)
        {
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Vote(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                Vote vote = new Vote
                {
                    LaptopId = id,
                    UserId = CurrentUserId
                };

                try
                {
                    Data.Votes.Add(vote);
                    Data.SaveChanges();
                }
                catch (Exception)
                {
                    return Json(new { message = "An error occured while voting. Maybe you already voted" });
                }
            }
            return Json(new { message = "Success" });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Comment(CommentInput comment)
        {
            if (ModelState.IsValid)
            {
                var newComment = Mapper.Map<Comment>(comment);
                newComment.AuthorId = CurrentUserId;

                Data.Comments.Add(newComment);
                Data.SaveChanges();

                var result = Mapper.Map<CommentInLaptop>(newComment);
                result.Author = CurrentUser.UserName;

                return PartialView("_CommentInLaptop", result);
            }
            return RedirectToAction("Error", "Home", new { area = "" });
        }

        public ActionResult Search(string term)
        {
            var laptops = Data.Laptops
                .All()
                .Include(l => l.Manufacturer)
                .Where(l => l.Model.Contains(term) || l.Manufacturer.Name.Contains(term))
                .OrderBy(l => l.Manufacturer.Name)
                .ThenBy(l => l.Model)
                .ToList()
                .Select(l => new
                {
                    id = l.Id,
                    label = l.Manufacturer.Name + " " + l.Model
                })
                .ToList();

            return Json(laptops, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles=GlobalConstants.AdminRole)]
        public ActionResult Laptops(int? manufacturerId)
        {
            var laptops = Data.Laptops
                .All()
                .Include(l => l.Manufacturer)
                .Include(l => l.Monitor);

            if (manufacturerId.HasValue)
            {
                laptops = laptops.Where(l => l.ManufacturerId == manufacturerId.Value);
            }

            var result = laptops
            .OrderBy(l => l.Manufacturer.Name)
            .ThenBy(l => l.Model)
            .Project()
            .To<LaptopAdminIndex>()
            .ToList();

            return PartialView("_Laptops", result);
        }
    }
}