using System;
using System.Collections.Generic;
using System.Text;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common;
using WSH.Common.Extend;

namespace WSH.CodeBuilder.Common
{
    public class CodeControlType
    {
        #region 获取Html控件
        public static string GetHtmlEditor(ColumnEntity col)
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
            return sb.ToString();
        }
        #endregion

        #region 获取song服务器控件标记
        public static string GetSongControl(ColumnEntity col)
        {
            string field =  col.Field.capitalize();
            TagBuilder tag = new TagBuilder();
            TagReanderMode mode = TagReanderMode.SelfClosing;
            tag.AddAttribute("runat", "server");
            tag.AddAttribute("ID", "cmp" + field);
            if (col.Required)
            {
                tag.AddAttribute("Required", "true");
            }
            switch (col.EditorType)
            {
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBox:

                case WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine:
                    {
                        tag.TagName = "song:InputBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.TextArea:
                    {
                        tag.TagName = "song:InputBox";
                        tag.AddAttribute("TextMode", "MultiLine");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.RichTextBox:
                    {
                        tag.TagName = "song:HtmlEditor";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.NumberBox:
                    {
                        tag.TagName = "song:NumberBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.IntBox:
                    {
                        tag.TagName = "song:IntBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.UIntBox:
                    {
                        tag.TagName = "song:UIntBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.DateBox:
                    {
                        tag.TagName = "song:DateBox";
                        if (!string.IsNullOrEmpty(col.FormatString))
                        {
                            tag.AddAttribute("DateFmt", col.FormatString);
                        }
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.CheckBox:
                    {
                        tag.TagName = "song:CheckBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.ComboBox:
                    {
                        tag.TagName = "song:ComboBox";
                        mode = TagReanderMode.Normal;
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.SearchBox:
                    {
                        tag.TagName = "song:SearchBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.FileUpload:
                    {
                        tag.TagName = "song:FileUpload";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.Template:
                    {
                        tag.TagName = "song:Template";
                        mode = TagReanderMode.Normal;
                    }
                    break;
            }
            return tag.ToString(mode);
        }
        #endregion

        #region 获取EasyUI服务器控件标记
        public static string GetEasyUIControl(ColumnEntity col, bool isQuery)
        {
            string field = col.Field.capitalize();
            string queryField =(isQuery ? "query-" : "") + field;
            TagBuilder tag = new TagBuilder();
            tag.TagName = "input";
            TagReanderMode mode = TagReanderMode.SelfClosing;
            tag.AddAttribute("id", isQuery ? queryField : field);
            if (!isQuery)
            {
                tag.AddAttribute("name", queryField);
            }
            Dictionary<string, object> options = new Dictionary<string, object>();
            if (col.Required && !isQuery)
            {
                options.Add("required", true);
                options.Add("missingmessage",col.Display+"必填");
            }
            switch (col.EditorType)
            {
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBox:

                case WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", isQuery ? "textbox" : "easyui-validatebox textbox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.TextArea:
                    {
                        tag.TagName = "textarea";
                        tag.AddAttribute("class", isQuery ? "textbox" : "easyui-validatebox textbox");
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
                        tag.AddAttribute("class", "easyui-numberbox textbox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.IntBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-numberbox textbox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.UIntBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-numberbox textbox");
                    }
                    break; 
                case WSH.CodeBuilder.DispatchServers.EditorType.DateBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-datepicker textbox");
                        //if (!string.IsNullOrEmpty(col.FormatString))
                        //{
                        //    tag.AddAttribute("DateFmt", col.FormatString);
                        //}
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
                        tag.AddAttribute("class", "easyui-combobox combobox");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.SearchBox:
                    {
                        tag.AddAttribute("type", "text");
                        tag.AddAttribute("class", "easyui-searchbox textbox");
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
            string dataOptions = DictHelper.ToJsonItem(options);
            if (!string.IsNullOrEmpty(dataOptions))
            {
                tag.AddAttribute("data-options", dataOptions);
            }
            return tag.ToString(mode);
        }
        #endregion

        #region 获取Asp.Net服务器控件标记
        public static string GetAspNetControl(ColumnEntity col)
        {
            string field = col.Field.capitalize();
            TagBuilder tag = new TagBuilder();
            TagReanderMode mode = TagReanderMode.SelfClosing;
            tag.AddAttribute("runat", "server");
            tag.AddAttribute("ID", "cmp" + field);
            switch (col.EditorType)
            {
                case WSH.CodeBuilder.DispatchServers.EditorType.TextBox:

                case WSH.CodeBuilder.DispatchServers.EditorType.TextBoxLine:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.TextArea:
                    {
                        tag.TagName = "asp:TextBox";
                        tag.AddAttribute("TextMode", "MultiLine");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.RichTextBox:
                    {
                        tag.TagName = "asp:TextBox";
                        tag.AddAttribute("TextMode", "MultiLine");
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.NumberBox:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.IntBox:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.UIntBox:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.DateBox:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.CheckBox:
                    {
                        tag.TagName = "asp:CheckBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.ComboBox:
                    {
                        tag.TagName = "asp:DropDownList";
                        mode = TagReanderMode.Normal;
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.SearchBox:
                    {
                        tag.TagName = "asp:TextBox";
                    }
                    break;
                case WSH.CodeBuilder.DispatchServers.EditorType.FileUpload:
                    {
                        tag.TagName = "asp:FileUpload";
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

        #region 获取MVC控件
        public static string GetMvcControl(ColumnEntity col) {
            col.Field = col.Field.capitalize();
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
            return sb.ToString();
        }
        #endregion
    }
}
