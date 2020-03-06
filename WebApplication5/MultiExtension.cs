using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5
{
    public static class MultiExtension
    {
        public static string Language(this HttpCookieCollection cookie)
        {
            return cookie["tural"]?.Value;
        }
    }
}