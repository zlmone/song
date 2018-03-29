using System;
using System.Collections.Generic;
using System.Web;
using WSH.WebForm.Controls;
 

namespace WSH.Web.Cmp
{
    /// <summary>
    /// zTreeAsync 的摘要说明
    /// </summary>
    public class zTreeAsync : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string pid=context.Request.Params["pid"];
            List<TreeItem> nodes = new List<TreeItem>();
            for (int i = 0; i < 10; i++)
            {
                TreeItem node = new TreeItem()
                {
                    Text = pid + DateTime.Now.ToString("yyyyMMddHHmmss"),
                    IsLeaf = i == 9 ? true : false
                };
                nodes.Add(node);
            }
            context.Response.Write(ZTreeMgr.GetzTreeData(nodes));
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