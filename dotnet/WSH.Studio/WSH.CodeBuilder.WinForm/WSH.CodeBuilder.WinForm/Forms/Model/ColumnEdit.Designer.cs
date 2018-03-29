namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ColumnEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSort = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDataKey = new System.Windows.Forms.ToolStripButton();
            this.grid = new WSH.WinForm.Controls.Grid();
            this.colSortID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEditorType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colEnable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSortable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQueryable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colHidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFormatString = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAlign = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSave,
            this.toolStripSeparator2,
            this.btnSort,
            this.toolStripSeparator1,
            this.btnDataKey});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(783, 25);
            this.toolbar.TabIndex = 6;
            this.toolbar.Text = "toolStrip1";
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSort
            // 
            this.btnSort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(84, 22);
            this.btnSort.Text = "设置默认排序";
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDataKey
            // 
            this.btnDataKey.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDataKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDataKey.Name = "btnDataKey";
            this.btnDataKey.Size = new System.Drawing.Size(60, 22);
            this.btnDataKey.Text = "设置主键";
            this.btnDataKey.Click += new System.EventHandler(this.btnDataKey_Click);
            // 
            // grid
            // 
            this.grid.AllowMenuDelete = true;
            this.grid.AllowMenuDeleteConfirm = true;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSortID,
            this.colField,
            this.colDisplay,
            this.colDataType,
            this.colLength,
            this.colEditorType,
            this.colEnable,
            this.colSortable,
            this.colQueryable,
            this.colHidden,
            this.colRequired,
            this.colDefaultValue,
            this.colWidth,
            this.colFormatString,
            this.colAlign});
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.grid.Location = new System.Drawing.Point(0, 25);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 23;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(783, 413);
            this.grid.TabIndex = 7;
            // 
            // colSortID
            // 
            this.colSortID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colSortID.DataPropertyName = "SortID";
            this.colSortID.FillWeight = 461.8556F;
            this.colSortID.HeaderText = "No";
            this.colSortID.Name = "colSortID";
            this.colSortID.Width = 42;
            // 
            // colField
            // 
            this.colField.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colField.DataPropertyName = "Field";
            this.colField.HeaderText = "字段";
            this.colField.Name = "colField";
            // 
            // colDisplay
            // 
            this.colDisplay.DataPropertyName = "Display";
            this.colDisplay.FillWeight = 72.16496F;
            this.colDisplay.HeaderText = "显示名";
            this.colDisplay.Name = "colDisplay";
            // 
            // colDataType
            // 
            this.colDataType.DataPropertyName = "DataType";
            this.colDataType.FillWeight = 72.16496F;
            this.colDataType.HeaderText = "数据类型";
            this.colDataType.Name = "colDataType";
            // 
            // colLength
            // 
            this.colLength.DataPropertyName = "Precision";
            this.colLength.FillWeight = 72.16496F;
            this.colLength.HeaderText = "长度";
            this.colLength.Name = "colLength";
            // 
            // colEditorType
            // 
            this.colEditorType.DataPropertyName = "EditorType";
            this.colEditorType.FillWeight = 72.16496F;
            this.colEditorType.HeaderText = "编辑类型";
            this.colEditorType.Name = "colEditorType";
            this.colEditorType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colEditorType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colEnable
            // 
            this.colEnable.DataPropertyName = "Enabled";
            this.colEnable.FillWeight = 72.16496F;
            this.colEnable.HeaderText = "是否可用";
            this.colEnable.Name = "colEnable";
            // 
            // colSortable
            // 
            this.colSortable.DataPropertyName = "Sortable";
            this.colSortable.FillWeight = 72.16496F;
            this.colSortable.HeaderText = "是否排序";
            this.colSortable.Name = "colSortable";
            // 
            // colQueryable
            // 
            this.colQueryable.DataPropertyName = "Queryable";
            this.colQueryable.FillWeight = 72.16496F;
            this.colQueryable.HeaderText = "是否查询";
            this.colQueryable.Name = "colQueryable";
            // 
            // colHidden
            // 
            this.colHidden.DataPropertyName = "Hidden";
            this.colHidden.FillWeight = 72.16496F;
            this.colHidden.HeaderText = "是否隐藏";
            this.colHidden.Name = "colHidden";
            // 
            // colRequired
            // 
            this.colRequired.DataPropertyName = "Required";
            this.colRequired.FillWeight = 72.16496F;
            this.colRequired.HeaderText = "是否必填";
            this.colRequired.Name = "colRequired";
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.DataPropertyName = "DefaultValue";
            this.colDefaultValue.FillWeight = 72.16496F;
            this.colDefaultValue.HeaderText = "默认值";
            this.colDefaultValue.Name = "colDefaultValue";
            this.colDefaultValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDefaultValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colWidth
            // 
            this.colWidth.DataPropertyName = "Width";
            this.colWidth.FillWeight = 72.16496F;
            this.colWidth.HeaderText = "列宽";
            this.colWidth.Name = "colWidth";
            this.colWidth.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colWidth.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colFormatString
            // 
            this.colFormatString.DataPropertyName = "FormatString";
            this.colFormatString.FillWeight = 72.16496F;
            this.colFormatString.HeaderText = "格式化";
            this.colFormatString.Name = "colFormatString";
            // 
            // colAlign
            // 
            this.colAlign.DataPropertyName = "Align";
            this.colAlign.FillWeight = 72.16496F;
            this.colAlign.HeaderText = "对齐方式";
            this.colAlign.Name = "colAlign";
            this.colAlign.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 438);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.toolbar);
            this.Name = "ColumnEdit";
            this.TabText = "列-编辑";
            this.Text = "列-编辑";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ColumnEdit_FormClosing);
            this.Load += new System.EventHandler(this.ColumnEdit_Load);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private WSH.WinForm.Controls.Grid grid;
        private System.Windows.Forms.ToolStripButton btnSort;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnDataKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSortID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colField;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplay;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDataType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLength;
        private System.Windows.Forms.DataGridViewComboBoxColumn colEditorType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSortable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colQueryable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHidden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRequired;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDefaultValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colWidth;
        private System.Windows.Forms.DataGridViewComboBoxColumn colFormatString;
        private System.Windows.Forms.DataGridViewComboBoxColumn colAlign;


    }
}