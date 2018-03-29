using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;
using WeifenLuo.WinFormsUI.Docking;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;
using WSH.CodeBuilder.Common;
using WSH.Options.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ColumnEdit : DockContent
    {
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        ConfigurationData config = new ConfigurationData();
        public string TableID;
        public TableEntity Table;
        private DataTable ColumnsSource;
        public ColumnEdit()
        {
            InitializeComponent();
            this.colFormatString.DropDownWidth = 150;
        }

        private void ColumnEdit_Load(object sender, EventArgs e)
        {
            this.Table = service.GetTableById(this.TableID);

            colEditorType.DataSource = Enum.GetNames(typeof(WSH.Common.EditorType));

            colDataType.DataSource = Enum.GetNames(typeof(DataType));

            colAlign.DataSource = Enum.GetNames(typeof(WSH.Common.AlignType));

            IList<DataItem> items = config.Get("FormatString");
            items.Insert(0, new Options.Common.DataItem() { Text = "", Value = "" }); ;
            colFormatString.DataSource = items;
            colFormatString.DisplayMember = "Text";

            BindGrid();
        }
        public void BindGrid()
        {
            ColumnsSource = service.GetColumnDataTable(TableID);
            this.grid.DataSource = ColumnsSource;
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            string field = GetSelectedField();
            if (!string.IsNullOrEmpty(field))
            {
                Table.DefaultSortName = field;
                if (service.UpdateTable(Table))
                {
                    MsgBox.Alert("设置成功");
                }
                else
                {
                    MsgBox.Alert("设置失败");
                }
            }
        }

        private void btnDataKey_Click(object sender, EventArgs e)
        {
            string field = GetSelectedField();
            if (!string.IsNullOrEmpty(field))
            {
                Table.DataKey = field;
                if (service.UpdateTable(Table))
                {
                    MsgBox.Alert("设置成功");
                }
                else
                {
                    MsgBox.Alert("设置失败");
                }
            }
        }
        public string GetSelectedField()
        {
            if (this.grid.SelectedRows.Count <= 0 || this.grid.SelectedRows[0].IsNewRow)
            {
                MsgBox.Alert("请选择一条记录进行操作");
                return null;
            }

            return this.grid.SelectedRows[0].Cells["colField"].Value.ToString();
        }
        //判断数据是否发生改变
        public DataTable GetSourceChange()
        {
            DataTable changeTable = this.ColumnsSource.GetChanges();
            return changeTable;
        }
        public bool CheckSourceChange()
        {
            if (this.ColumnsSource != null)
            {
                DataTable changeTable = GetSourceChange();
                if (changeTable != null)
                {
                    DialogResult result = MsgBox.Question("当前数据已发生改变，是否保存？");
                    if (result == DialogResult.Yes)
                    {
                        //保存
                        if (!SaveSourceChange()) { return false; }
                    }
                    else if (result == DialogResult.Cancel) { return false; }
                }
            }
            return true;
        }
        //保存列表修改
        public bool SaveSourceChange()
        {
            DataTable changeTable = GetSourceChange();
            if (changeTable != null)
            {
                //添加TableID列
                foreach (DataRow row in changeTable.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        row["TableID"] = this.Table.ID;
                    }
                }
                try
                {
                    bool result = service.BatchUpdateColumn(changeTable, Table.ID.ToString());
                }
                catch (Exception ex)
                {
                    MsgBox.Alert("保存失败！" + ex.Message);
                    return false;
                }
                this.ColumnsSource.AcceptChanges();
                return true;
            }
            return false;
        }
        //保存
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSourceChange())
            {
                BindGrid();
                MsgBox.Alert("保存成功");
            }
        }

        private void ColumnEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CheckSourceChange())
            {
                e.Cancel = true;
            }
        }

    }
}
