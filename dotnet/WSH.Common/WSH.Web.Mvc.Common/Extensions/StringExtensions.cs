using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WSH.Common.Helper;

namespace WSH.Web.Mvc.Common
{
    public static class StringExtensions
    {
        public static bool HasIndexOf(this string str,string strings) {
            return StringHelper.HasIndexOf(strings,str);
        }
        /// <summary>
        /// 如果结束位置包含该字符则剔除(不做全局处理)
        /// </summary>
        public static string DeleteEnd(this string str, string end)
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
        public static string DeleteStart(this string str, string start)
        {
            if (str.StartsWith(start))
            {
                str = str.Substring(start.Length, str.Length - start.Length);
            }
            return str;
        }
        /// <summary>
        /// 转成枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string enumValue)
        {
            return (T)Enum.Parse(typeof(T), enumValue);
        }
        /// <summary>
        /// 截断字符串
        /// </summary>
        public static string Truncate(this string str, int len)
        {
            return str.Length > len ? str.Substring(0, len) + "..." : str;
        }
        /// <summary>
        /// 如果等于空或者空字符串，则返回默认值
        /// </summary>
        public static string NullDefault(this string str, string defaultString)
        {
            return string.IsNullOrWhiteSpace(str) ? defaultString : str;
        }
        /// <summary>
        ///转换为DateTime
        /// </summary>
        /// <param name="theString"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string theString)
        {
            if (!string.IsNullOrEmpty(theString))
            {
                DateTime result;
                if (DateTime.TryParse(theString, out result))
                {
                    return result;
                }
            }
            return null;
        }

        #region 判断和转换
        public static TValue As<TValue>(this string value)
        {
            return value.As<TValue>(default(TValue));
        }

        public static TValue As<TValue>(this string value, TValue defaultValue)
        {
            try
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter.CanConvertFrom(typeof(string)))
                {
                    return (TValue)converter.ConvertFrom(value);
                }
                converter = TypeDescriptor.GetConverter(typeof(string));
                if (converter.CanConvertTo(typeof(TValue)))
                {
                    return (TValue)converter.ConvertTo(value, typeof(TValue));
                }
            }
            catch (Exception)
            {
            }
            return defaultValue;
        }

        public static bool AsBool(this string value)
        {
            return value.As<bool>(false);
        }

        public static bool AsBool(this string value, bool defaultValue)
        {
            return value.As<bool>(defaultValue);
        }

        public static DateTime AsDateTime(this string value)
        {
            return value.As<DateTime>();
        }

        public static DateTime AsDateTime(this string value, DateTime defaultValue)
        {
            return value.As<DateTime>(defaultValue);
        }

        public static decimal AsDecimal(this string value)
        {
            return value.As<decimal>();
        }

        public static decimal AsDecimal(this string value, decimal defaultValue)
        {
            return value.As<decimal>(defaultValue);
        }

        public static float AsFloat(this string value)
        {
            return value.As<float>();
        }

        public static float AsFloat(this string value, float defaultValue)
        {
            return value.As<float>(defaultValue);
        }

        public static int AsInt(this string value)
        {
            return value.As<int>();
        }

        public static int AsInt(this string value, int defaultValue)
        {
            return value.As<int>(defaultValue);
        }

        public static bool Is<TValue>(this string value)
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(TValue));
            return (((converter != null) && converter.CanConvertFrom(typeof(string))) && converter.IsValid(value));
        }

        public static bool IsBool(this string value)
        {
            return value.Is<bool>();
        }

        public static bool IsDateTime(this string value)
        {
            return value.Is<DateTime>();
        }

        public static bool IsDecimal(this string value)
        {
            return value.Is<decimal>();
        }

        public static bool IsEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsFloat(this string value)
        {
            return value.Is<float>();
        }

        public static bool IsInt(this string value)
        {
            return value.Is<int>();
        }
        #endregion
    }
}
