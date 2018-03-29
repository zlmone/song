using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.WinForm.Common;
using WSH.Common.Helper;
using System.IO;
using WSH.CodeBuilder.WinForm.Forms.Model;
using WSH.Windows.Common;
using WSH.CodeBuilder.DispatchServers;
using System.Linq;

namespace WSH.CodeBuilder.WinForm.UserControls
{
    public partial class Template : UserControl
    {
        public int TemplateID = -1;
        public static  string TemplateExt = ".template";
        public static  int TemplateRootID = -1;
        public bool IsShowExport = true;
        public bool IsShowCheckBox = false;
        public Template()
        {
            InitializeComponent();
        }
        private void Template_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                return;
            }
            //创建模版目录
            //FileHelper.CreateFolder(TemplateManager.TemplatePath);
            if (!IsShowExport)
            {
                this.menuExport.Enabled = false;
            }
            //设置管理员权限
            if (!Global.User.IsAdmin)
            {
                this.menuRemoveTemplate.Enabled = false;
                this.menuRemoveType.Enabled = false;
                this.menuEditTemplate.Enabled = false;
                this.menuAddTemplate.Enabled = false;
                this.menuAddType.Enabled = false;
                this.menuImport.Enabled = false;
                this.menuExport.Enabled = false;
                this.menuExportType.Enabled = false;
                this.menuRename.Enabled = false;
            }
        }
        private void SetNodeImage(TreeNode node, string key)
        {
            node.ImageKey = key;
            node.SelectedImageKey = key;
            node.StateImageKey = key;
        }
        //绑定模板
        public void DataBind()
        {
            
            if (IsShowCheckBox)
            {
                this.treeTemplate.CheckBoxes = true;
            }
            this.treeTemplate.Nodes.Clear();
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            TreeNode root = new TreeNode()
            {
                Text = "代码模板分类",
                Tag = TemplateRootID,
                ContextMenuStrip = menuType
            };
            SetNodeImage(root, "folder");
            //读取模版分类
            TemplateEntity[] types = service.GetTemplateList(TemplateRootID.ToString());
            foreach (TemplateEntity type in types)
            {
                //如果是指定类型则只绑定执行类型模版
                if (TemplateID > -1 && TemplateID != type.ID)
                {
                    continue;
                }
                TreeNode typeNode = new TreeNode()
                {
                    Text = type.TemplateName,
                    Tag = type.ID,
                    ContextMenuStrip = menuTemplate
                };
                SetNodeImage(typeNode, "folder");
                if (TemplateID > -1)
                {
                    typeNode.Checked = true;
                    root.Checked = true;
                }
                ReBindTemplateNodes(type.ID.ToString(), typeNode);
                root.Nodes.Add(typeNode);
            }

            this.treeTemplate.Nodes.Add(root);
            this.treeTemplate.ExpandAll();
        }
        //重新绑定模板分类下面的模板节点
        public void ReBindTemplateNodes(string typeId, TreeNode typeNode)
        {
            //读取模版文件
            typeNode.Nodes.Clear();
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            TemplateEntity[] templs = service.GetTemplateList(typeId);
            foreach (TemplateEntity templ in templs)
            {
                TreeNode templNode = new TreeNode()
                {
                    Text = templ.TemplateName + TemplateExt,
                    Tag = templ.ID,
                    ContextMenuStrip = menuTemplateInfo
                };
                string key = templ.FileExtensions.Replace(".", "");
                if (key.IndexOf("htm") > -1 && key!="cshtml")
                {
                    key = "html";
                }
                SetNodeImage(templNode, key);
                if (TemplateID > -1)
                {
                    templNode.Checked = true;
                }
                typeNode.Nodes.Add(templNode);
            }
        }
        public string GetSelectedID()
        {
            return this.treeTemplate.SelectedNode.Tag.ToString();
        }
        public TreeNode GetSelectNode()
        {
            return this.treeTemplate.SelectedNode;
        }
        //得到复选框选中的模板文件
        public List<TemplateEntity> GetCheckedFile()
        {
            List<TemplateEntity> list = new List<TemplateEntity>();
            foreach (TreeNode node in this.treeTemplate.Nodes)
            {
                GetChildNodeChecked(list, node);
            }
            return list;
        }
        private void GetChildNodeChecked(List<TemplateEntity> list, TreeNode node)
        {
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            if (node.Text.EndsWith(TemplateExt) && node.Checked)
            {
                list.Add(
                    service.GetTemplateById(node.Tag.ToString())
                );
            }
            foreach (TreeNode item in node.Nodes)
            {
                GetChildNodeChecked(list, item);
            }
        }
        //检查模版文件是否存在，如果不存在，则提示是否创建
        private bool ExistsTemplate(string fileName)
        {
            //if (!File.Exists(fileName))
            //{
            //    if (MsgBox.Confirm("模板文件不存在，是否需要创建？"))
            //    {
            //        //判断文件夹是否创建
            //        string path = Path.GetDirectoryName(fileName);
            //        if (!Directory.Exists(path))
            //        {
            //            Directory.CreateDirectory(path);
            //        }
            //        FileHelper.WriteFile(fileName, "");
            //        return true;
            //    }
            //    return false;
            //}
            return true;
        }
        //删除模版分类
        private void menuRemoveType_Click(object sender, EventArgs e)
        {
            string typeName = treeTemplate.SelectedNode.Text;
            if (DeleteNode("分类"))
            {
                // FileHelper.DeleteFolder(Path.Combine(TemplateManager.TemplatePath, typeName), true);
            }
        }
        //删除模版节点
        private bool DeleteNode(string type)
        {
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            if (MsgBox.Confirm("确定删除该模版" + type + "吗？"))
            {
                if (service.DeleteTemplate(GetSelectedID()))
                {
                    this.treeTemplate.SelectedNode.Remove();
                    return true;
                }
                else
                {
                    MsgBox.Alert("删除模版" + type + "失败！");
                    return false;
                }
            }
            return false;
        }
        //删除模版
        private void menuRemoveTemplate_Click(object sender, EventArgs e)
        {
            TreeNode node = this.treeTemplate.SelectedNode;
            string typeName = node.Parent.Text;
            string templateName = node.Text;
            if (DeleteNode(""))
            {
                // FileHelper.DeleteFile(TemplateManager.GetTemplateFile(templateName, typeName));
            }
        }
        //修改模版
        private void menuEditTemplate_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = this.treeTemplate.SelectedNode;
            string typeName = selectedNode.Parent.Text;
            // string fileName = TemplateManager.GetTemplateFile(selectedNode.Text, typeName);
            //if (ExistsTemplate(fileName))
            //{

            //}
            TemplateEdit edit = new TemplateEdit()
            {
                RecordID = GetSelectedID(),
                TypeName = typeName,
                ParentID = Convert.ToInt32(GetSelectedID()),
                EditMode = WSH.WinForm.Controls.EditMode.Edit
            };
            edit.ShowDialog();
            if (edit.SaveCount > 0)
            {
                DataBind();
            }
        }
        //新增模版
        private void menuAddTemplate_Click(object sender, EventArgs e)
        {
            TemplateEdit edit = new TemplateEdit()
            {
                EditMode = WSH.WinForm.Controls.EditMode.Add,
                ParentID = Convert.ToInt32(GetSelectedID()),
                TypeName = treeTemplate.SelectedNode.Text
            };
            edit.ShowDialog();
            if (edit.SaveCount > 0)
            {
                DataBind();
            }
        }


        private void menuAddType_Click(object sender, EventArgs e)
        {
            Prompt p = new Prompt("模板分类") { 
                 Height=100
            };
            string text = p.Show();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            TemplateEntity entity = new TemplateEntity()
            {
                ParentID = TemplateRootID,
                 Content="",
                 FilePrefix="",
                TemplateName = text
            };
            if (service.AddTemplate(entity) > 0)
            {
                //创建模版目录
                //string path = Path.Combine(TemplateManager.TemplatePath, text);
                //FileHelper.CreateFolder(path);
                DataBind();
            }
            else
            {
                MsgBox.Alert("添加模板分类失败");
            }
        }
        /// <summary>
        /// 模版分类重命名
        /// </summary>
        private void menuRename_Click(object sender, EventArgs e)
        {
            string name = this.treeTemplate.SelectedNode.Text;
            Prompt p = new Prompt("模板分类") { Height = 100, DefaultValue = name };
            string text = p.Show();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }
            CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
            TemplateEntity entity = service.GetTemplateById(GetSelectedID());
            entity.TemplateName = text;
            if (service.UpdateTemplate(entity))
            {
                //DirectoryInfo dir = new DirectoryInfo(TemplateManager.GetTemplateType(name));
                //dir.MoveTo(TemplateManager.GetTemplateType(text));
                this.treeTemplate.SelectedNode.Text = text;
            }
            else
            {
                MsgBox.Alert("模板分类重命名失败！");
            }
        }
        //获取模板导出的文件名
        public string GetTemplateFileName(TemplateEntity templ)
        {
            string[] templateFileName = new string[] { 
                        templ.TemplateName,templ.FileName,templ.FileExtensions
                    };
            string fileName = string.Join("-", templateFileName) + TemplateExt;
            return fileName;
        }
        //解析模板文件名
        public TemplateEntity ParseTemplateFileName(string fileName)
        {
            fileName = Path.GetFileNameWithoutExtension(fileName);
            string[] fileNameInfo = fileName.Split('-');
            TemplateEntity entity = new TemplateEntity()
            {
                TemplateName = fileName,
                FileExtensions = ".cs"
            };
            if (fileNameInfo.Length >= 3)
            {
                entity.TemplateName = fileNameInfo[0];
                entity.FileName = fileNameInfo[1];
                entity.FileExtensions = fileNameInfo[2];
            }
            return entity;
        }
        //导出模板
        private void menuExport_Click(object sender, EventArgs e)
        {
            TemplateExport export = new TemplateExport();
            export.ShowDialog();
        }
        private void menuExportType_Click(object sender, EventArgs e)
        {
            TemplateExport export = new TemplateExport();
            export.TemplateTypeID = GetSelectedID();
            export.ShowDialog();
        }
        //导入模板
        private void menuImport_Click(object sender, EventArgs e)
        {
            string[] fileNames = Dialog.GetFileNames();
            if (fileNames != null && fileNames.Length > 0)
            {
                CodeBuilderService service = ServiceHelper.GetCodeBuilderService();
                bool isReloadTreeNode = false;
                StringBuilder sb = new StringBuilder();
                string parentid=GetSelectedID();
                foreach (string fileName in fileNames)
                {
                    try
                    {
                        TemplateEntity entity = ParseTemplateFileName(fileName);
                        entity.Content = FileHelper.GetFileContent(fileName);
                        entity.ParentID=Convert.ToInt32(parentid);
                        int id = service.AddTemplate(entity);
                        if (id > 0)
                        {
                            isReloadTreeNode = true;
                        }
                        else
                        {
                            sb.AppendLine("文件：" + fileName + "导入失败!");
                        }
                    }
                    catch (Exception ex)
                    {
                        sb.AppendLine("文件：" + fileName + "导入失败，错误信息：" + ex.Message);
                    }
                }
                string errors = sb.ToString();
                if (string.IsNullOrEmpty(errors))
                {
                    MsgBox.Alert("导入成功");
                    if (isReloadTreeNode)
                    {
                        TreeNode typeNode=GetSelectNode();
                        ReBindTemplateNodes(parentid, typeNode);
                        typeNode.ExpandAll();
                    }
                }
                else
                {
                    Utils.ShowErrorDialog(errors);
                }
            }
        }
        //重新绑定树
        private void menuReload_Click(object sender, EventArgs e)
        {
            DataBind();
        }

        private void menuReloadType_Click(object sender, EventArgs e)
        {
            TreeNode node=GetSelectNode();
            ReBindTemplateNodes(GetSelectedID(), node);
            node.ExpandAll();
        }

        
    }
}
