namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class TemplateEdit
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
            this.cboCodeType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemplateName = new WSH.WinForm.Controls.InputBox();
            this.txtFileName = new WSH.WinForm.Controls.InputBox();
            this.label4 = new System.Windows.Forms.Label();
            this.required1 = new WSH.WinForm.Controls.Required();
            this.txtPrefix = new WSH.WinForm.Controls.InputBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // cboCodeType
            // 
            this.cboCodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCodeType.FormattingEnabled = true;
            this.cboCodeType.Location = new System.Drawing.Point(565, 9);
            this.cboCodeType.Name = "cboCodeType";
            this.cboCodeType.Size = new System.Drawing.Size(76, 20);
            this.cboCodeType.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "模版名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "文件类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "文件后缀：";
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(62, 7);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.RegexMessage = null;
            this.txtTemplateName.RegexType = WSH.Common.RegexType.None;
            this.txtTemplateName.Required = false;
            this.txtTemplateName.RequiredMessage = "此项必填";
            this.txtTemplateName.Size = new System.Drawing.Size(89, 21);
            this.txtTemplateName.TabIndex = 10;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(242, 8);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.RegexMessage = null;
            this.txtFileName.RegexType = WSH.Common.RegexType.None;
            this.txtFileName.Required = false;
            this.txtFileName.RequiredMessage = "此项必填";
            this.txtFileName.Size = new System.Drawing.Size(87, 21);
            this.txtFileName.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(647, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "按Ctrl+S可以保存模板";
            // 
            // required1
            // 
            this.required1.AutoSize = true;
            this.required1.ForeColor = System.Drawing.Color.Red;
            this.required1.Location = new System.Drawing.Point(1, 12);
            this.required1.Name = "required1";
            this.required1.Size = new System.Drawing.Size(11, 12);
            this.required1.TabIndex = 13;
            this.required1.Text = "*";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(429, 8);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.RegexMessage = null;
            this.txtPrefix.RegexType = WSH.Common.RegexType.None;
            this.txtPrefix.Required = false;
            this.txtPrefix.RequiredMessage = "此项必填";
            this.txtPrefix.Size = new System.Drawing.Size(62, 21);
            this.txtPrefix.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(361, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "文件前缀：";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(3, 35);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(777, 395);
            this.txtCode.TabIndex = 16;
            this.txtCode.Text = "";
            // 
            // TemplateEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 477);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.required1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboCodeType);
            this.KeyPreview = true;
            this.Name = "TemplateEdit";
            this.Text = "代码模板编辑";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemplateEdit_FormClosing);
            this.Load += new System.EventHandler(this.TemplateEdit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TemplateEdit_KeyDown);
            this.Controls.SetChildIndex(this.cboCodeType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.txtTemplateName, 0);
            this.Controls.SetChildIndex(this.txtFileName, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.required1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.txtPrefix, 0);
            this.Controls.SetChildIndex(this.txtCode, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboCodeType;
        private System.Windows.Forms.Label label1;
        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        
        private WSH.WinForm.Controls.InputBox txtTemplateName;
        private WSH.WinForm.Controls.InputBox txtFileName;
        private System.Windows.Forms.Label label4;
        private WSH.WinForm.Controls.Required required1;
        private WSH.WinForm.Controls.InputBox txtPrefix;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox txtCode;
    }
}