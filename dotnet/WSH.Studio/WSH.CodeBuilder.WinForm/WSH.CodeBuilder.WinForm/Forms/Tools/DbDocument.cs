using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;
using System.Linq;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class DbDocument : Form
    {
        public DbDocument()
        {
            InitializeComponent();
        }
        ConfigurationState config = new ConfigurationState();
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        private void DbDocument_Load(object sender, EventArgs e)
        {
            this.cboType.DataSource = Enum.GetNames(typeof(DbDocumentType));
            this.selectPath.Text = config.Get("DbDocumentPath");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string path = this.selectPath.Text;
            if(string.IsNullOrEmpty(path)){
                MsgBox.Alert("请选择导出地址"); return;
            }
            //if (this.cboType.Text.ToLower()=="word")
            //{
            //    MsgBox.Alert("暂不支持word文档导出");
            //    return;
            //}
            bool checkRequired = this.checkRequired.Checked;
            ProjectEntity project = Global.GetCurrentProject();
            List<TableEntity> tables = service.GetTableList(Global.GetCurrentProjectID()).ToList();
            if(tables.Count<=1){
                MsgBox.Alert("当前项目没有表"); return;
            }
            DbDocumentManager doc = new DbDocumentManager()
            {
                AllowRequired = checkRequired,
                Project = project,
                Tables = tables,
                ExportPath=path,
                Type = StringHelper.ToEnum<DbDocumentType>(this.cboType.Text)
            };
            this.progress.Value = 0;
            this.progress.Maximum = tables.Count;
            doc.OnProgress += new Options.Common.ProgressHandler(doc_OnProgress);
            doc.Export();
            if(MsgBox.Confirm("导出完毕，是否打开文件？")){
                FileHelper.OpenFile(doc.FileName);
            }
        }

        void doc_OnProgress(object sender, Options.Common.ProgressEventArgs e)
        {
            this.progress.Value++;
            Application.DoEvents();
        }

        private void DbDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.Set("DbDocumentPath", this.selectPath.Text);
        }

        
    }
}
