using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using WSH.Windows;
using WSH.Windows.Common;
using WSH.WinForm.Common;
using WSH.Common.Helper;

namespace WSH.WinForm.Controls
{
    public partial class TextArea : TextBox
    {
        public TextArea()
        {
            this.AddMenu();
            InitializeComponent();
        }
        public void AddMenu() {
            ContextMenuStrip m = new ContextMenuStrip();
            ToolStripMenuItem menuAll=new ToolStripMenuItem();
            menuAll.Text = "全选";
            menuAll.Click += new EventHandler(menuAll_Click);
            m.Items.Add(menuAll);

            ToolStripMenuItem menuCopyAll = new ToolStripMenuItem();
            menuCopyAll.Text = "全部复制";
            menuCopyAll.Click += new EventHandler(menuCopyAll_Click);
            m.Items.Add(menuCopyAll);

            ToolStripMenuItem menuExport = new ToolStripMenuItem();
            menuExport.Text = "导出";
            menuExport.Click += new EventHandler(menuExport_Click);
            m.Items.Add(menuExport);
            this.ContextMenuStrip = m;

            ToolStripMenuItem menuClear= new ToolStripMenuItem();
            menuClear.Text = "清空";
            menuClear.Click += new EventHandler(menuClear_Click);
            m.Items.Add(menuClear);

            this.ContextMenuStrip = m;

        }
        //清空
        void menuClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }
        //导出
        void menuExport_Click(object sender, EventArgs e)
        {
            string text = this.Text.Trim();
            if (text != string.Empty)
            {
                string fileName = Dialog.GetSaveFile("output.txt",FileFilter.Txt);
                if(fileName!=null){
                    try
                    {
                        FileHelper.WriteFile(fileName, text);
                        if (MsgBox.Confirm("文件已经成功导出到——>\n\r" + fileName + "\n\r是否打开文件？"))
                        {
                            FileHelper.OpenFile(fileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        MsgBox.Alert("导出代码失败，" + ex.Message);
                    }
                }
            }
        }
        //全部复制
        void menuCopyAll_Click(object sender, EventArgs e)
        {
            string txt = this.Text;
            if (!string.IsNullOrEmpty(txt))
            {
                Clipboard.SetData(DataFormats.Text, txt);
            }
        }
        //全选
        void menuAll_Click(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
}
