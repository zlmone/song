namespace WSH.Tools.Internet.Movie
{
    partial class MovieMain
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtUrl = new WSH.WinForm.Controls.InputBox();
            this.txtResultList = new WSH.WinForm.Controls.TextArea();
            this.checkSearchChild = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(511, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(13, 13);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.RegexMessage = null;
            this.txtUrl.RegexType = WSH.Common.RegexType.None;
            this.txtUrl.Required = true;
            this.txtUrl.RequiredMessage = "此项必填";
            this.txtUrl.Size = new System.Drawing.Size(378, 21);
            this.txtUrl.TabIndex = 0;
            // 
            // txtResultList
            // 
            this.txtResultList.Location = new System.Drawing.Point(13, 41);
            this.txtResultList.Multiline = true;
            this.txtResultList.Name = "txtResultList";
            this.txtResultList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResultList.Size = new System.Drawing.Size(573, 275);
            this.txtResultList.TabIndex = 2;
            // 
            // checkSearchChild
            // 
            this.checkSearchChild.AutoSize = true;
            this.checkSearchChild.Location = new System.Drawing.Point(397, 15);
            this.checkSearchChild.Name = "checkSearchChild";
            this.checkSearchChild.Size = new System.Drawing.Size(108, 16);
            this.checkSearchChild.TabIndex = 3;
            this.checkSearchChild.Text = "是否搜索子页面";
            this.checkSearchChild.UseVisualStyleBackColor = true;
            // 
            // MovieMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 328);
            this.Controls.Add(this.checkSearchChild);
            this.Controls.Add(this.txtResultList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtUrl);
            this.Name = "MovieMain";
            this.Text = "挖掘下载视频";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForm.Controls.InputBox txtUrl;
        private System.Windows.Forms.Button btnSearch;
        private WinForm.Controls.TextArea txtResultList;
        private System.Windows.Forms.CheckBox checkSearchChild;
    }
}