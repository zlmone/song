using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using WSH.Web.Common;

namespace WSH.Web.Song.Controls
{
    /// <summary>
    /// grid 的摘要说明
    /// </summary>
    public class grid : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageIndex=Convert.ToInt32( context.Request.Params["pageIndex"]);
            int pageSize=Convert.ToInt32( context.Request.Params["pageSize"]);
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            for (int i = 0; i < pageSize; i++)
            {
                 string fix=pageIndex.ToString()+i.ToString();
                sb.Append("{ \"name\": \"王松华"+fix+"\", \"man\": true, \"woman\": false, \"address\": \"湖南株洲攸县"+fix+"\" }");
                if(i<pageSize-1){
                    sb.Append(",");
                }
            }
            sb.Append("]");
            string json = sb.ToString();
           // System.Threading.Thread.Sleep(500);
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