using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using WSH.Common.Helper;
using System.Text.RegularExpressions;
using System.IO.Compression;

namespace WSH.Common.Http
{
    public class HttpHepler
    {
        #region 获取ContentType
        public static string GetContentType(string ext)
        {
            ext = ext.ToLower().Replace(".", "");
            switch (ext)
            {
                case "docx":
                case "doc": return "application/msword";
                case "bin":
                case "exe":
                case "class":
                case "dll":
                case "file":
                    return "application/octet-stream";
                case "pdf": return "application/pdf";
                case "xlsx":
                case "cvs":
                case "xls": return "application/vnd.ms-excel";
                case "pptx":
                case "ppt": return "application/vnd.ms-powerpoint";
                case "js": return "application/x-javascript";
                case "swf": return "application/x-shockwave-flash";
                case "rar":
                case "7z":
                case "zip": return "application/zip";
                case "mp3": return "audio/mpeg";
                case "bmp": return "image/bmp";
                case "gif": return "image/gif";
                case "jpeg":
                case "jpg":
                case "jpe": return "image/jpeg";
                case "png": return "image/png";
                case "css": return "text/css";
                case "html":
                case "htm": return "text/html";
                case "xsl":
                case "xml": return "text/xml";
                case "txt": return "text/plain";
            }
            return "application/octet-stream";
        }
        #endregion
       
        /// <summary>
        /// 获取html定义的编码
        /// </summary>
        /// <param name="htmlString"></param>
        /// <returns></returns>
        public static string GetHtmlEncoding(string htmlString) {
            string localCharacterSet = null;
            Match match = Regex.Match(htmlString, "<meta([^<]*)charset=([^<]*)\"", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                localCharacterSet = match.Groups[2].Value;

                var stringBuilder = new StringBuilder();
                foreach (char item in localCharacterSet)
                {
                    if (item == ' ')
                    {
                        break;
                    }

                    if (item != '\"')
                    {
                        stringBuilder.Append(item);
                    }
                }
                //另一种获取方式
                //string matchStr = match.Groups[2].Value.Replace("\"", "");
                //localCharacterSet = Regex.Split(matchStr, @"\s+")[0];
                localCharacterSet = stringBuilder.ToString();
            }
            return localCharacterSet;
        }
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="url">文件地址</param>
        /// <param name="saveFileName">文件保存的地址</param>
        public static void Download(string url,string saveFileName) {
            WebClient client = new WebClient();
            client.DownloadFile(url, saveFileName);
        }
        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string GetParamterString(Dictionary<string, string> parameters)
        {
            return DictHelper.ToParamterString(parameters);
        }
        /// <summary>
        /// 根据互联网路径读取二进制数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] GetResponseBytes(string url)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return GetResponseBytes(webResponse);
        }
        public static byte[] GetResponseBytes(HttpWebResponse response)
        {
            Stream readStream = response.GetResponseStream();
            byte[] bytes = new byte[readStream.Length];
            try
            {
                readStream.Read(bytes, 0, (int)readStream.Length);
            }
            finally
            {
                readStream.Close();
                response.Close();
            }
            return bytes;
        }
        public static string GetResponseContent(HttpWebResponse response) {
            return GetResponseContent(response, Encoding.Default);
        }
        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static string GetResponseContent(HttpWebResponse response, Encoding encoding)
        {
            StringBuilder result = new StringBuilder();
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                // 如果页面压缩，则解压数据流
                if (response.ContentEncoding == "gzip")
                {
                    Stream responseStream = response.GetResponseStream();
                    if (responseStream != null)
                    {
                        stream = new GZipStream(responseStream, CompressionMode.Decompress);
                    }
                }
                else {
                    stream = response.GetResponseStream();                    
                }
                reader = new StreamReader(stream, encoding);

                // 每次读取不大于256个字符，并写入字符串
                var buffer = new char[256];
                int readBytes;
                while ((readBytes = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(buffer, 0, readBytes);
                }
            }
            finally
            {
                // 释放资源
                if (reader != null) reader.Close();
                if (stream != null) stream.Close();
                if (response != null) response.Close();
            }
            return result.ToString();
        }
    }
}
