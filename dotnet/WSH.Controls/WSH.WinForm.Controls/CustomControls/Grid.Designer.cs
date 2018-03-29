namespace WSH.WinForm.Controls
{
    partial class Grid
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MultiSelect = false;
            this.AllowUserToResizeRows = false;
            this.AutoGenerateColumns = false;
            this.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RowHeadersVisible = false;
            this.AllowUserToDeleteRows = false;
            this.BackgroundColor = BaseColor.Background;
            this.ForeColor = System.Drawing.Color.Black;
            this.GridColor = BaseColor.GridCellBorder;
            this.AlternatingRowsDefaultCellStyle.BackColor = BaseColor.GridOdd;
        }

        #endregion
    }
}
