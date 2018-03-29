using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

namespace WSH.Web.Common.Response
{
    public class ResponseHelper
    {
        /// <summary>
        /// 获取当前流的编码
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public static Encoding GetEncoding(WebResponse response)
        {
            Encoding encoding = null;

            if (response.Headers.HasKeys())
            {
                var contentType = response.Headers[HttpResponseHeader.ContentType];
                if (contentType != null)
                {
                    foreach (var value in contentType.Split(';'))
                    {
                        var _value = value.Trim();
                        if (_value.StartsWith("charset=", StringComparison.OrdinalIgnoreCase))
                            encoding = Encoding.GetEncoding(_value.Substring(8));
                    }
                }
            }
            return encoding;
        }
        /// <summary>
        /// 获取文件输出流
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isAutoContentType"></param>
        /// <returns></returns>
        public static HttpResponse GetFileResponse(string fileName, bool isAutoContentType=false)
        {
            HttpResponse response = HttpContext.Current.Response;
            response.Buffer = true;
            response.Clear();
            response.ContentType =WSH.Common.Http.HttpHepler.GetContentType(isAutoContentType ? Path.GetExtension(fileName) : "file");
            response.ContentEncoding = System.Text.Encoding.UTF8;
            response.Charset = "utf-8";
            if (HttpContext.Current.Request.UserAgent.ToLower().Contains("msie"))
            {
                fileName = HttpContext.Current.Server.UrlEncode(fileName);
            }
            response.AppendHeader("Content-Disposition", "attachment;filename=" + fileName);
            return response;
        }
        
    }
}
