using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Areas.AdminPanel.Controllers
{
    public class PostController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/Post
        public ActionResult Index()
        {
            return View(db.tbl_Post.ToList());
        }

        // GET: AdminPanel/Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Post tbl_Post = db.tbl_Post.Find(id);
            if (tbl_Post == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Post);
        }

        // GET: AdminPanel/Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,Header,Header2,Description,Button")] tbl_Post tbl_Post)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Post.Add(tbl_Post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Post);
        }

        // GET: AdminPanel/Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Post tbl_Post = db.tbl_Post.Find(id);
            if (tbl_Post == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Post);
        }

        // POST: AdminPanel/Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Header,Header2,Description,Button")] tbl_Post tbl_Post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Post);
        }

        // GET: AdminPanel/Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Post tbl_Post = db.tbl_Post.Find(id);
            if (tbl_Post == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Post);
        }

        // POST: AdminPanel/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Post tbl_Post = db.tbl_Post.Find(id);
            db.tbl_Post.Remove(tbl_Post);
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
