using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        ResumeDB db = new ResumeDB();
        public ActionResult Index()
        {
            var mc = new ModelsClas
            {
                CV = db.tbl_CV.First(),
                CVPHOTO = db.tbl_CVPhoto.First(),
                AboutMe = db.tbl_AboutMe.First(),
                AboutMePhoto = db.tbl_AboutMePhoto.First(),
                WhatIDo = db.tbl_WhatIDo.ToList(),
                SkillLeft = db.tbl_SkillLeft.ToList(),
                SkillRight = db.tbl_SkillRight.ToList(),
                Educations = db.tbl_Education.ToList(),
                Works = db.tbl_Work.ToList(),
                Posts = db.tbl_Post.ToList(),
                Pricings = db.tbl_Pricing.ToList(),
                Clients = db.tbl_Client.ToList(),
                Contact = db.tbl_Contact.First(),
            };
            return View(mc);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PostDetail(int? id)
        {
            if (id == null) return HttpNotFound();
            tbl_Post PsDetail = db.tbl_Post.FirstOrDefault(ps => ps.Id == id);
            if (PsDetail == null) return HttpNotFound();
            ViewBag.postSingle = PsDetail;
            ViewBag.AllPost = db.tbl_Post.ToList();
            return View();
        }
    }
}