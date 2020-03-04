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
    public class EducationController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/Education
        public ActionResult Index()
        {
            return View(db.tbl_Education.ToList());
        }

        // GET: AdminPanel/Education/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Education tbl_Education = db.tbl_Education.Find(id);
            if (tbl_Education == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Education);
        }

        // GET: AdminPanel/Education/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Education/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Tarix,Description")] tbl_Education tbl_Education)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Education.Add(tbl_Education);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Education);
        }

        // GET: AdminPanel/Education/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Education tbl_Education = db.tbl_Education.Find(id);
            if (tbl_Education == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Education);
        }

        // POST: AdminPanel/Education/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Tarix,Description")] tbl_Education tbl_Education)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Education).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Education);
        }

        // GET: AdminPanel/Education/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Education tbl_Education = db.tbl_Education.Find(id);
            if (tbl_Education == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Education);
        }

        // POST: AdminPanel/Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Education tbl_Education = db.tbl_Education.Find(id);
            db.tbl_Education.Remove(tbl_Education);
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
