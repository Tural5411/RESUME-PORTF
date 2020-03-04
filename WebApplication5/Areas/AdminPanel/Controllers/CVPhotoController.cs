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
    public class CVPhotoController : Controller
    {
        private ResumeDB db = new ResumeDB();

        // GET: AdminPanel/CVPhoto
        public ActionResult Index()
        {
            return View(db.tbl_CVPhoto.ToList());
        }

        // GET: AdminPanel/CVPhoto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CVPhoto tbl_CVPhoto = db.tbl_CVPhoto.Find(id);
            if (tbl_CVPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CVPhoto);
        }

        // GET: AdminPanel/CVPhoto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/CVPhoto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Photo")] tbl_CVPhoto tbl_CVPhoto,HttpPostedFileBase CVPHOTO)
        {
            if (ModelState.IsValid)
            {
                if (CVPHOTO != null)
                {
                    if (CVPHOTO.ContentType.ToLower() == "image/jpg" ||
                       CVPHOTO.ContentType.ToLower() == "image/png" ||
                       CVPHOTO.ContentType.ToLower() == "image/jpeg" ||
                       CVPHOTO.ContentType.ToLower() == "image/gif")
                    {
                        WebImage image = new WebImage(CVPHOTO.InputStream);
                        FileInfo info = new FileInfo(CVPHOTO.FileName);
                        string name = "CVPhoto-" + Guid.NewGuid() + info.Extension;
                        image.Save("~/Uploads/CVPhoto/" + name);
                        tbl_CVPhoto.Photo = "/Uploads/CVPhoto/" + name;
                        db.tbl_CVPhoto.Add(tbl_CVPhoto);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
            }

            return View(tbl_CVPhoto);
        }

        // GET: AdminPanel/CVPhoto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CVPhoto tbl_CVPhoto = db.tbl_CVPhoto.Find(id);
            if (tbl_CVPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CVPhoto);
        }

        [HttpPost]
        public ActionResult Edit(int? id, tbl_CVPhoto tbl_CVPhoto, HttpPostedFileBase CVPHOTO)
        {
            if (ModelState.IsValid)
            {
                tbl_CVPhoto selectedCV = db.tbl_CVPhoto.FirstOrDefault(tp => tp.Id == id);

                if (CVPHOTO != null)
                {

                    if (CVPHOTO.ContentLength > 0)
                    {
                        if (CVPHOTO.ContentType.ToLower() == "image/jpg" ||
                            CVPHOTO.ContentType.ToLower() == "image/png" ||
                            CVPHOTO.ContentType.ToLower() == "image/gif" ||
                            CVPHOTO.ContentType.ToLower() == "image/jpeg" ||
                            CVPHOTO.ContentType.ToLower() == "image/bmp"

                            )
                        {

                            if (System.IO.File.Exists(Server.MapPath(selectedCV.Photo)))
                            {
                                System.IO.File.Delete(Server.MapPath(selectedCV.Photo));
                            }

                            WebImage img = new WebImage(CVPHOTO.InputStream);
                            FileInfo flInfo = new FileInfo(CVPHOTO.FileName);
                            string filename = "CVPHOTO" + Guid.NewGuid() + flInfo.Extension;
                            img.Save("~/Uploads/CVPhoto/" + filename);
                            tbl_CVPhoto.Photo = "/Uploads/CVPhoto/" + filename;
                            db.tbl_CVPhoto.Add(tbl_CVPhoto);
                            db.SaveChanges();
                        }


                    }
                }
                db.SaveChanges();
                return RedirectToAction("index");

            }

            return View();
        }

        // POST: AdminPanel/CVPhoto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Photo")] tbl_CVPhoto tbl_CVPhoto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_CVPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_CVPhoto);
        }

        // GET: AdminPanel/CVPhoto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_CVPhoto tbl_CVPhoto = db.tbl_CVPhoto.Find(id);
            if (tbl_CVPhoto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_CVPhoto);
        }

        // POST: AdminPanel/CVPhoto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_CVPhoto tbl_CVPhoto = db.tbl_CVPhoto.Find(id);
            db.tbl_CVPhoto.Remove(tbl_CVPhoto);
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
