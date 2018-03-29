using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using System.IO;
using System.Xml;
using ICSharpCode.TextEditor.Document;
using System.Text.RegularExpressions;
using WSH.Common.Configuration;

namespace WSH.Tools.Release
{
    public partial class ProjectRelease : Form
    {
        string dialogKey = "ProjectReleaseFilePath";
        string saveDialogKey = "ProjectReleaseSaveFileName";
        string filterFileKey = "ProjectReleaseFilterFile";
        string urlKey = "ProjectReleaseUrl";
        string defaultXmlName = "AutoUpdateService.xml";
        List<string> ReleaseFileList;
        public ProjectRelease()
        {
            InitializeComponent();
            this.selectDialog1.Type = Windows.Common.DialogType.Folder;
            #region 设置编辑器
            txtConfig.ShowEOLMarkers = false;
            txtConfig.ShowHRuler = false;
            txtConfig.ShowInvalidLines = false;
            txtConfig.ShowSpaces = false;
            txtConfig.ShowTabs = false;
            txtConfig.ShowVRuler = false;
            txtConfig.AllowCaretBeyondEOL = false;
            txtConfig.ShowMatchingBracket = true;
            txtConfig.AutoScroll = true;
            txtConfig.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategyForFile(".xml");
            txtConfig.Encoding = System.Text.Encoding.Default;
            #endregion
            this.dialogExport.SetDefaultSaveFileName(defaultXmlName);
            this.WindowState = FormWindowState.Maximized;
        }

        private void ProjectRelease_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            string fileName = state.Get(dialogKey);
            string saveFileName = state.Get(saveDialogKey);
            string url = state.Get(urlKey);
            this.selectDialog1.Text = fileName;
            this.dialogExport.Text = saveFileName;
            string filter = state.Get(filterFileKey);
            this.txtFilterFile.Text = string.IsNullOrEmpty(filter) ? "pdb,old" : filter;
            this.txtUrl.Text = url;
        }

        private void selectDialog1_OnSelectDialogOk(object sender, string url)
        {
            UpdateState(dialogKey, url);
        }
        private void dialogExport_OnSelectDialogOk(object sender, string url)
        {
            UpdateState(saveDialogKey, url);
        }
        #region 展示文件目录对应的树节点
        private void ShowDirectoryNode(DirectoryInfo dirInfo, TreeNode pntNode)
        {
            List<string> filterList=GetFilterFile();
            TreeNode node = new TreeNode(dirInfo.Name, 2, 3);
            node.Checked = true;
            node.Tag = "0";     //0表示文件夹， 1表示文件
            SetTreeNode(node, "folder");
            if (pntNode == null)
            {
                treeDlls.Nodes.Add(node);
            }
            else
            {
                pntNode.Nodes.Add(node);
            }
            DirectoryInfo[] childDirs = dirInfo.GetDirectories();
            foreach (DirectoryInfo childDir in childDirs)
            {
                ShowDirectoryNode(childDir, node);
            }
            FileInfo[] files = dirInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                if (filterList.Contains(PathHelper.GetExtension(file.Name)))
                {
                    continue;
                }
                TreeNode fileNode = new TreeNode(file.Name, 0, 1);
                fileNode.Checked = true;
                fileNode.Tag = "1";
                fileNode.ToolTipText = file.FullName;
                SetTreeNode(fileNode, Path.GetExtension(file.Name).Replace(".", ""));
                node.Nodes.Add(fileNode);
            }
        }
        void SetTreeNode(TreeNode node, string key)
        {
            key = key + ".png";
            node.ImageKey = key;
            node.SelectedImageKey = key;
            node.StateImageKey = key;
        }
        private void buttonImage1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.selectDialog1.Text))
            {
                return;
            }
            ConfigurationState state = new ConfigurationState();
            string fileName = state.Get(dialogKey);
            if (fileName != this.selectDialog1.Text)
            {
                state.Set(dialogKey, this.selectDialog1.Text);
            }
            treeDlls.Nodes.Clear();
            DirectoryInfo rootDir = new DirectoryInfo(this.selectDialog1.Text);
            ShowDirectoryNode(rootDir, null);
            treeDlls.ExpandAll();
        }
        #endregion
        /// <summary>
        /// 生成更新的配置文件
        /// </summary>
        private void btnUpdateConfig_Click(object sender, EventArgs e)
        {
            TreeNodeCollection nodes = this.treeDlls.Nodes;
            if (nodes != null && nodes.Count > 0)
            {
                UpdateConfig update = new UpdateConfig();
                update.DefaultXmlName = defaultXmlName;
                update.FilePath = this.selectDialog1.Text;
                update.SaveFileName = this.dialogExport.Text;
                update.Url = this.txtUrl.Text.Trim();
                update.Create(nodes);
                ReleaseFileList = update.ReleaseFileList;
                this.txtConfig.LoadFile(update.SaveFileName);
            }
        }
        void UpdateState(string key, string value)
        {
            ConfigurationState state = new ConfigurationState();
            state.Set(key, value);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateState(filterFileKey, this.txtFilterFile.Text.Trim());
        }
        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            UpdateState(urlKey, this.txtUrl.Text.Trim());
        }
        //获取过滤文件类型
        List<string> GetFilterFile()
        {
            List<string> list = new List<string>();
            string text = this.txtFilterFile.Text.Trim();
            if (!string.IsNullOrEmpty(text))
            {
                list.AddRange(Regex.Split(text, ",|，+"));
            }
            return list;
        }

        private void buttonImage3_Click(object sender, EventArgs e)
        {
            ReleaseFile release = new ReleaseFile();
            release.StartPosition = FormStartPosition.CenterScreen;
            release.FileBasePath = this.selectDialog1.Text;
            release.ReleaseFileList = ReleaseFileList;
            release.ShowDialog();
        }
    }
}
