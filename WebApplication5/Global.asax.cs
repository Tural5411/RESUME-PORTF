using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
       
        public void SetCulture(string name)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(name);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var language = HttpContext.Current.Request.Cookies.Language() ?? "az";
            SetCulture(language);
        }
    }
}
