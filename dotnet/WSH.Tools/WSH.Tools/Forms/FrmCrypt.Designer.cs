namespace WSH.Tools
{
    partial class FrmCrypt
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
            this.richBeginText = new System.Windows.Forms.TextBox();
            this.richEndText = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cobType = new System.Windows.Forms.ComboBox();
            this.btnEncode = new System.Windows.Forms.Button();
            this.btnDecode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richBeginText
            // 
            this.richBeginText.Location = new System.Drawing.Point(-1, 0);
            this.richBeginText.Multiline = true;
            this.richBeginText.Name = "richBeginText";
            this.richBeginText.Size = new System.Drawing.Size(323, 246);
            this.richBeginText.TabIndex = 1;
            // 
            // richEndText
            // 
            this.richEndText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richEndText.Location = new System.Drawing.Point(-1, 252);
            this.richEndText.Name = "richEndText";
            this.richEndText.Size = new System.Drawing.Size(499, 215);
            this.richEndText.TabIndex = 2;
            this.richEndText.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "类型";
            // 
            // cobType
            // 
            this.cobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobType.FormattingEnabled = true;
            this.cobType.Items.AddRange(new object[] {
            "default",
            "md5-long",
            "md5-short"});
            this.cobType.Location = new System.Drawing.Point(366, 70);
            this.cobType.Name = "cobType";
            this.cobType.Size = new System.Drawing.Size(121, 20);
            this.cobType.TabIndex = 3;
            // 
            // btnEncode
            // 
            this.btnEncode.Location = new System.Drawing.Point(376, 113);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(75, 23);
            this.btnEncode.TabIndex = 5;
            this.btnEncode.Text = "加密";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(376, 142);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(75, 23);
            this.btnDecode.TabIndex = 6;
            this.btnDecode.Text = "解密";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // FrmCrypt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 466);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.btnEncode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cobType);
            this.Controls.Add(this.richEndText);
            this.Controls.Add(this.richBeginText);
            this.Name = "FrmCrypt";
            this.Text = "加密解密";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox richBeginText;
        private System.Windows.Forms.RichTextBox richEndText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cobType;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnDecode;
    }
}