using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace WSH.Common.Helper
{
    public class PathHelper
    {
        /// <summary>
        /// 获取当前程序运行的根路径
        /// </summary>
        public static string GetMainPath
        {
            get { return AppDomain.CurrentDomain.BaseDirectory; }
        }
        /// <summary>
        /// 获取默认的配置根路径
        /// </summary>
        public static string GetConfigPath
        {
            get { return GetMainPath + "\\Config\\"; }
        }
        /// <summary>
        /// 获取文件后缀名，不包含"."
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).Replace(".", "");
        }
        /// <summary>
        /// 获取一个新的文件名
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetNewFileName(string fileName)
        {
            return GuidHelper.GuidNonSplit + Path.GetExtension(fileName);
        }
    }
}
