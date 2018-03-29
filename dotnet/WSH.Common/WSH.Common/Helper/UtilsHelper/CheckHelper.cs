using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.Common.Helper
{
    public class CheckHelper
    {
        /// <summary>
        /// 检查是否抛出异常
        /// </summary>
        public static void Exception(bool isException, string message)
        {
            if (isException)
            {
                throw new Exception(message);
            }
        }
    }
}
