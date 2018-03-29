using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;
using System.Text;
using Ext.Common;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddColumns : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            db d = new db();
            string tableName = Param.GetParam("tableName");
            string cols = "TableName,Field,Display,DataKey,Sort,Query,Hide,AllowBlank,Width,Format,DataType,EditType,Align";
            StringBuilder sb = new StringBuilder();
            //查询表的所有列
            string sqlCols=string.Format("select top 0 * from {0}",tableName);
            DataTable columns = d.GetDataTable(sqlCols);
            //查询主键
            string getPKSql = string.Format("select top 1 column_name FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE with(nolock) WHERE table_name='{0}'",tableName);
            string pkName = d.ExecuteSalar(getPKSql).ToString();
            foreach (DataColumn col in columns.Columns)
            {
                string colName = col.ColumnName;
                string sqlExists = "select count(*) from columns where field='"+colName+"' and tablename='"+tableName +"'";
                int exists = Convert.ToInt32(d.ExecuteSalar(sqlExists));
                if (exists<=0)
                {
                    string f = (colName == pkName ? "False" : "True");
                    string y = (colName == pkName ? "True" : "False");
                    //判断数据类型
                    string type = col.DataType.Name.ToString().Replace("String", "string");
                    type = type.Replace("Boolean", "bool").Replace("Int32", "int").Replace("Decimal","decimal");
                    type = type.Replace("Int16","int");
                    //对齐方式
                    string align = "center";
                    if (type == "decimal" || type=="int")
                    {
                        align = "right";
                    }
                    sb.Append(" insert into columns");
                    sb.AppendFormat("({0})", cols);
                    //检测是否为主键
                    // string[] colArray = cols.Split(",".ToCharArray());
                    sb.Append(" values(");
                    sb.Append(Utils.ToSQL(tableName) + ",");
                    //Field
                    sb.Append(Utils.ToSQL(colName) + ",");
                    //Display
                    sb.Append(Utils.ToSQL(colName) + ",");
                    //DataKey
                    sb.Append(Utils.ToSQL(y) + ",");
                    //Sort
                    sb.Append(Utils.ToSQL(f) + ",");
                    //Query
                    sb.Append(Utils.ToSQL("False") + ",");
                    //Hide
                    sb.Append(Utils.ToSQL(y) + ",");
                    //AllowBlank
                    sb.Append(Utils.ToSQL(f) + ",");
                    //Width
                    sb.Append(Utils.ToSQL("") + ",");
                    string format = "";
                    if(type=="DateTime"){
                        format = "yyyy-MM-dd HH:mm:ss";
                    }
                    sb.Append(Utils.ToSQL(format) + ",");
                    string controltype = "textbox";
                    if(type=="bool"){
                        controltype = "checkbox";
                    }
                    else if (type == "DateTime")
                    {
                        controltype = "date";
                    }
                    else if (type == "decimal")
                    {
                        controltype = "float";
                    }else if(type=="int"){
                        controltype = "int";
                    }
                    sb.Append(Utils.ToSQL(type) + ",");
                    sb.Append(Utils.ToSQL(controltype) + ",");
                    sb.Append(Utils.ToSQL(align));
                    sb.Append(")");
                }
            }
            string addSql = sb.ToString();
            bool result = true;
            if(addSql.Trim()!=""){
                 result = d.ExecuteNonQuery(addSql);
            }
            context.Response.Write(result.ToString().ToLower());
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
