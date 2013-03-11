namespace BMHDTVPlotTool
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabBox = new System.Windows.Forms.TabControl();
            this.tabReal = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.realLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.imagLabel = new System.Windows.Forms.Label();
            this.imagPixBox = new System.Windows.Forms.PictureBox();
            this.realPicBox = new System.Windows.Forms.PictureBox();
            this.tabFFT = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.fftPicBox = new System.Windows.Forms.PictureBox();
            this.tabHistogram = new System.Windows.Forms.TabPage();
            this.hisPicBox = new System.Windows.Forms.PictureBox();
            this.tabConstellation = new System.Windows.Forms.TabPage();
            this.picConstellation = new System.Windows.Forms.PictureBox();
            this.tabDFT = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.dftPicBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.button3 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.虚部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.生成报告ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.实部图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.虚部图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFT图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFT图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.星座图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出图像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fFT数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dFT数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本软件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.tabBox.SuspendLayout();
            this.tabReal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagPixBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.realPicBox)).BeginInit();
            this.tabFFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fftPicBox)).BeginInit();
            this.tabHistogram.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hisPicBox)).BeginInit();
            this.tabConstellation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picConstellation)).BeginInit();
            this.tabDFT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dftPicBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBox
            // 
            this.tabBox.Controls.Add(this.tabReal);
            this.tabBox.Controls.Add(this.tabFFT);
            this.tabBox.Controls.Add(this.tabHistogram);
            this.tabBox.Controls.Add(this.tabConstellation);
            this.tabBox.Controls.Add(this.tabDFT);
            this.tabBox.Location = new System.Drawing.Point(206, 48);
            this.tabBox.MaximumSize = new System.Drawing.Size(1100, 600);
            this.tabBox.MinimumSize = new System.Drawing.Size(100, 600);
            this.tabBox.Name = "tabBox";
            this.tabBox.SelectedIndex = 0;
            this.tabBox.Size = new System.Drawing.Size(1066, 600);
            this.tabBox.TabIndex = 0;
            // 
            // tabReal
            // 
            this.tabReal.Controls.Add(this.button8);
            this.tabReal.Controls.Add(this.button5);
            this.tabReal.Controls.Add(this.button6);
            this.tabReal.Controls.Add(this.button4);
            this.tabReal.Controls.Add(this.button2);
            this.tabReal.Controls.Add(this.realLabel);
            this.tabReal.Controls.Add(this.checkBox1);
            this.tabReal.Controls.Add(this.imagLabel);
            this.tabReal.Controls.Add(this.imagPixBox);
            this.tabReal.Controls.Add(this.realPicBox);
            this.tabReal.Location = new System.Drawing.Point(4, 22);
            this.tabReal.Name = "tabReal";
            this.tabReal.Padding = new System.Windows.Forms.Padding(3);
            this.tabReal.Size = new System.Drawing.Size(1058, 574);
            this.tabReal.TabIndex = 0;
            this.tabReal.Text = "时域图像";
            this.tabReal.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(1014, 268);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(38, 30);
            this.button8.TabIndex = 10;
            this.button8.Text = "移动";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(997, 544);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = ">>>>";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            this.button5.MouseEnter += new System.EventHandler(this.button5_MouseEnter);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(934, 543);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(57, 25);
            this.button6.TabIndex = 8;
            this.button6.Text = "最大化";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(873, 544);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 25);
            this.button4.TabIndex = 6;
            this.button4.Text = "最小化";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1014, 58);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(41, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "Undo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // realLabel
            // 
            this.realLabel.AutoSize = true;
            this.realLabel.Location = new System.Drawing.Point(23, 4);
            this.realLabel.MaximumSize = new System.Drawing.Size(1000, 20);
            this.realLabel.Name = "realLabel";
            this.realLabel.Size = new System.Drawing.Size(53, 12);
            this.realLabel.TabIndex = 3;
            this.realLabel.Text = "实部图像";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(22, 552);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 16);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "实部虚部自动同步";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // imagLabel
            // 
            this.imagLabel.AutoSize = true;
            this.imagLabel.Location = new System.Drawing.Point(25, 276);
            this.imagLabel.MaximumSize = new System.Drawing.Size(1000, 20);
            this.imagLabel.Name = "imagLabel";
            this.imagLabel.Size = new System.Drawing.Size(53, 12);
            this.imagLabel.TabIndex = 2;
            this.imagLabel.Text = "虚部图像";
            // 
            // imagPixBox
            // 
            this.imagPixBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imagPixBox.Location = new System.Drawing.Point(12, 291);
            this.imagPixBox.Name = "imagPixBox";
            this.imagPixBox.Size = new System.Drawing.Size(1000, 250);
            this.imagPixBox.TabIndex = 1;
            this.imagPixBox.TabStop = false;
            this.imagPixBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseDown);
            this.imagPixBox.MouseEnter += new System.EventHandler(this.realPicBox_MouseEnter);
            this.imagPixBox.MouseLeave += new System.EventHandler(this.imagPixBox_MouseLeave);
            this.imagPixBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseMove);
            this.imagPixBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseUp);
            // 
            // realPicBox
            // 
            this.realPicBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.realPicBox.Location = new System.Drawing.Point(12, 20);
            this.realPicBox.Name = "realPicBox";
            this.realPicBox.Size = new System.Drawing.Size(1000, 250);
            this.realPicBox.TabIndex = 0;
            this.realPicBox.TabStop = false;
            this.realPicBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseDown);
            this.realPicBox.MouseEnter += new System.EventHandler(this.realPicBox_MouseEnter);
            this.realPicBox.MouseLeave += new System.EventHandler(this.realPicBox_MouseLeave);
            this.realPicBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseMove);
            this.realPicBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.realPicBox_MouseUp);
            // 
            // tabFFT
            // 
            this.tabFFT.Controls.Add(this.label8);
            this.tabFFT.Controls.Add(this.comboBox3);
            this.tabFFT.Controls.Add(this.fftPicBox);
            this.tabFFT.Location = new System.Drawing.Point(4, 22);
            this.tabFFT.Name = "tabFFT";
            this.tabFFT.Padding = new System.Windows.Forms.Padding(3);
            this.tabFFT.Size = new System.Drawing.Size(1058, 574);
            this.tabFFT.TabIndex = 1;
            this.tabFFT.Text = "频域图像 (FFT)";
            this.tabFFT.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "FFT点数";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "自适应",
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048",
            "4096",
            "8192"});
            this.comboBox3.Location = new System.Drawing.Point(86, 537);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 20);
            this.comboBox3.TabIndex = 2;
            this.comboBox3.Text = "自适应";
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // fftPicBox
            // 
            this.fftPicBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.fftPicBox.Location = new System.Drawing.Point(22, 20);
            this.fftPicBox.Name = "fftPicBox";
            this.fftPicBox.Size = new System.Drawing.Size(1000, 500);
            this.fftPicBox.TabIndex = 1;
            this.fftPicBox.TabStop = false;
            // 
            // tabHistogram
            // 
            this.tabHistogram.Controls.Add(this.hisPicBox);
            this.tabHistogram.Location = new System.Drawing.Point(4, 22);
            this.tabHistogram.Name = "tabHistogram";
            this.tabHistogram.Size = new System.Drawing.Size(1058, 574);
            this.tabHistogram.TabIndex = 3;
            this.tabHistogram.Text = "直方图";
            this.tabHistogram.UseVisualStyleBackColor = true;
            // 
            // hisPicBox
            // 
            this.hisPicBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.hisPicBox.Location = new System.Drawing.Point(22, 20);
            this.hisPicBox.Name = "hisPicBox";
            this.hisPicBox.Size = new System.Drawing.Size(1000, 500);
            this.hisPicBox.TabIndex = 3;
            this.hisPicBox.TabStop = false;
            // 
            // tabConstellation
            // 
            this.tabConstellation.Controls.Add(this.picConstellation);
            this.tabConstellation.Location = new System.Drawing.Point(4, 22);
            this.tabConstellation.Name = "tabConstellation";
            this.tabConstellation.Size = new System.Drawing.Size(1058, 574);
            this.tabConstellation.TabIndex = 4;
            this.tabConstellation.Text = "星座图";
            this.tabConstellation.UseVisualStyleBackColor = true;
            // 
            // picConstellation
            // 
            this.picConstellation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.picConstellation.Location = new System.Drawing.Point(29, 37);
            this.picConstellation.Name = "picConstellation";
            this.picConstellation.Size = new System.Drawing.Size(1000, 500);
            this.picConstellation.TabIndex = 2;
            this.picConstellation.TabStop = false;
            // 
            // tabDFT
            // 
            this.tabDFT.Controls.Add(this.checkBox3);
            this.tabDFT.Controls.Add(this.button7);
            this.tabDFT.Controls.Add(this.dftPicBox);
            this.tabDFT.Location = new System.Drawing.Point(4, 22);
            this.tabDFT.Name = "tabDFT";
            this.tabDFT.Size = new System.Drawing.Size(1058, 574);
            this.tabDFT.TabIndex = 2;
            this.tabDFT.Text = "频域图像DFT";
            this.tabDFT.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(126, 541);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(114, 16);
            this.checkBox3.TabIndex = 8;
            this.checkBox3.Text = "使用20*lg10坐标";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(22, 526);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(89, 34);
            this.button7.TabIndex = 3;
            this.button7.Text = "进行DFT变换";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // dftPicBox
            // 
            this.dftPicBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dftPicBox.Location = new System.Drawing.Point(22, 20);
            this.dftPicBox.Name = "dftPicBox";
            this.dftPicBox.Size = new System.Drawing.Size(1000, 500);
            this.dftPicBox.TabIndex = 2;
            this.dftPicBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripStatusLabel2,
            this.ProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 640);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 17);
            this.statusLabel.Text = "状态栏";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(80, 17);
            this.toolStripStatusLabel2.Text = "数据处理进度";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(600, 16);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(12, 567);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(180, 60);
            this.button3.TabIndex = 7;
            this.button3.Text = "生成报告";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.导出ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 25);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.生成报告ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实部ToolStripMenuItem,
            this.虚部ToolStripMenuItem});
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 实部ToolStripMenuItem
            // 
            this.实部ToolStripMenuItem.Name = "实部ToolStripMenuItem";
            this.实部ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.实部ToolStripMenuItem.Text = "实部";
            // 
            // 虚部ToolStripMenuItem
            // 
            this.虚部ToolStripMenuItem.Name = "虚部ToolStripMenuItem";
            this.虚部ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.虚部ToolStripMenuItem.Text = "虚部";
            // 
            // 生成报告ToolStripMenuItem
            // 
            this.生成报告ToolStripMenuItem.Name = "生成报告ToolStripMenuItem";
            this.生成报告ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.生成报告ToolStripMenuItem.Text = "生成报告";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 导出ToolStripMenuItem
            // 
            this.导出ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导出文件ToolStripMenuItem,
            this.导出图像ToolStripMenuItem});
            this.导出ToolStripMenuItem.Name = "导出ToolStripMenuItem";
            this.导出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.导出ToolStripMenuItem.Text = "导出";
            // 
            // 导出文件ToolStripMenuItem
            // 
            this.导出文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.实部图像ToolStripMenuItem,
            this.虚部图像ToolStripMenuItem,
            this.fFT图像ToolStripMenuItem,
            this.dFT图像ToolStripMenuItem,
            this.直方图ToolStripMenuItem,
            this.星座图ToolStripMenuItem});
            this.导出文件ToolStripMenuItem.Name = "导出文件ToolStripMenuItem";
            this.导出文件ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出文件ToolStripMenuItem.Text = "导出图像";
            // 
            // 实部图像ToolStripMenuItem
            // 
            this.实部图像ToolStripMenuItem.Name = "实部图像ToolStripMenuItem";
            this.实部图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.实部图像ToolStripMenuItem.Text = "实部图像";
            this.实部图像ToolStripMenuItem.Click += new System.EventHandler(this.实部图像ToolStripMenuItem_Click);
            // 
            // 虚部图像ToolStripMenuItem
            // 
            this.虚部图像ToolStripMenuItem.Name = "虚部图像ToolStripMenuItem";
            this.虚部图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.虚部图像ToolStripMenuItem.Text = "虚部图像";
            this.虚部图像ToolStripMenuItem.Click += new System.EventHandler(this.虚部图像ToolStripMenuItem_Click);
            // 
            // fFT图像ToolStripMenuItem
            // 
            this.fFT图像ToolStripMenuItem.Name = "fFT图像ToolStripMenuItem";
            this.fFT图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.fFT图像ToolStripMenuItem.Text = "FFT图像";
            this.fFT图像ToolStripMenuItem.Click += new System.EventHandler(this.fFT图像ToolStripMenuItem_Click);
            // 
            // dFT图像ToolStripMenuItem
            // 
            this.dFT图像ToolStripMenuItem.Name = "dFT图像ToolStripMenuItem";
            this.dFT图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.dFT图像ToolStripMenuItem.Text = "DFT图像";
            this.dFT图像ToolStripMenuItem.Click += new System.EventHandler(this.dFT图像ToolStripMenuItem_Click);
            // 
            // 直方图ToolStripMenuItem
            // 
            this.直方图ToolStripMenuItem.Name = "直方图ToolStripMenuItem";
            this.直方图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.直方图ToolStripMenuItem.Text = "直方图";
            this.直方图ToolStripMenuItem.Click += new System.EventHandler(this.直方图ToolStripMenuItem_Click);
            // 
            // 星座图ToolStripMenuItem
            // 
            this.星座图ToolStripMenuItem.Name = "星座图ToolStripMenuItem";
            this.星座图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.星座图ToolStripMenuItem.Text = "星座图";
            this.星座图ToolStripMenuItem.Click += new System.EventHandler(this.星座图ToolStripMenuItem_Click);
            // 
            // 导出图像ToolStripMenuItem
            // 
            this.导出图像ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fFT数据ToolStripMenuItem,
            this.dFT数据ToolStripMenuItem,
            this.直方图数据ToolStripMenuItem});
            this.导出图像ToolStripMenuItem.Name = "导出图像ToolStripMenuItem";
            this.导出图像ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.导出图像ToolStripMenuItem.Text = "导出文件";
            // 
            // fFT数据ToolStripMenuItem
            // 
            this.fFT数据ToolStripMenuItem.Name = "fFT数据ToolStripMenuItem";
            this.fFT数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.fFT数据ToolStripMenuItem.Text = "FFT数据";
            // 
            // dFT数据ToolStripMenuItem
            // 
            this.dFT数据ToolStripMenuItem.Name = "dFT数据ToolStripMenuItem";
            this.dFT数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.dFT数据ToolStripMenuItem.Text = "DFT数据";
            // 
            // 直方图数据ToolStripMenuItem
            // 
            this.直方图数据ToolStripMenuItem.Name = "直方图数据ToolStripMenuItem";
            this.直方图数据ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.直方图数据ToolStripMenuItem.Text = "直方图数据";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.关于本软件ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于本软件ToolStripMenuItem
            // 
            this.关于本软件ToolStripMenuItem.Name = "关于本软件ToolStripMenuItem";
            this.关于本软件ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于本软件ToolStripMenuItem.Text = "关于本软件";
            // 
            // statusTimer
            // 
            this.statusTimer.Tick += new System.EventHandler(this.statusTimer_Tick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(81, 21);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "10000";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据最大处理量";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "导入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 106);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据处理选项";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "文件信息";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1284, 25);
            this.toolStrip1.TabIndex = 10;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton1.Text = "导出实部";
            this.toolStripButton1.Click += new System.EventHandler(this.实部图像ToolStripMenuItem_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "导出虚部";
            this.toolStripButton2.Click += new System.EventHandler(this.虚部图像ToolStripMenuItem_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton3.Text = "导出FFT";
            this.toolStripButton3.Click += new System.EventHandler(this.fFT图像ToolStripMenuItem_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton4.Text = "导出直方图";
            this.toolStripButton4.Click += new System.EventHandler(this.直方图ToolStripMenuItem_Click);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(72, 22);
            this.toolStripButton5.Text = "导出星座图";
            this.toolStripButton5.Click += new System.EventHandler(this.星座图ToolStripMenuItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(58, 22);
            this.toolStripButton6.Text = "导出DFT";
            this.toolStripButton6.Click += new System.EventHandler(this.dFT图像ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 662);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabBox);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1300, 700);
            this.MinimumSize = new System.Drawing.Size(1300, 700);
            this.Name = "Form1";
            this.Text = "BMHDTV Plot Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabBox.ResumeLayout(false);
            this.tabReal.ResumeLayout(false);
            this.tabReal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagPixBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.realPicBox)).EndInit();
            this.tabFFT.ResumeLayout(false);
            this.tabFFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fftPicBox)).EndInit();
            this.tabHistogram.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hisPicBox)).EndInit();
            this.tabConstellation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picConstellation)).EndInit();
            this.tabDFT.ResumeLayout(false);
            this.tabDFT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dftPicBox)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabBox;
        private System.Windows.Forms.TabPage tabReal;
        private System.Windows.Forms.Label realLabel;
        private System.Windows.Forms.Label imagLabel;
        private System.Windows.Forms.PictureBox imagPixBox;
        private System.Windows.Forms.PictureBox realPicBox;
        private System.Windows.Forms.TabPage tabFFT;
        private System.Windows.Forms.PictureBox fftPicBox;
        private System.Windows.Forms.TabPage tabDFT;
        private System.Windows.Forms.PictureBox dftPicBox;
        private System.Windows.Forms.TabPage tabHistogram;
        private System.Windows.Forms.PictureBox hisPicBox;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 虚部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生成报告ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 实部图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 虚部图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFT图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFT图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直方图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出图像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fFT数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dFT数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 直方图数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于本软件ToolStripMenuItem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Timer statusTimer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabConstellation;
        private System.Windows.Forms.PictureBox picConstellation;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.ToolStripMenuItem 星座图ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
    }
}

