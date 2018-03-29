using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.TransferData.Common
{
    public enum ExcelStyleType { 
        Default
    }
    public class ExcelStyleFactory
    {
        /// <summary>
        /// 获取excel导出样式
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IExcelStyle GetExcelStyleType(ExcelStyleType type) {
            switch (type)
            {
                default: return new DefaultExcelStyle();
            }
        }
    }
}
