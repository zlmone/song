using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Http;
using WSH.Common.Helper;
using WSH.Options.Common;

namespace WSH.Tools.Internet.InternetFate
{
    public class HttpFateRequest : HttpSimpleRequest
    {
        public HttpFateRequest()
        {
            this.Encoding = Encoding.UTF8;
            this.IsLogin = false;
        }
        /// <summary>
        /// 是否已经登录
        /// </summary>
        public bool IsLogin { get; set; }
        public string LoginUrl {
            get { return CryptHelper.DecryptDES("eKuJXgdpEuoCjB9beHdvwrU8Q0/IOwFBiJGQ74zuVeIt5YZbX+uT/8ckZwOJTdD4"); }
        }
        
        /// <summary>
        /// 登录
        /// </summary>
        public bool Login()
        {
            if (!this.IsLogin)
            {
                this.ClearParamters();
                this.AddParamter("name", CryptHelper.DecryptDES("hIbzJGv2Z3RufyWc+KKM5w=="));
                this.AddParamter("password", CryptHelper.DecryptDES("+J/9tEcTQtcBmZZcQBGg1Q=="));
                this.IsSaveCookie = true;
                Result result = this.Request(this.LoginUrl);
                this.IsSaveCookie = false;
                this.IsLogin = result.IsSuccess;
            }
            return this.IsLogin;
        }
         
    }
}
