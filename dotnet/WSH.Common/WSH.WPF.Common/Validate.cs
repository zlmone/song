using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Windows.Common;

namespace WSH.WPF.Common
{
  public   class Validate : BaseValidate
    {
        /// <summary>
        /// 验证并提示信息
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            string msg = this.CheckRequired() + this.CheckRegex();
            if (msg != "")
            {
                MsgBox.Alert(msg);
                return false;
            }
            return true;
        }
    }
}
