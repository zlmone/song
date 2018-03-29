using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WSH.Common.Helper
{
    public class UriHelper
    {
        /// <summary>
        /// 判断两个地址是否是相同的域名（如：二级域名和一级域名是同一个域）
        /// </summary>
        /// <returns></returns>
        public static bool IsSameDomain(string url1, string url2)
        {
            string[] u1 = new Uri(url1).Host.Split('.');
            string[] u2 = new Uri(url2).Host.Split('.');
            if (u1.Length >= 3 && u2.Length >= 3)
            {
                return (u1[1] + u1[2]) == (u2[1] + u2[2]);
            }
            return false;
        }
        /// <summary>
        /// 获取网址根目录
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="applicationPath">虚拟目录</param>
        /// <returns></returns>
        public static string GetUrlRoot(string url, string applicationPath = null)
        {
            Uri uri = new Uri(url);
            return url.Replace(uri.PathAndQuery, "") + applicationPath;
        }
        /// <summary>
        /// 拼接两个url路径
        /// </summary>
        /// <param name="url1">路径1</param>
        /// <param name="url2">路径2</param>
        /// <returns></returns>
        public static string Combine(string url1, string url2)
        {
            char split = '/';
            return url1.TrimEnd(split) + split + url2.TrimStart(split);
        }
        /// <summary>
        /// 判断是否是迅雷下载链接
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsThunderLink(string url)
        {
            bool isThunder = false;
            if (string.IsNullOrEmpty(url))
            {
                return isThunder;
            }
            //支持磁力链接，迅雷链接，电驴链接
            new List<string>() { "magnet:", "thunder:", "ed2k:" }.ForEach(o =>
            {
                if (url.Trim().ToLower().StartsWith(o))
                {
                    isThunder = true;
                }
            });
            return isThunder;
        }
        /// <summary>
        /// 是否是页面地址
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsWebPage(string url)
        {
            string ext = Path.GetExtension(url);
            List<string> exts = new List<string>() { ".htm", ".html", ".aspx", ".asp", ".jsp", ".php", ".cshtml" };
            if (exts.Contains(ext.ToLower()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 移除地址中的参数
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string RemoveParams(string uri)
        {
            int paramIndex = uri.IndexOf('?');
            return paramIndex > -1 ? uri.Substring(0, paramIndex) : uri;
        }
        /// <summary>
        /// 拼接URL和参数
        /// </summary>
        /// <param name="url"></param>
        /// <param name="paramString"></param>
        /// <returns></returns>
        public static string ConnectUrlParams(string url, string paramString)
        {
            if (string.IsNullOrEmpty(paramString))
            {
                return url;
            }
            bool isMark = url.IndexOf("?") > -1;
            if (!isMark)
            {
                url += "?";
            }
            bool isLastMark = url.LastIndexOf("&") > -1;
            if (!isLastMark)
            {
                url = url.TrimEnd('&') + "&";
            }
            return url + paramString.TrimStart('?').TrimStart('&');
        }
    }
}
