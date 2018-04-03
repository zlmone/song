using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Common.Extend
{
    public static class ObjectExtend
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool isNull(this object obj)
        {
            return (obj == null || obj == DBNull.Value);
        }
        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string toString(this object obj, string defaultValue = "")
        {
            return obj.isNull() ? defaultValue : obj.ToString();
        }
    }
}
