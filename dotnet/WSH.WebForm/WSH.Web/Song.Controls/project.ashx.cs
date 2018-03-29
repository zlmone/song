using System;
using System.Collections.Generic;
using System.Web;

namespace WSH.Web.Song.Controls
{
    /// <summary>
    /// project 的摘要说明
    /// </summary>
    public class project : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string json = "{\"totalRecord\":100,\"root\":[{\"name\":\"王松华\"}]}";
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