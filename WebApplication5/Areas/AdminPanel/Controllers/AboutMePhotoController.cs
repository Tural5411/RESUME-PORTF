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
    public class AboutMePhotoController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/AboutMePhoto
        public ActionResult Index()
        {
            return View(db.tbl_AboutMePhoto.ToList());
        }

        // GET: AdminPanel/AboutMePhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMePhoto tbl_AboutMePhoto = db.tbl_AboutMePhoto.Find(id);
            if (tbl_AboutMePhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMePhoto);
        }

        // GET: AdminPanel/AboutMePhoto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/AboutMePhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo")] tbl_AboutMePhoto tbl_AboutMePhoto,HttpPostedFileBase abphoto )
        {
            if (ModelState.IsValid)
            {
                if (abphoto != null)
                {
                    if (abphoto.ContentType.ToLower() == "image/jpg" ||
                       abphoto.ContentType.ToLower() == "image/png" ||
                       abphoto.ContentType.ToLower() == "image/jpeg" ||
                       abphoto.ContentType.ToLower() == "image/gif")
                    {
                        WebImage image = new WebImage(abphoto.InputStream);
                        FileInfo info = new FileInfo(abphoto.FileName);
                        string name = "AboutMephoto-" + Guid.NewGuid() + info.Extension;
                        image.Save("~/Uploads/AboutMePhoto/" + name);
                        tbl_AboutMePhoto.Photo = "/Uploads/AboutMePhoto/" + name;
                        db.tbl_AboutMePhoto.Add(tbl_AboutMePhoto);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }

            }

            return View(tbl_AboutMePhoto);
        }

        // GET: AdminPanel/AboutMePhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMePhoto tbl_AboutMePhoto = db.tbl_AboutMePhoto.Find(id);
            if (tbl_AboutMePhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMePhoto);
        }

        // POST: AdminPanel/AboutMePhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo")] tbl_AboutMePhoto tbl_AboutMePhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_AboutMePhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_AboutMePhoto);
        }

        // GET: AdminPanel/AboutMePhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_AboutMePhoto tbl_AboutMePhoto = db.tbl_AboutMePhoto.Find(id);
            if (tbl_AboutMePhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_AboutMePhoto);
        }

        // POST: AdminPanel/AboutMePhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_AboutMePhoto tbl_AboutMePhoto = db.tbl_AboutMePhoto.Find(id);
            db.tbl_AboutMePhoto.Remove(tbl_AboutMePhoto);
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
