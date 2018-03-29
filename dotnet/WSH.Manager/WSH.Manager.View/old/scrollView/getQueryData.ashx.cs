using System;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace Song.WebSite.View.page.scrollView
{
    /// <summary>
    /// getQueryData 的摘要说明
    /// </summary>
    public class getQueryData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{\"TotalRecord\":40,\"Items\":");
            sb.AppendLine("[");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1},");
            sb.AppendLine("{\"Header\":\"王松华\",\"TypeName\":\"王氏家族\",\"TypeId\":101,\"Id\":1}");
            sb.AppendLine("]");
            sb.AppendLine("}");
            context.Response.Write(sb.ToString());
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