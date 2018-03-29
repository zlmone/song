using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace WSH.Common.Helper
{
    public class ChineseCalendarHelper
    {
        ///<summary>
        /// 实例化一个 ChineseLunisolarCalendar
        ///</summary>
        private static ChineseLunisolarCalendar cc = new ChineseLunisolarCalendar();
        ///<summary>
        /// 十天干
        ///</summary>
        private static string[] tg = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
        ///<summary>
        /// 十二地支
        ///</summary>
        private static string[] dz = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
        ///<summary>
        /// 十二生肖
        ///</summary>
        private static string[] sx = { "鼠", "牛", "虎", "免", "龙", "蛇", "马", "羊", "猴", "鸡", "狗", "猪" };
        ///<summary>
        /// 返回农历天干地支年
        ///</summary>
        ///<param name="year">农历年</param>
        ///<returns></returns>
        public static string GetYear(int year)
        {
            if (year > 3)
            {
                int tgIndex = (year - 4) % 10;
                int dzIndex = (year - 4) % 12;
                return string.Concat(tg[tgIndex], dz[dzIndex], "[", sx[dzIndex], "]");
            }
            throw new ArgumentOutOfRangeException("无效的年份!");
        }
        ///<summary>
        /// 农历月
        ///</summary>
        ///<returns></returns>
        private static string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二(腊)" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days1 = { "初", "十", "廿", "三" };
        ///<summary>
        /// 农历日
        ///</summary>
        private static string[] days = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };
        ///<summary>
        /// 返回农历月
        ///</summary>
        ///<param name="month">月份</param>
        ///<returns></returns>
        public static string GetMonth(int month)
        {
            if (month < 13 && month > 0)
            {
                return months[month - 1];
            }

            throw new ArgumentOutOfRangeException("无效的月份!");
        }
        ///<summary>
        /// 返回农历日
        ///</summary>
        ///<param name="day">天</param>
        ///<returns></returns>
        public static string GetDay(int day)
        {
            if (day > 0 && day < 32)
            {
                if (day != 20 && day != 30)
                {
                    return string.Concat(days1[(day - 1) / 10], days[(day - 1) % 10]);
                }
                else
                {
                    return string.Concat(days[(day - 1) / 10], days1[1]);
                }
            }

            throw new ArgumentOutOfRangeException("无效的日!");
        }
        /// <summary>
        /// yyyy-MM-dd
        /// </summary>
        public static string GetDate(DateTime datetime)
        {
            string year = cc.GetYear(datetime).ToString();
            string month = (cc.GetMonth(datetime) - 1).ToString().PadLeft(2, '0');
            string day = cc.GetDayOfMonth(datetime).ToString().PadLeft(2, '0');
            return string.Format("{0}-{1}-{2}", year, month, day);
        }
        ///<summary>
        /// 根据公历获取农历日期
        ///</summary>
        ///<param name="datetime">公历日期</param>
        ///<returns></returns>
        public static string GetChineseDate(DateTime datetime)
        {
            int year = cc.GetYear(datetime);
            int month = cc.GetMonth(datetime);
            int day = cc.GetDayOfMonth(datetime);
            //获取闰月， 0 则表示没有闰月
            int leapMonth = cc.GetLeapMonth(year);

            bool isleap = false;

            if (leapMonth > 0)
            {
                if (leapMonth == month)
                {
                    //闰月
                    isleap = true;
                    month--;
                }
                else if (month > leapMonth)
                {
                    month--;
                }
            }
            return string.Concat(GetYear(year), "年", isleap ? "闰" : string.Empty, GetMonth(month), "月", GetDay(day));
        }
    }
}