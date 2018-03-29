namespace WSH.Tools.Release
{
    partial class ReleaseFile
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnLocal = new WSH.WinForm.Controls.ButtonImage();
            this.label1 = new System.Windows.Forms.Label();
            this.dialogLocal = new WSH.WinForm.Controls.SelectDialog();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBarLocal = new System.Windows.Forms.ProgressBar();
            this.lbLocal = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(532, 211);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.linkLabel1);
            this.tabPage1.Controls.Add(this.lbLocal);
            this.tabPage1.Controls.Add(this.progressBarLocal);
            this.tabPage1.Controls.Add(this.btnLocal);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dialogLocal);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(524, 185);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "本地发布";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnLocal
            // 
            this.btnLocal.BackColor = System.Drawing.Color.Transparent;
            this.btnLocal.Location = new System.Drawing.Point(237, 82);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(70, 30);
            this.btnLocal.TabIndex = 2;
            this.btnLocal.Text = "发布";
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择发布路径：";
            // 
            // dialogLocal
            // 
            this.dialogLocal.BackColor = System.Drawing.Color.Transparent;
            this.dialogLocal.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.dialogLocal.Location = new System.Drawing.Point(103, 34);
            this.dialogLocal.MaximumSize = new System.Drawing.Size(3000, 30);
            this.dialogLocal.MinimumSize = new System.Drawing.Size(100, 30);
            this.dialogLocal.Name = "dialogLocal";
            this.dialogLocal.ReadOnly = false;
            this.dialogLocal.Size = new System.Drawing.Size(363, 30);
            this.dialogLocal.TabIndex = 0;
            this.dialogLocal.Title = null;
            this.dialogLocal.Type = WSH.Windows.Common.DialogType.Folder;
            this.dialogLocal.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.dialogLocal_OnSelectDialogOk);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(524, 185);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "FTP发布";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBarLocal
            // 
            this.progressBarLocal.Location = new System.Drawing.Point(0, 159);
            this.progressBarLocal.Name = "progressBarLocal";
            this.progressBarLocal.Size = new System.Drawing.Size(524, 23);
            this.progressBarLocal.TabIndex = 3;
            // 
            // lbLocal
            // 
            this.lbLocal.AutoSize = true;
            this.lbLocal.Location = new System.Drawing.Point(9, 141);
            this.lbLocal.Name = "lbLocal";
            this.lbLocal.Size = new System.Drawing.Size(0, 12);
            this.lbLocal.TabIndex = 4;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(468, 43);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 12);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "打开目录";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ReleaseFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 211);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "ReleaseFile";
            this.Text = "发布文件";
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WinForm.Controls.ButtonImage btnLocal;
        private System.Windows.Forms.Label label1;
        private WinForm.Controls.SelectDialog dialogLocal;
        private System.Windows.Forms.ProgressBar progressBarLocal;
        private System.Windows.Forms.Label lbLocal;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}