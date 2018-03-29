using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Helper
{
    public enum CaseType
    {
        Upper, Lower
    }
    public class StringHelper
    {
        /// <summary>
        /// 空格分隔字符串
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string[] SplitWhiteSpace(string content)
        {
            return System.Text.RegularExpressions.Regex.Split(content, @"\s+");
        }
        
        /// <summary>
        /// 判断当前是否追加，
        /// </summary>
        /// <param name="count"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetLast(int count, int i) {
            return i < count - 1 ? "," : "";
        }
        /// <summary>
        /// 判断以，隔开的字符串里面是否包含子项
        /// </summary>
        /// <param name="codes"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool HasIndexOf(string codes,string code) {
            return Array.IndexOf(codes.Split(','), code) > -1;
        }
        /// <summary>
        /// 转成枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }

        #region 字符串功能扩展
        /// <summary>
        /// 如果结束位置包含该字符则剔除(不做全局处理)
        /// </summary>
        public static string DeleteEnd(string str, string end)
        {
            if (str.EndsWith(end))
            {
                str = str.Substring(0, str.Length - end.Length);
            }
            return str;
        }
        /// <summary>
        /// 如果开始位置包含该字符则剔除(不做全局处理)
        /// </summary>
        public static string DeleteStart(string str, string start)
        {
            if (str.StartsWith(start))
            {
                str = str.Substring(start.Length, str.Length - start.Length);
            }
            return str;
        }
        /// <summary>
        /// 首字母转换成大写或者小写
        /// </summary>
        public static string Capitalize(string str, CaseType type)
        {
            if (str == null || str.Trim().Length <= 0)
            {
                return str;
            }
            string first = str.Substring(0, 1);
            string remain = str.Substring(1);
            first = type == CaseType.Upper ? first.ToUpper() : first.ToLower();
            return first + remain;
        }
        /// <summary>
        /// 首字母大写
        /// </summary>
        public static string Capitalize(string str)
        {
            return Capitalize(str, CaseType.Upper);
        }
        /// <summary>
        /// 截断字符串
        /// </summary>
        public static string Truncate(string str, int len)
        {
            return str.Length > len ? str.Substring(0, len) + "..." : str;
        }
        public static int GetByteLength(string str) {
           return  System.Text.Encoding.Default.GetBytes(str).Length;
        }
        /// <summary>
        /// 根据字节截取字符串
        /// </summary>
        /// <param name="str"></param>  
        /// <param name="len"></param>
        /// <returns></returns>
        public static string TruncateByte(string str, int len) {
            Encoding _encoding = System.Text.Encoding.Default;
            byte[] bytes = _encoding.GetBytes(str);
            if (bytes.Length > len)
            {
                return _encoding.GetString(bytes, 0, len);
            }
            return str;
        }
        /// <summary>
        /// 将null值转成空字符串
        /// </summary>
        public static string AsEmpty(string str)
        {
            return str == null ? string.Empty : str;
        }
        #endregion

        #region 得到一个新的Guid
        /// <summary>
        /// 得到一个新的Guid
        /// </summary>
        public static string Guid
        {
            get { return System.Guid.NewGuid().ToString(); }
        }
        public static string GuidNonSplit
        {
            get { return Guid.Replace("-", ""); }
        }
        #endregion  
    }
}