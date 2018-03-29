using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using WSH.Common.Http;
using WSH.Options.Common;

namespace WSH.Common.Helper
{
    public class DateTimeHelper
    {
        public static int ToInt(DateTime dateTime)
        {
            return Math.Abs(dateTime.GetHashCode());
        }

        #region 获得系统当前时间
        public static string NowDateTime
        {
            get
            {
                return GetDateFormat(FormatHelper.DateTime);
            }
        }
        public static string NowDate
        {
            get
            {
                return GetDateFormat(FormatHelper.Date);
            }
        }
        public static string NowTime
        {
            get
            {
                return GetDateFormat(FormatHelper.Time);
            }
        }

        public static string GetDateFormat(string format)
        {
            return DateTime.Now.ToString(format);
        }
        #endregion
        /// <summary>
        /// 获取北京时间
        /// </summary>
        /// <returns></returns>
        public static DateTime GetBeijingTime()
        {
            DateTime dt = new DateTime();
            HttpSimpleRequest request = new HttpSimpleRequest("http://www.beijing-time.org/time.asp");
            Result result = request.Request();
            if (result.IsSuccess && !string.IsNullOrEmpty(result.Msg))
            {
                string[] tempArray = result.Msg.Split(';');
                for (int i = 0; i < tempArray.Length; i++)
                {
                    tempArray[i] = tempArray[i].Replace("\r\n", "");
                }
                string year = tempArray[1].Split('=')[1];
                string month = tempArray[2].Split('=')[1];
                string day = tempArray[3].Split('=')[1];
                string hour = tempArray[5].Split('=')[1];
                string minite = tempArray[6].Split('=')[1];
                string second = tempArray[7].Split('=')[1];
                dt = DateTime.Parse(year + "-" + month + "-" + day + " " + hour + ":" + minite + ":" + second);
            }
            return dt;
        }
        /// <summary>
        /// 获取相差的月份
        /// </summary>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>相差的月份</returns>
        public static int GetDiffMonth(DateTime beginDate, DateTime endDate)
        {
            if (beginDate > endDate)
            {
                throw new Exception("开始时间大于结束时间");
            }
            int beginYear = beginDate.Year;
            int endYear = endDate.Year;
            int beginMonth = beginDate.Month;
            int endMonth = endDate.Month;
            int diffMonth = 12 * (endYear - beginYear) + (endMonth - beginMonth);
            return diffMonth;
        }
    }
}
