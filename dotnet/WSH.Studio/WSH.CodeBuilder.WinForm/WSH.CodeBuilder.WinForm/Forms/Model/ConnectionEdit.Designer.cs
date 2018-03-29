namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ConnectionEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new WSH.WinForm.Controls.Grid();
            this.colConnectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colConnectionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colConnectionString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTest = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowMenuDelete = true;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colConnectionName,
            this.colConnectionType,
            this.colConnectionString,
            this.colTest});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 23;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(782, 382);
            this.grid.TabIndex = 0;
            this.grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellContentClick);
            // 
            // colConnectionName
            // 
            this.colConnectionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colConnectionName.DataPropertyName = "ConnectionName";
            this.colConnectionName.HeaderText = "连接说明";
            this.colConnectionName.Name = "colConnectionName";
            this.colConnectionName.Width = 78;
            // 
            // colConnectionType
            // 
            this.colConnectionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colConnectionType.DataPropertyName = "ConnectionType";
            this.colConnectionType.HeaderText = "连接类型";
            this.colConnectionType.Name = "colConnectionType";
            this.colConnectionType.Width = 72;
            // 
            // colConnectionString
            // 
            this.colConnectionString.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colConnectionString.DataPropertyName = "ConnectionString";
            this.colConnectionString.HeaderText = "连接字符串";
            this.colConnectionString.Name = "colConnectionString";
            this.colConnectionString.Width = 565;
            // 
            // colTest
            // 
            this.colTest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "测试连接";
            this.colTest.DefaultCellStyle = dataGridViewCellStyle2;
            this.colTest.HeaderText = "测试连接";
            this.colTest.Name = "colTest";
            this.colTest.Text = "测试";
            this.colTest.Width = 64;
            // 
            // ConnectionEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 425);
            this.Controls.Add(this.grid);
            this.Name = "ConnectionEdit";
            this.Text = "数据库连接";
            this.Load += new System.EventHandler(this.ConnectionEdit_Load);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WSH.WinForm.Controls.Grid grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConnectionName;
        private System.Windows.Forms.DataGridViewComboBoxColumn colConnectionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colConnectionString;
        private System.Windows.Forms.DataGridViewButtonColumn colTest;
    }
}