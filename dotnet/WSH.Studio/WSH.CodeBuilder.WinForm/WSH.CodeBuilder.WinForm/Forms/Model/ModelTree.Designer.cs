namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    partial class ModelTree
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModelTree));
            this.treeModel = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.menuProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuEditProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProjectCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReadPdm = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReadDb = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTables = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeleteTables = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuExportImport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTableCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReadDbInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRemoveTable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuAddProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReloadProject = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReloadTables = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProject.SuspendLayout();
            this.menuTables.SuspendLayout();
            this.menuTable.SuspendLayout();
            this.menuRoot.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeModel
            // 
            this.treeModel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeModel.ImageIndex = 0;
            this.treeModel.ImageList = this.imgList;
            this.treeModel.Location = new System.Drawing.Point(3, 31);
            this.treeModel.Name = "treeModel";
            this.treeModel.SelectedImageIndex = 0;
            this.treeModel.Size = new System.Drawing.Size(335, 381);
            this.treeModel.TabIndex = 0;
            this.treeModel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeModel_MouseDown);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "column");
            this.imgList.Images.SetKeyName(1, "project");
            this.imgList.Images.SetKeyName(2, "root");
            this.imgList.Images.SetKeyName(3, "table");
            this.imgList.Images.SetKeyName(4, "tables");
            this.imgList.Images.SetKeyName(5, "view");
            this.imgList.Images.SetKeyName(6, "views");
            this.imgList.Images.SetKeyName(7, "folder");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目：";
            // 
            // cboProject
            // 
            this.cboProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(60, 5);
            this.cboProject.Name = "cboProject";
            this.cboProject.Size = new System.Drawing.Size(268, 20);
            this.cboProject.TabIndex = 2;
            this.cboProject.SelectedValueChanged += new System.EventHandler(this.cboProject_SelectedValueChanged);
            // 
            // menuProject
            // 
            this.menuProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditProject,
            this.menuDoc,
            this.menuProjectCode,
            this.menuReadPdm,
            this.menuReadDb,
            this.menuRemoveProject,
            this.menuReloadProject});
            this.menuProject.Name = "menuProject";
            this.menuProject.Size = new System.Drawing.Size(151, 158);
            // 
            // menuEditProject
            // 
            this.menuEditProject.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.edit_project;
            this.menuEditProject.Name = "menuEditProject";
            this.menuEditProject.Size = new System.Drawing.Size(150, 22);
            this.menuEditProject.Text = "编辑项目";
            this.menuEditProject.Click += new System.EventHandler(this.menuEditProject_Click);
            // 
            // menuDoc
            // 
            this.menuDoc.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.document;
            this.menuDoc.Name = "menuDoc";
            this.menuDoc.Size = new System.Drawing.Size(150, 22);
            this.menuDoc.Text = "数据库文档";
            this.menuDoc.Click += new System.EventHandler(this.menuDoc_Click);
            // 
            // menuProjectCode
            // 
            this.menuProjectCode.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.codebuilder;
            this.menuProjectCode.Name = "menuProjectCode";
            this.menuProjectCode.Size = new System.Drawing.Size(150, 22);
            this.menuProjectCode.Text = "生成代码";
            this.menuProjectCode.Click += new System.EventHandler(this.menuProjectCode_Click);
            // 
            // menuReadPdm
            // 
            //this.menuReadPdm.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.add_pdm;
            this.menuReadPdm.Name = "menuReadPdm";
            this.menuReadPdm.Size = new System.Drawing.Size(150, 22);
            this.menuReadPdm.Text = "读取Pdm文件";
            this.menuReadPdm.Click += new System.EventHandler(this.menuReadPdm_Click);
            // 
            // menuReadDb
            // 
            this.menuReadDb.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.database_connect;
            this.menuReadDb.Name = "menuReadDb";
            this.menuReadDb.Size = new System.Drawing.Size(150, 22);
            this.menuReadDb.Text = "读取数据库";
            this.menuReadDb.Click += new System.EventHandler(this.menuReadDb_Click);
            // 
            // menuRemoveProject
            // 
            this.menuRemoveProject.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.delete_project;
            this.menuRemoveProject.Name = "menuRemoveProject";
            this.menuRemoveProject.Size = new System.Drawing.Size(150, 22);
            this.menuRemoveProject.Text = "删除项目";
            this.menuRemoveProject.Click += new System.EventHandler(this.menuRemoveProject_Click);
            // 
            // menuTables
            // 
            this.menuTables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddTable,
            this.menuDeleteTables,
            this.menuReloadTables});
            this.menuTables.Name = "menuTables";
            this.menuTables.Size = new System.Drawing.Size(153, 92);
            // 
            // menuAddTable
            // 
            this.menuAddTable.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.table_add;
            this.menuAddTable.Name = "menuAddTable";
            this.menuAddTable.Size = new System.Drawing.Size(152, 22);
            this.menuAddTable.Text = "添加表";
            this.menuAddTable.Click += new System.EventHandler(this.menuAddTable_Click);
            // 
            // menuDeleteTables
            // 
            this.menuDeleteTables.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.table_delete;
            this.menuDeleteTables.Name = "menuDeleteTables";
            this.menuDeleteTables.Size = new System.Drawing.Size(152, 22);
            this.menuDeleteTables.Text = "删除表";
            this.menuDeleteTables.Click += new System.EventHandler(this.menuDeleteTables_Click);
            // 
            // menuTable
            // 
            this.menuTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExportImport,
            this.menuEditTable,
            this.menuEditColumn,
            this.menuTableCode,
            this.menuReadDbInfo,
            this.menuRemoveTable});
            this.menuTable.Name = "menuTable";
            this.menuTable.Size = new System.Drawing.Size(161, 136);
            // 
            // menuExportImport
            // 
            this.menuExportImport.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.import_export;
            this.menuExportImport.Name = "menuExportImport";
            this.menuExportImport.Size = new System.Drawing.Size(160, 22);
            this.menuExportImport.Text = "导入导出数据";
            this.menuExportImport.Click += new System.EventHandler(this.menuTableExcel_Click);
            // 
            // menuEditTable
            // 
            this.menuEditTable.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.table_edit;
            this.menuEditTable.Name = "menuEditTable";
            this.menuEditTable.Size = new System.Drawing.Size(160, 22);
            this.menuEditTable.Text = "编辑表";
            this.menuEditTable.Click += new System.EventHandler(this.menuEditTable_Click);
            // 
            // menuEditColumn
            // 
            this.menuEditColumn.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.columns;
            this.menuEditColumn.Name = "menuEditColumn";
            this.menuEditColumn.Size = new System.Drawing.Size(160, 22);
            this.menuEditColumn.Text = "编辑列";
            this.menuEditColumn.Click += new System.EventHandler(this.menuEditColumn_Click);
            // 
            // menuTableCode
            // 
            this.menuTableCode.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.codebuilder;
            this.menuTableCode.Name = "menuTableCode";
            this.menuTableCode.Size = new System.Drawing.Size(160, 22);
            this.menuTableCode.Text = "生成代码";
            this.menuTableCode.Click += new System.EventHandler(this.menuTableCode_Click);
            // 
            // menuReadDbInfo
            // 
            this.menuReadDbInfo.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.database_refresh;
            this.menuReadDbInfo.Name = "menuReadDbInfo";
            this.menuReadDbInfo.Size = new System.Drawing.Size(160, 22);
            this.menuReadDbInfo.Text = "读取数据库字段";
            this.menuReadDbInfo.Click += new System.EventHandler(this.menuReadDbInfo_Click);
            // 
            // menuRemoveTable
            // 
            this.menuRemoveTable.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.table_delete;
            this.menuRemoveTable.Name = "menuRemoveTable";
            this.menuRemoveTable.Size = new System.Drawing.Size(160, 22);
            this.menuRemoveTable.Text = "删除表";
            this.menuRemoveTable.Click += new System.EventHandler(this.menuRemoveTable_Click);
            // 
            // menuRoot
            // 
            this.menuRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddProject});
            this.menuRoot.Name = "menuRoot";
            this.menuRoot.Size = new System.Drawing.Size(125, 26);
            // 
            // menuAddProject
            // 
            this.menuAddProject.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.add_project;
            this.menuAddProject.Name = "menuAddProject";
            this.menuAddProject.Size = new System.Drawing.Size(124, 22);
            this.menuAddProject.Text = "添加项目";
            this.menuAddProject.Click += new System.EventHandler(this.menuAddProject_Click);
            // 
            // menuReloadProject
            // 
            this.menuReloadProject.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.refresh;
            this.menuReloadProject.Name = "menuReloadProject";
            this.menuReloadProject.Size = new System.Drawing.Size(150, 22);
            this.menuReloadProject.Text = "刷新";
            this.menuReloadProject.Click += new System.EventHandler(this.menuReloadProject_Click);
            // 
            // menuReloadTables
            // 
            this.menuReloadTables.Image = global::WSH.CodeBuilder.WinForm.Properties.Resources.refresh;
            this.menuReloadTables.Name = "menuReloadTables";
            this.menuReloadTables.Size = new System.Drawing.Size(152, 22);
            this.menuReloadTables.Text = "刷新";
            this.menuReloadTables.Click += new System.EventHandler(this.menuReloadTables_Click);
            // 
            // ModelTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 413);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeModel);
            this.HideOnClose = true;
            this.Name = "ModelTree";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            this.TabText = "数据模型";
            this.Text = "数据模型";
            this.Load += new System.EventHandler(this.ModelTree_Load);
            this.menuProject.ResumeLayout(false);
            this.menuTables.ResumeLayout(false);
            this.menuTable.ResumeLayout(false);
            this.menuRoot.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip menuProject;
        private System.Windows.Forms.ToolStripMenuItem menuEditProject;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveProject;
        private System.Windows.Forms.ToolStripMenuItem menuDoc;
        private System.Windows.Forms.ToolStripMenuItem menuProjectCode;
        private System.Windows.Forms.ContextMenuStrip menuTables;
        private System.Windows.Forms.ToolStripMenuItem menuAddTable;
        private System.Windows.Forms.ContextMenuStrip menuTable;
        private System.Windows.Forms.ToolStripMenuItem menuExportImport;
        private System.Windows.Forms.ToolStripMenuItem menuEditTable;
        private System.Windows.Forms.ToolStripMenuItem menuRemoveTable;
        private System.Windows.Forms.ToolStripMenuItem menuEditColumn;
        private System.Windows.Forms.ToolStripMenuItem menuTableCode;
        private System.Windows.Forms.ContextMenuStrip menuRoot;
        private System.Windows.Forms.ToolStripMenuItem menuAddProject;
        private System.Windows.Forms.ToolStripMenuItem menuReadPdm;
        private System.Windows.Forms.ToolStripMenuItem menuReadDbInfo;
        private System.Windows.Forms.ToolStripMenuItem menuReadDb;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteTables;
        private System.Windows.Forms.ToolStripMenuItem menuReloadProject;
        private System.Windows.Forms.ToolStripMenuItem menuReloadTables;
    }
}