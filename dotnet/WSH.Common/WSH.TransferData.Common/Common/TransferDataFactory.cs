using System;
using System.Collections.Generic;
using System.Text;

namespace WSH.TransferData.Common
{
    public class TransferDataFactory
    {
        public static string GetFileExtension(TransferFileType type){
            return "."+type.ToString().ToLower();
        }
        /// <summary>
        /// 根据文件后缀名，自动选择数据转换器
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static ITransferData GetTransferData(string fileName)
        {
            var array = fileName.Split('.');
            var dataType = (TransferFileType)Enum.Parse(typeof(TransferFileType), array[array.Length - 1], true);
            return GetTransferData(dataType);
        }

        public static ITransferData GetTransferData(TransferFileType dataType)
        {
            switch (dataType)
            {
                case TransferFileType.Csv: return new CsvTransferData();
                case TransferFileType.Xls: return new XlsTransferData();
                case TransferFileType.Xlsx: return new XlsxTransferData();
                case TransferFileType.Txt: return new TxtTransferData();
                default: return new XlsTransferData();
            }
        }

    }
}
