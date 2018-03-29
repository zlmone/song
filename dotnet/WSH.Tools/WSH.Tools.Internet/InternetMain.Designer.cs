namespace WSH.Tools.Internet
{
    partial class InternetMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFateUser = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMovie365 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFateUser,
            this.menuMovie365});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFateUser
            // 
            this.menuFateUser.Name = "menuFateUser";
            this.menuFateUser.Size = new System.Drawing.Size(71, 21);
            this.menuFateUser.Text = "FateUser";
            this.menuFateUser.Click += new System.EventHandler(this.menuFateUser_Click);
            // 
            // menuMovie365
            // 
            this.menuMovie365.Name = "menuMovie365";
            this.menuMovie365.Size = new System.Drawing.Size(77, 21);
            this.menuMovie365.Text = "Movie365";
            this.menuMovie365.Click += new System.EventHandler(this.menuMovie365_Click);
            // 
            // InternetMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 353);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InternetMain";
            this.Text = "InternetMain";
            this.Controls.SetChildIndex(this.menuStrip1, 0);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFateUser;
        private System.Windows.Forms.ToolStripMenuItem menuMovie365;


    }
}