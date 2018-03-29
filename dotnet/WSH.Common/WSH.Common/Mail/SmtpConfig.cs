using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Common.Mail
{
    public class SmtpConfig : ServerConfigItem
    {
        private string sendName;
        /// <summary>
        /// 发件人姓名
        /// </summary>
        public string SendName
        {
            get { return sendName; }
            set { sendName = value; }
        }
        private bool encrypt;
        /// <summary>
        /// 是否加密用户名密码
        /// </summary>
        public bool Encrypt
        {
            get { return encrypt; }
            set { encrypt = value; }
        }
    }
}
