using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using NPOI.XSSF.UserModel;

namespace WSH.TransferData.Common
{
    public class XlsxTransferData : ExcelTransferData
    {
        private IExcelStyle styleType;
        /// <summary>
        /// 设置Excel样式
        /// </summary>
        public IExcelStyle StyleType
        {
            get { return styleType; }
            set { styleType = value; }
        }
        public override byte[] GetBytes(DataTable table,bool isColumn= false)
        {
            base._workBook = new XSSFWorkbook();
            if (StyleType != null)
            {
                base.SetColumnCellStyle = StyleType.SetColumnCellStyle;
                base.SetRowCellStyle = StyleType.SetRowCellStyle;
            }
            return base.GetBytes(table,isColumn);
        }

        public override DataTable GetData(Stream stream,string[] columnNames=null,bool isFirstColumn = false)
        {
            base._workBook = new XSSFWorkbook(stream);
            return base.GetData(stream, columnNames, isFirstColumn);
        }
        public override DataTable GetData(string fileName, string[] columnNames = null, bool isFirstColumn = false)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            return GetData(fs, columnNames, isFirstColumn);
        }
    }
}
