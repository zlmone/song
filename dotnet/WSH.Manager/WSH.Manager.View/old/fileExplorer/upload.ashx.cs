using System;
using System.Collections.Generic;
using System.Web;

namespace Song.WebSite.View.js.fileExplorer
{
    /// <summary>
    /// upload 的摘要说明
    /// </summary>
    public class upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            for (int i = 0; i < context.Request.Files.Count; i++)
            {
                HttpPostedFile file = context.Request.Files[i];
                string path = System.IO.Path.Combine(context.Server.MapPath("~/App_Data"), System.IO.Path.GetFileName(file.FileName));
                file.SaveAs(path);
            }
             
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