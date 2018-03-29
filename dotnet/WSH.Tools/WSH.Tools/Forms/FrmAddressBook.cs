using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using WSH.Common;
using System.IO;
using WSH.Tools.Common;
using WSH.Windows.Common;
using WSH.WinForm.Common;
using WSH.TransferData;
using WSH.TransferData.Common;
using WSH.Common.Helper;
using WSH.Common.Configuration;

namespace WSH.Tools
{
    public partial class FrmAddressBook : Form
    {
        public FrmAddressBook()
        {
            InitializeComponent();
            this.selectDialog.Filter = FileFilter.AddressBook;
        }
        /// <summary>
        /// 导出到txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImage_Click(object sender, EventArgs e)
        {
            string fileName = this.selectDialog.Text;
            string text = AddressBook.Parse(fileName);
            string saveFile = Dialog.GetSaveFile("AddressBook.txt");
            if (!string.IsNullOrEmpty(saveFile))
            {
                BindGrid();
                FileHelper.WriteFile(saveFile, text);
                if (MsgBox.Confirm("导出完毕，是否打开文件？"))
                {
                    FileHelper.OpenFile(saveFile);
                }
            }
        }

        private void selectDialog_OnSelectDialogOk(object sender, string url)
        {
            if(!string.IsNullOrEmpty(url)){
                ConfigurationState state = new ConfigurationState();
                state.Set("AddressBookFileName", url);
            }
        }

        private void FrmAddressBook_Load(object sender, EventArgs e)
        {
            ConfigurationState state = new ConfigurationState();
            string fileName=state.Get("AddressBookFileName");
            this.selectDialog.Text = fileName;
        }
        /// <summary>
        /// 导出到grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImage1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        public DataTable BindGrid()
        {
            string fileName = this.selectDialog.Text;
            DataTable dt = new DataTable();
            if (!string.IsNullOrEmpty(fileName))
            {
                string ext = Path.GetExtension(fileName).ToLower();
                FileType fileType = FileHelper.GetFileType(ext);
                bool isFirstColumn = true;
                string[] columns = new string[] { "联系人", "号码", "号码类型" };
                this.grid1.AutoGenerateColumns = true;
                this.grid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                this.grid1.ReadOnly = true;
                this.grid1.DataSource = null;
                if (fileType== FileType.Txt)
                {
                    dt = TxtHelper.ParseDataTable(fileName, columns, isFirstColumn);
                }
                else if (fileType== FileType.Excel)
                {
                    ITransferData t = TransferDataFactory.GetTransferData(fileName);
                    dt = t.GetData(fileName,columns,isFirstColumn);
                }
                else
                {
                    dt = TxtHelper.ToDataTable(AddressBook.Parse(fileName), columns, isFirstColumn);
                }
                this.grid1.DataSource = dt;
            }
            return dt;
        }
        /// <summary>
        /// 导出excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonImage2_Click(object sender, EventArgs e)
        {
            string saveFile = Dialog.GetSaveFile("AddressBook.xls");
            if(!string.IsNullOrEmpty(saveFile)){
                DataTable dt=BindGrid();
                XlsTransferData transfer = new XlsTransferData();
                transfer.StyleType = ExcelStyleFactory.GetExcelStyleType(ExcelStyleType.Default);
                byte[] bytes = transfer.GetBytes(dt,true);
                FileHelper.WriteFile(saveFile, bytes);
                if(MsgBox.Confirm("导出完毕，是否打开文件？")){
                    FileHelper.OpenFile(saveFile);
                }
            }
        }
 
    }
}
