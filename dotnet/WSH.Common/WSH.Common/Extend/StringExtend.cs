using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WSH.Common.Extend
{
    public static class StringExtend
    {
        /// <summary>
        /// 判断字符串为空则转为空字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string asEmpty(this string str) {
            return str == null ? string.Empty : str.Trim();
        }
        /// <summary>
        /// 判断字符串是否为空或者空白
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool isEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
        /// <summary>
        /// 判断如果是空白或空字符串，则替换值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string replaceEmpty(this string str, string replaceValue = "")
        {
            return str.isEmpty() ? replaceValue : str;
        }
        /// <summary>
        /// 判断字符串是否包含节点
        /// </summary>
        /// <param name="str"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool hasItem(this string str, string item)
        {
            return Array.IndexOf(str.Split(','), item) > -1;
        }
        /// <summary>
        /// 根据空格或空白切割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] splitBlank(this string str) {
            return System.Text.RegularExpressions.Regex.Split(str, @"\s+");
        }
        /// <summary>
        /// 将字符串转为枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T toEnum<T>(this string str, string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }
        /// <summary>
        /// 首字母大写或小写
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <returns></returns>
        public static string capitalize(this string str, bool isUpper=true)
        {
            if (str == null || str.Trim().Length <= 0)
            {
                return str;
            }
            string first = str.Substring(0, 1);
            string remain = str.Substring(1);
            first = isUpper ? first.ToUpper() : first.ToLower();
            return first + remain;
        }
        /// <summary>
        /// 截断字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <param name="more"></param>
        /// <returns></returns>
        public static string truncate(this string str, int len, string more = "...")
        {
            return str.Length > len ? str.Substring(0, len) + more : str;
        }
        /// <summary>
        /// 按byte长度截断字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <param name="more"></param>
        /// <returns></returns>
        public static string truncateByte(this string str, int len, string more = "...")
        {
            Encoding _encoding = System.Text.Encoding.Default;
            byte[] bytes = _encoding.GetBytes(str);
            if (bytes.Length > len)
            {
                return _encoding.GetString(bytes, 0, len)+more;
            }
            return str;
        }
        /// <summary>
        /// 字符串格式化
        /// </summary>
        /// <param name="str"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string format(this string str,params object[] args)
        {
            return string.Format(str, args);
        }
        /// <summary>
        /// 转换bool值的近亲
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static bool similarBool(this string str, bool defaultValue=false)
        { 
            if(str.isEmpty()){
                return defaultValue;
            }
            if ("true,1,y,yes,是,ok".hasItem(str.ToLower()))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 字符串包裹
        /// </summary>
        /// <param name="str"></param>
        /// <param name="wrap"></param>
        /// <returns></returns>
        public static string wrap(this string str, string wrap) {
            return wrap + str + wrap;
        }
        /// <summary>
        /// 按正则匹配查找
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static List<string> match(this string str, string pattern,RegexOptions options= RegexOptions.None)
        {
            Match m = Regex.Match(str, pattern, options);
            List<string> list = new List<string>();
            if(m.Success && m.Groups.Count>0){
                foreach (Group item in m.Groups)
                {
                    list.Add(item.Value);
                }
            }
            return list;
        }

        #region 格式转换
        public static int toInt(this string str, int defaultValue = 0) { 
            int value=defaultValue;
            int.TryParse(str,out value);
            return value;
        }
        public static long toLong(this string str, long defaultValue = 0)
        {
            long value = defaultValue;
            long.TryParse(str, out value);
            return value;
        }
        public static double toDouble(this string str, double defaultValue = 0)
        {
            double value = defaultValue;
            double.TryParse(str, out value);
            return value;
        }
        public static float toDouble(this string str, float defaultValue = 0)
        {
            float value = defaultValue;
            float.TryParse(str, out value);
            return value;
        }
        #endregion
    }
   
}
