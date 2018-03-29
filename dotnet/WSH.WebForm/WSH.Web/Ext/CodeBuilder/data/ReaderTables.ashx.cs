using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;

namespace Ext.CodeBuilder
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class ReaderTables : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string xtype = Param.GetParam("xtype");
            Filter f = new Filter("sysobjects");
            f.Columns = "name,xtype";
            f.Eq("xtype","u").Or().Eq("xtype","v").OrderBy().Asc("xtype");
            DataTable dt = Data.Query(f);
            string json = Utils.ToJsonString(dt);
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
