using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.Web.Common.Helper
{
    public class WebUrlHelper
    {
        /// <summary>
        /// 判断Url是否是静态文件
        /// </summary>
        /// <returns></returns>
        public static bool IsStaticFile(string url)
        {
            FileType fileType = FileHelper.GetFileType(System.IO.Path.GetExtension(url));
            var fileTypes = new List<FileType>() { 
                 FileType.Image,
                 FileType.Html,
                 FileType.Txt
            };
            if (fileTypes.Contains(fileType))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 根目录的虚拟路径
        /// </summary>
        public static string ApplicationPath
        {
            get
            {
                return HttpContext.Current.Request.ApplicationPath;
            }
        }
        /// <summary>
        /// 根目录的物理路径
        /// </summary>
        public static string ApplicationMapPath
        {
            get {
                return HttpContext.Current.Server.MapPath("/");
            }
        }
        /// <summary>
        /// 将物理路径转换成虚拟路径
        /// </summary>
        /// <param name="mapPath"></param>
        /// <returns></returns>
        public static string ToVirtual(string mapPath) {
            return mapPath.Remove(0, ApplicationMapPath.Length - 1).Replace("\\", "/");
        }
        /// <summary>
        /// 页面名称
        /// </summary>
        public static string PageName
        {
            get
            {
                string str = HttpContext.Current.Request.ServerVariables["URL"];
                return str.Substring(str.LastIndexOf("/") + 1);
            }
        }
        public static string PageUrl
        {
            get
            {
                return HttpContext.Current.Request.Url.ToString();
            }
        }
        public static string PagePath
        {
            get
            {
                return HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"].ToString();

            }
        }
    }
}
