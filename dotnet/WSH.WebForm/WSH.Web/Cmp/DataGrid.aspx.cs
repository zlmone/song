using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WSH.Web.Cmp
{
    public partial class DataGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                this.grid.DataSource = GetDataTable();
                this.grid.DataBind();
            
        }
        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn wang = new DataColumn("wang", typeof(int));
            dt.Columns.Add(wang);
            DataColumn song = new DataColumn("song", typeof(string));
            dt.Columns.Add(song);
            for (int i = 1; i <= 10; i++)
            {
                DataRow row = dt.NewRow();
                row["wang"] = i;
                row["song"] = "songi";
                dt.Rows.Add(row);
            }
            return dt;
        }

    }
}