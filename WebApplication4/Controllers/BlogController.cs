using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Blog
        public ActionResult Index()
        {
            var Posts = db.Posts.ToList();
            return View(Posts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BlogPost Post)
        {
            Post.Created = System.DateTimeOffset.Now;
            db.Posts.Add(Post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Post = db.Posts.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Post = db.Posts.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(Post);
        }

        [HttpPost]
        public ActionResult Edit(BlogPost Post)
        {
            Post.Updated = System.DateTimeOffset.Now;
            db.Posts.Attach(Post);
            db.Entry(Post).Property("Title").IsModified = true;
            db.Entry(Post).Property("Body").IsModified = true;
            db.Entry(Post).Property("Updated").IsModified = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Post = db.Posts.Find(id);
            if (Post == null)
            {
                return HttpNotFound();
            }
            return View(id);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Post = db.Posts.Find(id);
            db.Posts.Remove(Post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}