using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WSH.Common.Helper;
using System.IO;
using WSH.Common.Configuration;
using WSH.WinForm.Common;

namespace WSH.Tools.Release
{
    public partial class ReleaseFile : Form
    {
        string localPathKey = "ProjectReleaseLocalPath";
        public List<string> ReleaseFileList;
        public string FileBasePath;
        public ReleaseFile()
        {
            InitializeComponent();
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            string path = this.dialogLocal.Text.Trim();
            if (!string.IsNullOrEmpty(path) && ReleaseFileList != null && ReleaseFileList.Count > 0)
            {
                //发布文件到本地服务器
                this.progressBarLocal.Maximum = ReleaseFileList.Count;
                this.progressBarLocal.Value = 0;
                try
                {
                    lbLocal.ForeColor = Color.Gray;
                    for (int i = 0; i < ReleaseFileList.Count; i++)
                    {
                        string filePath = ReleaseFileList[i];
                        string name = Path.GetFileName(filePath);
                        string fullName=Path.Combine(FileBasePath,filePath);
                        this.lbLocal.Text = name;
                        if(File.Exists(fullName)){
                            //创建文件夹
                            this.lbLocal.Text ="正在发布："+ filePath;
                            string copyPath = Path.Combine(path,filePath);
                            FileHelper.CreateFolder(Path.GetDirectoryName(copyPath));
                            File.Copy(fullName, copyPath, true);
                            this.progressBarLocal.Value++;
                        }
                    }
                    this.lbLocal.ForeColor = Color.Red;
                    this.lbLocal.Text = string.Format("发布成功，共发布个{0}文件", ReleaseFileList.Count);
                    MsgBox.Alert("发布成功");
                    this.Close();
                }
                catch (Exception ex)
                {
                    this.lbLocal.ForeColor = Color.Red;
                    this.lbLocal.Text = "发布失败，错误信息：" + ex.Message;
                }
            }
        }

        private void UploadFile_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            string path = state.Get(localPathKey);
            this.dialogLocal.Text = path;
        }

        private void dialogLocal_OnSelectDialogOk(object sender, string url)
        {
            SetState(localPathKey, url);
        }
        void SetState(string key, string value) {
            ConfigurationState state = new ConfigurationState();
            state.Set(key, value);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FileHelper.OpenPath(this.dialogLocal.Text);
        }
    }
}
