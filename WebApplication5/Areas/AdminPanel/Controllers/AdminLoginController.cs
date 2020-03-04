using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Model;

namespace WebApplication5.Areas.AdminPanel.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminPanel/AdminLogin
        ResumeDB db = new ResumeDB();




        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(tbl_admin adm)
        {
            if(adm.AdminEmail!=string.Empty && adm.AdminPassword != string.Empty)
            {
                if(!db.tbl_admin.Any(ad=>ad.AdminEmail==adm.AdminEmail && ad.AdminPassword == adm.AdminPassword))
                {
                    Session["ActiveAdmin"] = adm;
                    return RedirectToAction("Index", "Home");
                }
            }



            return View();
        }
    }
}