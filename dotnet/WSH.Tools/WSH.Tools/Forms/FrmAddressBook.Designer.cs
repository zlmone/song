namespace WSH.Tools
{
    partial class FrmAddressBook
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
            this.buttonImage2 = new WSH.WinForm.Controls.ButtonImage();
            this.buttonImage1 = new WSH.WinForm.Controls.ButtonImage();
            this.grid1 = new WSH.WinForm.Controls.Grid();
            this.buttonImage = new WSH.WinForm.Controls.ButtonImage();
            this.selectDialog = new WSH.WinForm.Controls.SelectDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImage2
            // 
            this.buttonImage2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage2.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage2.Location = new System.Drawing.Point(270, 34);
            this.buttonImage2.Name = "buttonImage2";
            this.buttonImage2.Size = new System.Drawing.Size(70, 30);
            this.buttonImage2.TabIndex = 5;
            this.buttonImage2.Text = "导出Excel";
            this.buttonImage2.Click += new System.EventHandler(this.buttonImage2_Click);
            // 
            // buttonImage1
            // 
            this.buttonImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage1.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage1.Location = new System.Drawing.Point(422, 34);
            this.buttonImage1.Name = "buttonImage1";
            this.buttonImage1.Size = new System.Drawing.Size(70, 30);
            this.buttonImage1.TabIndex = 4;
            this.buttonImage1.Text = "解析数据";
            this.buttonImage1.Click += new System.EventHandler(this.buttonImage1_Click);
            // 
            // grid1
            // 
            this.grid1.AllowUserToDeleteRows = false;
            this.grid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.grid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.grid1.Location = new System.Drawing.Point(0, 70);
            this.grid1.MultiSelect = false;
            this.grid1.Name = "grid1";
            this.grid1.RowHeadersVisible = false;
            this.grid1.RowTemplate.Height = 23;
            this.grid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid1.Size = new System.Drawing.Size(492, 268);
            this.grid1.TabIndex = 3;
            // 
            // buttonImage
            // 
            this.buttonImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage.Location = new System.Drawing.Point(346, 34);
            this.buttonImage.Name = "buttonImage";
            this.buttonImage.Size = new System.Drawing.Size(70, 30);
            this.buttonImage.TabIndex = 2;
            this.buttonImage.Text = "导出Txt";
            this.buttonImage.Click += new System.EventHandler(this.buttonImage_Click);
            // 
            // selectDialog
            // 
            this.selectDialog.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog.Dock = System.Windows.Forms.DockStyle.Top;
            this.selectDialog.Filter = "";
            this.selectDialog.Location = new System.Drawing.Point(0, 0);
            this.selectDialog.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectDialog.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectDialog.Name = "selectDialog";
            this.selectDialog.ReadOnly = false;
            this.selectDialog.Size = new System.Drawing.Size(492, 30);
            this.selectDialog.TabIndex = 0;
            this.selectDialog.Title = null;
            this.selectDialog.Type = WSH.Windows.Common.DialogType.File;
            this.selectDialog.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.selectDialog_OnSelectDialogOk);
            // 
            // FrmAddressBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 338);
            this.Controls.Add(this.buttonImage2);
            this.Controls.Add(this.buttonImage1);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.buttonImage);
            this.Controls.Add(this.selectDialog);
            this.Name = "FrmAddressBook";
            this.Text = "解析通讯录文件";
            this.Load += new System.EventHandler(this.FrmAddressBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private WinForm.Controls.SelectDialog selectDialog;
        private WinForm.Controls.ButtonImage buttonImage;
        private WinForm.Controls.Grid grid1;
        private WinForm.Controls.ButtonImage buttonImage1;
        private WinForm.Controls.ButtonImage buttonImage2;
    }
}