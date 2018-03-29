namespace WSH.Tools
{
    partial class FrmControlBuilder
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCls = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnControl = new WSH.WinForm.Controls.ButtonImage();
            this.textAreaControl = new WSH.WinForm.Controls.TextArea();
            this.gridColumn = new WSH.WinForm.Controls.Grid();
            this.colHeader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "控件类型：";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "Table"});
            this.cboType.Location = new System.Drawing.Point(77, 11);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(79, 20);
            this.cboType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Class：";
            // 
            // txtCls
            // 
            this.txtCls.Location = new System.Drawing.Point(215, 11);
            this.txtCls.Name = "txtCls";
            this.txtCls.Size = new System.Drawing.Size(93, 21);
            this.txtCls.TabIndex = 3;
            this.txtCls.Text = "grid";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 373);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRow);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.btnControl);
            this.tabPage1.Controls.Add(this.textAreaControl);
            this.tabPage1.Controls.Add(this.gridColumn);
            this.tabPage1.Controls.Add(this.txtCls);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboType);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(511, 347);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HTML";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(367, 10);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(53, 21);
            this.txtRow.TabIndex = 8;
            this.txtRow.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(314, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "行数：";
            // 
            // btnControl
            // 
            this.btnControl.BackColor = System.Drawing.Color.Transparent;
            this.btnControl.Location = new System.Drawing.Point(435, 6);
            this.btnControl.Name = "btnControl";
            this.btnControl.Size = new System.Drawing.Size(70, 30);
            this.btnControl.TabIndex = 6;
            this.btnControl.Text = "生成";
            this.btnControl.Click += new System.EventHandler(this.btnControl_Click);
            // 
            // textAreaControl
            // 
            this.textAreaControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textAreaControl.Location = new System.Drawing.Point(196, 42);
            this.textAreaControl.Multiline = true;
            this.textAreaControl.Name = "textAreaControl";
            this.textAreaControl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textAreaControl.Size = new System.Drawing.Size(312, 306);
            this.textAreaControl.TabIndex = 5;
            // 
            // gridColumn
            // 
            this.gridColumn.AllowUserToResizeRows = false;
            this.gridColumn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridColumn.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colHeader,
            this.colValue});
            this.gridColumn.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridColumn.Location = new System.Drawing.Point(0, 41);
            this.gridColumn.MultiSelect = false;
            this.gridColumn.Name = "gridColumn";
            this.gridColumn.RowHeadersVisible = false;
            this.gridColumn.RowTemplate.Height = 23;
            this.gridColumn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridColumn.Size = new System.Drawing.Size(190, 306);
            this.gridColumn.TabIndex = 4;
            // 
            // colHeader
            // 
            this.colHeader.HeaderText = "列名";
            this.colHeader.Name = "colHeader";
            // 
            // colValue
            // 
            this.colValue.HeaderText = "值";
            this.colValue.Name = "colValue";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(511, 347);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "框架";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmControlBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 373);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmControlBuilder";
            this.Text = "控件生成";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridColumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCls;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private WinForm.Controls.Grid gridColumn;
        private WinForm.Controls.TextArea textAreaControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private WinForm.Controls.ButtonImage btnControl;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage2;

    }
}