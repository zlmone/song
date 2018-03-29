namespace WSH.Tools.Release
{
    partial class ProjectRelease
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectRelease));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.txtConfig = new ICSharpCode.TextEditor.TextEditorControl();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFilterFile = new System.Windows.Forms.TextBox();
            this.buttonImage1 = new WSH.WinForm.Controls.ButtonImage();
            this.selectDialog1 = new WSH.WinForm.Controls.SelectDialog();
            this.dialogExport = new WSH.WinForm.Controls.SelectDialog();
            this.buttonImage3 = new WSH.WinForm.Controls.ButtonImage();
            this.btnUpdateConfig = new WSH.WinForm.Controls.ButtonImage();
            this.treeDlls = new WSH.WinForm.Controls.Tree();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "file.png");
            this.imgList.Images.SetKeyName(1, "7z.png");
            this.imgList.Images.SetKeyName(2, "accdb.png");
            this.imgList.Images.SetKeyName(3, "asax.png");
            this.imgList.Images.SetKeyName(4, "ashx.png");
            this.imgList.Images.SetKeyName(5, "asmx.png");
            this.imgList.Images.SetKeyName(6, "aspx.png");
            this.imgList.Images.SetKeyName(7, "avi.png");
            this.imgList.Images.SetKeyName(8, "bat.png");
            this.imgList.Images.SetKeyName(9, "bmp.png");
            this.imgList.Images.SetKeyName(10, "config.png");
            this.imgList.Images.SetKeyName(11, "cs.png");
            this.imgList.Images.SetKeyName(12, "cshtml.png");
            this.imgList.Images.SetKeyName(13, "css.png");
            this.imgList.Images.SetKeyName(14, "dll.png");
            this.imgList.Images.SetKeyName(15, "doc.png");
            this.imgList.Images.SetKeyName(16, "docx.png");
            this.imgList.Images.SetKeyName(17, "exe.png");
            this.imgList.Images.SetKeyName(18, "folder.png");
            this.imgList.Images.SetKeyName(19, "gif.png");
            this.imgList.Images.SetKeyName(20, "html.png");
            this.imgList.Images.SetKeyName(21, "jpg.png");
            this.imgList.Images.SetKeyName(22, "js.png");
            this.imgList.Images.SetKeyName(23, "ldf.png");
            this.imgList.Images.SetKeyName(24, "master.png");
            this.imgList.Images.SetKeyName(25, "mdb.png");
            this.imgList.Images.SetKeyName(26, "mdf.png");
            this.imgList.Images.SetKeyName(27, "mp3.png");
            this.imgList.Images.SetKeyName(28, "mp4.png");
            this.imgList.Images.SetKeyName(29, "msi.png");
            this.imgList.Images.SetKeyName(30, "png.png");
            this.imgList.Images.SetKeyName(31, "ppt.png");
            this.imgList.Images.SetKeyName(32, "pptx.png");
            this.imgList.Images.SetKeyName(33, "rar.png");
            this.imgList.Images.SetKeyName(34, "resx.png");
            this.imgList.Images.SetKeyName(35, "rmvb.png");
            this.imgList.Images.SetKeyName(36, "settings.png");
            this.imgList.Images.SetKeyName(37, "sitemap.png");
            this.imgList.Images.SetKeyName(38, "sql.png");
            this.imgList.Images.SetKeyName(39, "txt.png");
            this.imgList.Images.SetKeyName(40, "wav.png");
            this.imgList.Images.SetKeyName(41, "wma.png");
            this.imgList.Images.SetKeyName(42, "xaml.png");
            this.imgList.Images.SetKeyName(43, "xls.png");
            this.imgList.Images.SetKeyName(44, "xlsx.png");
            this.imgList.Images.SetKeyName(45, "xml.png");
            this.imgList.Images.SetKeyName(46, "xsd.png");
            this.imgList.Images.SetKeyName(47, "zip.png");
            this.imgList.Images.SetKeyName(48, "pdb.png");
            // 
            // txtConfig
            // 
            this.txtConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfig.Encoding = ((System.Text.Encoding)(resources.GetObject("txtConfig.Encoding")));
            this.txtConfig.Location = new System.Drawing.Point(331, 117);
            this.txtConfig.Name = "txtConfig";
            this.txtConfig.ShowEOLMarkers = true;
            this.txtConfig.ShowSpaces = true;
            this.txtConfig.ShowTabs = true;
            this.txtConfig.ShowVRuler = true;
            this.txtConfig.Size = new System.Drawing.Size(424, 378);
            this.txtConfig.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "配置导出地址:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFilterFile);
            this.groupBox1.Controls.Add(this.buttonImage1);
            this.groupBox1.Controls.Add(this.selectDialog1);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 42);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择项目文件地址";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "过滤文件类型:";
            // 
            // txtFilterFile
            // 
            this.txtFilterFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterFile.Location = new System.Drawing.Point(522, 14);
            this.txtFilterFile.Name = "txtFilterFile";
            this.txtFilterFile.Size = new System.Drawing.Size(153, 21);
            this.txtFilterFile.TabIndex = 2;
            this.txtFilterFile.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonImage1
            // 
            this.buttonImage1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage1.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage1.Location = new System.Drawing.Point(681, 9);
            this.buttonImage1.Name = "buttonImage1";
            this.buttonImage1.Size = new System.Drawing.Size(70, 30);
            this.buttonImage1.TabIndex = 1;
            this.buttonImage1.Text = "加载";
            this.buttonImage1.Click += new System.EventHandler(this.buttonImage1_Click);
            // 
            // selectDialog1
            // 
            this.selectDialog1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDialog1.BackColor = System.Drawing.Color.Transparent;
            this.selectDialog1.Filter = "";
            this.selectDialog1.Location = new System.Drawing.Point(8, 9);
            this.selectDialog1.MaximumSize = new System.Drawing.Size(3000, 30);
            this.selectDialog1.MinimumSize = new System.Drawing.Size(100, 30);
            this.selectDialog1.Name = "selectDialog1";
            this.selectDialog1.ReadOnly = false;
            this.selectDialog1.Size = new System.Drawing.Size(426, 30);
            this.selectDialog1.TabIndex = 0;
            this.selectDialog1.Title = null;
            this.selectDialog1.Type = WSH.Windows.Common.DialogType.Folder;
            this.selectDialog1.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.selectDialog1_OnSelectDialogOk);
            // 
            // dialogExport
            // 
            this.dialogExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dialogExport.BackColor = System.Drawing.Color.Transparent;
            this.dialogExport.Filter = "";
            this.dialogExport.Location = new System.Drawing.Point(416, 45);
            this.dialogExport.MaximumSize = new System.Drawing.Size(3000, 30);
            this.dialogExport.MinimumSize = new System.Drawing.Size(100, 30);
            this.dialogExport.Name = "dialogExport";
            this.dialogExport.ReadOnly = false;
            this.dialogExport.Size = new System.Drawing.Size(339, 30);
            this.dialogExport.TabIndex = 7;
            this.dialogExport.Title = null;
            this.dialogExport.Type = WSH.Windows.Common.DialogType.Save;
            this.dialogExport.OnSelectDialogOk += new WSH.WinForm.Controls.SelectDialog.SelectDialogOkHandler(this.dialogExport_OnSelectDialogOk);
            // 
            // buttonImage3
            // 
            this.buttonImage3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImage3.BackColor = System.Drawing.Color.Transparent;
            this.buttonImage3.Location = new System.Drawing.Point(685, 81);
            this.buttonImage3.Name = "buttonImage3";
            this.buttonImage3.Size = new System.Drawing.Size(70, 30);
            this.buttonImage3.TabIndex = 5;
            this.buttonImage3.Text = "发布";
            this.buttonImage3.Click += new System.EventHandler(this.buttonImage3_Click);
            // 
            // btnUpdateConfig
            // 
            this.btnUpdateConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateConfig.BackColor = System.Drawing.Color.Transparent;
            this.btnUpdateConfig.Location = new System.Drawing.Point(609, 81);
            this.btnUpdateConfig.Name = "btnUpdateConfig";
            this.btnUpdateConfig.Size = new System.Drawing.Size(70, 30);
            this.btnUpdateConfig.TabIndex = 4;
            this.btnUpdateConfig.Text = "生成配置";
            this.btnUpdateConfig.Click += new System.EventHandler(this.btnUpdateConfig_Click);
            // 
            // treeDlls
            // 
            this.treeDlls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeDlls.CheckBoxes = true;
            this.treeDlls.ImageIndex = 0;
            this.treeDlls.ImageList = this.imgList;
            this.treeDlls.Location = new System.Drawing.Point(4, 45);
            this.treeDlls.Name = "treeDlls";
            this.treeDlls.SelectedImageIndex = 0;
            this.treeDlls.Size = new System.Drawing.Size(325, 450);
            this.treeDlls.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "网络地址:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(416, 86);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(187, 21);
            this.txtUrl.TabIndex = 12;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // ProjectRelease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 499);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dialogExport);
            this.Controls.Add(this.txtConfig);
            this.Controls.Add(this.buttonImage3);
            this.Controls.Add(this.btnUpdateConfig);
            this.Controls.Add(this.treeDlls);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProjectRelease";
            this.Text = "项目发布工具";
            this.Load += new System.EventHandler(this.ProjectRelease_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WinForm.Controls.SelectDialog selectDialog1;
        private WinForm.Controls.ButtonImage buttonImage1;
        private WSH.WinForm.Controls.Tree treeDlls;
        private System.Windows.Forms.ImageList imgList;
        private WinForm.Controls.ButtonImage btnUpdateConfig;
        private WinForm.Controls.ButtonImage buttonImage3;
        private ICSharpCode.TextEditor.TextEditorControl txtConfig;
        private WinForm.Controls.SelectDialog dialogExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFilterFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUrl;
    }
}

