using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;
using LitJson;
using System.Text;
using Ext.Common;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class EditColumns : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            db dbc = new db();
            string data = Param.GetParam("data");
            if(data!=""){
                data = context.Server.UrlDecode(data);
            }
            string[] cols=new string[]{"Display","DataKey","Hide","Sort","Query","AllowBlank","Width","Format","EditType","Align"};
            JsonData json = JsonMapper.ToObject(data);
            //string id = json[0]["ID"].ToString();
            StringBuilder sb = new StringBuilder();
            for (int j= 0; j < json.Count;j++)
            {
                sb.Append(" update columns set");
                for (int i = 0; i < cols.Length; i++)
                {
                    string d=json[j][cols[i]].ToString();
                    sb.AppendFormat(" {0}='{1}',", cols[i],d );
                }
                sb.Remove(sb.Length - 1, 1);
                sb.AppendFormat(" where ID='{0}'", json[j]["ID"].ToString());
            }
            string editSql = sb.ToString();
            bool result = dbc.ExecuteNonQuery(editSql);
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
