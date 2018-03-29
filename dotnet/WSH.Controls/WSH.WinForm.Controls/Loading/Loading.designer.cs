 
namespace WSH.WinForm.Controls
{
    partial class Loading
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLoadingText = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLoadingText
            // 
            this.lbLoadingText.AutoSize = true;
            this.lbLoadingText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.lbLoadingText.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lbLoadingText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(138)))), ((int)(((byte)(84)))));
            this.lbLoadingText.Location = new System.Drawing.Point(58, 17);
            this.lbLoadingText.Name = "lbLoadingText";
            this.lbLoadingText.Size = new System.Drawing.Size(137, 17);
            this.lbLoadingText.TabIndex = 7;
            this.lbLoadingText.Text = "正在努力加载您的请求...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WSH.WinForm.Controls.Properties.Resources.loading;
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 48);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(252)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbLoadingText);
            this.Name = "Loading";
            this.Size = new System.Drawing.Size(214, 51);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbLoadingText;
    }
}
