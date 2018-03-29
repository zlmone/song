using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WSH.Common.Http;
using System.Net;
using WSH.Web.Common.Request;

namespace WSH.Manager.Services
{
    /// <summary>
    /// ManagerResponse 的摘要说明
    /// </summary>
    public class ManagerResponse : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string content = RequestHelper.GetPostData();
            context.Response.Write(content);
            context.Response.End();
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