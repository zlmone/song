namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class UserList
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
            this.grid = new WSH.WinForm.Controls.Grid();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
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
            this.Column1,
            this.UserName,
            this.RealName,
            this.Password,
            this.IsAdmin,
            this.IPAddress,
            this.MacAddress});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.grid.Location = new System.Drawing.Point(0, 1);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 23;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(779, 379);
            this.grid.TabIndex = 5;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Enabled";
            this.Column1.FillWeight = 59.73608F;
            this.Column1.HeaderText = "是否有效";
            this.Column1.Name = "Column1";
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.FillWeight = 60.04273F;
            this.UserName.HeaderText = "用户名";
            this.UserName.Name = "UserName";
            // 
            // RealName
            // 
            this.RealName.DataPropertyName = "RealName";
            this.RealName.FillWeight = 81.72588F;
            this.RealName.HeaderText = "真实姓名";
            this.RealName.Name = "RealName";
            // 
            // Password
            // 
            this.Password.DataPropertyName = "Password";
            this.Password.FillWeight = 134.515F;
            this.Password.HeaderText = "密码";
            this.Password.Name = "Password";
            // 
            // IsAdmin
            // 
            this.IsAdmin.DataPropertyName = "IsAdmin";
            this.IsAdmin.FillWeight = 83.62399F;
            this.IsAdmin.HeaderText = "是否管理员";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAdmin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IPAddress
            // 
            this.IPAddress.DataPropertyName = "IPAddress";
            this.IPAddress.FillWeight = 119.8234F;
            this.IPAddress.HeaderText = "IP地址";
            this.IPAddress.Name = "IPAddress";
            // 
            // MacAddress
            // 
            this.MacAddress.DataPropertyName = "MacAddress";
            this.MacAddress.FillWeight = 160.5329F;
            this.MacAddress.HeaderText = "Mac地址";
            this.MacAddress.Name = "MacAddress";
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 421);
            this.Controls.Add(this.grid);
            this.Name = "UserList";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WSH.WinForm.Controls.Grid grid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Password;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IPAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn MacAddress;
    }
}