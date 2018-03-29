using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.CodeBuilder.Entity
{
    public class UserInfoEntity : Entity
    {
        private string userName;
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string realName;
        /// <summary>
        /// RealName
        /// </summary>
        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }
        private string password;
        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private bool isAdmin;
        /// <summary>
        /// IsAdmin
        /// </summary>
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
        private string iPAddress;
        /// <summary>
        /// IPAddress
        /// </summary>
        public string IPAddress
        {
            get { return iPAddress; }
            set { iPAddress = value; }
        }
        private string macAddress;
        /// <summary>
        /// MacAddress
        /// </summary>
        public string MacAddress
        {
            get { return macAddress; }
            set { macAddress = value; }
        }
        private bool enabled;
        /// <summary>
        /// Enable
        /// </summary>
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }
        private string email;
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}
