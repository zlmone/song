using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Helper;

namespace WSH.CodeBuilder.Common
{
   public  class SongCodeHelper : CodeHelper
    {
       #region 生成表格列配置
       public static string GetGridColumn(IList<ColumnEntity> columns, ControlType controlType, int tabCount)
       {
           string tab = CodeUtils.GetTab(tabCount);
           IList<ColumnEntity> list = FilterColumns(columns, false);
           StringBuilder sb = new StringBuilder();
           for (int i = 0; i < list.Count; i++)
           {
               string last = StringHelper.GetLast(list.Count, i);
               sb.AppendLine(tab + GetColumnByType(list[i], controlType) + last);
           }
           return StringHelper.DeleteEnd(sb.ToString(), CodeUtils.Line);
       }
       #endregion

       #region 生成保存或者绑定的列
       public static string GetSaveBindData(IList<ColumnEntity> columns, string type, int tabCount)
       {
           string tab = CodeUtils.GetTab(tabCount);
           StringBuilder sb = new StringBuilder();
           IList<ColumnEntity> list = FilterColumns(columns, false);
           foreach (ColumnEntity col in list)
           {
               string line = string.Empty;
               string attr = "Text";
               DataType dataType = DataTypeManager.Parse(col.DataType);
               if (dataType == DataType.Boolean)
               {
                   attr = "Checked";
               }
               if (type == "save")
               {
                   if (dataType != DataType.Boolean)
                   {
                       attr += ".Trim()";
                   }
                   line = string.Format("entity.{0}=this.cmp{1}.{2};", col.Field, col.Field, attr);
               }
               else
               {
                   line = string.Format("this.cmp{0}.{1}=entity.{2};", col.Field, attr, col.Field);
               }
               sb.AppendLine(tab + line);
           }
           return StringHelper.DeleteEnd(sb.ToString(), CodeUtils.Line);
       }
       #endregion

       #region 获取表单行
       public static string GetFormRow(IList<ColumnEntity> columns, int column, ControlType controlType, int tabCount, bool isQuery)
       {
           IList<ColumnEntity> list = FilterColumns(columns, isQuery);
           string rowTab = CodeUtils.GetTab(tabCount);
           StringBuilder sb = new StringBuilder();
           int columnIndex = -1;
           int count = list.Count;
           int rows = CodeUtils.GetRowCount(count, column);
           for (int i = 0; i < rows; i++)
           {
               sb.AppendLine(rowTab + "<tr>");
               for (int j = 0; j < column; j++)
               {
                   columnIndex++;
                   string colTab = CodeUtils.Tab + rowTab;
                   if (columnIndex >= count)
                   {    
                       sb.AppendLine(colTab + "<th>&nbsp;</th>");
                       sb.AppendLine(colTab + "<td>&nbsp;</td>");
                   }
                   else
                   {
                       ColumnEntity entity = list[columnIndex];
                       string required = "";
                       if (!isQuery && entity.Required)
                       {
                           required = "<span class=\"required\">*</span>";
                       }
                       sb.AppendLine(colTab + "<th>" + required + entity.Display + ":</th>");
                       string control = string.Empty;
                       if (isQuery && entity.EditorType == WSH.CodeBuilder.DispatchServers.EditorType.DateBox)
                       {
                           //处理查询的日期控件
                           string field = entity.Field;
                           entity.Field = field + "Begin";
                           control += GetControlByType(entity, controlType, isQuery);
                           entity.Field = field + "End";
                           control += "至" + GetControlByType(entity, controlType, isQuery);
                       }
                       else
                       {
                           control = GetControlByType(entity, controlType, isQuery);
                       }
                       sb.AppendLine(colTab + "<td>" + control + "</td>");
                   }
               }
               sb.AppendLine(rowTab + "</tr>");
           }
           return StringHelper.DeleteEnd(sb.ToString(), CodeUtils.Line);
       }
       #endregion

       #region 生成查询条件
       public static string GetQueryItem(IList<ColumnEntity> columns, int tabCount)
       {
           string tab = CodeUtils.GetTab(tabCount);
           IList<ColumnEntity> list = FilterColumns(columns, true);
           StringBuilder sb = new StringBuilder();
           foreach (var item in list)
           {
               string upperName = StringHelper.Capitalize(item.Field);
               DataType dataType = DataTypeManager.Parse(item.DataType);
               if (dataType == DataType.String)
               {
                   sb.AppendLine(tab + "if (!string.IsNullOrEmpty(entity." + upperName + "))");
                   sb.AppendLine(tab + "{");
                   sb.AppendLine(tab + CodeUtils.Tab + "query = query.Where(o => o." + upperName + ".Contains(entity." + upperName + "));");
                   sb.AppendLine(tab + "}");
               }
               else
               {
                   sb.AppendLine(tab + "if (entity." + upperName + ".HasValue)");
                   sb.AppendLine(tab + "{");
                   sb.AppendLine(tab + CodeUtils.Tab + "query = query.Where(o => o." + upperName + "==entity." + upperName + ".Value);");
                   sb.AppendLine(tab + "}");
               }

           }
           return StringHelper.DeleteEnd(sb.ToString(), CodeUtils.Line);
       }
       #endregion
    }
}
