using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using WSH.WinForm.Common;
using WSH.CodeBuilder.Common;
using WSH.CodeBuilder.DispatchServers;

namespace WSH.CodeBuilder.WinForm
{
    //public enum FilterDataType { 
    //    All,
    //    Page
    //}
    public partial class FilterData : UserControl
    {
        public FilterData()
        {
            InitializeComponent();

            this.checkBoxDataKey.CheckedChanged += new EventHandler(checkBoxDataKey_CheckedChanged);
            // BindType();
        }

        void checkBoxDataKey_CheckedChanged(object sender, EventArgs e)
        {
            CreateSql();
        }
        //private FilterDataType type= FilterDataType.All;
        ///// <summary>
        ///// 数据过滤的类型
        ///// </summary>
        //public FilterDataType Type
        //{
        //    get { return (FilterDataType)Enum.Parse(typeof(FilterDataType), this.cboType.SelectedItem.ToString()); }
        //    set { type = value; }
        //}
        ////private void BindType() { 
        //    this.cboType.DataSource=Enum.GetNames(typeof(FilterDataType));
        //    this.cboType.SelectedItem = Type.ToString();
        //}
        ///// <summary>
        ///// 过滤where条件语句
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void txtFilter_TextChanged(object sender, EventArgs e)
        //{
        //    string str = this.txtFilter.Text.TrimStart().Replace("where", "").TrimStart();
        //    if (str.StartsWith("and"))
        //    {
        //        str = StringHelper.DeleteStart(str, "and").Trim();
        //    }
        //    if(str.StartsWith("or")){
        //        str=StringHelper.DeleteStart(str,"or").Trim();
        //    }
        //    this.txtFilter.Text = str;
        //    if(str.Length>0){
        //        this.txtFilter.SelectionStart = this.txtFilter.Text.Length;
        //        this.txtFilter.SelectionLength = 0;
        //    }
        //    CreateSql();
        //}
        ///// <summary>
        ///// 得到查询条件
        ///// </summary>
        //public string Filter {
        //    get
        //    {
        //        return StringHelper.DeleteEnd(StringHelper.DeleteEnd(this.txtFilter.Text.Trim(), "and").Trim(), "or");
        //    }
        //}
        /// <summary>
        /// 获取查询数据量
        /// </summary>
        public int PageSize
        {
            get
            {
                string size = this.cboSize.Text.Trim();
                if (!RegexHelper.Test(size, RegexHelper.Int))
                {
                    MsgBox.Alert(RegexHelper.IntMsg);
                    return 0;
                }
                return Convert.ToInt32(size);
            }
        }
        public int PageBegin
        {
            get
            {
                int begin = Convert.ToInt32(this.txtPageBegin.Text.Trim());
                return begin * PageSize + 1;
            }
        }
        public int PageEnd
        {
            get
            {
                int end = Convert.ToInt32(this.txtPageEnd.Text.Trim());
                return end * PageSize;
            }
        }
        public bool IsDataKey {
            set {
                this.checkBoxDataKey.Checked = value;
            }
            get {
                return this.checkBoxDataKey.Checked;   
            }
        }
        public string TableName
        {
            get { return this.txtTableName.Text.Trim(); }
            set { this.txtTableName.Text = value; }
        }
        public string SortName
        {
            get;
            set;
        }
        public WSH.Common.SortMode SortMode
        {
            get;
            set;
        }
        private List<ColumnInfo> columnsData;

        public List<ColumnInfo> ColumnsData
        {
            get
            {
                if (columnsData == null)
                {
                    ConnectionEntity entity = Global.GetProjectConnection();
                    DbModelData model = DbModelDataFactory.GetDbModelData(entity.ConnectionType.ToString(), entity.ConnectionString);
                    columnsData = model.GetColumns(TableName);
                }
                return columnsData;
            }
        }
        /// <summary>
        /// 创建sql语句
        /// </summary>
        /// <returns></returns>
        public string CreateSql()
        {
            StringBuilder sb = new StringBuilder();
            string sortname = string.IsNullOrEmpty(SortName) ? "Id" : SortName;
            string sortmode = SortMode.ToString();
            sb.AppendLine(";with tab as( select (ROW_NUMBER() over(order by [" + sortname + "] " + sortmode + ")) as _rownumber,");
            sb.AppendLine(GetColumns());
            sb.AppendLine(" from [" + TableName + "] where 1=1)");
            sb.AppendLine(string.Format("select * from tab where _rownumber between {0} and {1}", PageBegin, PageEnd));
            string sql = sb.ToString();
            this.txtSql.Text = sql;
            return sql;
        }
        public string GetColumns()
        {
            bool isDataAllowKey = this.checkBoxDataKey.Checked;
            StringBuilder sb = new StringBuilder();
            var columns = ColumnsData;
            if (columns != null)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    var col = columns[i];
                    if (!isDataAllowKey && col.IsDataKey)
                    {
                        continue;
                    }
                    sb.Append("[" + col.Field + "]");
                    if (i < columns.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
            }
            string cols= sb.ToString();
            return string.IsNullOrEmpty(cols) ? "*" : cols;
        }
        private void txtPageEnd_TextChanged(object sender, EventArgs e)
        {
            CreateSql();
        }

        private void txtPageBegin_TextChanged(object sender, EventArgs e)
        {
            CreateSql();
        }

        private void txtTableName_TextChanged(object sender, EventArgs e)
        {
            CreateSql();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataSource();
            this.grid.AutoGenerateColumns = true;
            this.grid.ReadOnly = true;
            this.grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.grid.DataSource = null;
            this.grid.DataSource = dt;
        }
        public DataTable GetDataSource()
        {
            string sql = this.txtSql.Text.Trim();
            if (!string.IsNullOrEmpty(sql))
            {
                ConnectionEntity entity = Global.GetProjectConnection();
                DbHelper db = new DbHelper(StringHelper.ToEnum<WSH.Common.DataBaseType>(entity.ConnectionType.ToString()), entity.ConnectionString);
                DataTable dt = db.GetDataTable(sql);
                dt.Columns.Remove("_rownumber");
                dt.TableName = TableName;
                return dt;
            }
            return null;
        }
        private void cboSize_TextChanged(object sender, EventArgs e)
        {
            CreateSql();
        }
    }
}
