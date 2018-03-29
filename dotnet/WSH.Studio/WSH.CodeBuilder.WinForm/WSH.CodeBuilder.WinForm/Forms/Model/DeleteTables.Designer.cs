namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class DeleteTables
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
            this.buttonImage1 = new WSH.WinForm.Controls.ButtonImage();
            this.tables = new WSH.CodeBuilder.WinForm.UserControls.Tables();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // buttonImage1
            // 
            this.buttonImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage1.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage1.Location = new System.Drawing.Point(297, 407);
            this.buttonImage1.Name = "buttonImage1";
            this.buttonImage1.Size = new System.Drawing.Size(70, 30);
            this.buttonImage1.TabIndex = 1;
            this.buttonImage1.Text = "批量删除";
            this.buttonImage1.Click += new System.EventHandler(this.buttonImage1_Click);
            // 
            // tables
            // 
            this.tables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tables.Location = new System.Drawing.Point(0, 0);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(377, 397);
            this.tables.TabIndex = 0;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 410);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(278, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // DeleteTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 445);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonImage1);
            this.Controls.Add(this.tables);
            this.Name = "DeleteTables";
            this.Text = "批量删除表";
            this.Load += new System.EventHandler(this.DeleteTables_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.Tables tables;
        private WSH.WinForm.Controls.ButtonImage buttonImage1;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}