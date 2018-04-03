using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Common.Extend
{
    public static class StringExtend
    {
        public static string asEmpty(this string str) {
            return str == null ? string.Empty : str;
        }

        public static bool hasItem(this string str, string item)
        {
            return Array.IndexOf(str.Split(','), item) > -1;
        }

        public static string[] splitBlank(this string str) {
            return System.Text.RegularExpressions.Regex.Split(str, @"\s+");
        }

        public static T toEnum<T>(this string str, string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }

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

        public static string truncate(this string str, int len, string more = "...")
        {
            return str.Length > len ? str.Substring(0, len) + more : str;
        }
        
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

        public static string format(this string str,params object[] args)
        {
            return string.Format(str, args);
        }
    }
   
}
