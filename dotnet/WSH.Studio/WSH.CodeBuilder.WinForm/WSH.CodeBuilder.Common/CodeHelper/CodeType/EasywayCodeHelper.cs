using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.Common
{
    public class EasywayCodeHelper : CodeHelper
    {
        #region 知微公司编辑器
        public static string GetEasywayEditor(ColumnEntity col, bool isRequired)
        {
            StringBuilder sb = new StringBuilder();
            switch (col.EditorType)
            {
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBox:
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine:
                case WSH.CodeBuilder.DispatchServers.EditorType.SearchBox:
                    {
                        sb.Append("@Html.TextBoxFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.TextArea:
                case WSH.CodeBuilder.DispatchServers.EditorType.RichTextBox:
                    {
                        sb.Append("@Html.TextAreaFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.NumberBox:
                case WSH.CodeBuilder.DispatchServers.EditorType.IntBox:
                case WSH.CodeBuilder.DispatchServers.EditorType.UIntBox:
                    {
                        sb.Append("@Html.NumberBoxFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.DateBox:
                    {
                        sb.Append("@Html.DateBoxFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.CheckBox:
                    {
                        sb.Append("@Html.CheckBoxFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.ComboBox:
                    {
                        sb.Append("@Html.DropDownListFor(m => m." + col.Field + ", new { @class = \"textbox\" })");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.FileUpload:
                    {
                        sb.Append("@Html.Upload(\"upload" + col.Field + "\", new UploadOptions() {  UploadPath=\"FP/FPAdmin\"})");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.Template:
                    {
                        sb.Append("<div>自定义模板控件</div>");
                    }
                    break;
            }
            if (isRequired && col.Required)
            {
                sb.Append("\n				<span class=\"required\">*</span>");
            }
            return sb.ToString();

        }
        #endregion
    }
}
