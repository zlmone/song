namespace WSH.Tools
{
    partial class FrmSplitBackgroundPosition
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
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSplit = new System.Windows.Forms.ComboBox();
            this.cbox = new System.Windows.Forms.ComboBox();
            this.cboy = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "横向分割";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colX,
            this.colY});
            this.grid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grid.Location = new System.Drawing.Point(13, 86);
            this.grid.Name = "grid";
            this.grid.RowHeadersVisible = false;
            this.grid.RowTemplate.Height = 23;
            this.grid.Size = new System.Drawing.Size(413, 246);
            this.grid.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "间隔";
            // 
            // cboSplit
            // 
            this.cboSplit.FormattingEnabled = true;
            this.cboSplit.Items.AddRange(new object[] {
            "16",
            "32",
            "48",
            "64"});
            this.cboSplit.Location = new System.Drawing.Point(249, 16);
            this.cboSplit.Name = "cboSplit";
            this.cboSplit.Size = new System.Drawing.Size(60, 20);
            this.cboSplit.TabIndex = 10;
            this.cboSplit.Text = "16";
            // 
            // cbox
            // 
            this.cbox.FormattingEnabled = true;
            this.cbox.Items.AddRange(new object[] {
            "16",
            "32",
            "48",
            "64"});
            this.cbox.Location = new System.Drawing.Point(30, 48);
            this.cbox.Name = "cbox";
            this.cbox.Size = new System.Drawing.Size(61, 20);
            this.cbox.TabIndex = 11;
            this.cbox.Text = "0";
            // 
            // cboy
            // 
            this.cboy.FormattingEnabled = true;
            this.cboy.Items.AddRange(new object[] {
            "16",
            "32",
            "48",
            "64"});
            this.cboy.Location = new System.Drawing.Point(124, 48);
            this.cboy.Name = "cboy";
            this.cboy.Size = new System.Drawing.Size(61, 20);
            this.cboy.TabIndex = 12;
            this.cboy.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(169, 348);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "生成css样式";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "图片长度：";
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(85, 13);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(100, 21);
            this.txtWidth.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(348, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "页面单位：px";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "竖向分割";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colName
            // 
            this.colName.DataPropertyName = "keyword";
            this.colName.HeaderText = "关键字";
            this.colName.Name = "colName";
            // 
            // colX
            // 
            this.colX.DataPropertyName = "x";
            this.colX.HeaderText = "横坐标";
            this.colX.Name = "colX";
            this.colX.ReadOnly = true;
            // 
            // colY
            // 
            this.colY.DataPropertyName = "y";
            this.colY.HeaderText = "竖坐标";
            this.colY.Name = "colY";
            this.colY.ReadOnly = true;
            // 
            // FrmSplitBackgroundPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.cboy);
            this.Controls.Add(this.cbox);
            this.Controls.Add(this.cboSplit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmSplitBackgroundPosition";
            this.Text = "分割背景图片位置";
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSplit;
        private System.Windows.Forms.ComboBox cbox;
        private System.Windows.Forms.ComboBox cboy;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colY;
    }
}