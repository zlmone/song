using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;
using Ext.Common;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Reader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = Param.GetParam("action");
            db d = new db();
            string json = "[]";
            if (action == "ReaderColumns")
            {
                string tableName = Param.GetParam("tableName");
                int count = 0;
                DataTable dt = new DataTable();
                if (tableName != "")
                {
                    string sql = "select * from Columns where TableName='"+tableName+"'";
                    dt = d.GetDataTable(sql);
                    count = dt.Rows.Count;
                }
                json = ExtCommon.GetGridJson(dt, count);
            }else if(action=="ReaderTables"){
                string xtype = Param.GetParam("xtype");
                string sql = "select name,xtype from sysobjects where xtype='u' or xtype='v' order by xtype asc";
                DataTable dt = d.GetDataTable(sql);
                json = Utils.ToJsonString(dt);
            }
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
