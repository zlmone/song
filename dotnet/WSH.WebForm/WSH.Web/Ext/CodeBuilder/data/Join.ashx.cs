using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Text;
using Common;
using Ext.Common;
using System.Xml;
using LitJson;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Join : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Clear();
            context.Response.ContentType = "text/plain";
            string action = Param.GetParam("action");
            //配置参数
            string server = Param.GetParam("server");
            string source = Param.GetParam("source");
            string mode=Param.GetParam("mode");
            string type = Param.GetParam("type");
            string uid = Param.GetParam("uid");
            string pwd = Param.GetParam("pwd");
            db d = new db();
            DataBaseConfig dbc = new DataBaseConfig();
            StringBuilder sb = new StringBuilder();
            if (action == "SetConnection")
            {
                dbc.Server = server;
                dbc.Source=source;
                dbc.Mode=mode;
                dbc.Type=type;               
                dbc.Uid = uid;
                dbc.Pwd = pwd;

                string success = "true";
                 string msg = "";
                d.SetConnectionString(dbc,out msg);
                sb.Append("{success:"+success+",msg:'"+msg+"'}");
            }
            else if (action == "CheckJoin")
            {
                //判断连接是否成功

            }else if(action=="GetConnection"){
                dbc = d.GetDataBaseConfig();
                string json = "{root:[{type:'"+dbc.Type+"',mode:'"+dbc.Mode+"',server:'"+@dbc.Server+"',source:'"+dbc.Source+"',uid:'"+dbc.Uid+"',pwd:'"+dbc.Pwd+"'}]}";
                sb.Append(json);
            }
            string result = sb.ToString();
            context.Response.Write(result);
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
