using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.Common
{
    public class CodeColumnType
    {
        #region 获取song.grid的列配置
        public static string GetSongColumn(ColumnEntity col)
        {
            StringBuilder sb = new StringBuilder();
            int width = col.Width <= 0 ? 100 : col.Width;
            sb.Append("{");
            sb.Append("field:\"" + col.Field + "\",header:\"" + col.Display + "\",");
            sb.Append("align:\"" + col.Align.ToString().ToLower() + "\",width:" + width + "");
            if (!col.Sortable)
            {
                sb.Append(",sortable:false");
            }
            if (!string.IsNullOrEmpty(col.FormatString))
            {
                sb.Append(",render:song.option.render.format(\"" + col.FormatString + "\")");
            }
            DataType dataType = DataTypeManager.Parse(col.DataType);
            if (dataType== DataType.Boolean)
            {
                sb.Append(",render:song.option.render.yesno");
            }
            sb.Append("}");
            return sb.ToString();
        }
        #endregion

        #region 读取EasyUI的表格列配置
        public static string GetEasyUIColumn(ColumnEntity col)
        {
            StringBuilder sb = new StringBuilder();
            int width = col.Width <= 0 ? 100 : col.Width;
            sb.Append("{");
            sb.Append("field:\"" + col.Field + "\",title:\"" + col.Display + "\",");
            sb.Append("align:\"" + col.Align.ToString().ToLower() + "\",width:" + width + "");
            if (!col.Sortable)
            {
                sb.Append(",sortable:false");
            }
            if (!string.IsNullOrEmpty(col.FormatString))
            {
                sb.Append(",formatter:song.column.render.format(\"" + col.FormatString + "\")");
            }
            DataType dataType = DataTypeManager.Parse(col.DataType);
            if (dataType == DataType.Boolean)
            {
                sb.Append(",formatter:song.column.render.yesno");
            }
            sb.Append("}");
            return sb.ToString();
        }
        #endregion

        #region 读取Asp.Net的表格列配置
        public static string GetAspNetColumn(ColumnEntity col)
        {
            StringBuilder sb = new StringBuilder();
            string width = col.Width > 0 ? "HeaderStyle-Width=\"" + col.Width + "\"" : "";
            sb.AppendFormat("<asp:BoundField DataField=\"{0}\" HeaderText=\"{1}\" {2}/>", col.Field, col.Display, width);
            return sb.ToString();
        }
        #endregion
    }
}
