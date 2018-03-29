using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Controls;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class UserList : BaseEditForm
    {
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        public DataTable DataSource;
        public UserList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.grid.AllowUserToDeleteRows = true;
            this.grid.AllowMenuDelete = true;
            this.grid.AllowMenuDeleteConfirm = true;
        }

        public override bool SaveData()
        {
            DataTable changes = GetSourceChange();
            if (changes != null)
            {
                foreach (DataRow row in DataSource.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        if (row["IsAdmin"] == null || row["IsAdmin"] == DBNull.Value)
                        {
                            row["IsAdmin"] = false;
                        }
                    }
                }
                return service.BatchUpdateUser(DataSource);
            }
            return true;
        }
        public DataTable GetSourceChange()
        {
            DataTable changeTable = this.DataSource.GetChanges();
            return changeTable;
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            DataSource = service.GetUserDataTable();
            this.grid.DataSource = DataSource;
        }
    }
}
