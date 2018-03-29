using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Drawing;

namespace WSH.Common.Helper
{
    public class RandomHelper
    {

        #region 随机生成汉字和数字
        /// <summary>
        /// 随机生成指定长度的数字
        /// </summary>
        public static string GetNumber(int len)
        {
            string randomnum = "";
            Random random = new Random();
            for (int i = 0; i < len; i++)
            {
                randomnum += random.Next(0, 10).ToString();
            }
            return randomnum;
        }
        /// <summary>
        /// 随机生成指定长度的汉字
        /// </summary>
        public static string GetChinese(int len)
        {
            var random = new Random();
            var bs = new byte[len * 2];
            for (var i = 0; i < len; i++)
            {
                var x = random.Next(40) + 16;
                var y = random.Next(x == 55 ? 89 : 94) + 1;
                var c = new Point(x, y);
                bs[i * 2] = (byte)(c.X + 0xa0);
                bs[i * 2 + 1] = (byte)(c.Y + 0xa0);
            }
            return Encoding.GetEncoding("GB2312").GetString(bs);
        }
        #endregion
        /// <summary>
        /// 获取指定长度的字符串
        /// </summary>
        /// <returns></returns>
        public static string GetText(RandomText rt = null)
        {
            if (rt == null)
            {
                rt = new RandomText();
            }
            byte[] b = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = rt.CustomString;

            if (rt.AllowNumber) { str += "0123456789"; }
            if (rt.AllowLowerLetter) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (rt.AllowUpperLetter) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (rt.AllowSpecial) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }
            if (!rt.AllowAlmost)
            {
                str = str.Replace("o", "").Replace("O", "").Replace("0", "").Replace("1", "").Replace("i", "").Replace("I", "");
            }
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            for (int i = 0; i < rt.Length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }
            return s;
        }
    }
    /// <summary>
    /// 随机文字选项
    /// </summary>
    public class RandomText
    {
        private bool allowNumber = true;
        /// <summary>
        /// 是否允许数字
        /// </summary>
        public bool AllowNumber
        {
            get { return allowNumber; }
            set { allowNumber = value; }
        }
        private bool allowLowerLetter = false;
        /// <summary>
        /// 是否允许小写字母
        /// </summary>
        public bool AllowLowerLetter
        {
            get { return allowLowerLetter; }
            set { allowLowerLetter = value; }
        }
        private bool allowUpperLetter = true;
        /// <summary>
        /// 是否允许大写字母
        /// </summary>
        public bool AllowUpperLetter
        {
            get { return allowUpperLetter; }
            set { allowUpperLetter = value; }
        }
        private bool allowSpecial = false;
        /// <summary>
        /// 是否允许特殊字符
        /// </summary>
        public bool AllowSpecial
        {
            get { return allowSpecial; }
            set { allowSpecial = value; }
        }
        private int length = 4;

        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        private string customString;
        /// <summary>
        /// 自定义生成的字符串
        /// </summary>
        public string CustomString
        {
            get { return customString; }
            set { customString = value; }
        }
        private bool allowAlmost = true;
        /// <summary>
        /// 是否过滤难以辨认的字符
        /// </summary>
        public bool AllowAlmost
        {
            get { return allowAlmost; }
            set { allowAlmost = value; }
        }
    }

}
