using System;
using System.Collections.Generic;
using System.Text;
using NPOI.SS.UserModel;

namespace WSH.TransferData.Common
{
    public interface IExcelStyle
    {
        /// <summary>
        /// 设置表头单元格样式
        /// </summary>
        void SetColumnCellStyle(ICellStyle cellStyle);
        /// <summary>
        /// 设置表体单元格样式
        /// </summary>
        void SetRowCellStyle(ICellStyle cellStyle);
    }
}
