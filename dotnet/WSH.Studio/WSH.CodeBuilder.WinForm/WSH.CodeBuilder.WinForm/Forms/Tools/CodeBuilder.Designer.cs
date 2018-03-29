namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class CodeBuilder
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectDialog = new WSH.WinForm.Controls.SelectDialog();
            this.btnCreate = new WSH.WinForm.Controls.ButtonImage();
            this.tables = new WSH.CodeBuilder.WinForm.UserControls.Tables();
            this.template = new WSH.CodeBuilder.WinForm.UserControls.Template();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(0, 347);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(501, 22);
            this.progressBar.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "选择表：";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(245, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "选择模版";
            // 
            // selectDialog
            // 
            this.selectDialog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDialog.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialog.Location = new System.Drawing.Point(0, 314);
            this.selectDialog.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectDialog.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectDialog.Name = "selectDialog";
            this.selectDialog.ReadOnly = false;
            this.selectDialog.Size = new System.Drawing.Size(425, 30);
            this.selectDialog.TabIndex = 7;
            this.selectDialog.Title = null;
            this.selectDialog.Type = WSH.Windows.Common.DialogType.Folder;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.Location = new System.Drawing.Point(431, 314);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(70, 30);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "生成代码";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tables
            // 
            this.tables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tables.Location = new System.Drawing.Point(1, 24);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(240, 287);
            this.tables.TabIndex = 1;
            // 
            // template
            // 
            this.template.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.template.Location = new System.Drawing.Point(246, 24);
            this.template.Name = "template";
            this.template.Size = new System.Drawing.Size(256, 287);
            this.template.TabIndex = 0;
            // 
            // CodeBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 369);
            this.Controls.Add(this.selectDialog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.template);
            this.Name = "CodeBuilder";
            this.Text = "代码生成";
            this.Load += new System.EventHandler(this.CodeBuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Template template;
        private UserControls.Tables tables;
        private System.Windows.Forms.ProgressBar progressBar;
        private WSH.WinForm.Controls.ButtonImage btnCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private WSH.WinForm.Controls.SelectDialog selectDialog;
    }
}