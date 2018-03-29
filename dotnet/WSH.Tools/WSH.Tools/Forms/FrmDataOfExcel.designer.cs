namespace WSH.Tools
{
    partial class FrmDataOfExcel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblimportinfo = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.togridimport = new System.Windows.Forms.Button();
            this.btnselectfile = new System.Windows.Forms.Button();
            this.import = new System.Windows.Forms.Button();
            this.importtables = new System.Windows.Forms.ComboBox();
            this.lbltableimport = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.importpath = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.togridoutput = new System.Windows.Forms.Button();
            this.btnsavefile = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Button();
            this.outputtables = new System.Windows.Forms.ComboBox();
            this.lbltableoutput = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.outputpath = new System.Windows.Forms.TextBox();
            this.selectFile = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbljoininfo = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtpwd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtuid = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtdatabasse = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtserver = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.connstring = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnconn = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtwhere = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gvtest = new WSH.WinForm.Controls.Grid();
            this.button1 = new System.Windows.Forms.Button();
            this.cbotables = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txttopall = new System.Windows.Forms.TextBox();
            this.lblselect = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvtest)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblimportinfo);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.togridimport);
            this.groupBox1.Controls.Add(this.btnselectfile);
            this.groupBox1.Controls.Add(this.import);
            this.groupBox1.Controls.Add(this.importtables);
            this.groupBox1.Controls.Add(this.lbltableimport);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.importpath);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "导入";
            // 
            // lblimportinfo
            // 
            this.lblimportinfo.AutoSize = true;
            this.lblimportinfo.ForeColor = System.Drawing.Color.Red;
            this.lblimportinfo.Location = new System.Drawing.Point(11, 88);
            this.lblimportinfo.Name = "lblimportinfo";
            this.lblimportinfo.Size = new System.Drawing.Size(0, 12);
            this.lblimportinfo.TabIndex = 8;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(11, 54);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 16);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "选择对应的表";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // togridimport
            // 
            this.togridimport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.togridimport.Location = new System.Drawing.Point(464, 52);
            this.togridimport.Name = "togridimport";
            this.togridimport.Size = new System.Drawing.Size(64, 23);
            this.togridimport.TabIndex = 6;
            this.togridimport.Text = "选择数据";
            this.togridimport.UseVisualStyleBackColor = true;
            this.togridimport.Visible = false;
            this.togridimport.Click += new System.EventHandler(this.togridimport_Click);
            // 
            // btnselectfile
            // 
            this.btnselectfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnselectfile.Location = new System.Drawing.Point(464, 19);
            this.btnselectfile.Name = "btnselectfile";
            this.btnselectfile.Size = new System.Drawing.Size(64, 21);
            this.btnselectfile.TabIndex = 5;
            this.btnselectfile.Text = "...";
            this.btnselectfile.UseVisualStyleBackColor = true;
            this.btnselectfile.Click += new System.EventHandler(this.btnselectfile_Click);
            // 
            // import
            // 
            this.import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.import.Location = new System.Drawing.Point(464, 103);
            this.import.Name = "import";
            this.import.Size = new System.Drawing.Size(64, 23);
            this.import.TabIndex = 4;
            this.import.Text = "导入";
            this.import.UseVisualStyleBackColor = true;
            this.import.Click += new System.EventHandler(this.import_Click);
            // 
            // importtables
            // 
            this.importtables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importtables.Enabled = false;
            this.importtables.FormattingEnabled = true;
            this.importtables.Location = new System.Drawing.Point(217, 54);
            this.importtables.Name = "importtables";
            this.importtables.Size = new System.Drawing.Size(241, 20);
            this.importtables.TabIndex = 3;
            // 
            // lbltableimport
            // 
            this.lbltableimport.AutoSize = true;
            this.lbltableimport.ForeColor = System.Drawing.Color.Red;
            this.lbltableimport.Location = new System.Drawing.Point(146, 58);
            this.lbltableimport.Name = "lbltableimport";
            this.lbltableimport.Size = new System.Drawing.Size(65, 12);
            this.lbltableimport.TabIndex = 2;
            this.lbltableimport.Text = "选择表名：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择文件：";
            // 
            // importpath
            // 
            this.importpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.importpath.Location = new System.Drawing.Point(80, 20);
            this.importpath.Name = "importpath";
            this.importpath.Size = new System.Drawing.Size(378, 21);
            this.importpath.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.togridoutput);
            this.groupBox2.Controls.Add(this.btnsavefile);
            this.groupBox2.Controls.Add(this.output);
            this.groupBox2.Controls.Add(this.outputtables);
            this.groupBox2.Controls.Add(this.lbltableoutput);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.outputpath);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(540, 307);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "导出";
            // 
            // togridoutput
            // 
            this.togridoutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.togridoutput.Location = new System.Drawing.Point(467, 54);
            this.togridoutput.Name = "togridoutput";
            this.togridoutput.Size = new System.Drawing.Size(61, 23);
            this.togridoutput.TabIndex = 12;
            this.togridoutput.Text = "选择数据";
            this.togridoutput.UseVisualStyleBackColor = true;
            this.togridoutput.Visible = false;
            this.togridoutput.Click += new System.EventHandler(this.togridoutput_Click);
            // 
            // btnsavefile
            // 
            this.btnsavefile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnsavefile.Location = new System.Drawing.Point(467, 22);
            this.btnsavefile.Name = "btnsavefile";
            this.btnsavefile.Size = new System.Drawing.Size(61, 21);
            this.btnsavefile.TabIndex = 11;
            this.btnsavefile.Text = "...";
            this.btnsavefile.UseVisualStyleBackColor = true;
            this.btnsavefile.Click += new System.EventHandler(this.btnsavefile_Click);
            // 
            // output
            // 
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.output.Location = new System.Drawing.Point(467, 101);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(61, 23);
            this.output.TabIndex = 10;
            this.output.Text = "导出";
            this.output.UseVisualStyleBackColor = true;
            this.output.Click += new System.EventHandler(this.output_Click);
            // 
            // outputtables
            // 
            this.outputtables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputtables.FormattingEnabled = true;
            this.outputtables.Location = new System.Drawing.Point(80, 55);
            this.outputtables.Name = "outputtables";
            this.outputtables.Size = new System.Drawing.Size(377, 20);
            this.outputtables.TabIndex = 9;
            // 
            // lbltableoutput
            // 
            this.lbltableoutput.AutoSize = true;
            this.lbltableoutput.ForeColor = System.Drawing.Color.Red;
            this.lbltableoutput.Location = new System.Drawing.Point(9, 60);
            this.lbltableoutput.Name = "lbltableoutput";
            this.lbltableoutput.Size = new System.Drawing.Size(65, 12);
            this.lbltableoutput.TabIndex = 8;
            this.lbltableoutput.Text = "选择表名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "导出地址：";
            // 
            // outputpath
            // 
            this.outputpath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.outputpath.Location = new System.Drawing.Point(80, 21);
            this.outputpath.Name = "outputpath";
            this.outputpath.Size = new System.Drawing.Size(377, 21);
            this.outputpath.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.lbljoininfo);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.btnconn);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(534, 301);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "连接";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "提示：";
            // 
            // lbljoininfo
            // 
            this.lbljoininfo.AutoSize = true;
            this.lbljoininfo.ForeColor = System.Drawing.Color.Red;
            this.lbljoininfo.Location = new System.Drawing.Point(219, 20);
            this.lbljoininfo.Name = "lbljoininfo";
            this.lbljoininfo.Size = new System.Drawing.Size(77, 12);
            this.lbljoininfo.TabIndex = 9;
            this.lbljoininfo.Text = "未连接数据库";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "是否写连接字符串";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtpwd);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtuid);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtdatabasse);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtserver);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(13, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(532, 166);
            this.panel2.TabIndex = 7;
            // 
            // txtpwd
            // 
            this.txtpwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtpwd.Location = new System.Drawing.Point(66, 128);
            this.txtpwd.Name = "txtpwd";
            this.txtpwd.PasswordChar = '*';
            this.txtpwd.Size = new System.Drawing.Size(450, 21);
            this.txtpwd.TabIndex = 7;
            this.txtpwd.Text = "sasa";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "密  码：";
            // 
            // txtuid
            // 
            this.txtuid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuid.Location = new System.Drawing.Point(66, 89);
            this.txtuid.Name = "txtuid";
            this.txtuid.Size = new System.Drawing.Size(450, 21);
            this.txtuid.TabIndex = 5;
            this.txtuid.Text = "sa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 4;
            this.label7.Text = "用户名：";
            // 
            // txtdatabasse
            // 
            this.txtdatabasse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdatabasse.Location = new System.Drawing.Point(66, 50);
            this.txtdatabasse.Name = "txtdatabasse";
            this.txtdatabasse.Size = new System.Drawing.Size(450, 21);
            this.txtdatabasse.TabIndex = 3;
            this.txtdatabasse.Text = "MyProject";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "数据库：";
            // 
            // txtserver
            // 
            this.txtserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtserver.Location = new System.Drawing.Point(66, 11);
            this.txtserver.Name = "txtserver";
            this.txtserver.Size = new System.Drawing.Size(450, 21);
            this.txtserver.TabIndex = 1;
            this.txtserver.Text = "SY-WANGSH\\SQLEXPRESS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "服务器：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.connstring);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(13, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 70);
            this.panel1.TabIndex = 6;
            // 
            // connstring
            // 
            this.connstring.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.connstring.Location = new System.Drawing.Point(66, 6);
            this.connstring.Name = "connstring";
            this.connstring.Size = new System.Drawing.Size(450, 54);
            this.connstring.TabIndex = 0;
            this.connstring.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "连接串：";
            // 
            // btnconn
            // 
            this.btnconn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnconn.Location = new System.Drawing.Point(451, 13);
            this.btnconn.Name = "btnconn";
            this.btnconn.Size = new System.Drawing.Size(77, 26);
            this.btnconn.TabIndex = 3;
            this.btnconn.Text = "测试连接";
            this.btnconn.UseVisualStyleBackColor = true;
            this.btnconn.Click += new System.EventHandler(this.btnconn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(548, 333);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(540, 307);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "连接";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(540, 307);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "导入";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(540, 307);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "导出";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtwhere);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.gvtest);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.cbotables);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.txttopall);
            this.tabPage4.Controls.Add(this.lblselect);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(540, 307);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "测试导入数据";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtwhere
            // 
            this.txtwhere.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtwhere.Location = new System.Drawing.Point(279, 4);
            this.txtwhere.Name = "txtwhere";
            this.txtwhere.Size = new System.Drawing.Size(204, 21);
            this.txtwhere.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(244, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "where";
            // 
            // gvtest
            // 
            this.gvtest.AllowUserToAddRows = false;
            this.gvtest.AllowUserToDeleteRows = false;
            this.gvtest.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.gvtest.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvtest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gvtest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvtest.Location = new System.Drawing.Point(0, 30);
            this.gvtest.Margin = new System.Windows.Forms.Padding(0);
            this.gvtest.MultiSelect = false;
            this.gvtest.Name = "gvtest";
            this.gvtest.ReadOnly = true;
            this.gvtest.RowHeadersVisible = false;
            this.gvtest.RowTemplate.Height = 23;
            this.gvtest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvtest.Size = new System.Drawing.Size(540, 278);
            this.gvtest.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(486, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbotables
            // 
            this.cbotables.FormattingEnabled = true;
            this.cbotables.Location = new System.Drawing.Point(138, 4);
            this.cbotables.Name = "cbotables";
            this.cbotables.Size = new System.Drawing.Size(105, 20);
            this.cbotables.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "from";
            // 
            // txttopall
            // 
            this.txttopall.Location = new System.Drawing.Point(45, 4);
            this.txttopall.Name = "txttopall";
            this.txttopall.Size = new System.Drawing.Size(53, 21);
            this.txttopall.TabIndex = 1;
            this.txttopall.Text = "*";
            // 
            // lblselect
            // 
            this.lblselect.AutoSize = true;
            this.lblselect.Location = new System.Drawing.Point(2, 8);
            this.lblselect.Name = "lblselect";
            this.lblselect.Size = new System.Drawing.Size(41, 12);
            this.lblselect.TabIndex = 0;
            this.lblselect.Text = "select";
            // 
            // FrmDataOfExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(548, 333);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataOfExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据导入导出";
            this.Load += new System.EventHandler(this.DataOfExcel_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvtest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnselectfile;
        private System.Windows.Forms.Button import;
        private System.Windows.Forms.ComboBox importtables;
        private System.Windows.Forms.Label lbltableimport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox importpath;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnsavefile;
        private System.Windows.Forms.Button output;
        private System.Windows.Forms.ComboBox outputtables;
        private System.Windows.Forms.Label lbltableoutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox outputpath;
        private System.Windows.Forms.OpenFileDialog selectFile;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnconn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox connstring;
        private System.Windows.Forms.FolderBrowserDialog saveFile;
        private System.Windows.Forms.Button togridoutput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button togridimport;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtpwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtuid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtdatabasse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtserver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbljoininfo;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label lblimportinfo;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbotables;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txttopall;
        private System.Windows.Forms.Label lblselect;
        private WSH.WinForm.Controls.Grid gvtest;
        private System.Windows.Forms.TextBox txtwhere;
        private System.Windows.Forms.Label label8;
    }
}