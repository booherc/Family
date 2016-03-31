using Family.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;


namespace Family.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index()
        {
            var allPosts = db.Posts.Include("Author").Where(p => p.PostId > 0).OrderByDescending(p => p.PostTime);
            return View(allPosts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Post/Create
        public ActionResult AddPost()
        {
            return View();
        }

        // POST: Post/Create
        [HttpPost]
        public ActionResult AddPost(Post post)
        {
            try
            {
                post.PostTime = DateTime.Now;
                post.AuthorID = User.Identity.GetUserId();
                db.Posts.Add(post);
                db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Post/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
