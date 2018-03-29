using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WSH.Common.Helper
{
    public class RegexItem
    {
        private string regexString;

        public string RegexString
        {
            get { return regexString; }
            set { regexString = value; }
        }
        private string regexMessage;

        public string RegexMessage
        {
            get { return regexMessage; }
            set { regexMessage = value; }
        }
    }
    public class RegexHelper
    {
        #region 正则表达式集合
        public const string Int = @"^(-|\+)?\d+$";
        public const string IntMsg = "必须是整数";
        public const string Float = @"^(-?\d+)(\.\d+)?$";
        public const string FloatMsg = "必须是数字";
        public const string Email = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string EmailMsg = "邮箱格式不正确";
        /// <summary>
        /// 电话
        /// </summary>
        public const string Tel = @"((\\d{11})|^((\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})|(\\d{4}|\\d{3})-(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1})|(\\d{7,8})-(\\d{4}|\\d{3}|\\d{2}|\\d{1}))$)";
        public const string TelMsg = "电话格式不正确";
        /// <summary>
        /// 手机
        /// </summary>
        public const string Mobile = @"^1[3|4|5|8][0-9]\d{4,8}$";
        public const string MobileMsg = "手机号码格式不正确";
        /// <summary>
        /// 英文
        /// </summary>
        public const string En = @"^[A-Za-z]+$";
        public const string EnMsg = "必须是英文";
        /// <summary>
        /// 中文
        /// </summary>
        public const string Cn = @"^[\u0391-\uFFE5]+$";
        public const string CnMsg = "必须是中文";
        public const string Url = @"^(http|https)://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
        public const string UrlMsg = "网址格式不正确";
        public const string IP = @"^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$";
        public const string IPMsg = "IP地址格式不正确";
        /// <summary>
        /// 邮政编码
        /// </summary>
        public const string Zip = @"^[1-9]\d{5}$";
        public const string ZipMsg = "邮政编码格式不正确";
        /// <summary>
        /// 数字字母下划线
        /// </summary>
        public const string Alpha = @"^[0-9a-zA-Z\_]+$";
        public const string AlphaMsg = "必须以字母或者数字或者下划线开头";
        /// <summary>
        /// 身份证
        /// </summary>
        public const string IdCard = @"^\d{15}(\d{2}[A-Za-z0-9])?$";
        public const string IdCardMsg = "身份证格式不正确";
        /// <summary>
        /// 车牌号码（例：粤J12350）
        /// </summary>
        public const string CarNo = @"^[\u4E00-\u9FA5][\da-zA-Z]{6}$";
        public const string CarNoMsg = "车牌号码不正确（例：粤J12350）";
        public const string QQ = @"^[1-9]\d{4,10}$";
        public const string QQMsg = "qq号码格式不正确";
        public const string Msn = @"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";
        public const string MsnMsg = "msn账号格式不正确";
        #endregion

        public static RegexItem GetRegexItem(RegexType type)
        {
            RegexItem item = new RegexItem();
            switch (type)
            {
                case RegexType.Int: { item.RegexString = RegexHelper.Int; item.RegexMessage = RegexHelper.IntMsg; }
                    break;
                case RegexType.Float: { item.RegexString = RegexHelper.Float; item.RegexMessage = RegexHelper.FloatMsg; }
                    break;
                case RegexType.Email: { item.RegexString = RegexHelper.Email; item.RegexMessage = RegexHelper.EmailMsg; }
                    break;
                case RegexType.Tel: { item.RegexString = RegexHelper.Tel; item.RegexMessage = RegexHelper.TelMsg; }
                    break;
                case RegexType.Mobile: { item.RegexString = RegexHelper.Mobile; item.RegexMessage = RegexHelper.MobileMsg; }
                    break;
                case RegexType.En: { item.RegexString = RegexHelper.En; item.RegexMessage = RegexHelper.EnMsg; }
                    break;
                case RegexType.Cn: { item.RegexString = RegexHelper.Cn; item.RegexMessage = RegexHelper.CnMsg; }
                    break;
                case RegexType.Url: { item.RegexString = RegexHelper.Url; item.RegexMessage = RegexHelper.UrlMsg; }
                    break;
                case RegexType.IP: { item.RegexString = RegexHelper.IP; item.RegexMessage = RegexHelper.IPMsg; }
                    break;
                case RegexType.Zip: { item.RegexString = RegexHelper.Zip; item.RegexMessage = RegexHelper.ZipMsg; }
                    break;
                case RegexType.Alpha: { item.RegexString = RegexHelper.Alpha; item.RegexMessage = RegexHelper.AlphaMsg; }
                    break;
                case RegexType.IdCard: { item.RegexString = RegexHelper.IdCard; item.RegexMessage = RegexHelper.IdCardMsg; }
                    break;
                case RegexType.CarNo: { item.RegexString = RegexHelper.CarNo; item.RegexMessage = RegexHelper.CarNoMsg; }
                    break;
                case RegexType.QQ: { item.RegexString = RegexHelper.QQ; item.RegexMessage = RegexHelper.QQMsg; }
                    break;
                case RegexType.Msn: { item.RegexString = RegexHelper.Msn; item.RegexMessage = RegexHelper.MsnMsg; }
                    break;
            }
            return item;
        }

        public static bool Test(string value, string regex)
        {
            return Regex.IsMatch(value, regex);
        }
        public static bool Test(string value, RegexType regexType)
        {
            return Regex.IsMatch(value, GetRegexItem(regexType).RegexString);
        }
        public static string ParseIdCard(string _sId)
        {
            string[] sArrCity = new string[] { 
                null, null, null, null, null, null, null, null, null, null, null, 
                "北京", "天津", "河北", "山西", "内蒙古", 
                null, null, null, null, null, 
                "辽宁", "吉林", "黑龙江", 
                null, null, null, null, null, null, null, 
                "上海", "江苏", "浙江", "安微", "福建", "江西", "山东", 
                null, null, null, 
                "河南", "湖北", "湖南", "广东", "广西", "海南",
                null, null, null, 
                "重庆", "四川", "贵州", "云南", "西藏",
                null, null, null, null, null, null, 
                "陕西", "甘肃", "青海", "宁夏", "新疆", 
                null, null, null, null, null, 
                "台湾",
                null, null, null, null, null, null, null, null, null,
                "香港", "澳门", 
                null, null, null, null, null, null, null, null, 
                "国外" 
            };
            double nSum = 0;
            System.Text.RegularExpressions.Regex oRegex = new System.Text.RegularExpressions.Regex(@"^\d{17}(\d|x)$");
            System.Text.RegularExpressions.Match oMatch = oRegex.Match(_sId);
            if (!oMatch.Success)
            {
                return "";
            }
            _sId = _sId.ToLower();
            _sId = _sId.Replace("x", "a");
            if (sArrCity[int.Parse(_sId.Substring(0, 2))] == null)
            {
                return "非法地区";
            }
            try
            {
                DateTime.Parse(_sId.Substring(6, 4) + "-" + _sId.Substring(10, 2) + "-" + _sId.Substring(12, 2));
            }
            catch
            {
                return "非法生日";
            }
            for (int i = 17; i >= 0; i--)
            {
                nSum += (System.Math.Pow(2, i) % 11) * int.Parse(_sId[17 - i].ToString(), System.Globalization.NumberStyles.HexNumber);

            }
            if (nSum % 11 != 1)
                return ("非法证号");

            return (sArrCity[int.Parse(_sId.Substring(0, 2))] + 
                "," + _sId.Substring(6, 4) + 
                "-" + _sId.Substring(10, 2) + 
                "-" + _sId.Substring(12, 2) + 
                "," + (int.Parse(_sId.Substring(16, 1)) % 2 == 1 ? "男" : "女")
            );
        }
    }
}
