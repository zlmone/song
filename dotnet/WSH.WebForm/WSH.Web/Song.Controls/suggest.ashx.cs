using System;
using System.Collections.Generic;
using System.Web;

namespace WSH.Web.Song.Controls
{
    /// <summary>
    /// suggest 的摘要说明
    /// </summary>
    public class suggest : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "[{\"text\":\"王松华\"},{\"ext\":\"彭文涛\"},{\"text\":\"儿子\"},{\"text\":\"孙子\"},{\"text\":\"曾孙子\"}]";
            System.Threading.Thread.Sleep(500);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}