using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

namespace WSH.Common.Ftp
{
    public class FtpConfig : ServerConfigItem
    {
        private string url;
        /// <summary>
        /// 可访问的Web地址
        /// </summary>
        public string Url
        {
            get { return url; }
            set { url = value; }
        }

    }
}
