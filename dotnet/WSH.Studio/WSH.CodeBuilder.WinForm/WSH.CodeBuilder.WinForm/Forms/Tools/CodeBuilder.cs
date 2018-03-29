using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.CodeBuilder.Common;
using WSH.CodeBuilder.WinForm.Common;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class CodeBuilder : Form
    {
        public CodeBuilder()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormClosing += new FormClosingEventHandler(CodeBuilder_FormClosing);
            this.template.IsShowCheckBox = true;
        }

        void CodeBuilder_FormClosing(object sender, FormClosingEventArgs e)
        {
            string path = this.selectDialog.Text;
            if (!string.IsNullOrEmpty(path))
            {
                ConfigurationState state = new ConfigurationState();
                state.Set("CodeBuilderPath",path);
            }
        }
        public string TableID;
        private void CodeBuilder_Load(object sender, EventArgs e)
        {
            this.tables.DataBind(TableID);
            ProjectEntity project = Global.GetCurrentProject();
            this.template.TemplateID = project.TemplateID;
            this.template.DataBind();
            ConfigurationState state = new ConfigurationState();
            this.selectDialog.Text = state.Get("CodeBuilderPath");
        }
        //生成代码
        private void btnCreate_Click(object sender, EventArgs e)
        {
            string path=selectDialog.Text;
            if(string.IsNullOrEmpty(path)){
                MsgBox.Alert("请选择导出地址");return;
            }
            //选中的表集合
            List<string> tableList = this.tables.GetCheckedTables();
            if (tableList.Count <= 0)
            {
                MsgBox.Alert("请至少选择表进行操作"); return;
            }
            //选中的模板
            List<TemplateEntity> templateList = this.template.GetCheckedFile();
            if (templateList.Count <= 0)
            {
                MsgBox.Alert("请至少选择代码模板进行操作"); return;
            }
            this.btnCreate.Enabled = false;
            this.btnCreate.Text = "生成中...";
            Application.DoEvents();
            CodeBuilderManager builder = new CodeBuilderManager() { 
                 Project=Global.GetCurrentProject(),
                 User=Global.User
            };
            this.progressBar.Value = 0;
            this.progressBar.Maximum = tableList.Count * templateList.Count;
            builder.OnProgress += new Options.Common.ProgressHandler(builder_OnProgress);
            List<string> files= builder.ExportByTables(tableList, templateList, path);
            this.btnCreate.Enabled = true;
            this.btnCreate.Text = "生成代码";
            if (builder.Error.Length > 0)
            {
                Utils.ShowErrorDialog(builder.Error.ToString());
            }
            else {
                string firstFileName="";
                if (files.Count>0)
                {
                    firstFileName=files[0];
                }
                if(MsgBox.Confirm("导出完毕，是否打开目录")){
                    FileHelper.OpenPath(path, firstFileName);
                }
            }
        }

        void builder_OnProgress(object sender, Options.Common.ProgressEventArgs e)
        {
            this.progressBar.Value++;
            Application.DoEvents();
        }
    }
}
