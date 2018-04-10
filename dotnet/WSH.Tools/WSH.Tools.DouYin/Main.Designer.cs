namespace WSH.Tools.DouYin
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.lbMsg = new System.Windows.Forms.Label();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.selectDialog1 = new WSH.WinForm.Controls.SelectDialog();
            this.selectFolder = new WSH.WinForm.Controls.SelectDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "抖音ID：";
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.ForeColor = System.Drawing.Color.Red;
            this.lbMsg.Location = new System.Drawing.Point(9, 205);
            this.lbMsg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(135, 15);
            this.lbMsg.TabIndex = 3;
            this.lbMsg.Text = "                ";
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(6, 230);
            this.progress.Margin = new System.Windows.Forms.Padding(4);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(466, 29);
            this.progress.TabIndex = 4;
            // 
            // selectDialog1
            // 
            this.selectDialog1.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog1.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialog1.Location = new System.Drawing.Point(94, 45);
            this.selectDialog1.Margin = new System.Windows.Forms.Padding(4);
            this.selectDialog1.Name = "selectDialog1";
            this.selectDialog1.ReadOnly = false;
            this.selectDialog1.Size = new System.Drawing.Size(378, 26);
            this.selectDialog1.TabIndex = 6;
            this.selectDialog1.Title = null;
            this.selectDialog1.Type = WSH.Windows.Common.DialogType.Folder;
            // 
            // selectFolder
            // 
            this.selectFolder.BackColor = System.Drawing.Color.Transparent;
            this.selectFolder.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectFolder.Location = new System.Drawing.Point(6, 49);
            this.selectFolder.Margin = new System.Windows.Forms.Padding(4);
            this.selectFolder.Name = "selectFolder";
            this.selectFolder.ReadOnly = false;
            this.selectFolder.Size = new System.Drawing.Size(326, 26);
            this.selectFolder.TabIndex = 6;
            this.selectFolder.Title = null;
            this.selectFolder.Type = WSH.Windows.Common.DialogType.File;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 127);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 26);
            this.button1.TabIndex = 7;
            this.button1.Text = "下载";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "存放位置：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(284, 89);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(188, 25);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(94, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(164, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "发布日期不得小于：";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(166, 127);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 26);
            this.button2.TabIndex = 12;
            this.button2.Text = "暂停";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(94, 13);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(379, 25);
            this.txtNumber.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(13, 172);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(441, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "本软件免费使用，后续接口及功能更新请加群725436279下载    ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 263);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.selectDialog1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "抖音下载助手(qq群:725436279)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.ProgressBar progress;
        private WinForm.Controls.SelectDialog selectFolder;
        private WinForm.Controls.SelectDialog selectDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label3;
    }
}