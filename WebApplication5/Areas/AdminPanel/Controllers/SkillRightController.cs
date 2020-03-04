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
    public class SkillRightController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/SkillRight
        public ActionResult Index()
        {
            return View(db.tbl_SkillRight.ToList());
        }

        // GET: AdminPanel/SkillRight/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillRight tbl_SkillRight = db.tbl_SkillRight.Find(id);
            if (tbl_SkillRight == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillRight);
        }

        // GET: AdminPanel/SkillRight/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/SkillRight/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Header,Skillname")] tbl_SkillRight tbl_SkillRight)
        {
            if (ModelState.IsValid)
            {
                db.tbl_SkillRight.Add(tbl_SkillRight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_SkillRight);
        }

        // GET: AdminPanel/SkillRight/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillRight tbl_SkillRight = db.tbl_SkillRight.Find(id);
            if (tbl_SkillRight == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillRight);
        }

        // POST: AdminPanel/SkillRight/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Header,Skillname")] tbl_SkillRight tbl_SkillRight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_SkillRight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_SkillRight);
        }

        // GET: AdminPanel/SkillRight/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_SkillRight tbl_SkillRight = db.tbl_SkillRight.Find(id);
            if (tbl_SkillRight == null)
            {
                return HttpNotFound();
            }
            return View(tbl_SkillRight);
        }

        // POST: AdminPanel/SkillRight/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_SkillRight tbl_SkillRight = db.tbl_SkillRight.Find(id);
            db.tbl_SkillRight.Remove(tbl_SkillRight);
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
