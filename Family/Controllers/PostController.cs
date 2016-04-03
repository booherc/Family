using Family.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

namespace Family.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Post
        public ActionResult Index()
        {
            var allPosts = db.Posts.Where(p => p.PostId > 0).OrderByDescending(p => p.PostTime).ToList();
            return View(allPosts);
        }

        // GET: Post/Details/5
        public ActionResult Details(int id)
        {
            var post = db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            return View(post);
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
            var post = db.Posts.Where(p => p.PostId == id).FirstOrDefault();
            if (post.AuthorID == User.Identity.GetUserId())
            {
                return View(post);
            }
            return RedirectToAction("Index");
        }

        // POST: Post/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                if (post.AuthorID == User.Identity.GetUserId())
                {
                    db.Entry(post).State = EntityState.Modified;
                    db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View();
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
