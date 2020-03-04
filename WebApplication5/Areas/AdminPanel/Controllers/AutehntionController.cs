using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication5.Areas.AdminPanel.Controllers
{
    public class AuthenticationFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        [AuthenticationFilter]
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                return;
            }

            if (HttpContext.Current.Session["ActiveAdmin"] == null)
            {
                filterContext.Result = new RedirectResult("~/TravelAdmin/AdminAccount/Login");
            }
        }
        // GET: TravelAdmin/AuthenticationFilter

    }
}