namespace WSH.Tools
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.menuObjectBuilder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBackgroundSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrypt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFmtCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuControl = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDataMining = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddressBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTools,
            this.menuToExcel,
            this.menuDataMining});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(566, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuTools
            // 
            this.menuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuObjectBuilder,
            this.menuBackgroundSplit,
            this.menuCrypt,
            this.menuFmtCode,
            this.menuControl,
            this.menuClear,
            this.menuAddressBook});
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(56, 21);
            this.menuTools.Text = "工具集";
            // 
            // menuObjectBuilder
            // 
            this.menuObjectBuilder.Name = "menuObjectBuilder";
            this.menuObjectBuilder.Size = new System.Drawing.Size(172, 22);
            this.menuObjectBuilder.Text = "对象生成器";
            this.menuObjectBuilder.Click += new System.EventHandler(this.menuObjectBuilder_Click);
            // 
            // menuBackgroundSplit
            // 
            this.menuBackgroundSplit.Name = "menuBackgroundSplit";
            this.menuBackgroundSplit.Size = new System.Drawing.Size(172, 22);
            this.menuBackgroundSplit.Text = "背景图片位置分割";
            this.menuBackgroundSplit.Click += new System.EventHandler(this.menuBackgroundSplit_Click);
            // 
            // menuCrypt
            // 
            this.menuCrypt.Name = "menuCrypt";
            this.menuCrypt.Size = new System.Drawing.Size(172, 22);
            this.menuCrypt.Text = "加密解密";
            this.menuCrypt.Click += new System.EventHandler(this.menuCrypt_Click);
            // 
            // menuFmtCode
            // 
            this.menuFmtCode.Name = "menuFmtCode";
            this.menuFmtCode.Size = new System.Drawing.Size(172, 22);
            this.menuFmtCode.Text = "格式化代码";
            this.menuFmtCode.Click += new System.EventHandler(this.menuFmtCode_Click);
            // 
            // menuControl
            // 
            this.menuControl.Name = "menuControl";
            this.menuControl.Size = new System.Drawing.Size(172, 22);
            this.menuControl.Text = "控件生成";
            this.menuControl.Click += new System.EventHandler(this.menuControl_Click);
            // 
            // menuClear
            // 
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(172, 22);
            this.menuClear.Text = "清理文件";
            this.menuClear.Click += new System.EventHandler(this.menuClearIIS_Click);
            // 
            // menuToExcel
            // 
            this.menuToExcel.Name = "menuToExcel";
            this.menuToExcel.Size = new System.Drawing.Size(97, 21);
            this.menuToExcel.Text = "导入导出Excel";
            this.menuToExcel.Click += new System.EventHandler(this.menuToExcel_Click);
            // 
            // menuDataMining
            // 
            this.menuDataMining.Name = "menuDataMining";
            this.menuDataMining.Size = new System.Drawing.Size(68, 21);
            this.menuDataMining.Text = "数据挖掘";
            this.menuDataMining.Click += new System.EventHandler(this.menuDataMining_Click);
            // 
            // menuAddressBook
            // 
            this.menuAddressBook.Name = "menuAddressBook";
            this.menuAddressBook.Size = new System.Drawing.Size(172, 22);
            this.menuAddressBook.Text = "解析通讯录";
            this.menuAddressBook.Click += new System.EventHandler(this.menuAddressBook_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(566, 482);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "WSH.Tools";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem menuObjectBuilder;
        private System.Windows.Forms.ToolStripMenuItem menuBackgroundSplit;
        private System.Windows.Forms.ToolStripMenuItem menuCrypt;
        private System.Windows.Forms.ToolStripMenuItem menuFmtCode;
        private System.Windows.Forms.ToolStripMenuItem menuToExcel;
        private System.Windows.Forms.ToolStripMenuItem menuControl;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.ToolStripMenuItem menuDataMining;
        private System.Windows.Forms.ToolStripMenuItem menuAddressBook;


    }
}