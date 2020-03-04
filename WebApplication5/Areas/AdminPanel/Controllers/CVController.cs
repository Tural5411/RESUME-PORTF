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
    public class CVController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/CV
        public ActionResult Index()
        {
            return View(db.tbl_CV.ToList());
        }

        // GET: AdminPanel/CV/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CV tbl_CV = db.tbl_CV.Find(id);
            if (tbl_CV == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CV);
        }

        // GET: AdminPanel/CV/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/CV/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Icon,Fullname,Job,Mail,Phone,place,Link")] tbl_CV tbl_CV)
        {
            if (ModelState.IsValid)
            {
                db.tbl_CV.Add(tbl_CV);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_CV);
        }

        // GET: AdminPanel/CV/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CV tbl_CV = db.tbl_CV.Find(id);
            if (tbl_CV == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CV);
        }

        

        // POST: AdminPanel/CV/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Icon,Fullname,Job,Mail,Phone,place,Link")] tbl_CV tbl_CV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CV);
        }

        // GET: AdminPanel/CV/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CV tbl_CV = db.tbl_CV.Find(id);
            if (tbl_CV == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CV);
        }

        // POST: AdminPanel/CV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CV tbl_CV = db.tbl_CV.Find(id);
            db.tbl_CV.Remove(tbl_CV);
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
