namespace WSH.CodeBuilder.WinForm.Forms
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuTop = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarTop = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.imgs = new System.Windows.Forms.ImageList(this.components);
            this.menuDirection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolModel = new System.Windows.Forms.ToolStripButton();
            this.btnTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnConnection = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUser = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSystemSetting = new System.Windows.Forms.ToolStripButton();
            this.menuAddProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTop.SuspendLayout();
            this.toolBarTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.menuCreateCode,
            this.menuTools,
            this.帮助ToolStripMenuItem});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.Size = new System.Drawing.Size(586, 25);
            this.menuTop.TabIndex = 8;
            this.menuTop.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddProject});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // menuCreateCode
            // 
            this.menuCreateCode.Name = "menuCreateCode";
            this.menuCreateCode.Size = new System.Drawing.Size(68, 21);
            this.menuCreateCode.Text = "创建代码";
            // 
            // menuTools
            // 
            this.menuTools.Name = "menuTools";
            this.menuTools.Size = new System.Drawing.Size(56, 21);
            this.menuTools.Text = "工具集";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout,
            this.menuDirection});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // toolBarTop
            // 
            this.toolBarTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolModel,
            this.toolStripSeparator1,
            this.btnTemplate,
            this.toolStripSeparator3,
            this.btnConnection,
            this.toolStripSeparator2,
            this.toolStripButtonUser,
            this.toolStripSeparator4,
            this.toolStripButtonSystemSetting});
            this.toolBarTop.Location = new System.Drawing.Point(0, 25);
            this.toolBarTop.Name = "toolBarTop";
            this.toolBarTop.Size = new System.Drawing.Size(586, 25);
            this.toolBarTop.TabIndex = 10;
            this.toolBarTop.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel.Location = new System.Drawing.Point(0, 50);
            this.dockPanel.Name = "dockPanel";
            this.dockPanel.RightToLeftLayout = true;
            this.dockPanel.ShowPadIcon = false;
            this.dockPanel.Size = new System.Drawing.Size(586, 329);
            this.dockPanel.TabIndex = 6;
            // 
            // imgs
            // 
            this.imgs.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgs.ImageStream")));
            this.imgs.TransparentColor = System.Drawing.Color.Transparent;
            this.imgs.Images.SetKeyName(0, "as");
            this.imgs.Images.SetKeyName(1, "aspx");
            this.imgs.Images.SetKeyName(2, "cs");
            this.imgs.Images.SetKeyName(3, "cshtml");
            this.imgs.Images.SetKeyName(4, "css");
            this.imgs.Images.SetKeyName(5, "exe");
            this.imgs.Images.SetKeyName(6, "folder");
            this.imgs.Images.SetKeyName(7, "html");
            this.imgs.Images.SetKeyName(8, "html5");
            this.imgs.Images.SetKeyName(9, "js");
            this.imgs.Images.SetKeyName(10, "tag");
            this.imgs.Images.SetKeyName(11, "xaml");
            this.imgs.Images.SetKeyName(12, "xml");
            // 
            // menuDirection
            // 
            this.menuDirection.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.use;
            this.menuDirection.Name = "menuDirection";
            this.menuDirection.Size = new System.Drawing.Size(168, 22);
            this.menuDirection.Text = "使用说明";
            this.menuDirection.Click += new System.EventHandler(this.menuDirection_Click);
            // 
            // toolModel
            // 
            this.toolModel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolModel.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.model;
            this.toolModel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolModel.Name = "toolModel";
            this.toolModel.Size = new System.Drawing.Size(23, 22);
            this.toolModel.Text = "数据模型";
            this.toolModel.Click += new System.EventHandler(this.toolModel_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTemplate.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.template;
            this.btnTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(23, 22);
            this.btnTemplate.Text = "模板";
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnection.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.connection;
            this.btnConnection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(23, 22);
            this.btnConnection.Text = "数据连接";
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // toolStripButtonUser
            // 
            this.toolStripButtonUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUser.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUser.Image")));
            this.toolStripButtonUser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUser.Name = "toolStripButtonUser";
            this.toolStripButtonUser.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUser.Text = "用户管理";
            this.toolStripButtonUser.Click += new System.EventHandler(this.toolStripButtonUser_Click);
            // 
            // toolStripButtonSystemSetting
            // 
            this.toolStripButtonSystemSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSystemSetting.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.system;
            this.toolStripButtonSystemSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSystemSetting.Name = "toolStripButtonSystemSetting";
            this.toolStripButtonSystemSetting.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSystemSetting.Text = "系统设置";
            this.toolStripButtonSystemSetting.Click += new System.EventHandler(this.toolStripButtonSystemSetting_Click);
            // 
            // menuAddProject
            // 
            this.menuAddProject.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.add_project;
            this.menuAddProject.Name = "menuAddProject";
            this.menuAddProject.Size = new System.Drawing.Size(124, 22);
            this.menuAddProject.Text = "新建项目";
            this.menuAddProject.Click += new System.EventHandler(this.menuAddProject_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.help;
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(168, 22);
            this.menuAbout.Text = "关于WSH.Studio";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 379);
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.toolBarTop);
            this.Controls.Add(this.menuTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "WSH.Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            this.toolBarTop.ResumeLayout(false);
            this.toolBarTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel;
        private System.Windows.Forms.MenuStrip menuTop;
        private System.Windows.Forms.ToolStripMenuItem menuCreateCode;
        private System.Windows.Forms.ToolStrip toolBarTop;
        private System.Windows.Forms.ToolStripButton btnTemplate;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddProject;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnConnection;
        private System.Windows.Forms.ToolStripButton toolStripButtonUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSystemSetting;
        private System.Windows.Forms.ToolStripButton toolModel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuTools;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ImageList imgs;
        private System.Windows.Forms.ToolStripMenuItem menuDirection;


    }
}