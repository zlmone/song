using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.Common.Helper;

namespace WSH.TransferData.Common
{
    public class TxtTransferData : ITransferData
    {

        public byte[] GetBytes(System.Data.DataTable table, bool isColumn = false)
        {
            string txt= TxtHelper.ToTextContent(table, isColumn);
            return Encoding.Default.GetBytes(txt);
        }

        public System.Data.DataTable GetData(System.IO.Stream stream, string[] columnNames = null, bool isFirstColumn = false)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            string txt=Encoding.Default.GetString(bytes);
            return TxtHelper.ToDataTable(txt, columnNames, isFirstColumn);
        }

        public System.Data.DataTable GetData(string fileName, string[] columnNames = null, bool isFirstColumn = false)
        {
            return TxtHelper.ParseDataTable(fileName, columnNames, isFirstColumn);
        }
    }
}
