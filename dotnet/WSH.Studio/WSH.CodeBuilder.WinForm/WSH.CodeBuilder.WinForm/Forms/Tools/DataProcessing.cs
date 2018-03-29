using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Helper;
using WSH.Windows.Common;
using WSH.WinForm.Common;
using WSH.CodeBuilder.Common;
using WSH.TransferData.Common;
using System.IO;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class DataProcessing : Form
    {
        public string TableName;
        public DataProcessing()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.selectDialogImport.Filter = "文件(*.xls;*.xlsx;*.txt)|*.xls;*.xlsx;*.txt";
        }

        private void DataProcessing_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TableName))
            {
                this.filterData1.TableName = TableName;
                this.txtTableName.Text = TableName;
                string projectid = Global.GetCurrentProjectID();
                TableEntity table = ServiceHelper.GetCodeBuilderService().GetTableByName(projectid,TableName);
                this.filterData1.SortName = string.IsNullOrEmpty(table.DefaultSortName) ? table.DataKey : table.DefaultSortName;
                this.filterData1.SortMode = StringHelper.ToEnum<WSH.Common.SortMode>(table.DefaultSortMode.ToString());
                this.filterData1.CreateSql();
            }
            
        }
        private void ExportFile(TransferFileType type,DataTable dt=null)
        {
            if (dt == null)
            {
                 dt = this.filterData1.GetDataSource();
            }
            if (dt != null)
            {
                string savePath = Dialog.GetSaveFile(TableName + TransferDataFactory.GetFileExtension(type));
                if (!string.IsNullOrEmpty(savePath))
                {
                    ITransferData transfer = TransferDataFactory.GetTransferData(type);
                    byte[] bytes = transfer.GetBytes(dt, true);
                    FileHelper.WriteFile(savePath, bytes);
                    if (MsgBox.Confirm("导出完毕，是否打开文件？"))
                    {
                        FileHelper.OpenFile(savePath);
                    }
                }
            }
        }
        //导出txt
        private void btnExportTxt_Click(object sender, EventArgs e)
        {
            ExportFile(TransferFileType.Txt);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportFile(TransferFileType.Xls);
        }

        private void btnExportSql_Click(object sender, EventArgs e)
        {
            ConnectionEntity conn = Global.GetProjectConnection();
            DbModelData model = DbModelDataFactory.GetDbModelData(conn.ConnectionType.ToString(), conn.ConnectionString);
            string script = model.CreateInsertScript(this.filterData1.GetDataSource(),this.filterData1.IsDataKey);
            if (!string.IsNullOrEmpty(script))
            {
                string savePath = Dialog.GetSaveFile("insert-"+TableName + ".sql");
                if (!string.IsNullOrEmpty(savePath))
                {
                    FileHelper.WriteFile(savePath, script);
                    if (MsgBox.Confirm("导出完毕，是否打开文件？"))
                    {
                        FileHelper.OpenFile(savePath);
                    }
                }
            }
        }
        //加载数据
        private void btnLoadImport_Click(object sender, EventArgs e)
        {
            this.gridImport.AutoGenerateColumns = true;
            this.gridImport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            string fileName = this.selectDialogImport.Text;
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                ITransferData trans = TransferDataFactory.GetTransferData(fileName);
                DataTable dt = trans.GetData(fileName, null, true);
                dt.TableName = Path.GetFileNameWithoutExtension(fileName);
                this.gridImport.DataSource = dt;
            }
        }
        //导入数据
        private void btnImport_Click(object sender, EventArgs e)
        {
            DataTable dt = this.gridImport.DataSource as DataTable;
            if(dt!=null){
                this.btnImport.Enabled = false;
                try
                {
                    ConnectionEntity conn = Global.GetProjectConnection();
                    DbModelData model = DbModelDataFactory.GetDbModelData(conn.ConnectionType.ToString(), conn.ConnectionString);
                    bool import = model.ImportData(dt,this.checkIsDataKey.Checked);
                    MsgBox.Alert(string.Format("导入数据成功，共导入{0}条数据", dt.Rows.Count));
                    this.Close();
                }
                catch (Exception ex) {
                    this.btnImport.Enabled = true;
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("导入数据失败，错误信息：");
                    sb.AppendLine(ex.Message);
                    Utils.ShowErrorDialog(sb.ToString()+" ");
                }
            }
        }
 
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            ExporTemplate( TransferFileType.Xls);
        }

        private void btnTxtTemplate_Click(object sender, EventArgs e)
        {
            ExporTemplate(TransferFileType.Txt);
        }
        private void ExporTemplate(TransferFileType type) {
            DataTable dt = this.filterData1.GetDataSource();
            dt.Clear();
            this.ExportFile(type, dt);
        }
       
    }
}
