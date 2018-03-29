using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WSH.Common.Helper;
using ICSharpCode.TextEditor.Document;
using WSH.CodeBuilder.WinForm.Common;
using WSH.WinForm.Common;
using WSH.Windows.Common;

namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    public partial class CodeView : DocumentForm
    {
        public string FileName;
        public string Extension=".cs";
        public string Caption = "代码";
        public CodeView()
        {
            InitializeComponent();
            
            Utils.SetTextEditor(this.txtCode);
        }
        public void SetCode(string code,string ext) {
            this.txtCode.Text = code;
            if (!string.IsNullOrEmpty(ext))
            {
                Extension = "." + ext;
            }
            Utils.SetEditorLang(this.txtCode,ext);
        }
        public void SetCode(string fileName) {
            this.FileName = fileName;
            this.txtCode.LoadFile(fileName,true,true);
        }

        #region 代码编辑器右键操作
        private void menuSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FileName))
            {
                FileName = Dialog.GetSaveFile(Caption + Extension);
            }
            if (!string.IsNullOrEmpty(FileName))
            {
                this.txtCode.SaveFile(FileName);
            }
        }

        private void menuCopy_Click(object sender, EventArgs e)
        {
            string text=this.txtCode.ActiveTextAreaControl.SelectionManager.SelectedText;
            if(!string.IsNullOrEmpty(text)){
                Clipboard.SetDataObject(text); 
            }
        }
        private void menuCopyAll_Click(object sender, EventArgs e)
        {
            string text=this.txtCode.Text;
            if(!string.IsNullOrEmpty(text)){
                Clipboard.SetDataObject(text); 
            }
        }
        private void menuPaste_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {
                string text=(String)iData.GetData(DataFormats.Text);
                this.txtCode.ActiveTextAreaControl.TextArea.InsertString(text);
            }
        }
        #endregion

        private void CodeView_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Caption))
            {
                this.Text = Caption;
                this.TabText = Caption;
            }
        }
    }
}
