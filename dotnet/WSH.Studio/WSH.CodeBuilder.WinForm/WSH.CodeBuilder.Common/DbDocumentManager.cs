using System;
using System.Collections.Generic;
using System.Text;
using WSH.Options.Common;

using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;
using Docx = Novacode;
using System.Reflection;
using System.Data;


namespace WSH.CodeBuilder.WinForm
{
    public enum DbDocumentType
    {
        Html,
        Word
    }
    public class DbDocumentManager
    {
        private bool allowRequired = true;
        /// <summary>
        /// 是否显示为空列
        /// </summary>
        public bool AllowRequired
        {
            get { return allowRequired; }
            set { allowRequired = value; }
        }
        public WSH.CodeBuilder.DispatchServers.ProjectEntity Project;
        public List<WSH.CodeBuilder.DispatchServers.TableEntity> Tables;
        private CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        public string ExportPath;
        /// <summary>
        /// 文档类型
        /// </summary>
        public DbDocumentType Type;
        public string FileName
        {
            get
            {
                string ext = "." + Type.ToString().ToLower();
                if (Type == DbDocumentType.Word)
                {
                    ext = ".docx";
                }
                return System.IO.Path.Combine(ExportPath, DocumentName + ext);
            }
        }
        private string DocumentName
        {
            get
            {

                return Project.ProjectName + "_数据库文档";
            }
        }
        public event ProgressHandler OnProgress;
        private static string colName1 = "字段名";
        private static string colName2 = "描述";
        private static string colName3 = "数据类型";
        private static string colName4 = "是否必填";
        private static string requiredKey = "Required";
        private static Dictionary<string, string> exportColumns = new Dictionary<string, string>() { 
            {"Field",colName1},
            {"Display",colName2},
            {"DataType",colName3},
            {requiredKey,colName4}
        };
        public Dictionary<string, string> Columns
        {
            get
            {
                string key = requiredKey;
                if (!AllowRequired && exportColumns.ContainsKey(key))
                {
                    exportColumns.Remove(key);
                }
                return exportColumns;
            }
        }
        #region 导出Html
        private void ExportHtml()
        {
            #region 导出Html
            string outputText = string.Empty;
            StringBuilder nav = new StringBuilder();
            StringBuilder txt = new StringBuilder();
            int j = 0;
            foreach (WSH.CodeBuilder.DispatchServers.TableEntity table in Tables)
            {
                //if (isAllTable != true && table.Enable == false) { continue; }
                j++;
                string name = table.TableName + j;
                string enable = !table.Enabled ? "enable " : "";
                //拼接nav
                nav.AppendLine("<a href=\"#" + name + "\" title=\"" + table.Attr + "\" class=\"" + enable + "\">" + table.TableName + "</a>");
                //拼接内容
                txt.AppendLine("<a hidefocus=\"true\" class=\"tabTitle " + enable + "\" href=\"javascript:void(0)\" name=\"" + name + "\"><span>" + table.TableName + "</span>(" + table.Attr + ")</a>");
                txt.AppendLine("<table class=\"tab " + enable + "\" cellpadding=\"0\" cellspacing=\"0\">");
                //生成列集合
                WSH.CodeBuilder.DispatchServers.ColumnEntity[] columns = service.GetColumnList(table.ID.ToString());
                txt.AppendLine("                <tr>");
                txt.AppendLine("                    <th>" + colName1 + "</th>");
                txt.AppendLine("                    <th>" + colName2 + "</th>");
                txt.AppendLine("                    <th>" + colName3 + "</th>");
                if (AllowRequired == true)
                {
                    txt.AppendLine("                    <th>" + colName4 + "</th>");
                }
                txt.AppendLine("                </tr>");
                int i = 0;
                foreach (WSH.CodeBuilder.DispatchServers.ColumnEntity column in columns)
                {
                    // if (isAllField != true && column.Enable == false) { continue; }
                    string oddClass = i % 2 == 0 ? "" : "odd ";
                    string enableClass = !column.Enabled ? "enable " : "";
                    txt.AppendLine("                <tr class=\"" + oddClass + enableClass + "\">");
                    txt.AppendLine("                    <td>" + column.Field + "</td>");
                    txt.AppendLine("                    <td>" + column.Display + "</td>");
                    txt.AppendLine("                    <td>" + column.DataType + "</td>");
                    if (AllowRequired == true)
                    {
                        string required = column.Required ? " checked=\"true\"" : "";
                        txt.AppendLine("                    <td><input disabled=\"true\" type=\"checkbox\"" + required + "/></td>");
                    }
                    txt.AppendLine("                </tr>");
                    i++;
                }
                txt.AppendLine("</table>");
                if (OnProgress != null)
                {
                    OnProgress(this, new ProgressEventArgs() { Max = Tables.Count, Value = j });
                }
            }
            #region 拼接Html内容
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.AppendLine("<head>");
            sb.AppendLine("    <title>" + DocumentName + "</title>");
            sb.AppendLine("    <style type=\"text/css\">");
            sb.AppendLine("        html,body{ height:100%; overflow-y:hidden; overflow-x:auto;}");
            sb.AppendLine("        body{ background:#DFE8F6; text-align:center; margin:0px; font-family:Arial,宋体; font-size:12px;}");
            sb.AppendLine("        .border{ border:1px solid #99BBE8;}");
            sb.AppendLine("        .bg{ background:#DFE8F6;}");
            sb.AppendLine("        .wrap{ height:80%; margin:0px auto; text-align:left; width:1000px; margin-top:10px;}");
            sb.AppendLine("        .nav{ height:100%; width:200px; float:left; background:#fff; overflow:auto; font-size:13px;}");
            sb.AppendLine("        .content{float:left; height:100%; background:#fff; margin-left:10px; width:786px; overflow:auto; text-align:center;}");
            sb.AppendLine("        a{ text-decoration:none; color:#000; font-weight:bold;}");
            sb.AppendLine("        a:hover{ color:Red; }");
            sb.AppendLine("        .nav a{ display:block; height:20px; line-height:20px; padding:0px 2px;}");
            sb.AppendLine("        .nav a:hover{ background:#eee; }");
            sb.AppendLine("        .tabTitle{padding:10px 0px; display:block; outline:none;}");
            sb.AppendLine("        .tabTitle span{  font-size:16px; font-weight:bold; margin-right:8px;}");
            sb.AppendLine("        .tab{ width:92%;  margin:0px auto;border-collapse:collapse; }");
            sb.AppendLine("        .tab th,.tab td{ border:1px solid #A3BAE9; text-align:center;}");
            sb.AppendLine("        .tab th{ background:#DEECFD; color:#333; font-weight:normal; font-size:13px; height:22px;}");
            sb.AppendLine("        .tab td{ height:20px;}");
            sb.AppendLine("        .tab tr.odd{ background:#F7F7F7;}");
            sb.AppendLine("        .tab tr.enable,.enable{text-decoration:line-through;}");
            sb.AppendLine("    </style>");
            sb.AppendLine("    <script type=\"text/javascript\">");
            sb.AppendLine("        ; (function () {");
            sb.AppendLine("            window.j = function (el) {");
            sb.AppendLine("                return typeof el == \"string\" ? document.getElementById(el) : el;");
            sb.AppendLine("            };");
            sb.AppendLine("            j.getClient = function () {");
            sb.AppendLine("                return { width: document.documentElement.clientWidth, height: document.documentElement.clientHeight };");
            sb.AppendLine("            }");
            sb.AppendLine("            j.setHeight=function(){");
            sb.AppendLine("                var client = j.getClient();");
            sb.AppendLine("                var wrap = j(\"wrap\").style.height = client.height -2- 20+\"px\";");
            sb.AppendLine("            }");
            sb.AppendLine("        })();");
            sb.AppendLine("        window.onresize=j.setHeight;");
            sb.AppendLine("        window.onload = function () {");
            sb.AppendLine("            j.setHeight();");
            sb.AppendLine("");
            sb.AppendLine("        };");
            sb.AppendLine("    </script>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("    <div class=\"wrap\" id=\"wrap\">");
            sb.AppendLine("        <div class=\"nav border\">");
            //生成表名导航
            sb.Append(nav.ToString());
            sb.AppendLine("        </div>");
            sb.AppendLine("        <div class=\"content border\">");
            //生成表内容
            sb.Append(txt.ToString());
            sb.AppendLine("        </div>");
            sb.AppendLine("    </div>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            #endregion
            outputText = sb.ToString();
            #endregion
            FileHelper.WriteFile(FileName, outputText);
        }
        #endregion

        #region 导出Word
        private void ExportWord()
        {
            if (Tables != null)
            {
                var columns = Columns;
                using (Docx.DocX doc = Docx.DocX.Create(FileName))
                {
                    //表格的边框样式
                    Docx.Border border = new Docx.Border();
                    border.Tcbs = Docx.BorderStyle.Tcbs_single;
                    int n = 0;
                    foreach (TableEntity tableEntity in Tables)
                    {
                        string tableId = tableEntity.ID.ToString();
                        //插入表名
                        Docx.Paragraph title = doc.InsertParagraph();
                        title.Append(tableEntity.TableName+"("+tableEntity.Attr+")");
                        title.Alignment = Docx.Alignment.center;
                        title.FontSize(15);
                        title.Bold();
                        title.SetLineSpacing(Docx.LineSpacingType.After, 1);
                        title.SetLineSpacing(Docx.LineSpacingType.Before, 1);
                        DataTable fields = service.GetColumnDataTable(tableId);
                        int rowCount = (fields == null ? 0 : fields.Rows.Count) + 1;
                        //计算表格多少行，多少列
                        Docx.Table table = doc.InsertTable(rowCount, columns.Count);
                        //先生成列头
                        Docx.Row colRow = table.Rows[0];
                        int k = 0;
                        foreach (string colKey in columns.Keys)
                        {
                            Docx.Cell colCell = colRow.Cells[k];
                            colCell.Paragraphs[0].Append(columns[colKey]).Alignment = Docx.Alignment.center;
                            colCell.SetBorder(Docx.TableCellBorderType.Top, border);
                            colCell.SetBorder(Docx.TableCellBorderType.Bottom, border);
                            colCell.SetBorder(Docx.TableCellBorderType.Left, border);
                            colCell.SetBorder(Docx.TableCellBorderType.Right, border);
                            k++;
                        }
                        for (int i = 0; i < fields.Rows.Count; i++)
                        {
                            //一个属性为一行
                            Docx.Row row = table.Rows[i+1];
                            //循环每列
                            int j = 0;
                            foreach (string key in columns.Keys)
                            {
                                Docx.Cell cell = row.Cells[j];
                                string text = fields.Rows[i][key].ToString();
                                if(key== requiredKey){
                                    text = text.ToLower() == "true" ? "是" : "";
                                }
                                cell.Paragraphs[0].Append(text).Alignment = Docx.Alignment.center;
                                cell.Paragraphs[0].FontSize(10);
                                cell.SetBorder(Docx.TableCellBorderType.Top, border);
                                cell.SetBorder(Docx.TableCellBorderType.Bottom, border);
                                cell.SetBorder(Docx.TableCellBorderType.Left, border);
                                cell.SetBorder(Docx.TableCellBorderType.Right, border);
                                j++;
                            }
                        }
                        n++;
                        if (OnProgress != null)
                        {
                            OnProgress(this, new ProgressEventArgs() { Max = Tables.Count, Value = n });
                        }
                    }
                    doc.Save();
                }
            }
        }
        #endregion

        public void Export()
        {
            
            switch (Type)
            {
               
                case DbDocumentType.Html: ExportHtml();
                    break;
                case DbDocumentType.Word: ExportWord();
                    break;
            }
        }
    }
}
