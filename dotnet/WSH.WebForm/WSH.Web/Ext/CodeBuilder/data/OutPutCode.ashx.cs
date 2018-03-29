using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using Common;
using System.IO;
using System.Text;

namespace Ext.CodeBuilder.data
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class OutPutCode : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = "ok";
            string path = context.Server.UrlDecode(Param.GetParam("path"));
            string content = context.Server.UrlDecode(Param.GetParam("content"));
            string fileName = Param.GetParam("fileName");
            string fileType = Param.GetParam("fileType");
            try
            {
                if (!Directory.Exists(path))
                {
                    result = "指定导出路径不存在！";
                }
                else
                {
                    FileStream file = File.Open(path + fileName + "." + fileType, FileMode.Create);
                    byte[] b = Encoding.Default.GetBytes(content);
                    file.Write(b, 0, b.Length);
                    file.Close();
                    result = "文件已经成功导出到指定目录！";
                }
            }catch(Exception e){
                result = e.Message;
            }
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
