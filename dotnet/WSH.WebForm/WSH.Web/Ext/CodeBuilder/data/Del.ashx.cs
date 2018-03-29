using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;
using System.Text;

namespace Ext.Common
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Del : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            db mgr = new db();
            context.Response.ContentType = "text/plain";
            string tableName = Param.GetParam("tableName");
            string idField = Param.GetParam("idField");
            string ids = Param.GetParam("ids");
            string sql = "delete "+tableName+" where "+idField+" in("+ids+")" ;
            string result = mgr.ExecuteNonQuery(sql).ToString().ToLower();
            context.Response.Write(result);
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
