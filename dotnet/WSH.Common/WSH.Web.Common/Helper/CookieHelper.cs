using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WSH.Web.Common.Helper
{
    public class CookieHelper
    {
        // 写cookie值
        public static void Set(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        // 写cookie值
        public static void Set(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddHours(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }
        // 读cookie值
        public static string Get(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }
    }
}
