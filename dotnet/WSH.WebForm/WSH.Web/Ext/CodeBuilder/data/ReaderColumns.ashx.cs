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
    public class ReaderColumns : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string tableName = Param.GetParam("tableName");
            ////自定义列表
            //DataTable dt = new DataTable();
            //DataColumn dataIndex = new DataColumn("dataIndex");
            //dt.Columns.Add(dataIndex);
            //DataColumn header = new DataColumn("header");
            //dt.Columns.Add(header);
            //DataColumn sortable = new DataColumn("sortable");
            //dt.Columns.Add(sortable);
            //DataColumn width = new DataColumn("width");
            //dt.Columns.Add(width);
            //DataColumn format = new DataColumn("format");
            //dt.Columns.Add(format);
            //DataColumn allowBlank = new DataColumn("allowBlank");
            //dt.Columns.Add(allowBlank);
            ////查询表的列信息
            //int totalRecord = 0;
            //if (tableName != "")
            //{
            //    Filter f = new Filter(tableName);
            //    f.Top = "0";
            //    DataTable columns = Data.Query(f);
            //    totalRecord = columns.Columns.Count;
            //    foreach (DataColumn col in columns.Columns)
            //    {
            //        DataRow row = dt.NewRow();
            //        row["dataIndex"] = col.ColumnName;
            //        row["header"] = col.ColumnName;
            //        row["sortable"] = true;
            //        row["width"] = "0";
            //        row["format"] = "";
            //        row["allowBlank"] = true;
            //        dt.Rows.Add(row);
            //    }
            //}
            int count = 0;
            DataTable dt = new DataTable();
            if (tableName != "")
            {
                Filter f = new Filter("Columns");
             //   f.Columns = "Field,Display,Sort,Width,Format,AllowBlank";
                f.Eq("TableName", tableName);
                dt = Data.Query(f);
                count = dt.Rows.Count;
            }
            string json = ExtCommon.GetGridJson(dt,count);
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
