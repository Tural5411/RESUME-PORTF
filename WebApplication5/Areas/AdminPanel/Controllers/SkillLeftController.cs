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
    public class SkillLeftController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/SkillLeft
        public ActionResult Index()
        {
            return View(db.tbl_SkillLeft.ToList());
        }

        // GET: AdminPanel/SkillLeft/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillLeft tbl_SkillLeft = db.tbl_SkillLeft.Find(id);
            if (tbl_SkillLeft == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillLeft);
        }

        // GET: AdminPanel/SkillLeft/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/SkillLeft/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Skillname")] tbl_SkillLeft tbl_SkillLeft)
        {
            if (ModelState.IsValid)
            {
                db.tbl_SkillLeft.Add(tbl_SkillLeft);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_SkillLeft);
        }

        // GET: AdminPanel/SkillLeft/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillLeft tbl_SkillLeft = db.tbl_SkillLeft.Find(id);
            if (tbl_SkillLeft == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillLeft);
        }

        // POST: AdminPanel/SkillLeft/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Skillname")] tbl_SkillLeft tbl_SkillLeft)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SkillLeft).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_SkillLeft);
        }

        // GET: AdminPanel/SkillLeft/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillLeft tbl_SkillLeft = db.tbl_SkillLeft.Find(id);
            if (tbl_SkillLeft == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillLeft);
        }

        // POST: AdminPanel/SkillLeft/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_SkillLeft tbl_SkillLeft = db.tbl_SkillLeft.Find(id);
            db.tbl_SkillLeft.Remove(tbl_SkillLeft);
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
