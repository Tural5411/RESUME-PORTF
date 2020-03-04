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
    public class AboutMeController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/AboutMe
        public ActionResult Index()
        {
            return View(db.tbl_AboutMe.ToList());
        }

        // GET: AdminPanel/AboutMe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMe tbl_AboutMe = db.tbl_AboutMe.Find(id);
            if (tbl_AboutMe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMe);
        }

        // GET: AdminPanel/AboutMe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/AboutMe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Description,Skills,Download")] tbl_AboutMe tbl_AboutMe)
        {
            if (ModelState.IsValid)
            {
                db.tbl_AboutMe.Add(tbl_AboutMe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_AboutMe);
        }

        // GET: AdminPanel/AboutMe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMe tbl_AboutMe = db.tbl_AboutMe.Find(id);
            if (tbl_AboutMe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMe);
        }

        // POST: AdminPanel/AboutMe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Description,Skills,Download")] tbl_AboutMe tbl_AboutMe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_AboutMe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_AboutMe);
        }

        // GET: AdminPanel/AboutMe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMe tbl_AboutMe = db.tbl_AboutMe.Find(id);
            if (tbl_AboutMe == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMe);
        }

        // POST: AdminPanel/AboutMe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_AboutMe tbl_AboutMe = db.tbl_AboutMe.Find(id);
            db.tbl_AboutMe.Remove(tbl_AboutMe);
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
