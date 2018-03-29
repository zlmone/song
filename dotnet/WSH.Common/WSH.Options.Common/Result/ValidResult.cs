using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Options.Common
{
    public class ValidResult : Result
    {
        private string value;
        /// <summary>
        /// 当前需要验证的值
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
    }
}
