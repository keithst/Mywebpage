﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using PagedList.Mvc;

namespace WebApplication4.Controllers
{
    [RequireHttps]
    public class BlogController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private IPagedList<BlogPost> masterlist;
        // GET: Blog
        [AllowAnonymous]
        public ActionResult Index(Nullable<int> page, string search)
        {
            ViewBag.search = search;
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            if(!string.IsNullOrWhiteSpace(search))
            {
                var query = db.Posts.AsQueryable();
                var queryt = query;
                var queryc = db.Comments.AsQueryable();
                var queryd = queryc.Where(x => x.Body.Contains(search)).Select(e => e.PostId);
                string[] subsearch = search.Split(' ');
                foreach (string sub in subsearch)
                {
                    queryd = queryd.Union(queryc.Where(x => x.Body.Contains(sub)).Select(e => e.PostId));
                }
                query = query.Where(o => (o.Title.Contains(search)) || (o.Body.Contains(search)) || (o.Tags.Contains(search))
                || (o.Slug.Contains(search)));
                foreach (int pid in queryd)
                {
                    query = query.Union(queryt.Where(z => z.Id == pid));
                }
                foreach (string sub1 in subsearch)
                {
                    query = query.Union(queryt.Where(o => (o.Title.Contains(sub1)) || (o.Body.Contains(sub1)) || (o.Tags.Contains(sub1))
                    || (o.Slug.Contains(sub1))));
                }
                if (User.IsInRole("Admin"))
                {
                    masterlist = query.OrderByDescending(x => x.Created).ToPagedList(pageNumber, pageSize);
                }
                else
                {
                    masterlist = query.Where(y => y.Published == true).OrderByDescending(x => x.Created).ToPagedList(pageNumber, pageSize);
                }
            }
            else
            {
                if (User.IsInRole("Admin"))
                {
                    masterlist = db.Posts.OrderByDescending(x => x.Created).ToPagedList(pageNumber, pageSize);
                }
                else
                {
                    masterlist = db.Posts.Where(y => y.Published == true).OrderByDescending(x => x.Created).ToPagedList(pageNumber, pageSize);
                }
            }

            return View(masterlist);
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(string Slug)
        {
            
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.FirstOrDefault(p=>p.Slug == Slug);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Created,Updated,Title,Slug,Tags,Body,MediaURL,Published")] BlogPost blogPost, HttpPostedFileBase image)
        {
            if(image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filePath = "/Uploads/";
                    var absPath = Server.MapPath("~" + filePath);
                    Directory.CreateDirectory(absPath);
                    blogPost.MediaURL = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }
                var Slug = StringUtilities.URLFriendly(blogPost.Title);
                if(String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid title.");
                    return View(blogPost);
                }
                if (db.Posts.Any(p=>p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPost);
                }

                blogPost.Slug = Slug;

                blogPost.Created = System.DateTimeOffset.Now;
                db.Posts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Slug,Tags,Body,MediaURL,Published")] BlogPost blogPost, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                var ext = Path.GetExtension(image.FileName).ToLower();
                if (ext != ".png" && ext != ".jpg" && ext != ".jpeg" && ext != ".gif" && ext != ".bmp")
                    ModelState.AddModelError("image", "Invalid Format.");
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var filePath = "/Uploads/";
                    var absPath = Server.MapPath("~" + filePath);
                    Directory.CreateDirectory(absPath);
                    blogPost.MediaURL = filePath + image.FileName;
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }
                blogPost.Updated = System.DateTimeOffset.Now;
                db.Posts.Attach(blogPost);
                db.Entry(blogPost).Property("Title").IsModified = true;
                if (image != null)
                {
                    db.Entry(blogPost).Property("MediaURL").IsModified = true;
                }
                db.Entry(blogPost).Property("Body").IsModified = true;
                db.Entry(blogPost).Property("Updated").IsModified = true;
                db.Entry(blogPost).Property("Published").IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            db.Posts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SComment([Bind(Include = "PostId, Body")]Comment comment)
        {
            comment.AuthorId = User.Identity.GetUserId();
            comment.Created = System.DateTimeOffset.Now;

            db.Comments.Add(comment);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DComment(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EComment([Bind(Include = "Id, Body, UpdateReason")]Comment comment)
        {
            comment.Updated = System.DateTimeOffset.Now;
            db.Comments.Attach(comment);
            db.Entry(comment).Property("Body").IsModified = true;
            db.Entry(comment).Property("UpdateReason").IsModified = true;
            db.Entry(comment).Property("Updated").IsModified = true;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}