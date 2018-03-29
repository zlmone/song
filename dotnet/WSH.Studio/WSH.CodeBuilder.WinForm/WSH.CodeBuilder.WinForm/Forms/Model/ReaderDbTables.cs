using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.Common;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Helper;
using WSH.WinForm.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ReaderDbTables : Form
    {
        public string TableName;
        public int SuccessCount = 0;
        public ReaderDbTables()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void btnReadTables_Click(object sender, EventArgs e)
        {
            var checks = this.tables.GetCheckedTables();
            if(checks.Count<=0){
                MsgBox.Alert("请选择表"); return;
            }
            this.btnReadTables.Text = "读取中...";
            this.btnReadTables.Enabled = false;
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.Maximum = checks.Count;
            this.progressBar.Value =0;
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.RunWorkerAsync(checks); 
        }

        private void ReaderDbTables_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TableName))
            {
                this.tables.AddItem(TableName);
            }
            else
            {
                ConnectionEntity connection = Global.GetProjectConnection();
                //绑定列表
                DbModelData modelData = DbModelDataFactory.GetDbModelData(connection.ConnectionType.ToString(), connection.ConnectionString);
                List<string> tableNames = modelData.GetNames(DbListType.UserTable);
                this.tables.DataBind(tableNames, true);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var checks = e.Argument as List<string>;
            ProjectEntity project = Global.GetCurrentProject();
            ConnectionEntity connection = Global.GetProjectConnection();
            DbModelReader modelReader = new DbModelReader(project, connection);
            int i = 0;
            foreach (string tableName in checks)
            {
                i++;
                this.backgroundWorker.ReportProgress(i);
                try
                {
                    var table = modelReader.FillTable(tableName);
                    if (table != null && table.ID > 0)
                    {
                        SuccessCount++;
                    }
                }
                catch (Exception ex) {
                    modelReader.Error.AppendLine("读取数据表—" + tableName + "出错！" + ex.Message);
                }
            }
            if (modelReader.Error.Length > 0)
            {
                Utils.ShowErrorDialog(modelReader.Error.ToString());
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar.Value = e.ProgressPercentage;
            Application.DoEvents();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.SuccessCount > 0)
            {
                this.Close();
            }
            else {
                this.btnReadTables.Text = "读取";
                this.btnReadTables.Enabled = true;
            }
        }
    }
}
