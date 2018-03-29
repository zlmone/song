using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WSH.CodeBuilder.Common;
using WSH.Common.Helper;
using WSH.WinForm.Common;
using WSH.WinForm.Controls;
using WeifenLuo.WinFormsUI.Docking;
using WSH.Windows.Common;
using WSH.CodeBuilder.WinForm.Common;
using WSH.CodeBuilder.WinForm.Forms.Tools;
using WSH.Tools.Connection;
using WSH.Options.Common;
using WSH.Tools.Connection.DB;
using WSH.CodeBuilder.DispatchServers;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms.Model
{
    public partial class ModelTree : DockContent
    {
        #region 初始化
        ConfigurationState state = new ConfigurationState();
        CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
        public bool IsReloadTree = true;
        #endregion

        #region 加载
        public ModelTree()
        {
            InitializeComponent();
            this.HideOnClose = true;
        }

        private void ModelTree_Load(object sender, EventArgs e)
        {
            IsReloadTree = false;
            DataTable dt = BindProjectList();
            string id = state.Get("HistoryProjectID");
            //查询项目是否已经删除
            if (!string.IsNullOrEmpty(id))
            {
                if(dt!=null){
                    if (dt.Select("ID="+id).Length>0)
                    {
                        this.cboProject.SelectedValue = id;  
                    }
                }
            }
            object pid = this.cboProject.SelectedValue;
            IsReloadTree = true;
            if (pid != null)
            {
                BindModelTree(pid.ToString());
            }
        }
        #endregion

        #region 数据绑定
        private DataTable BindProjectList()
        {
           DataTable list = service.GetProjectDataTable();
           
            DataBind.BindCombox(this.cboProject, list, "ProjectName", "ID");
            return list;
        }
        private void SetNodeImage(TreeNode node, string key)
        {
            node.ImageKey = key;
            node.SelectedImageKey = key;
            node.StateImageKey = key;
        }
        private TreeNode GetSelectedNode()
        {
            return this.treeModel.SelectedNode;
        }
        private string GetNodeTag() {
            return GetSelectedNode().Tag.ToString();
        }
        #region 右键选中树节点
        private void treeModel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                TreeNode node = this.treeModel.GetNodeAt(e.X, e.Y);
                if (node != null)
                {
                    this.treeModel.SelectedNode = node;
                }
            }
        }
        #endregion
        public TreeNode GetTableNode(TableEntity table) {
            TreeNode tableNode = new TreeNode();
            tableNode.Text = table.TableName;
            tableNode.Tag = table.ID;
            tableNode.ToolTipText = table.TableName;
            tableNode.ContextMenuStrip = this.menuTable;
            SetNodeImage(tableNode, "table");
            return tableNode;
        }
        private void BindModelTree(string projectid)
        {
            if (!IsReloadTree)
            {
                return;
            }
            if (!string.IsNullOrEmpty(projectid))
            {
                this.treeModel.Nodes.Clear();
                WSH.CodeBuilder.DispatchServers.ProjectEntity project = service.GetProjectById(projectid);
                Global.SetCurrentProject(project);
                TreeNode root = new TreeNode();
                root.Text = "项目集合";
                root.Tag = "root";
                root.ContextMenuStrip = this.menuRoot;
                SetNodeImage(root, "root");
                //绑定项目
                TreeNode projectNode = new TreeNode();
                projectNode.Text = project.ProjectName;
                projectNode.Tag = project.ID;
                projectNode.ContextMenuStrip = this.menuProject;
                SetNodeImage(projectNode, "project");
                //绑定表集合
                TreeNode tablesNode = new TreeNode();
                tablesNode.Tag = "tables";
                tablesNode.ContextMenuStrip = this.menuTables;
                SetNodeImage(tablesNode, "folder");
                //绑定表
                BindTablesNode(tablesNode, projectid);
                projectNode.Nodes.Add(tablesNode);
                ////绑定视图集合
                //TreeNode viewsNode = new TreeNode();
                //viewsNode.Text = "Views";
                //viewsNode.Tag = "views";
                //SetNodeImage(viewsNode, "folder");
                //projectNode.Nodes.Add(viewsNode);
                ////绑定存储过程集合
                //TreeNode procsNode = new TreeNode();
                //procsNode.Text = "Procs";
                //procsNode.Tag = "procs";
                //SetNodeImage(procsNode, "folder");
                //projectNode.Nodes.Add(procsNode);
                root.Nodes.Add(projectNode);
                this.treeModel.Nodes.Add(root);
                //展开树
                this.treeModel.ExpandAll();
            }
        }
        public void BindTablesNode(TreeNode tablesNode,string projectid) {
            tablesNode.Nodes.Clear();
            TableEntity[] tables = service.GetTableList(projectid);
            tablesNode.Text = "Tables(" + tables.Length + ")";
            foreach (TableEntity table in tables)
            {
                tablesNode.Nodes.Add(GetTableNode(table));
            }
        }
        #endregion

        #region 切换项目
        private void cboProject_SelectedValueChanged(object sender, EventArgs e)
        {
            object value = this.cboProject.SelectedValue;
            if (value != null)
            {
                BindModelTree(value.ToString());
            }
        }
        #endregion

        #region 项目操作
        public void ClearProject() {
            this.treeModel.Nodes.Clear();
            Global.SetCurrentProject(new ProjectEntity());
        }
        //绑定当前项目-Project
        public void SetProject(string projectid)
        {
            Global.ConnectionString = string.Empty;

            IsReloadTree = false;
            this.BindProjectList();
            IsReloadTree = true;
            if (this.cboProject.SelectedValue.Equals(projectid))
            {
                this.cboProject.SelectedValue = projectid;
            }
            else {
                BindModelTree(projectid);
            }
        }
        //新增项目-Project
        public void AddProject()
        {
            ProjectEdit form = new ProjectEdit();
            form.ShowDialog();
            if (form.SaveCount > 0)
            {
                SetProject(form.RecordID);
            }
        }
        private void menuAddProject_Click(object sender, EventArgs e)
        {
            AddProject();
        }
        //编辑项目-Project
        private void menuEditProject_Click(object sender, EventArgs e)
        {
            ProjectEdit form = new ProjectEdit();
            form.EditMode = EditMode.Edit;
            form.RecordID = Global.GetCurrentProjectID();
            form.ShowDialog();
            if (form.SaveCount > 0)
            {
                GetSelectedNode().Text = form.ProjectName;
            }
        }
        //删除项目-Project
        private void menuRemoveProject_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("确定要删除该项目吗？"))
            {
                if (service.DeleteProject(Global.GetCurrentProjectID()))
                {
                    this.BindProjectList();
                    if(this.cboProject.Items.Count<=0){
                        ClearProject();
                    }
                }
                else
                {
                    MsgBox.Alert("删除项目失败");
                }
            }
        }
        //读取Pdm文件-Project (判断表名是否已存在，不存在则添加)
        private void menuReadPdm_Click(object sender, EventArgs e)
        {
            ReadPdm(GetSelectedNode().Tag.ToString());
        }
        
        //数据库文档-Project
        private void menuDoc_Click(object sender, EventArgs e)
        {
            DbDocument doc = new DbDocument();
            doc.ShowDialog();
        }
        //生成代码-Project
        private void menuProjectCode_Click(object sender, EventArgs e)
        {
            Tools.CodeBuilder cb = new Tools.CodeBuilder();
            cb.ShowDialog();
        }
        //读取数据库
        private void menuReadDb_Click(object sender, EventArgs e)
        {
            ReadDbTables();
        }
        #endregion

        #region 读取Pdm文件
        public void ReadPdm(string projectid)
        {
            ReaderPdm reader = new ReaderPdm();
            reader.ShowDialog();
            if (reader.IsReload)
            {
                BindModelTree(Global.GetCurrentProjectID());
            }
        }
        
        #endregion

        #region 表操作
        //删除表-Table
        private void menuRemoveTable_Click(object sender, EventArgs e)
        {
            if (MsgBox.Confirm("确定删除该表吗？"))
            {
                string tableid = GetNodeTag();
                if (service.DeleteTable(tableid))
                {
                    GetSelectedNode().Remove();
                }
                else {
                    MsgBox.Alert("删除表失败！");
                }
            }
        }
        
        //导入导出
        private void menuTableExcel_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDbConnection())
            {
                DataProcessing data = new DataProcessing();
                data.TableName = GetSelectedNode().ToolTipText;
                data.ShowDialog();
            }
        }
        //编辑表-Table
        private void menuEditTable_Click(object sender, EventArgs e)
        {
            TableEdit te = new TableEdit(); 
            te.RecordID = GetNodeTag();
            te.EditMode = EditMode.Edit;
            te.ShowDialog();
            if(te.SaveCount>0){
                UpdateTableNode(new TableEntity() { TableName=te.TableName });
            }
        }
        private void UpdateTableNode(TableEntity table) {
            if (table != null && !string.IsNullOrEmpty(table.TableName))
            {
                TreeNode node = GetSelectedNode();
                node.Text = table.TableName;
                node.ToolTipText = table.TableName;
            }
        } 
        //编辑列-Table
        private void menuEditColumn_Click(object sender, EventArgs e)
        {
            ColumnEdit ce = new ColumnEdit();
            ce.Text =GetSelectedNode().ToolTipText+ "-字段编辑";
            ce.TableID = GetNodeTag();
            ce.ShowDialog();
        }
        
        //生成代码-Table
        private void menuTableCode_Click(object sender, EventArgs e)
        {
            Tools.CodeBuilder builder = new Tools.CodeBuilder() {
                TableID = GetNodeTag()
            };
            builder.ShowDialog();
        }
        //读取数据库字段
        private void menuReadDbInfo_Click(object sender, EventArgs e)
        {
            if (Utils.CheckDbConnection())
            {
                string tableName = GetSelectedNode().ToolTipText;
                ReaderDbTables reader = new ReaderDbTables();
                reader.TableName = tableName;
                reader.ShowDialog();
            }
        }
        #endregion

        #region 表集合操作
        private void ReadDbTables() {
            if (Utils.CheckDbConnection())
            {
                ReaderDbTables frm = new ReaderDbTables();
                frm.ShowDialog();
                if (frm.SuccessCount > 0)
                {
                    IsReloadTree = true;
                    BindModelTree(Global.GetCurrentProjectID());
                }
            }
        }
        //添加表-Tables
        private void menuAddTable_Click(object sender, EventArgs e)
        {
            TableEdit te = new TableEdit();
            te.ShowDialog();
            if(te.SaveCount>0){
                TreeNode node = GetTableNode(new TableEntity(){ID=Convert.ToInt32(te.RecordID),TableName=te.TableName});
                GetSelectedNode().Nodes.Add(node);
                this.treeModel.SelectedNode = node;
            }
        }
        //批量删除表
        private void menuDeleteTables_Click(object sender, EventArgs e)
        {
            DeleteTables dt = new DeleteTables();
            dt.ShowDialog();
            if (dt.SuccessCount>0)
            {
                this.BindTablesNode(GetSelectedNode(), Global.GetCurrentProjectID());
            }
        }
        #endregion
        public void ShowCenter(DockContent content,string caption) {
            ((Main)ParentForm).ShowCenter(content, caption);
        }

        private void menuReloadProject_Click(object sender, EventArgs e)
        {
            BindModelTree(Global.GetCurrentProjectID());
        }

        private void menuReloadTables_Click(object sender, EventArgs e)
        {
            BindTablesNode(GetSelectedNode(),Global.GetCurrentProjectID());
        }
    }
}
