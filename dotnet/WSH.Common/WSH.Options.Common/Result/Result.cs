using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class Result
    {
        public Result Add(string key, string value)
        {
            this.Attrs.Add(key, value);
            return this;
        }
        public string Get(string key)
        {
            if (Attrs.ContainsKey(key))
            {
                return Attrs[key];
            }
            return null;
        }
        private bool isSuccess = true;
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess
        {
            get { return isSuccess; }
            set { isSuccess = value; }
        }
        private string msg = string.Empty;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }

        protected Dictionary<string, string> Attrs = new Dictionary<string, string>();
    }
}
