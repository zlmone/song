using System;
using System.Collections.Generic;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.HSSF.Util;

namespace WSH.TransferData.Common
{
    public class DefaultExcelStyle : IExcelStyle
    {
        public void SetColumnCellStyle(ICellStyle cellStyle)
        {
           
        }

        public void SetRowCellStyle(ICellStyle cellStyle)
        {
        }
    }
}
