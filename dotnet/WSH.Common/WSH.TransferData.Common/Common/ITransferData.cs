using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;

namespace WSH.TransferData.Common
{
    public enum TransferFileType
    {
        Txt,
        Csv,
        Xls,
        Xlsx
    }
    public interface ITransferData
    {
        /// <summary>
        /// 将DataTable转换成byte[]文件流
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        byte[] GetBytes(DataTable table,bool isColumn= false);

        /// <summary>
        /// 将流转换成DataTable
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        DataTable GetData(Stream stream,string[] columnNames=null, bool isFirstColumn=false);

        /// <summary>
        /// 将文件转换成DataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        DataTable GetData(string fileName, string[] columnNames=null, bool isFirstColumn=false);
    }
}
