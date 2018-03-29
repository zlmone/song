using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using WSH.WinForm.Controls;
using WSH.WinForm.Common;
using WSH.Options.Common;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ConnectionEdit : BaseEditForm
    {
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        public ConnectionEdit()
        {
            InitializeComponent();
        }
        public bool IsSelect=false;
        public DataTable DataSource;
        public string ConnectionName;
        private void ConnectionEdit_Load(object sender, EventArgs e)
        {
            this.colConnectionType.DataSource = Enum.GetNames(typeof(WSH.CodeBuilder.DispatchServers.DataBaseType));
            if(IsSelect){
                this.grid.AllowUserToAddRows = false;
                this.grid.AllowUserToDeleteRows = false;
                this.grid.AllowMenuDelete = false;
                this.grid.ReadOnly = true;
            }
            DataSource = service.GetConnectionDataTable();
            this.grid.DataSource = DataSource;
            if(!string.IsNullOrEmpty(this.RecordID)){
                foreach (DataGridViewRow row in this.grid.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataRowView rowView = (DataRowView)(row.DataBoundItem);
                        if (ConvertHelper.AsEmpty(rowView["ID"]) == this.RecordID)
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                }
            }
        }
        public override bool IsValid()
        {
            bool result = true;
            if(IsSelect){
                if (this.grid.SelectedRows.Count > 0)
                {
                    if (this.grid.SelectedRows[0].IsNewRow)
                    {
                        result = false;
                    }
                }
                else {
                    result = false;
                }
            }
            if(!result){
                MsgBox.Alert("请选择一条记录");
            }
            return result;
        }
        public override bool SaveData()
        {
            if (IsSelect)
            {
                DataRowView row=(DataRowView)(this.grid.SelectedRows[0].DataBoundItem);
                this.RecordID = row["ID"].ToString();
                this.ConnectionName = ConvertHelper.AsEmpty(row["ConnectionName"]);
                return true;
            }
            else {
                return service.BatchUpdateConnection(DataSource);
            }
        }
        //测试连接
        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex==3 && e.RowIndex>-1){
                DataGridViewCellCollection cells= this.grid.Rows[e.RowIndex].Cells;
                string str = ConvertHelper.AsEmpty(cells["colConnectionString"].Value);
                string dbType = ConvertHelper.AsEmpty(cells["colConnectionType"].Value);
                if (!string.IsNullOrEmpty(str) && !string.IsNullOrEmpty(dbType))
                {
                    DbConnectionOptions option = new DbConnectionOptions()
                    {
                        ConnectionString = str
                    };
                    Result r = DataBaseHelper.Test(DataBaseHelper.GetDbType(dbType), option);
                    MsgBox.Alert(r.Msg);
                }
                else {
                    MsgBox.Alert("连接字符串或者数据库类型为空");
                }
            }
        }
    }
}
