using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Areas.AdminPanel.Controllers
{
    public class ClientController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/Client
        public ActionResult Index()
        {
            return View(db.tbl_Client.ToList());
        }

        // GET: AdminPanel/Client/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // GET: AdminPanel/Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo,Description,FullName,Firm")] tbl_Client tbl_Client,HttpPostedFileBase CLIENTPHOTO)
        {
            if (ModelState.IsValid)
            {
                if(CLIENTPHOTO!= null)
                {
                    if(CLIENTPHOTO.ContentType.ToLower()== "image/jpg" ||
                        CLIENTPHOTO.ContentType.ToLower()== "image/png" ||
                        CLIENTPHOTO.ContentType.ToLower()== "image/jpeg" )
                    {
                        WebImage image = new WebImage(CLIENTPHOTO.InputStream);
                        FileInfo info = new FileInfo(CLIENTPHOTO.FileName);
                        string name = "CVPHOTO-" + Guid.NewGuid() + info.Extension;
                        tbl_Client.Photo = "~Upload/CVPHOTO/" + name;
                        db.tbl_Client.Add(tbl_Client);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }

                }
            }

            return View(tbl_Client);
        }

        // GET: AdminPanel/Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // POST: AdminPanel/Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo,Description,FullName,Firm")] tbl_Client tbl_Client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Client);
        }

        // GET: AdminPanel/Client/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            if (tbl_Client == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Client);
        }

        // POST: AdminPanel/Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Client tbl_Client = db.tbl_Client.Find(id);
            db.tbl_Client.Remove(tbl_Client);
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
