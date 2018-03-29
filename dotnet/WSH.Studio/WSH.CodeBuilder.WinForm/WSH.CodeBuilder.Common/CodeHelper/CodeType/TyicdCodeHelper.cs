using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common;
using WSH.Common.Helper;

namespace WSH.CodeBuilder.Common
{
    public class TyicdCodeHelper : CodeHelper
    {
        /// <summary>
        /// 生成表单
        /// </summary>
        /// <param name="columns">列集合</param>
        /// <param name="column">每行生成多少个字段</param>
        /// <returns></returns>
        public static string GetFormItems(IList<ColumnEntity> columns, int column,int tabCount)
        {
            bool isQuery = false;
            StringBuilder sb = new StringBuilder();
            IList<ColumnEntity> list = FilterColumns(columns, isQuery);
            int lines = CodeUtils.GetLineCount(list.Count, column);
            int columnIndex = 0;
            string lineTab = CodeUtils.GetTab(tabCount), itemTab = CodeUtils.GetNextTab(lineTab), controlTab = CodeUtils.GetNextTab(itemTab);
            //循环生成表单
            for (int i = 0; i < lines; i++)
            {
                sb.AppendLine(lineTab+"<div class=\"line\">");
                //循环生成每一行的表单元素
                for (int j = 0; j < column; j++)
                {
                    if (columnIndex < list.Count)
                    {
                        ColumnEntity col = list[columnIndex];
                        sb.AppendLine(itemTab+"<div class=\"short\">");
                        sb.AppendLine(controlTab + "<label>" + (col.Required ? "<em>*</em>" : "") + ""+col.Display+"：</label>");
                        sb.AppendLine(controlTab + GetFormControl(col));
                        sb.AppendLine(itemTab + "</div>");
                        columnIndex++;
                    }
                }
                sb.AppendLine(lineTab+"</div>");
            }
            return sb.ToString();
        }
        #region
        public static string GetFormControl(ColumnEntity col)
        {
            string field = StringHelper.Capitalize(col.Field);
            TagBuilder tag = new TagBuilder();
            tag.TagName = "input";
            TagReanderMode mode = TagReanderMode.SelfClosing;
            tag.AddAttribute("id", field);
            tag.AddAttribute("name", field);
            if (col.Required)
            {
                tag.AddAttribute("required", "true");
                tag.AddAttribute("missingmessage", col.Display + "必填");
            }
            switch (col.EditorType)
            {
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBox:

                case WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-validatebox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.TextArea:
                    {
                        tag.TagName = "textarea";
                        tag.AddAttribute("class", "easyui-validatebox");
                        mode = TagReanderMode.Normal;
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.RichTextBox:
                    {
                        tag.TagName = "textarea";
                        mode = TagReanderMode.Normal;
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.NumberBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-numberbox");
                        if (StringHelper.ToEnum<DataType>(col.DataType)== DataType.Currency)
                        {
                            tag.AddAttribute("precision", "2"); 
                        }
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.IntBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-numberbox");
                        
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.UIntBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-numberbox");
                        tag.AddAttribute("min", "0");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.DateBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-datebox");
                        tag.AddAttribute("style","width:150px");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.CheckBox:
                    {
                        tag.AddAttribute("type", "checkbox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.ComboBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-combobox");
                        tag.AddAttribute("validtype", "combobox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.SearchBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-searchbox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.FileUpload:
                    {
                        tag.AddAttribute("type", "file");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.Template:
                    {
                        tag.TagName = "div";
                        mode = TagReanderMode.Normal;
                    }
                    break;
            }
            return tag.ToString(mode);
        }
        #endregion
    }
}
