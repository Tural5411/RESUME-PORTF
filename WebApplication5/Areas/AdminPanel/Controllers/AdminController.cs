using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.AdminPanel.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminPanel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}