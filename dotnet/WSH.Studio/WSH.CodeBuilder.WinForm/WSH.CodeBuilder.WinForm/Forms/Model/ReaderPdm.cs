using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Configuration;
using WSH.CodeBuilder.Common;
using WSH.Windows.Common;
using WSH.WinForm.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ReaderPdm : Form
    {
        public bool IsReload = false;
        public ReaderPdm()
        {
            InitializeComponent();
            Utils.SetFormNoresize(this);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.selectDialog1.Filter = FileFilter.Pdm;
        }
        //读取
        private void btnReader_Click(object sender, EventArgs e)
        {
            List<string> tableNames = this.tables1.GetCheckedTables();
            if(tableNames.Count<=0){
                MsgBox.Alert("请至少选择一个表！"); return;
            }
            this.btnReader.Enabled = false;
            this.btnReader.Text = "读取中...";
            Application.DoEvents();
            PowerDesignerModelReader reader = new PowerDesignerModelReader(Global.GetCurrentProject(), this.selectDialog1.Text);
            reader.FillTables(tableNames);
            IsReload = true;
            this.btnReader.Enabled = true;
            this.btnReader.Text = "读取";
            Application.DoEvents();
            if (reader.Error.Length > 0)
            {
                Utils.ShowErrorDialog(reader.Error.ToString());
            }
            else {
                this.Close();
            }
        }
        /// <summary>
        /// 加载pdm文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="url"></param>
        private void selectDialog1_OnSelectDialogOk(object sender, string url)
        {
            if(!string.IsNullOrEmpty(url))
            {
                ConfigurationState state = new ConfigurationState();
                state.Set(StateKeys.ReadPdmPath,url);

                BindTables(url);
            }
        }
        private void BindTables(string url) {
            if (!string.IsNullOrEmpty(url))
            {
                PowerDesignerModelReader reader = new PowerDesignerModelReader(Global.GetCurrentProject(), url);
                List<TableInfo> tables = reader.GetTableInfos();
                this.tables1.Clear();
                foreach (TableInfo table in tables)
                {
                    this.tables1.AddItem(table.TableName);
                }
            }
        }
        private void ReaderPdm_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            this.selectDialog1.Text= state.Get(StateKeys.ReadPdmPath);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            BindTables(this.selectDialog1.Text);
        }
    }
}
