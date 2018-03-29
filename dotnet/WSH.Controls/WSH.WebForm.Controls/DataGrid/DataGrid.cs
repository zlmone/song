using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WSH.WebForm.Controls
{
    [DefaultProperty("Columns")]
    [ToolboxData("<{0}:DataGrid runat=server></{0}:DataGrid>")]
    public class DataGrid : CompositeDataBoundControl
    {

        private List<GridColumn> columns;
        [Description("列集合")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<GridColumn> Columns
        {
            get
            {
                if (columns == null)
                {
                    columns = new List<GridColumn>();
                }
                return columns;
            }
        }
        #region 事件集合
        public delegate void CellBindingEventHandler(object sender,CellBindingArgs e);
        public event CellBindingEventHandler OnCellBinding;
        #endregion
        protected override int CreateChildControls(System.Collections.IEnumerable dataSource, bool dataBinding)
        {
            int result = 0;
            HtmlTable table = new HtmlTable();
            //创建头部
            CreateHeader(table);
            if (dataBinding)
            {
                foreach (object o in dataSource)
                {
                    HtmlTableRow row = new HtmlTableRow();
                    foreach (GridColumn  col in columns)
                    {
                        HtmlTableCell cell = new HtmlTableCell();
                        cell.InnerHtml = DataBinder.GetPropertyValue(o, col.Field, null);
                        row.Cells.Add(cell);
                    }
                    table.Rows.Add(row);
                }
            }
            this.Controls.Add(table);
            return result;
        }
        private void CreateHeader(HtmlTable table) {
            if(columns.Count<=0){
                return;
            }
            HtmlTableRow row = new HtmlTableRow();
            foreach (GridColumn item in columns)
            {
                HtmlTableCell cell = new HtmlTableCell();
                cell.InnerText = item.Header;
                row.Cells.Add(cell);
            }
            table.Rows.Add(row);
        }
    }
    public class CellBindingArgs{
        private HtmlTableCell cell;

        public HtmlTableCell Cell
        {
            get { return cell; }
            set { cell = value; }
        }
    }
}
