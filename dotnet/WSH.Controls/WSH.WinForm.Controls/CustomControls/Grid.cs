using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using WSH.WinForm.Common;

namespace WSH.WinForm.Controls
{
    public partial class Grid : DataGridView
    {
        public Grid()
        {
            InitializeComponent();
        }
       

        #region 设置样式
        protected override void OnCellFormatting(DataGridViewCellFormattingEventArgs e)
        {
            base.OnCellFormatting(e);
            if (!DesignMode)
            {
                e.CellStyle.SelectionBackColor = BaseColor.GridSelectedRow;
                e.CellStyle.SelectionForeColor = ColorTranslator.FromHtml("#333333");
            }
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
         
            if ((e.RowIndex == -1 || e.ColumnIndex==-1) && !this.DesignMode)
            {
                
                bool mouseOver = e.CellBounds.Contains(this.PointToClient(Cursor.Position));
                LinearGradientBrush brush = new LinearGradientBrush(
                    e.CellBounds,
                    //  mouseOver ? Color.PeachPuff : Color.LightGray,
                    // Color.DarkOrange,
                  BaseColor.GridHeaderBegin,
                   BaseColor.GridHeaderEnd,
                    LinearGradientMode.Vertical);

                using (brush)
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                    Rectangle border = e.CellBounds;
                    //border.Width -= 1;
                    // border.Y -= 2;
                    int rb = (e.ColumnIndex == this.Columns.Count - 1) ? 1 : 1;
                    Color bc = BaseColor.GridHeaderBorder;
                    //e.Graphics.DrawRectangle(p,border);
                    ControlPaint.DrawBorder(e.Graphics, border,
                        bc,
                        0,
                        ButtonBorderStyle.None,
                          bc, 0, ButtonBorderStyle.None, bc, rb, ButtonBorderStyle.Solid, bc, 1, ButtonBorderStyle.Solid);
                }

                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }
        
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            
            //this.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            //this.RowTemplate.DefaultCellStyle.BackColor = Color.Transparent;
           
            //Rectangle rect = new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height - DisplayRectangle.Height);
            //using(LinearGradientBrush brush=new LinearGradientBrush(rect,Color.Indigo,Color.Gray,LinearGradientMode.Vertical))
            //{
            //    pe.Graphics.FillRectangle(brush, rect);
            //}
            if (!DesignMode)
            {
               
                Color b = BaseColor.Border;
                ControlPaint.DrawBorder(pe.Graphics, this.ClientRectangle, b, ButtonBorderStyle.Solid);
                
                 
            }
        }
        #endregion

        #region 设置单元格右键菜单
        private ContextMenuStrip cellContextMenu;
        [DefaultValue(null)]
        /// <summary>
        /// 单元格右键菜单
        /// </summary>
        public ContextMenuStrip CellContextMenu
        {
            get { return cellContextMenu; }
            set { cellContextMenu = value; }
        }
        protected override void OnCellMouseClick(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseClick(e);
            if(CellContextMenu!=null && CellContextMenu.Items.Count>0){
                //判断右键并且是数据行
                if(e.Button== System.Windows.Forms.MouseButtons.Right && e.RowIndex>-1 && e.ColumnIndex>-1){
                    if (this.SelectionMode == DataGridViewSelectionMode.FullRowSelect
                        || this.SelectionMode == DataGridViewSelectionMode.ColumnHeaderSelect)
                    {
                        this.ClearSelection();
                    }
                    this.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                    CellContextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        #endregion

        #region 右键操作
        private bool ExistsMenuItem(string name) { 
            if(this.CellContextMenu!=null && CellContextMenu.Items.Count >0){
                foreach (ToolStripMenuItem item in CellContextMenu.Items)
                {
                    if(item.Name==name){
                        return true;
                    }
                }
            }
            return false;
        }
        private string MenuDeleteName{
            get{return this.Name+"MenuDelete";}
        }
        private bool allowMenuDelete;
        [DefaultValue(false)]
        public bool AllowMenuDelete
        {
            get { return allowMenuDelete; }
            set
            {
                allowMenuDelete = value;
                if (allowMenuDelete)
                {
                    if (!ExistsMenuItem(MenuDeleteName))
                    {
                        if (CellContextMenu == null)
                        {
                            CellContextMenu = new ContextMenuStrip();
                        }
                        ToolStripMenuItem item = new ToolStripMenuItem()
                        {
                            Text = "删除",
                            Name = MenuDeleteName
                        };
                        item.Click += new EventHandler(item_Click);
                        CellContextMenu.Items.Add(item);
                    }
                }
                else { 
                    if(CellContextMenu!=null){
                        if (ExistsMenuItem(MenuDeleteName))
                        {
                            CellContextMenu.Items.RemoveByKey(MenuDeleteName);
                        }
                    }
                }
            }
        }
        private bool allowMenuDeleteConfirm;
        [DefaultValue(false)]
        public bool AllowMenuDeleteConfirm
        {
            get { return allowMenuDeleteConfirm; }
            set { allowMenuDeleteConfirm = value; }
        }
        /// <summary>
        /// 移除行
        /// </summary>
        void item_Click(object sender, EventArgs e)
        {
            if (this.SelectedRows != null && this.SelectedRows.Count > 0)
            {
                bool isRemove = true;
                if (AllowMenuDeleteConfirm)
                {
                    isRemove = MsgBox.Confirm("确定删除选中的记录吗？");
                }
                if (isRemove)
                {
                    for (int i = 0; i < this.SelectedRows.Count; i++)
                    {
                        if (!this.SelectedRows[i].IsNewRow)
                        {
                            this.Rows.Remove(this.SelectedRows[i]);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
