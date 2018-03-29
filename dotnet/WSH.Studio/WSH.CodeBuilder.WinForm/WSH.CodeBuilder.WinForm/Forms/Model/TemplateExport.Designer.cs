namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class TemplateExport
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
            this.template = new WSH.CodeBuilder.WinForm.UserControls.Template();
            this.btnExport = new WSH.WinForm.Controls.ButtonImage();
            this.selectDialog = new WSH.WinForm.Controls.SelectDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // template
            // 
            this.template.Dock = System.Windows.Forms.DockStyle.Top;
            this.template.Location = new System.Drawing.Point(0, 0);
            this.template.Name = "template";
            this.template.Size = new System.Drawing.Size(464, 330);
            this.template.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Transparent;
            this.btnExport.Location = new System.Drawing.Point(197, 376);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(70, 30);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出模板";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // selectDialog
            // 
            this.selectDialog.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialog.Location = new System.Drawing.Point(69, 336);
            this.selectDialog.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectDialog.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectDialog.Name = "selectDialog";
            this.selectDialog.ReadOnly = false;
            this.selectDialog.Size = new System.Drawing.Size(395, 30);
            this.selectDialog.TabIndex = 2;
            this.selectDialog.Title = null;
            this.selectDialog.Type = WSH.Windows.Common.DialogType.File;
            this.selectDialog.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.selectDialog_OnSelectDialogOk);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "导出地址：";
            // 
            // TemplateExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 418);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectDialog);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.template);
            this.Name = "TemplateExport";
            this.Text = "模板导出";
            this.Load += new System.EventHandler(this.TemplateExport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Template template;
        private WSH.WinForm.Controls.ButtonImage btnExport;
        private WSH.WinForm.Controls.SelectDialog selectDialog;
        private System.Windows.Forms.Label label1;
    }
}