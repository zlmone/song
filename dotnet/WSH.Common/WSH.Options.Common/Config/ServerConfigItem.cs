using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class ServerConfigItem : ConfigItem
    {
        private string server;
        /// <summary>
        /// 服务器地址
        /// </summary>
        public string Server
        {
            get { return server; }
            set { server = value; }
        }

        private string username;
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string port;
        /// <summary>
        /// 端口号
        /// </summary>
        public string Port
        {
            get { return port; }
            set { port = value; }
        }
        private string timeout;
        /// <summary>
        /// 超时时间
        /// </summary>
        public string Timeout
        {
            get { return timeout; }
            set { timeout = value; }
        }
    }
}
