using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.UserControls
{
    public partial class Tables : UserControl
    {
        public Tables()
        {
            InitializeComponent();
        }
        public void DataBind(string tableID) {
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            if (string.IsNullOrEmpty(tableID))
            {
                DataTable dt = service.GetTableDataTable(Global.GetCurrentProjectID());
                this.filterCheckList.DataBind(dt, "TableName");
            }
            else
            {
                TableEntity table = service.GetTableById(tableID);
                this.filterCheckList.AddItem(table.TableName, true);
            }
        }
        public void Clear() {
            this.filterCheckList.Clear();
        }
        public void AddItem(string tableName) {
            this.filterCheckList.AddItem(tableName,true);
        }
        public void AddItem(string tableName, bool isChecked) {
            this.filterCheckList.AddItem(tableName, isChecked);
        }
        public void DataBind(List<string> tables,bool isChecked) { 
            if(tables!=null){
                foreach (string tableName in tables)
                {
                    this.filterCheckList.AddItem(tableName, isChecked);
                }
            }
        }
        public List<string> GetCheckedTables() {
            return this.filterCheckList.GetChecked();
        }
    }
}
