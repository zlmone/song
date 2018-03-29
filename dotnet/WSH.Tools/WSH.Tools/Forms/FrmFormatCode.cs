using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace WSH.Tools
{
    public partial class FrmFormatCode : Form
    {
        public FrmFormatCode()
        {
            InitializeComponent();
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Modifiers.CompareTo(Keys.Control) == 0 &&  e.KeyCode == Keys.S)
            //{
                
                
            //}
        }

        private void menuFmt_Click(object sender, EventArgs e)
        {
            //string text=this.txtCode.Text;
            //text = Regex.Replace(text, @"[/\r/\n]+", "\r\n");
            //this.txtCode.Text = Regex.Replace(text, @"^\d+\.","").Trim();
            string[] lines = this.txtCode.Lines;
            if (lines.Length <= 0 || this.txtCode.Text.Trim() == string.Empty)
            {
                return;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (!string.IsNullOrEmpty(line.Trim()))
                {
                    sb.AppendLine(Regex.Replace(line, @"^\d+\.", ""));
                }
            }
            string value = sb.ToString().Trim();
            this.txtCode.Text = value;
            CopyCode(value);
        }
        public void CopyCode(string txt) {
            Clipboard.SetData(DataFormats.Text, txt);
        }
        #region 删除C#注释
        private void menuNote_Click(object sender, EventArgs e)
        {
            string text = this.txtCode.Text.Trim();
            if (text != string.Empty)
            {
                string txt = Regex.Replace(Regex.Replace(Regex.Replace(text, @"(//.*\n)|((?<=\/\*)([\s\S]*)(?=\*\/))", ""), @"//.*", ""), @"/\*.*\*/", "");
                this.txtCode.Text = txt;
                CopyCode(txt);
            }
        }
        #endregion

        #region 删除HTML注释
        private void menuHtmlNote_Click(object sender, EventArgs e)
        {
            string text = this.txtCode.Text.Trim();
            if (text!= string.Empty)
            {
                string txt = Regex.Replace(text, @"<!--.*-->", "");
                this.txtCode.Text = txt;
                CopyCode(txt);
            }
        }
        #endregion

        #region 拖入文件
        private void txtCode_DragDrop(object sender, DragEventArgs e)
        {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (filePaths.Length > 0)
                {
                    string filePath = filePaths[0];
                    StreamReader sr = new StreamReader(filePath);
                     string sLine="";
                     StringBuilder sb = new StringBuilder();
                     while (sLine != null)
                     {
                         sLine = sr.ReadLine();
                         sb.AppendLine(sLine);
                     }
                     sr.Close();
                     this.txtCode.Text = sb.ToString();
                }
        }

        private void txtCode_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else { 
                e.Effect = DragDropEffects.None;
            }
        }
        #endregion

        private void menuClear_Click(object sender, EventArgs e)
        {
            this.txtCode.Text = "";
        }

        private void menuParams_Click(object sender, EventArgs e)
        {
            string pat = "string|int|DateTime|float|decimal|double|bool|byte|\\[\\]";

            string txt = Regex.Replace(this.txtCode.Text, pat, "");
            this.txtCode.Text = txt;
            CopyCode(txt);
        }
    }
}
