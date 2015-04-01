using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using PagedList;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using LaptopsSystem.Data;
using LaptopsSystem.Models;
using LaptopsSystem.Web.Areas.Admin.Models;
using LaptopsSystem.Web.ViewModels;

namespace LaptopsSystem.Web.Areas.Admin.Controllers
{
    public class CommentsController : AdminController
    {
        public CommentsController(ILaptopsSystemData data)
            :base(data)
        {
        }

        // GET: Admin/Comments
        public ActionResult Index(int? page)
        {
            var comments = Data.Comments
                .All()
                .Include(c => c.Laptop)
                .Include(c => c.Author)
                .OrderByDescending(c => c.Id)
                .Project()
                .To<CommentIndex>()
                .ToPagedList(page ?? 1, 10);

            return View(comments);
        }

        // GET: Admin/Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var comment = Data.Comments
                .All()
                .Include(c => c.Laptop)
                .Include(c => c.Author)
                .Where(c => c.Id == id.Value)
                .Project()
                .To<CommentEdit>()
                .FirstOrDefault();

            if (comment == null)
            {
                return HttpNotFound();
            }

            return View(comment);
        }

        // POST: Admin/Comments/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CommentEdit edited)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var comment = Mapper.Map<Comment>(edited);
                    Data.Comments.Update(comment, c => c.LaptopId, c => c.AuthorId);
                    //Data.Comments.Update(comment, "LaptopId", "AuthorId");
                    bool saveFailed;
                    do
                    {
                        saveFailed = false;
                        try
                        {
                            Data.SaveChanges();

                        }
                        catch (DbUpdateConcurrencyException dbex)
                        {
                            saveFailed = true;
                            dbex.Entries.Single().Reload();
                        }
                    } while (saveFailed);
                    TempData["Message"] = "Comment successfully updated";
                    return RedirectToAction("Index");
                }
                return View(edited);
            }
            catch
            {
                ModelState.AddModelError("", "Some error occurred.Try again");
                return View(edited);
            }
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                Data.Comments.Delete(id.Value);
                Data.SaveChanges();
                TempData["Message"] = "Comment successfully deleted";
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }
    }
}
