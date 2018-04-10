using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSH.Common.Extend
{
    public static class DateTimeExtend
    {
        /// <summary>
        /// 判断是否在日期范围
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dateStart">开始日期</param>
        /// <param name="dateEnd">结束日期</param>
        /// <returns></returns>
        public static bool between(this DateTime dt, DateTime dateStart, DateTime dateEnd)
        {
            return dt.CompareTo(dateStart) >= 0 && dt.CompareTo(dateEnd) <= 0;
        }

        public static string toDateTime(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string toDate(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
    }
}
