using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Tools.Common;
using WSH.Windows.Common;
using WSH.Common;
using WSH.WinForm.Common;
using WSH.Common.Helper;
namespace WSH.Tools
{
    public partial class FrmObjectBuilder : BaseForm
    {
        string br = "\t";
        public FrmObjectBuilder()
        {
            InitializeComponent();
            this.cboEntityType.SelectedIndex = 0;
            this.cboBuilderMethod.SelectedIndex = 0;
            this.cboBuilderType.SelectedIndex = 0;
        }

        #region 自定义DataTable生成器
        private void btnDataTable_Click(object sender, EventArgs e)
        {
            string[] lines = this.txtDataTableLine.Lines;
            if (lines.Length >0 && txtDataTableLine.Text.Trim()!=string.Empty)
            {
                bool isExtend = this.checkIsExtend.Checked;
                bool isData = this.checkData.Checked;
                StringBuilder sb = new StringBuilder();
                try
                {
                    if (!isExtend)
                    {
                        sb.AppendLine("public DataTable GetDataTable(){");
                        sb.AppendLine(br + "DataTable dt=new DataTable();");
                        CreateColumnHeader(sb, lines, br, "dt");
                        CreateTestData(isData, lines, sb, br, "dt");
                        sb.AppendLine(br + "return dt;");
                        sb.AppendLine("}");
                    }
                    else { 
                        //如果是继承模式
                        sb.AppendLine("public class NewDataTable : DataTable{");
                        sb.AppendLine(br + "public NewDataTable(){");
                        CreateColumnHeader(sb, lines, br+br,"this");
                        CreateTestData(isData, lines, sb, br+br, "this");
                        sb.AppendLine(br + "}");
                        sb.Append(br+"public AddRow(");
                        for (int i = 0; i < lines.Length; i++)
                        {
                            if (lines[i].Trim() == string.Empty) { continue; }
                            FieldLine line = FieldLines.GetFieldLine(lines[i]);
                            sb.Append(line.DataType+" "+line.Field+",");
                        }
                        string sbString = sb.ToString();
                        if(sbString.EndsWith(",")){
                            sb.Remove(sb.Length-1,1);
                        }
                        sb.Append(")");
                        sb.AppendLine("{");
                        sb.AppendLine(br+br+"DataRow row=this.NewRow();");
                        foreach (string item in lines)
                        {
                            if (item.Trim() == string.Empty) { continue; }
                            FieldLine line = FieldLines.GetFieldLine(item);
                            sb.AppendLine(br+br+"row[\""+line.Field+"\"]="+line.Field+";");
                        }
                        sb.AppendLine(br+br+"this.Rows.Add(row);");
                        sb.AppendLine(br+"}");
                        sb.AppendLine("}");

                    }
                    this.txtCode.Text = sb.ToString();
                }
                catch (Exception ex) {
                    MsgBox.Alert(ex.Message);
                }
            }
        }
        public void CreateColumnHeader(StringBuilder sb,string[] lines,string br,string name) {
            foreach (string item in lines)
            {
                if (item.Trim() == string.Empty) { continue; }
                FieldLine line = FieldLines.GetFieldLine(item);
                sb.AppendLine(br + "DataColumn " + line.Field + " = new DataColumn(\"" + line.Field + "\", typeof(" + line.DataType + "));");
                sb.AppendLine(br + name+".Columns.Add(" + line.Field + ");");
            }
        }
        public void CreateTestData(bool isData,string[] lines,StringBuilder sb,string br,string name) {
            if (isData)
            {
                int dataLine = Convert.ToInt32(this.txtDataLine.Text);
                sb.AppendLine(br + "for(int i=1;i<=" + dataLine + ";i++){");
                sb.AppendLine(br + br + "DataRow row="+name+".NewRow();");
                foreach (string item in lines)
                {
                    if (item.Trim() == string.Empty) { continue; }
                    FieldLine line = FieldLines.GetFieldLine(item);
                    string value = "\"" + line.Field + "\""+"+i.ToString()";
                    if (line.DataType == "int" || line.DataType == "double" || line.DataType == "decimal" || line.DataType == "float")
                    {
                        value = "i";
                    }
                    else if (line.DataType == "bool")
                    {
                        value = "i%2==0 ? true : false";
                    }
                    sb.AppendLine(br + br + "row[\"" + line.Field + "\"]=" + value + ";");
                }
                sb.AppendLine(br +br+ name+".Rows.Add(row);");
                sb.AppendLine(br + "}");
            }
        }
        #endregion

        #region 导出复制
        private void copyCode_Click(object sender, EventArgs e)
        {
            string txt = this.txtCode.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                Clipboard.SetData(DataFormats.Text,txt);
            }
        }

        private void exportCode_Click(object sender, EventArgs e)
        {
            string text = this.txtCode.Text.Trim();
            if(text!=string.Empty){
                DialogResult result = this.saveFile.ShowDialog();
                if(result== System.Windows.Forms.DialogResult.OK){
                    string fileName = this.saveFile.FileName;
                    try
                    {
                        FileHelper.WriteFile(fileName, text);
                        if(MsgBox.Confirm("文件已经成功导出到——>\n\r"+fileName+"\n\r是否打开文件？")){
                            FileHelper.OpenFile(fileName);
                        }
                    }
                    catch (Exception ex) {
                        MsgBox.Alert("导出代码失败，"+ex.Message);
                    }
                }
            }
        }
        #endregion

        #region 生成实体
        private void btnEntity_Click(object sender, EventArgs e)
        {
            string[] lines = this.txtEntity.Lines;
            if (lines.Length>=0 && txtEntity.Text.Trim()!=string.Empty)
            {
                try
                {
                    string type = this.cboEntityType.Text;
                    StringBuilder sb = new StringBuilder();
                    foreach (string item in lines)
                    {
                        if (item.Trim() == string.Empty) { continue; }
                        FieldLine line = FieldLines.GetFieldLine(item);
                        string upper = StringHelper.Capitalize(line.Field.Replace("_", ""));
                        string lower = StringHelper.Capitalize(line.Field, CaseType.Lower);
                        string dataType = line.DataType;
                        if (type == "framework2")
                        {
                            sb.AppendLine("private " + dataType + " " + lower + ";");
                            CreateNote(sb, upper);
                            sb.AppendLine("public " + dataType + " " + upper);
                            sb.AppendLine("{");
                            sb.AppendLine(br + "get { return " + lower + "; }");
                            sb.AppendLine(br + "set { " + lower + " = value; }");
                            sb.AppendLine("}");
                        }
                        else
                        {
                            CreateNote(sb, upper);
                            sb.AppendLine("public " + dataType + " " + upper + "{ get; set; }");
                        }
                    }
                    this.txtCode.Text = sb.ToString();
                }
                catch (Exception ex) {
                    MsgBox.Alert(ex.Message);
                }
            }
        }
        public void CreateNote(StringBuilder sb, string upper) {
            bool note = this.checkNote.Checked;
            if (note)
            {
                sb.AppendLine("/// <summary>");
                sb.AppendLine("/// " + upper);
                sb.AppendLine("/// </summary>");
            }
            else {
                sb.AppendLine("");
            }
        }
        #endregion

        #region 字符串拼接
        private void btnStringBuilder_Click(object sender, EventArgs e)
        {
            string beginText = txtStringBuilder.Text;
            string[] txtLine=txtStringBuilder.Lines;
            try
            {
                if (!string.IsNullOrEmpty(beginText) && txtLine.Length > 0)
                {
                    string name = this.txtBuilderName.Text.Trim();
                    string method = this.cboBuilderMethod.Text;
                    string type = this.cboBuilderType.Text;
                    StringBuilder sb = new StringBuilder();
                    switch (type)
                    {
                        case "Net-StringBuilder":
                            {
                                sb.AppendLine("StringBuilder " + name + "=new StringBuilder();");
                            }; break;
                        case "Java-StringBuffer":
                            {
                                sb.AppendLine("StringBuffer " + name + "=new StringBuffer();");
                            }; break;
                        case "Js-song.builder":
                            {
                                sb.AppendLine("var " + name + "=new song.builder();");
                                method = method == "Append" ? "add" : "addLine";
                            }; break;
                        case "Js-Array":
                            {
                                sb.AppendLine("var " + name + "=[");
                                for (int i = 0; i < txtLine.Length; i++)
                                {
                                    string last = i == txtLine.Length - 1 ? "" : ",";
                                    string t = txtLine[i].Replace("\"", "\\\"");
                                    if (t.Trim() != string.Empty)
                                    {
                                        sb.AppendLine("\t\"" + t + "\"" + last);
                                    }
                                }
                                sb.Append("];");
                            }; break;
                    }
                    if (type != "Js-Array")
                    {
                        foreach (string item in txtLine)
                        {
                            string t = item.Replace("\"", "\\\"");
                            if (t.Trim() != string.Empty)
                            {
                                sb.AppendLine(name + "." + method + "(\"" + t + "\");");
                            }
                        }
                    }
                    this.txtCode.Text = sb.ToString();
                }
            }
            catch (Exception ex) {
                MsgBox.Alert(ex.Message);
            }
        }
        #endregion

        #region 大小写转换
        public string GetCapText() {
            return this.txtCap.Text.Trim();
        }
        public void SetCapText(string text) {
            this.txtCode.Text = text;
        }
        private void btnUpper_Click(object sender, EventArgs e)
        {
            SetCapText(GetCapText().ToUpper());
        }

        private void btnLower_Click(object sender, EventArgs e)
        {
            SetCapText(GetCapText().ToLower());
        }

        private void btnCapUpper_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in this.txtCap.Lines)
            {
                if (item.Trim() != string.Empty)
                {
                    sb.AppendLine(StringHelper.Capitalize(item));
                }
            }
            SetCapText(sb.ToString());
        }

        private void btnCapLower_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in this.txtCap.Lines)
            {
                if (item.Trim() != string.Empty)
                {
                    sb.AppendLine(StringHelper.Capitalize(item, CaseType.Lower));
                }
            }
            SetCapText(sb.ToString());
        }
        #endregion

    }
}
