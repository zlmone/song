namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ReaderDbTables
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
            this.btnReadTables = new WSH.WinForm.Controls.ButtonImage();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tables = new WSH.CodeBuilder.WinForm.UserControls.Tables();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnReadTables
            // 
            this.btnReadTables.BackColor = System.Drawing.Color.Transparent;
            this.btnReadTables.Location = new System.Drawing.Point(307, 359);
            this.btnReadTables.Name = "btnReadTables";
            this.btnReadTables.Size = new System.Drawing.Size(70, 30);
            this.btnReadTables.TabIndex = 1;
            this.btnReadTables.Text = "读取";
            this.btnReadTables.Click += new System.EventHandler(this.btnReadTables_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(3, 363);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(301, 23);
            this.progressBar.TabIndex = 2;
            // 
            // tables
            // 
            this.tables.Location = new System.Drawing.Point(3, 2);
            this.tables.Name = "tables";
            this.tables.Size = new System.Drawing.Size(374, 355);
            this.tables.TabIndex = 3;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // ReaderDbTables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 391);
            this.Controls.Add(this.tables);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnReadTables);
            this.Name = "ReaderDbTables";
            this.Text = "读取数据库表";
            this.Load += new System.EventHandler(this.ReaderDbTables_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WSH.WinForm.Controls.ButtonImage btnReadTables;
        private System.Windows.Forms.ProgressBar progressBar;
        private UserControls.Tables tables;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}