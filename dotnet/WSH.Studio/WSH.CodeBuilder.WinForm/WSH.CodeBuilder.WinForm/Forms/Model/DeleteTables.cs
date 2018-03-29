using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.WinForm.Controls;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class DeleteTables : Form
    {
        private LoadMaskManager helper = new LoadMaskManager();
        public int SuccessCount = 0;
        public DeleteTables()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Utils.SetFormNoresize(this);
        }

        private void DeleteTables_Load(object sender, EventArgs e)
        {
            this.tables.DataBind(null);
        }

        private void buttonImage1_Click(object sender, EventArgs e)
        {
            var checkeds = this.tables.GetCheckedTables();
            if (checkeds.Count <= 0)
            {
                MsgBox.Alert("请勾选要删除的表！"); return;
            }
            if (MsgBox.Confirm("确定删除选中的表吗？"))
            {
                this.buttonImage1.Text = "删除中...";
                this.buttonImage1.Enabled = false;
                this.progressBar1.Style = ProgressBarStyle.Continuous;
                this.progressBar1.Maximum = checkeds.Count;
                this.progressBar1.Value = 0;
                this.backgroundWorker.WorkerReportsProgress = true;
                this.backgroundWorker.RunWorkerAsync(checkeds);
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var checkeds = e.Argument as List<string>;
            List<string> nonDelete = new List<string>();
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            int i = 0;
            foreach (var tableName in checkeds)
            {
                i++;
                backgroundWorker.ReportProgress(i);
                bool result = false;
                try
                {
                    TableEntity table = service.GetTableByName(Global.GetCurrentProjectID(), tableName);
                    if (table != null)
                    {
                        result = service.DeleteTable(table.ID.ToString());
                    }
                }
                catch (Exception ex)
                {
                    result = false;
                }
                if (!result)
                {
                    nonDelete.Add(tableName);
                }
                else
                {
                    SuccessCount++;
                }
            }
            if (nonDelete.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("删除失败的表如下：");
                sb.AppendLine(string.Join(",", nonDelete.ToArray()));
                Utils.ShowErrorDialog(sb.ToString());
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.SuccessCount > 0)
            {
                this.Close();
            }
            else {
                this.buttonImage1.Text = "批量删除";
                this.buttonImage1.Enabled = true;
            }
        }
    }
}
