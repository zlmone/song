using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.CodeBuilder.WinForm.Forms.Model;
using WSH.CodeBuilder.WinForm.Common;
using WeifenLuo.WinFormsUI.Docking;
using WSH.Common.Helper;
using WSH.Common.Plugins;
using System.IO;
using WSH.CodeBuilder.WinForm.Forms.Tools;
using System.Reflection;
using WSH.WinForm.Common;
using WSH.Common.Configuration;

namespace WSH.CodeBuilder.WinForm.Forms
{
    public partial class Main : Form
    {
        ModelTree modelTree = new ModelTree();
        TemplateTree template = new TemplateTree();
        Instruction i = new Instruction();
        public Main()
        {
            InitializeComponent();
            ShowLeft(modelTree);
            ShowRight(template);

        }
        public void ShowRight(DockContent f)
        {
            f.Show(this.dockPanel,DockState.DockRight);
        }
        public void ShowCenter(DockContent f,string caption) {
            DockContent content= FindDocument(caption);
            if (content==null)
            {
                content = f;
            }
            content.Show(this.dockPanel);
            content.BringToFront();
            content.ShowHint = DockState.Document;
        }
        public void ShowLeft(DockContent f)
        {
            f.Show(this.dockPanel,DockState.DockLeft);
        }
        private void menuAddProject_Click(object sender, EventArgs e)
        {
            modelTree.AddProject();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(Global.GetCurrentProjectID()))
            {
                ConfigurationState state = new ConfigurationState();
                state.Set("HistoryProjectID", Global.GetCurrentProjectID());
            }
        }

        private void menuReadPdm_Click(object sender, EventArgs e)
        {
            modelTree.ReadPdm(null);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if(!Global.User.IsAdmin){
                this.toolStripButtonUser.Enabled = false;
            }
            LoadCodeFiles();
            LoadPlugins();

            ShowUse();
        }
        #region 创建插件
        private void LoadCodeFiles() {
            //创建代码
            string path = Application.StartupPath + "\\CodeTemplate";
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                ToolStripItem item = new ToolStripMenuItem();
                item.Text = Path.GetFileNameWithoutExtension(file.Name);
                item.Image = imgs.Images[Path.GetExtension(file.Name).TrimStart('.')];
                item.Tag = file.FullName;
                item.Click += (obj, args) =>
                {
                    CodeView view = new CodeView();
                    string fileName = item.Tag.ToString();
                    string code = FileHelper.GetFileContent(fileName);
                    view.Caption = item.Text;
                    view.SetCode(code,PathHelper.GetExtension(fileName));
                    ShowCenter(view,item.Text);
                };
                this.menuCreateCode.DropDownItems.Add(item);
            }
        }
        /// <summary>
        /// 加载插件菜单
        /// </summary>
        private void LoadPlugins() {
            PluginsManager pluginsMgr = new PluginsManager();
            pluginsMgr.Load();
            if (pluginsMgr.Plugins != null && pluginsMgr.Plugins.Count>0)
            {
                foreach (PluginGroupInfo group in pluginsMgr.Plugins)
                {
                    if (group.Plugins.Count > 0)
                    {
                        ToolStripMenuItem item = new ToolStripMenuItem()
                        {
                            Text = group.GroupText,
                            Tag=group.GroupName
                        };
                        foreach (var plugin in group.Plugins)
                        {
                            ToolStripMenuItem subItem = new ToolStripMenuItem()
                            {
                                Text = plugin.Text
                            };
                            subItem.Tag = plugin;
                            subItem.Click += new EventHandler(subItem_Click);
                            item.DropDownItems.Add(subItem);
                        }
                        menuTools.DropDownItems.Add(item);
                    }
                }
            }
        }
        #endregion
        //点击插件菜单，弹出插件
        void subItem_Click(object sender, EventArgs e)
        {
            PluginInfo plugin = ((ToolStripItem)sender).Tag as PluginInfo;
            FormPlugins.ShowDialog(plugin.Group.GroupName,plugin.Name);
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            ShowRight(template);
        }

        private void btnConnection_Click(object sender, EventArgs e)
        {
            ConnectionEdit conn = new ConnectionEdit() { 
                 EditMode= WSH.WinForm.Controls.EditMode.Edit
            };
            conn.ShowDialog();
        }

        private void toolStripButtonUser_Click(object sender, EventArgs e)
        {
            UserList user = new UserList();
            user.EditMode = WSH.WinForm.Controls.EditMode.Edit;
            user.ShowDialog();
        }

        private void toolStripButtonSystemSetting_Click(object sender, EventArgs e)
        {
            SystemConfig sys = new SystemConfig();
            sys.EditMode = WSH.WinForm.Controls.EditMode.Edit;
            sys.ShowDialog();
        }

        #region DockPanel管理
        public DockContent FindDocument(string text) {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as DockContent;

                return null;
            }
            else
            {
                foreach (DockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }
        public DockContent ShowContent(string caption, Type formType)
        {
            DockContent frm = FindDocument(caption);
            if (frm == null)
            {
                frm=Assembly.Load(Assembly.GetExecutingAssembly().GetName().Name).CreateInstance(formType.Name) as DockContent;
            }
            frm.Show(this.dockPanel);
            frm.BringToFront();
            return frm;
        }
        public void CloseOtherDocuments() {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                    {
                        form.Close();
                    }
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                    {
                        document.DockHandler.Close();
                    }
                }
            }
        }
        public void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                {
                    form.Close();
                }
            }
            else
            {
                IDockContent[] documents = dockPanel.DocumentsToArray();
                foreach (IDockContent content in documents)
                {
                    content.DockHandler.Close();
                }
            }
        }
        private void LoadDockPanelConfig() {
            var m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            if (File.Exists(configFile))
            {
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            }
        }
        private IDockContent GetContentFromPersistString(string persistString)
        {
            return null;
        }
        private void SaveDockPanelConfig() {
            string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
            dockPanel.SaveAsXml(configFile);
             
        }
        #endregion

        private void toolModel_Click(object sender, EventArgs e)
        {
            ShowLeft(modelTree);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void menuDirection_Click(object sender, EventArgs e)
        {
            ShowUse();
        }
        private void ShowUse() {
            ShowCenter(i, "使用说明");
        }
    }
}
