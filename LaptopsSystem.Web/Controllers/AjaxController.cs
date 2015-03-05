using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using LaptopsSystem.Data;
using LaptopsSystem.Models;
using LaptopsSystem.Web.Models;
using LaptopsSystem.Web.ViewModels;
using AutoMapper;

namespace LaptopsSystem.Web.Controllers
{
    [Authorize]
    public class AjaxController : BaseController
    {
        public AjaxController(ILaptopsSystemData data)
            :base(data)
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

                return PartialView("_CommentInLaptop", result);
            }
            return RedirectToAction("Error", "Home", new { area = "" });
        }
    }
}