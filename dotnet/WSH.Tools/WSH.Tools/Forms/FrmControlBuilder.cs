using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSH.Tools
{
    public partial class FrmControlBuilder : Form
    {
        public FrmControlBuilder()
        {
            InitializeComponent();
            this.cboType.SelectedIndex = 0;
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            DataGridViewRowCollection rows= this.gridColumn.Rows;
            
            string type = this.cboType.Text;
            string cls = (string.IsNullOrEmpty(this.txtCls.Text.Trim()) ? "grid" : this.txtCls.Text.Trim());
            string html = "";
            if(type=="Table"){
                html = GetTableHtml(rows,cls);
            }
            this.textAreaControl.Text = html;
        }
        public string GetTableHtml(DataGridViewRowCollection rows,string cls)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table class=\"" + cls + "\">");
            
                sb.AppendLine(" <thead>");
                sb.AppendLine("     <tr>");
                foreach (DataGridViewRow row in rows)
                {
                    if (!row.IsNewRow)
                    {
                        sb.AppendLine(string.Format("         <th>{0}</th>", row.Cells[0].Value));
                    }
                }
                sb.AppendLine("     </tr>");
                sb.AppendLine(" </thead>");
                sb.AppendLine(" <tbody>");
                int rowLength = string.IsNullOrEmpty(this.txtRow.Text) ? 10 : Convert.ToInt32(this.txtRow.Text);
                for (int i = 0; i < rowLength; i++)
                {
                    sb.AppendLine("     <tr>");
                    foreach (DataGridViewRow row in rows)
                    {
                        if (!row.IsNewRow)
                        {
                            sb.AppendLine(string.Format("         <td>{0}</td>", row.Cells[1].Value + row.Index.ToString()));
                        }
                    }
                    sb.AppendLine("     </tr>");
                }
                sb.AppendLine(" </tbody>");
           
            sb.AppendLine("</table>");
            return sb.ToString();
        }
    }
}
