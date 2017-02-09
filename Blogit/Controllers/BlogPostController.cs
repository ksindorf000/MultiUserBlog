﻿using Blogit.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Blogit.Controllers
{
    [Authorize]
    public class BlogPostController : Controller
    {
        //Create the context to avoid having to use "using" statements
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogPost
        public ActionResult Index()
        {
            //Get logged in user and only list BlogPosts belonging to that user
            var userId = User.Identity.GetUserId();
            var blogPost = db.BlogPosts.Include(b => b.Owner).Where(b => b.Owner.Id == userId);
            
            ViewBag.PostList = blogPost.OrderBy(b => b.Created).ToList();

            return View();
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Author,Teaser,Body,Public")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                //The ONLY way to get/pass User Identity
                //"Grab it from the incoming request."
                //blogPost.OwnerId = User.Identity.GetUserId();
                blogPost.Created = DateTime.Now;
                db.BlogPosts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blogPost);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Only allow edits to books that belong to the current user
            //var userId = User.Identity.GetUserId();
            BlogPost blogPost = db.BlogPosts
            //    .Where(b => b.OwnerId == userId)
                .Where(b => b.Id == id)
                .FirstOrDefault();
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            //ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", blogPost.OwnerId);
            return View(blogPost);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Author,Teaser,Body,Public")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                //blogPost.OwnerId = User.Identity.GetUserId();
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.OwnerId = new SelectList(db.Users, "Id", "Email", blogPost.OwnerId);
            return View(blogPost);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.BlogPosts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.BlogPosts.Find(id);
            db.BlogPosts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction("Index");
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
