using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.Windows.Common;
using System.IO;

namespace WSH.WinForm.Controls
{
    public partial class SelectDialog : UserControl
    {
        public SelectDialog()
        {
            InitializeComponent();
        }
        public override string Text {
            get { return this.txtFile.Text.Trim(); }
            set {
                bool isExists = true;
                if(type== DialogType.File){
                    if (!File.Exists(value)) {
                        isExists = false;
                    }
                }
                if(type== DialogType.Folder){
                    if(!Directory.Exists(value)){
                        isExists = false;
                    }
                }
                this.txtFile.Text = isExists ? value : string.Empty;
            }
        }
        private DialogType type = DialogType.File;
        /// <summary>
        /// 选择文件还是选择文件夹，默认选择文件
        /// </summary>
        public DialogType Type
        {
            get { return type; }
            set { type = value; }
        }
        private string filter=FileFilter.Excel;

        public string Filter
        {
            get { return filter; }
            set { filter = value; }
        }
       
        private string title;
        /// <summary>
        /// 对话框标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 是否可以编辑
        /// </summary>
        public bool ReadOnly
        {
            get { return this.txtFile.ReadOnly; }
            set { this.txtFile.ReadOnly = value; }
        }
        public delegate void SelectDialogOkHandler(object sender, string url);
        public event SelectDialogOkHandler OnSelectDialogOk;
        public void SetDefaultSaveFileName(string name)
        {
            this.saveFile.FileName = name;
        }
        #region 拖入文件
        private void txtPath_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void txtPath_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = Path.GetExtension(path);
            if (this.Filter.IndexOf(ext) != -1 || this.Filter==FileFilter.All)
            {
                this.Text = path;
            }
        }
        #endregion

        private void buttonImage1_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.No;
            if (this.Type == DialogType.File)
            {
                this.dialogFile.Filter = Filter;
                result = this.dialogFile.ShowDialog();
            }
            else if (Type == DialogType.Folder)
            {
                if (!string.IsNullOrEmpty(Title))
                {
                    this.dialogFolder.Description = Title;
                }
                result = this.dialogFolder.ShowDialog();
            }
            else
            {
                saveFile.Filter = Filter;
                result = saveFile.ShowDialog();
            }
            if (result == DialogResult.OK)
            {
                if (this.Type == DialogType.Save)
                {
                    this.Text = this.saveFile.FileName;
                }
                else
                {
                    this.Text = this.Type == DialogType.File ? this.dialogFile.FileName : this.dialogFolder.SelectedPath;
                }
                if (OnSelectDialogOk != null)
                {
                    OnSelectDialogOk(this, this.Text.Trim());
                }
            }
        }

         
    }
}
