using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Tools.Common;


namespace WSH.Tools
{
    public partial class FrmSplitBackgroundPosition : BaseForm
    {
        public DataTable dtSource = new DataTable();
        public FrmSplitBackgroundPosition()
        {
            InitializeComponent();
            dtSource.Columns.AddRange(new DataColumn[]{
                new DataColumn("keyword",typeof(string)),
                new DataColumn("x",typeof(string)),
                new DataColumn("y",typeof(string))
            });
            this.grid.AutoGenerateColumns = false;
            this.grid.DataSource = dtSource;
        }
        public void AddRow(string keyword,string x,string y) {
            DataRow row = dtSource.NewRow();
            row["keyword"] = keyword;
            row["x"] = x + "px";
            row["y"] = y + "px";
            dtSource.Rows.Add(row);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataRow  row in dtSource.Rows)
            {
                sb.AppendLine("."+row["keyword"]+"{background-position:"+row["x"]+" "+row["y"]+";}");   
            }
            string text = sb.ToString().Trim();
            if(text!=string.Empty){
                Clipboard.SetText(text);
                MessageBox.Show("样式已经复制到粘贴板!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Split("x");
        }
        public void Split(string type) {
            string t = txtWidth.Text.Trim();
            if (t != string.Empty)
            {
                dtSource.Clear();
                int split = Convert.ToInt32(cboSplit.Text.Trim());
                int w = Convert.ToInt32(t);
                int itemLength = Convert.ToInt32(w / split);
                for (int i = 1; i <= itemLength; i++)
                {
                    int item = Convert.ToInt32((i-1) * split);
                    if (item > 0)
                    {
                        item = -item;
                    }
                    string x = type == "x" ? item.ToString() : this.cbox.Text.Trim();
                    string y= type == "y" ? item.ToString() : this.cboy.Text.Trim();
                    AddRow("unnamed_"+i.ToString(), x, y);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Split("y");
        }
    }
}
