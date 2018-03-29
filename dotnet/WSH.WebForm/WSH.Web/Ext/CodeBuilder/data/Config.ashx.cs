using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Xml;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// Config 的摘要说明
    /// </summary>
    public class Config : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string msg="", success = "true";
            string action=context.Request.Params["action"];
            if (action == "GetConfig")
            {
                StringBuilder sb = new StringBuilder();
                XmlDocument doc = new XmlDocument();
                doc.Load(context.Server.MapPath("../xml/config.xml"));
                XmlNode root = doc.SelectSingleNode("config");
                XmlNodeList nodes = root.ChildNodes;
                foreach (XmlNode node in nodes)
                {
                    sb.Append(node.Name+":\""+node.InnerText+"\",");
                }
                sb.Remove(sb.Length - 1, 1);
                msg ="{"+ sb.ToString()+"}";
            }
            context.Response.Write("{msg:"+msg+",success:"+success+"}");
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