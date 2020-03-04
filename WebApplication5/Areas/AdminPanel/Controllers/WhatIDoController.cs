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
    public class WhatIDoController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/WhatIDo
        public ActionResult Index()
        {
            return View(db.tbl_WhatIDo.ToList());
        }

        // GET: AdminPanel/WhatIDo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WhatIDo tbl_WhatIDo = db.tbl_WhatIDo.Find(id);
            if (tbl_WhatIDo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WhatIDo);
        }

        // GET: AdminPanel/WhatIDo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/WhatIDo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Icon,Header,Description")] tbl_WhatIDo tbl_WhatIDo)
        {
            if (ModelState.IsValid)
            {
                db.tbl_WhatIDo.Add(tbl_WhatIDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_WhatIDo);
        }

        // GET: AdminPanel/WhatIDo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WhatIDo tbl_WhatIDo = db.tbl_WhatIDo.Find(id);
            if (tbl_WhatIDo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WhatIDo);
        }

        // POST: AdminPanel/WhatIDo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Icon,Header,Description")] tbl_WhatIDo tbl_WhatIDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_WhatIDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_WhatIDo);
        }

        // GET: AdminPanel/WhatIDo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_WhatIDo tbl_WhatIDo = db.tbl_WhatIDo.Find(id);
            if (tbl_WhatIDo == null)
            {
                return HttpNotFound();
            }
            return View(tbl_WhatIDo);
        }

        // POST: AdminPanel/WhatIDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_WhatIDo tbl_WhatIDo = db.tbl_WhatIDo.Find(id);
            db.tbl_WhatIDo.Remove(tbl_WhatIDo);
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
