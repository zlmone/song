using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.Common
{
    public class ModelReaderHelper
    {
        public static void SetDefault(ColumnEntity entity)
        {
            entity.Enabled = true;
            entity.Sortable = true;
            entity.Queryable = false;
            entity.Hidden = false;
            entity.Width = 0;
        }
        public static void SetColumnDataKey(ColumnEntity col)
        {
            col.IsDataKey = true;
            col.Hidden = true;
            col.Required = true;
        }
        public static void SetFormatString(ColumnEntity col, DataType dataType)
        {
            if (dataType == DataType.Currency)
            {
                col.FormatString = FormatHelper.Money;
            }
            if (dataType == DataType.DateTime)
            {
                col.FormatString = FormatHelper.DateTime;
            }
        }
        public static void SetAlign(ColumnEntity col, DataType dataType)
        {
            col.Align = DispatchServers.AlignType.Left;
            if (IsNumber(dataType))
            {
                col.Align = DispatchServers.AlignType.Right;
            }
        }
        public static void SetLength(ColumnEntity col, DataType dataType, int len, int p)
        {
            //只有string类型才读取长度
            if (dataType == DataType.String)
            {
                col.Length = len;
            }
            col.Precision = p > 0 ? p : len;
        }
        public static bool IsInt(DataType dataType)
        {
            if (dataType == DataType.Int || dataType == DataType.SmallInt || dataType == DataType.BigInt)
            {
                return true;
            }
            return false;
        }
        public static bool IsNumber(DataType dataType)
        {
            if (dataType == DataType.Int ||
                dataType == DataType.SmallInt ||
                dataType == DataType.BigInt ||
                dataType == DataType.Decimal ||
                dataType == DataType.Float ||
                dataType == DataType.Currency)
            {
                return true;
            }
            return false;
        }
        public static void SetColumnEditor(ColumnEntity col, DataType dataType)
        {
            col.EditorType = DispatchServers.EditorType.TextBox;
            if (dataType == DataType.String)
            {

                if (col.Precision > 200)
                {
                    col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine;
                }
                else
                {
                    col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.TextBox;
                }
            }
            if (IsNumber(dataType))
            {
                if (IsInt(dataType))
                {
                    col.EditorType = DispatchServers.EditorType.IntBox;
                }
                else
                {
                    col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.NumberBox;
                }
            }
            if (dataType == DataType.Boolean)
            {
                col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.CheckBox;
            }
            if (dataType == DataType.DateTime)
            {
                col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.DateBox;
            }
            if (dataType == DataType.Binary)
            {
                col.EditorType = WSH.CodeBuilder.DispatchServers.EditorType.FileUpload;
            }
            if (dataType == DataType.Xml)
            {
                col.EditorType = DispatchServers.EditorType.TextArea;
            }
            if (dataType == DataType.Byte)
            {
                col.EditorType = DispatchServers.EditorType.ComboBox;
            }
        }
    }
}
