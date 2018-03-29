namespace WSH.CodeBuilder.WinForm.UserControls
{
    partial class Template
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Template));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.menuType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTemplate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.menuImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExportType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReloadType = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTemplateInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEditTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveTemplate = new System.Windows.Forms.ToolStripMenuItem();
            this.treeTemplate = new WSH.WinForm.Controls.Tree();
            this.menuType.SuspendLayout();
            this.menuTemplate.SuspendLayout();
            this.menuTemplateInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "txt");
            this.imageList.Images.SetKeyName(1, "as");
            this.imageList.Images.SetKeyName(2, "aspx");
            this.imageList.Images.SetKeyName(3, "cs");
            this.imageList.Images.SetKeyName(4, "cshtml");
            this.imageList.Images.SetKeyName(5, "css");
            this.imageList.Images.SetKeyName(6, "exe");
            this.imageList.Images.SetKeyName(7, "folder");
            this.imageList.Images.SetKeyName(8, "html");
            this.imageList.Images.SetKeyName(9, "html");
            this.imageList.Images.SetKeyName(10, "js");
            this.imageList.Images.SetKeyName(11, "tag");
            this.imageList.Images.SetKeyName(12, "xaml");
            this.imageList.Images.SetKeyName(13, "xml");
            this.imageList.Images.SetKeyName(14, "sql");
            // 
            // menuType
            // 
            this.menuType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddType,
            this.menuExport,
            this.menuReload});
            this.menuType.Name = "menuType";
            this.menuType.Size = new System.Drawing.Size(125, 70);
            // 
            // menuAddType
            // 
            this.menuAddType.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.add;
            this.menuAddType.Name = "menuAddType";
            this.menuAddType.Size = new System.Drawing.Size(124, 22);
            this.menuAddType.Text = "新增分类";
            this.menuAddType.Click += new System.EventHandler(this.menuAddType_Click);
            // 
            // menuExport
            // 
            this.menuExport.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.export;
            this.menuExport.Name = "menuExport";
            this.menuExport.Size = new System.Drawing.Size(124, 22);
            this.menuExport.Text = "导出模板";
            this.menuExport.Click += new System.EventHandler(this.menuExport_Click);
            // 
            // menuReload
            // 
            this.menuReload.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.refresh;
            this.menuReload.Name = "menuReload";
            this.menuReload.Size = new System.Drawing.Size(124, 22);
            this.menuReload.Text = "刷新";
            this.menuReload.Click += new System.EventHandler(this.menuReload_Click);
            // 
            // menuTemplate
            // 
            this.menuTemplate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddTemplate,
            this.menuRemoveType,
            this.menuRename,
            this.menuImport,
            this.menuExportType,
            this.menuReloadType});
            this.menuTemplate.Name = "menuTemplate";
            this.menuTemplate.Size = new System.Drawing.Size(125, 136);
            // 
            // menuAddTemplate
            // 
            this.menuAddTemplate.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.add;
            this.menuAddTemplate.Name = "menuAddTemplate";
            this.menuAddTemplate.Size = new System.Drawing.Size(124, 22);
            this.menuAddTemplate.Text = "新增模版";
            this.menuAddTemplate.Click += new System.EventHandler(this.menuAddTemplate_Click);
            // 
            // menuRemoveType
            // 
            this.menuRemoveType.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.delete;
            this.menuRemoveType.Name = "menuRemoveType";
            this.menuRemoveType.Size = new System.Drawing.Size(124, 22);
            this.menuRemoveType.Text = "删除分类";
            this.menuRemoveType.Click += new System.EventHandler(this.menuRemoveType_Click);
            // 
            // menuRename
            // 
            this.menuRename.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.rename;
            this.menuRename.Name = "menuRename";
            this.menuRename.Size = new System.Drawing.Size(124, 22);
            this.menuRename.Text = "重命名";
            this.menuRename.Click += new System.EventHandler(this.menuRename_Click);
            // 
            // menuImport
            // 
            this.menuImport.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.import;
            this.menuImport.Name = "menuImport";
            this.menuImport.Size = new System.Drawing.Size(124, 22);
            this.menuImport.Text = "导入模板";
            this.menuImport.Click += new System.EventHandler(this.menuImport_Click);
            // 
            // menuExportType
            // 
            this.menuExportType.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.export;
            this.menuExportType.Name = "menuExportType";
            this.menuExportType.Size = new System.Drawing.Size(124, 22);
            this.menuExportType.Text = "导出模板";
            this.menuExportType.Click += new System.EventHandler(this.menuExportType_Click);
            // 
            // menuReloadType
            // 
            this.menuReloadType.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.refresh;
            this.menuReloadType.Name = "menuReloadType";
            this.menuReloadType.Size = new System.Drawing.Size(124, 22);
            this.menuReloadType.Text = "刷新";
            this.menuReloadType.Click += new System.EventHandler(this.menuReloadType_Click);
            // 
            // menuTemplateInfo
            // 
            this.menuTemplateInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditTemplate,
            this.menuRemoveTemplate});
            this.menuTemplateInfo.Name = "menuTemplateInfo";
            this.menuTemplateInfo.Size = new System.Drawing.Size(125, 48);
            // 
            // menuEditTemplate
            // 
            this.menuEditTemplate.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.edit;
            this.menuEditTemplate.Name = "menuEditTemplate";
            this.menuEditTemplate.Size = new System.Drawing.Size(124, 22);
            this.menuEditTemplate.Text = "编辑模版";
            this.menuEditTemplate.Click += new System.EventHandler(this.menuEditTemplate_Click);
            // 
            // menuRemoveTemplate
            // 
            this.menuRemoveTemplate.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.delete;
            this.menuRemoveTemplate.Name = "menuRemoveTemplate";
            this.menuRemoveTemplate.Size = new System.Drawing.Size(124, 22);
            this.menuRemoveTemplate.Text = "删除模版";
            this.menuRemoveTemplate.Click += new System.EventHandler(this.menuRemoveTemplate_Click);
            // 
            // treeTemplate
            // 
            this.treeTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeTemplate.ImageIndex = 0;
            this.treeTemplate.ImageList = this.imageList;
            this.treeTemplate.Location = new System.Drawing.Point(0, 0);
            this.treeTemplate.Name = "treeTemplate";
            this.treeTemplate.SelectedImageIndex = 0;
            this.treeTemplate.Size = new System.Drawing.Size(300, 284);
            this.treeTemplate.TabIndex = 0;
            // 
            // Template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeTemplate);
            this.Name = "Template";
            this.Size = new System.Drawing.Size(300, 284);
            this.Load += new System.EventHandler(this.Template_Load);
            this.menuType.ResumeLayout(false);
            this.menuTemplate.ResumeLayout(false);
            this.menuTemplateInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private WSH.WinForm.Controls.Tree treeTemplate;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip menuType;
        private System.Windows.Forms.ToolStripMenuItem menuAddType;
        private System.Windows.Forms.ContextMenuStrip menuTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuAddTemplate;
        private System.Windows.Forms.ContextMenuStrip menuTemplateInfo;
        private System.Windows.Forms.ToolStripMenuItem menuEditTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveType;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveTemplate;
        private System.Windows.Forms.ToolStripMenuItem menuRename;
        private System.Windows.Forms.ToolStripMenuItem menuExport;
        private System.Windows.Forms.ToolStripMenuItem menuImport;
        private System.Windows.Forms.ToolStripMenuItem menuExportType;
        private System.Windows.Forms.ToolStripMenuItem menuReload;
        private System.Windows.Forms.ToolStripMenuItem menuReloadType;
    }
}
