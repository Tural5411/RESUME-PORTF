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
    
    public class WorkController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/Work
        public ActionResult Index()
        {
            return View(db.tbl_Work.ToList());
        }

        // GET: AdminPanel/Work/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Work tbl_Work = db.tbl_Work.Find(id);
            if (tbl_Work == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Work);
        }

        // GET: AdminPanel/Work/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Work/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Tarix,Description")] tbl_Work tbl_Work)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Work.Add(tbl_Work);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Work);
        }

        // GET: AdminPanel/Work/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Work tbl_Work = db.tbl_Work.Find(id);
            if (tbl_Work == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Work);
        }

        // POST: AdminPanel/Work/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Tarix,Description")] tbl_Work tbl_Work)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Work).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Work);
        }

        // GET: AdminPanel/Work/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Work tbl_Work = db.tbl_Work.Find(id);
            if (tbl_Work == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Work);
        }

        // POST: AdminPanel/Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Work tbl_Work = db.tbl_Work.Find(id);
            db.tbl_Work.Remove(tbl_Work);
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
