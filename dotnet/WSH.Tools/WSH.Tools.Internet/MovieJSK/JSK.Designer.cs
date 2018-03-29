namespace WSH.Tools.Internet.MovieJSK
{
    partial class JSK
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
            this.components = new System.ComponentModel.Container();
            this.txtResultList = new WSH.WinForm.Controls.TextArea();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtUrl = new WSH.WinForm.Controls.InputBox();
            this.txtMaxNumber = new WSH.WinForm.Controls.InputBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumber = new WSH.WinForm.Controls.InputBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtResultList
            // 
            this.txtResultList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResultList.Location = new System.Drawing.Point(2, 72);
            this.txtResultList.Margin = new System.Windows.Forms.Padding(4);
            this.txtResultList.Multiline = true;
            this.txtResultList.Name = "txtResultList";
            this.txtResultList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultList.Size = new System.Drawing.Size(763, 347);
            this.txtResultList.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(657, 34);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(71, 5);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.RegexMessage = null;
            this.txtUrl.RegexType = WSH.Common.RegexType.None;
            this.txtUrl.Required = false;
            this.txtUrl.RequiredMessage = "此项必填";
            this.txtUrl.Size = new System.Drawing.Size(686, 25);
            this.txtUrl.TabIndex = 3;
            // 
            // txtMaxNumber
            // 
            this.txtMaxNumber.Location = new System.Drawing.Point(71, 38);
            this.txtMaxNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxNumber.Name = "txtMaxNumber";
            this.txtMaxNumber.RegexMessage = null;
            this.txtMaxNumber.RegexType = WSH.Common.RegexType.None;
            this.txtMaxNumber.Required = true;
            this.txtMaxNumber.RequiredMessage = "此项必填";
            this.txtMaxNumber.Size = new System.Drawing.Size(94, 25);
            this.txtMaxNumber.TabIndex = 6;
            this.txtMaxNumber.Text = "152";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(368, 40);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 19);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "暂停";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(2, 427);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(764, 25);
            this.progressBar1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "最大：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(197, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "当前：";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(256, 38);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.RegexMessage = null;
            this.txtNumber.RegexType = WSH.Common.RegexType.None;
            this.txtNumber.Required = false;
            this.txtNumber.RequiredMessage = "此项必填";
            this.txtNumber.Size = new System.Drawing.Size(94, 25);
            this.txtNumber.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "地址：";
            // 
            // JSK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 463);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.txtMaxNumber);
            this.Controls.Add(this.txtResultList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtUrl);
            this.Name = "JSK";
            this.Text = "JSK";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForm.Controls.TextArea txtResultList;
        private System.Windows.Forms.Button btnSearch;
        private WinForm.Controls.InputBox txtUrl;
        private WinForm.Controls.InputBox txtMaxNumber;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private WinForm.Controls.InputBox txtNumber;
        private System.Windows.Forms.Label label1;
    }
}