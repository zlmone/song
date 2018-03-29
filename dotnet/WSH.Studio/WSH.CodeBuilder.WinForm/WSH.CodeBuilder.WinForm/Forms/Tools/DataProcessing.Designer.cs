namespace WSH.CodeBuilder.WinForm.Forms.Tools
{
    partial class DataProcessing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnTxtTemplate = new WSH.WinForm.Controls.ButtonImage();
            this.btnExcelTemplate = new WSH.WinForm.Controls.ButtonImage();
            this.btnExportTxt = new WSH.WinForm.Controls.ButtonImage();
            this.btnExportSql = new WSH.WinForm.Controls.ButtonImage();
            this.btnExportExcel = new WSH.WinForm.Controls.ButtonImage();
            this.filterData1 = new WSH.CodeBuilder.WinForm.FilterData();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.selectDialogImport = new WSH.WinForm.Controls.SelectDialog();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkIsDataKey = new System.Windows.Forms.CheckBox();
            this.gridImport = new WSH.WinForm.Controls.Grid();
            this.btnLoadImport = new WSH.WinForm.Controls.ButtonImage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new WSH.WinForm.Controls.ButtonImage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(995, 578);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnTxtTemplate);
            this.tabPage1.Controls.Add(this.btnExcelTemplate);
            this.tabPage1.Controls.Add(this.btnExportTxt);
            this.tabPage1.Controls.Add(this.btnExportSql);
            this.tabPage1.Controls.Add(this.btnExportExcel);
            this.tabPage1.Controls.Add(this.filterData1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(987, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "导出";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnTxtTemplate
            // 
            this.btnTxtTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTxtTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnTxtTemplate.Location = new System.Drawing.Point(110, 504);
            this.btnTxtTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.btnTxtTemplate.Name = "btnTxtTemplate";
            this.btnTxtTemplate.Size = new System.Drawing.Size(70, 30);
            this.btnTxtTemplate.TabIndex = 5;
            this.btnTxtTemplate.Text = "Txt模板";
            this.btnTxtTemplate.Click += new System.EventHandler(this.btnTxtTemplate_Click);
            // 
            // btnExcelTemplate
            // 
            this.btnExcelTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcelTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnExcelTemplate.Location = new System.Drawing.Point(9, 504);
            this.btnExcelTemplate.Margin = new System.Windows.Forms.Padding(5);
            this.btnExcelTemplate.Name = "btnExcelTemplate";
            this.btnExcelTemplate.Size = new System.Drawing.Size(70, 30);
            this.btnExcelTemplate.TabIndex = 4;
            this.btnExcelTemplate.Text = "Excel模板";
            this.btnExcelTemplate.Click += new System.EventHandler(this.btnExcelTemplate_Click);
            // 
            // btnExportTxt
            // 
            this.btnExportTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportTxt.BackColor = System.Drawing.Color.Transparent;
            this.btnExportTxt.Location = new System.Drawing.Point(742, 509);
            this.btnExportTxt.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportTxt.Name = "btnExportTxt";
            this.btnExportTxt.Size = new System.Drawing.Size(70, 30);
            this.btnExportTxt.TabIndex = 3;
            this.btnExportTxt.Text = "导出Txt";
            this.btnExportTxt.Click += new System.EventHandler(this.btnExportTxt_Click);
            // 
            // btnExportSql
            // 
            this.btnExportSql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSql.BackColor = System.Drawing.Color.Transparent;
            this.btnExportSql.Location = new System.Drawing.Point(641, 509);
            this.btnExportSql.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportSql.Name = "btnExportSql";
            this.btnExportSql.Size = new System.Drawing.Size(70, 30);
            this.btnExportSql.TabIndex = 2;
            this.btnExportSql.Text = "导出Sql";
            this.btnExportSql.Click += new System.EventHandler(this.btnExportSql_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExportExcel.Location = new System.Drawing.Point(540, 509);
            this.btnExportExcel.Margin = new System.Windows.Forms.Padding(5);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(70, 30);
            this.btnExportExcel.TabIndex = 1;
            this.btnExportExcel.Text = "导出Excel";
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // filterData1
            // 
            this.filterData1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filterData1.IsDataKey = true;
            this.filterData1.Location = new System.Drawing.Point(4, 4);
            this.filterData1.Margin = new System.Windows.Forms.Padding(5);
            this.filterData1.Name = "filterData1";
            this.filterData1.Size = new System.Drawing.Size(978, 490);
            this.filterData1.SortMode = WSH.Common.SortMode.Asc;
            this.filterData1.SortName = null;
            this.filterData1.TabIndex = 0;
            this.filterData1.TableName = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.selectDialogImport);
            this.tabPage2.Controls.Add(this.txtTableName);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.checkIsDataKey);
            this.tabPage2.Controls.Add(this.gridImport);
            this.tabPage2.Controls.Add(this.btnLoadImport);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(987, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "导入";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // selectDialogImport
            // 
            this.selectDialogImport.BackColor = System.Drawing.Color.Transparent;
            this.selectDialogImport.Filter = "Excel文件(*.xls;*.xlsx)|*.xls;*.xlsx";
            this.selectDialogImport.Location = new System.Drawing.Point(277, 14);
            this.selectDialogImport.Margin = new System.Windows.Forms.Padding(4);
            this.selectDialogImport.Name = "selectDialogImport";
            this.selectDialogImport.ReadOnly = false;
            this.selectDialogImport.Size = new System.Drawing.Size(593, 26);
            this.selectDialogImport.TabIndex = 8;
            this.selectDialogImport.Title = null;
            this.selectDialogImport.Type = WSH.Windows.Common.DialogType.File;
            // 
            // txtTableName
            // 
            this.txtTableName.Enabled = false;
            this.txtTableName.Location = new System.Drawing.Point(44, 15);
            this.txtTableName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(155, 25);
            this.txtTableName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "表：";
            // 
            // checkIsDataKey
            // 
            this.checkIsDataKey.AutoSize = true;
            this.checkIsDataKey.Checked = true;
            this.checkIsDataKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkIsDataKey.Location = new System.Drawing.Point(740, 509);
            this.checkIsDataKey.Margin = new System.Windows.Forms.Padding(4);
            this.checkIsDataKey.Name = "checkIsDataKey";
            this.checkIsDataKey.Size = new System.Drawing.Size(119, 19);
            this.checkIsDataKey.TabIndex = 5;
            this.checkIsDataKey.Text = "是否插入主键";
            this.checkIsDataKey.UseVisualStyleBackColor = true;
            // 
            // gridImport
            // 
            this.gridImport.AllowUserToDeleteRows = false;
            this.gridImport.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.gridImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridImport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridImport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(254)))));
            this.gridImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridImport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.gridImport.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(237)))), ((int)(((byte)(237)))));
            this.gridImport.Location = new System.Drawing.Point(14, 63);
            this.gridImport.Margin = new System.Windows.Forms.Padding(4);
            this.gridImport.MultiSelect = false;
            this.gridImport.Name = "gridImport";
            this.gridImport.RowHeadersVisible = false;
            this.gridImport.RowTemplate.Height = 23;
            this.gridImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridImport.Size = new System.Drawing.Size(965, 438);
            this.gridImport.TabIndex = 4;
            // 
            // btnLoadImport
            // 
            this.btnLoadImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadImport.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadImport.Location = new System.Drawing.Point(890, 8);
            this.btnLoadImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnLoadImport.Name = "btnLoadImport";
            this.btnLoadImport.Size = new System.Drawing.Size(70, 30);
            this.btnLoadImport.TabIndex = 3;
            this.btnLoadImport.Text = "加载";
            this.btnLoadImport.Click += new System.EventHandler(this.btnLoadImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件：";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.Location = new System.Drawing.Point(883, 500);
            this.btnImport.Margin = new System.Windows.Forms.Padding(5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 30);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "导入";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // DataProcessing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 578);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataProcessing";
            this.Text = "数据处理";
            this.Load += new System.EventHandler(this.DataProcessing_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private WSH.WinForm.Controls.ButtonImage btnExportTxt;
        private WSH.WinForm.Controls.ButtonImage btnExportSql;
        private WSH.WinForm.Controls.ButtonImage btnExportExcel;
        private FilterData filterData1;
        private WSH.WinForm.Controls.ButtonImage btnImport;
        private System.Windows.Forms.Label label1;
        private WSH.WinForm.Controls.Grid gridImport;
        private WSH.WinForm.Controls.ButtonImage btnLoadImport;
        private System.Windows.Forms.CheckBox checkIsDataKey;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private WSH.WinForm.Controls.ButtonImage btnTxtTemplate;
        private WSH.WinForm.Controls.ButtonImage btnExcelTemplate;
        private WSH.WinForm.Controls.SelectDialog selectDialogImport;
    }
}