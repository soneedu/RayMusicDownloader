namespace MusicDownloader
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.高品质ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MusicTools = new System.Windows.Forms.TabPage();
            this.loding = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.设置 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.gm_gs = new System.Windows.Forms.RadioButton();
            this.gs_gm = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.fugai = new System.Windows.Forms.RadioButton();
            this.tiaoguo = new System.Windows.Forms.RadioButton();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.DownloadLujing = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Test = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.radioBtn_Playlist = new System.Windows.Forms.RadioButton();
            this.radioBtn_Single = new System.Windows.Forms.RadioButton();
            this.btn_Youtube_DownloadMp3 = new System.Windows.Forms.Button();
            this.btn_unSelectAll = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.dataGridView_Youtube = new System.Windows.Forms.DataGridView();
            this.progressBar_MP3 = new System.Windows.Forms.ProgressBar();
            this.label_percent_MP3download = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Youtube_GetMusicList = new System.Windows.Forms.Button();
            this.txtB_Youtube_URL = new System.Windows.Forms.TextBox();
            this.无损品质ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.普通品质ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制IDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标准品质ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.普通品质ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.高品质ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.无损品质ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载所选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标准品质ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.普通品质ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.高品质ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.无损品质ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.下载全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标准品质ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.YoutubeListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_DownloadMP3 = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btn_pasteURL = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.MusicTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loding)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.设置.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Youtube)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.YoutubeListContextMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // 高品质ToolStripMenuItem2
            // 
            this.高品质ToolStripMenuItem2.Name = "高品质ToolStripMenuItem2";
            this.高品质ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.高品质ToolStripMenuItem2.Text = "高品质";
            this.高品质ToolStripMenuItem2.Click += new System.EventHandler(this.高品质ToolStripMenuItem2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MusicTools);
            this.tabControl1.Controls.Add(this.设置);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(668, 620);
            this.tabControl1.TabIndex = 54;
            // 
            // MusicTools
            // 
            this.MusicTools.Controls.Add(this.loding);
            this.MusicTools.Controls.Add(this.panel1);
            this.MusicTools.Controls.Add(this.label4);
            this.MusicTools.Controls.Add(this.dataGridView1);
            this.MusicTools.Controls.Add(this.progressBar1);
            this.MusicTools.Location = new System.Drawing.Point(4, 22);
            this.MusicTools.Name = "MusicTools";
            this.MusicTools.Padding = new System.Windows.Forms.Padding(3);
            this.MusicTools.Size = new System.Drawing.Size(660, 594);
            this.MusicTools.TabIndex = 0;
            this.MusicTools.Text = "MusicTools";
            this.MusicTools.UseVisualStyleBackColor = true;
            // 
            // loding
            // 
            this.loding.BackColor = System.Drawing.Color.White;
            this.loding.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.loding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loding.Image = global::MusicDownloader.Properties.Resources._5_130H2191323_50;
            this.loding.Location = new System.Drawing.Point(221, 283);
            this.loding.Name = "loding";
            this.loding.Size = new System.Drawing.Size(180, 90);
            this.loding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.loding.TabIndex = 52;
            this.loding.TabStop = false;
            this.loding.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 60);
            this.panel1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "网易云音乐",
            "QQ音乐",
            "虾米音乐",
            "酷狗音乐",
            "百度音乐"});
            this.comboBox1.Location = new System.Drawing.Point(31, 17);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(137, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 16);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.Text = "歌单ID";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(206, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "搜索";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(471, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "获取 Music";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.textBox1.Location = new System.Drawing.Point(262, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(198, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Window;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(280, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "0%";
            this.label4.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(6, 99);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(610, 485);
            this.dataGridView1.TabIndex = 51;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 72);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(610, 20);
            this.progressBar1.TabIndex = 12;
            // 
            // 设置
            // 
            this.设置.Controls.Add(this.panel4);
            this.设置.Controls.Add(this.panel3);
            this.设置.Controls.Add(this.linkLabel1);
            this.设置.Controls.Add(this.label1);
            this.设置.Controls.Add(this.DownloadLujing);
            this.设置.Location = new System.Drawing.Point(4, 22);
            this.设置.Name = "设置";
            this.设置.Size = new System.Drawing.Size(660, 594);
            this.设置.TabIndex = 2;
            this.设置.Text = "设置";
            this.设置.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.gm_gs);
            this.panel4.Controls.Add(this.gs_gm);
            this.panel4.Location = new System.Drawing.Point(3, 125);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(616, 50);
            this.panel4.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "文件名格式";
            // 
            // gm_gs
            // 
            this.gm_gs.AutoSize = true;
            this.gm_gs.Checked = true;
            this.gm_gs.Location = new System.Drawing.Point(183, 15);
            this.gm_gs.Name = "gm_gs";
            this.gm_gs.Size = new System.Drawing.Size(101, 16);
            this.gm_gs.TabIndex = 18;
            this.gm_gs.TabStop = true;
            this.gm_gs.Text = "歌曲名 - 歌手";
            this.gm_gs.UseVisualStyleBackColor = true;
            this.gm_gs.Click += new System.EventHandler(this.gm_gs_CheckedChanged);
            // 
            // gs_gm
            // 
            this.gs_gm.AutoSize = true;
            this.gs_gm.Location = new System.Drawing.Point(348, 15);
            this.gs_gm.Name = "gs_gm";
            this.gs_gm.Size = new System.Drawing.Size(101, 16);
            this.gs_gm.TabIndex = 19;
            this.gs_gm.Text = "歌手 - 歌曲名";
            this.gs_gm.UseVisualStyleBackColor = true;
            this.gs_gm.Click += new System.EventHandler(this.gs_gm_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.fugai);
            this.panel3.Controls.Add(this.tiaoguo);
            this.panel3.Location = new System.Drawing.Point(3, 69);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(616, 50);
            this.panel3.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "文件存在处理方式";
            // 
            // fugai
            // 
            this.fugai.AutoSize = true;
            this.fugai.Checked = true;
            this.fugai.Location = new System.Drawing.Point(183, 16);
            this.fugai.Name = "fugai";
            this.fugai.Size = new System.Drawing.Size(47, 16);
            this.fugai.TabIndex = 16;
            this.fugai.TabStop = true;
            this.fugai.Text = "覆盖";
            this.fugai.UseVisualStyleBackColor = true;
            this.fugai.Click += new System.EventHandler(this.fugai_CheckedChanged);
            // 
            // tiaoguo
            // 
            this.tiaoguo.AutoSize = true;
            this.tiaoguo.Location = new System.Drawing.Point(348, 16);
            this.tiaoguo.Name = "tiaoguo";
            this.tiaoguo.Size = new System.Drawing.Size(47, 16);
            this.tiaoguo.TabIndex = 17;
            this.tiaoguo.Text = "跳过";
            this.tiaoguo.UseVisualStyleBackColor = true;
            this.tiaoguo.Click += new System.EventHandler(this.tiaoguo_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(536, 32);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "浏览";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "下载路径";
            // 
            // DownloadLujing
            // 
            this.DownloadLujing.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DownloadLujing.Location = new System.Drawing.Point(105, 29);
            this.DownloadLujing.Name = "DownloadLujing";
            this.DownloadLujing.Size = new System.Drawing.Size(425, 21);
            this.DownloadLujing.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_pasteURL);
            this.tabPage1.Controls.Add(this.btn_Test);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.radioBtn_Playlist);
            this.tabPage1.Controls.Add(this.radioBtn_Single);
            this.tabPage1.Controls.Add(this.btn_Youtube_DownloadMp3);
            this.tabPage1.Controls.Add(this.btn_unSelectAll);
            this.tabPage1.Controls.Add(this.btn_SelectAll);
            this.tabPage1.Controls.Add(this.dataGridView_Youtube);
            this.tabPage1.Controls.Add(this.progressBar_MP3);
            this.tabPage1.Controls.Add(this.label_percent_MP3download);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btn_Youtube_GetMusicList);
            this.tabPage1.Controls.Add(this.txtB_Youtube_URL);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(660, 594);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Youtube转MP3";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_Test
            // 
            this.btn_Test.Location = new System.Drawing.Point(479, 90);
            this.btn_Test.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Test.Name = "btn_Test";
            this.btn_Test.Size = new System.Drawing.Size(56, 18);
            this.btn_Test.TabIndex = 12;
            this.btn_Test.Text = "Test";
            this.btn_Test.UseVisualStyleBackColor = true;
            this.btn_Test.Click += new System.EventHandler(this.btn_Test_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 11;
            this.label7.Text = "模式:";
            // 
            // radioBtn_Playlist
            // 
            this.radioBtn_Playlist.AutoSize = true;
            this.radioBtn_Playlist.Checked = true;
            this.radioBtn_Playlist.Location = new System.Drawing.Point(102, 6);
            this.radioBtn_Playlist.Name = "radioBtn_Playlist";
            this.radioBtn_Playlist.Size = new System.Drawing.Size(71, 16);
            this.radioBtn_Playlist.TabIndex = 10;
            this.radioBtn_Playlist.TabStop = true;
            this.radioBtn_Playlist.Text = "播放列表";
            this.radioBtn_Playlist.UseVisualStyleBackColor = true;
            // 
            // radioBtn_Single
            // 
            this.radioBtn_Single.AutoSize = true;
            this.radioBtn_Single.Location = new System.Drawing.Point(46, 6);
            this.radioBtn_Single.Name = "radioBtn_Single";
            this.radioBtn_Single.Size = new System.Drawing.Size(47, 16);
            this.radioBtn_Single.TabIndex = 9;
            this.radioBtn_Single.Text = "单曲";
            this.radioBtn_Single.UseVisualStyleBackColor = true;
            // 
            // btn_Youtube_DownloadMp3
            // 
            this.btn_Youtube_DownloadMp3.Location = new System.Drawing.Point(564, 87);
            this.btn_Youtube_DownloadMp3.Name = "btn_Youtube_DownloadMp3";
            this.btn_Youtube_DownloadMp3.Size = new System.Drawing.Size(75, 23);
            this.btn_Youtube_DownloadMp3.TabIndex = 8;
            this.btn_Youtube_DownloadMp3.Text = "下载MP3";
            this.btn_Youtube_DownloadMp3.UseVisualStyleBackColor = true;
            this.btn_Youtube_DownloadMp3.Click += new System.EventHandler(this.btn_Youtube_DownloadMp3_Click);
            // 
            // btn_unSelectAll
            // 
            this.btn_unSelectAll.Location = new System.Drawing.Point(98, 88);
            this.btn_unSelectAll.Name = "btn_unSelectAll";
            this.btn_unSelectAll.Size = new System.Drawing.Size(75, 23);
            this.btn_unSelectAll.TabIndex = 7;
            this.btn_unSelectAll.Text = "取消全选";
            this.btn_unSelectAll.UseVisualStyleBackColor = true;
            this.btn_unSelectAll.Click += new System.EventHandler(this.btn_unSelectAll_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.Location = new System.Drawing.Point(7, 88);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(75, 23);
            this.btn_SelectAll.TabIndex = 6;
            this.btn_SelectAll.Text = "全部选择";
            this.btn_SelectAll.UseVisualStyleBackColor = true;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // dataGridView_Youtube
            // 
            this.dataGridView_Youtube.AllowUserToAddRows = false;
            this.dataGridView_Youtube.AllowUserToDeleteRows = false;
            this.dataGridView_Youtube.AllowUserToOrderColumns = true;
            this.dataGridView_Youtube.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Youtube.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            this.dataGridView_Youtube.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Youtube.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Youtube.Location = new System.Drawing.Point(3, 117);
            this.dataGridView_Youtube.Name = "dataGridView_Youtube";
            this.dataGridView_Youtube.ReadOnly = true;
            this.dataGridView_Youtube.RowHeadersVisible = false;
            this.dataGridView_Youtube.RowTemplate.Height = 23;
            this.dataGridView_Youtube.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Youtube.Size = new System.Drawing.Size(654, 477);
            this.dataGridView_Youtube.TabIndex = 5;
            this.dataGridView_Youtube.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Youtube_CellContentClick);
            this.dataGridView_Youtube.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_Youtube_CellMouseDown);
            // 
            // progressBar_MP3
            // 
            this.progressBar_MP3.Location = new System.Drawing.Point(46, 63);
            this.progressBar_MP3.Name = "progressBar_MP3";
            this.progressBar_MP3.Size = new System.Drawing.Size(512, 19);
            this.progressBar_MP3.TabIndex = 4;
            // 
            // label_percent_MP3download
            // 
            this.label_percent_MP3download.AutoSize = true;
            this.label_percent_MP3download.Location = new System.Drawing.Point(222, 67);
            this.label_percent_MP3download.Name = "label_percent_MP3download";
            this.label_percent_MP3download.Size = new System.Drawing.Size(35, 12);
            this.label_percent_MP3download.TabIndex = 3;
            this.label_percent_MP3download.Text = "     ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "下载:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "URL:";
            // 
            // btn_Youtube_GetMusicList
            // 
            this.btn_Youtube_GetMusicList.Location = new System.Drawing.Point(564, 34);
            this.btn_Youtube_GetMusicList.Name = "btn_Youtube_GetMusicList";
            this.btn_Youtube_GetMusicList.Size = new System.Drawing.Size(75, 23);
            this.btn_Youtube_GetMusicList.TabIndex = 1;
            this.btn_Youtube_GetMusicList.Text = "获取列表";
            this.btn_Youtube_GetMusicList.UseVisualStyleBackColor = true;
            this.btn_Youtube_GetMusicList.Click += new System.EventHandler(this.btn_Youtube_GetMusiclist_Click);
            // 
            // txtB_Youtube_URL
            // 
            this.txtB_Youtube_URL.Location = new System.Drawing.Point(46, 36);
            this.txtB_Youtube_URL.Name = "txtB_Youtube_URL";
            this.txtB_Youtube_URL.Size = new System.Drawing.Size(512, 21);
            this.txtB_Youtube_URL.TabIndex = 0;
            this.txtB_Youtube_URL.Text = "https://www.youtube.com/watch?v=EJx2CmnLeIo";
            // 
            // 无损品质ToolStripMenuItem2
            // 
            this.无损品质ToolStripMenuItem2.Name = "无损品质ToolStripMenuItem2";
            this.无损品质ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.无损品质ToolStripMenuItem2.Text = "无损品质";
            this.无损品质ToolStripMenuItem2.Click += new System.EventHandler(this.无损品质ToolStripMenuItem2_Click);
            // 
            // 普通品质ToolStripMenuItem2
            // 
            this.普通品质ToolStripMenuItem2.Name = "普通品质ToolStripMenuItem2";
            this.普通品质ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.普通品质ToolStripMenuItem2.Text = "普通品质";
            this.普通品质ToolStripMenuItem2.Click += new System.EventHandler(this.普通品质ToolStripMenuItem2_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制IDToolStripMenuItem,
            this.下载ToolStripMenuItem,
            this.下载所选ToolStripMenuItem,
            this.下载全部ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 92);
            // 
            // 复制IDToolStripMenuItem
            // 
            this.复制IDToolStripMenuItem.Name = "复制IDToolStripMenuItem";
            this.复制IDToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复制IDToolStripMenuItem.Text = "复制ID";
            this.复制IDToolStripMenuItem.Click += new System.EventHandler(this.复制IDToolStripMenuItem_Click);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标准品质ToolStripMenuItem,
            this.普通品质ToolStripMenuItem,
            this.高品质ToolStripMenuItem,
            this.无损品质ToolStripMenuItem});
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            this.下载ToolStripMenuItem.Click += new System.EventHandler(this.下载ToolStripMenuItem_Click);
            // 
            // 标准品质ToolStripMenuItem
            // 
            this.标准品质ToolStripMenuItem.Name = "标准品质ToolStripMenuItem";
            this.标准品质ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.标准品质ToolStripMenuItem.Text = "标准品质";
            this.标准品质ToolStripMenuItem.Click += new System.EventHandler(this.标准品质ToolStripMenuItem_Click);
            // 
            // 普通品质ToolStripMenuItem
            // 
            this.普通品质ToolStripMenuItem.Name = "普通品质ToolStripMenuItem";
            this.普通品质ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.普通品质ToolStripMenuItem.Text = "普通品质";
            this.普通品质ToolStripMenuItem.Click += new System.EventHandler(this.普通品质ToolStripMenuItem_Click);
            // 
            // 高品质ToolStripMenuItem
            // 
            this.高品质ToolStripMenuItem.Name = "高品质ToolStripMenuItem";
            this.高品质ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.高品质ToolStripMenuItem.Text = "高品质";
            this.高品质ToolStripMenuItem.Click += new System.EventHandler(this.高品质ToolStripMenuItem_Click);
            // 
            // 无损品质ToolStripMenuItem
            // 
            this.无损品质ToolStripMenuItem.Name = "无损品质ToolStripMenuItem";
            this.无损品质ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.无损品质ToolStripMenuItem.Text = "无损品质";
            this.无损品质ToolStripMenuItem.Click += new System.EventHandler(this.无损品质ToolStripMenuItem_Click);
            // 
            // 下载所选ToolStripMenuItem
            // 
            this.下载所选ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标准品质ToolStripMenuItem1,
            this.普通品质ToolStripMenuItem1,
            this.高品质ToolStripMenuItem1,
            this.无损品质ToolStripMenuItem1});
            this.下载所选ToolStripMenuItem.Name = "下载所选ToolStripMenuItem";
            this.下载所选ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.下载所选ToolStripMenuItem.Text = "下载所选";
            this.下载所选ToolStripMenuItem.Click += new System.EventHandler(this.下载所选ToolStripMenuItem_Click);
            // 
            // 标准品质ToolStripMenuItem1
            // 
            this.标准品质ToolStripMenuItem1.Name = "标准品质ToolStripMenuItem1";
            this.标准品质ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.标准品质ToolStripMenuItem1.Text = "标准品质";
            this.标准品质ToolStripMenuItem1.Click += new System.EventHandler(this.标准品质ToolStripMenuItem1_Click);
            // 
            // 普通品质ToolStripMenuItem1
            // 
            this.普通品质ToolStripMenuItem1.Name = "普通品质ToolStripMenuItem1";
            this.普通品质ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.普通品质ToolStripMenuItem1.Text = "普通品质";
            this.普通品质ToolStripMenuItem1.Click += new System.EventHandler(this.普通品质ToolStripMenuItem1_Click);
            // 
            // 高品质ToolStripMenuItem1
            // 
            this.高品质ToolStripMenuItem1.Name = "高品质ToolStripMenuItem1";
            this.高品质ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.高品质ToolStripMenuItem1.Text = "高品质";
            this.高品质ToolStripMenuItem1.Click += new System.EventHandler(this.高品质ToolStripMenuItem1_Click);
            // 
            // 无损品质ToolStripMenuItem1
            // 
            this.无损品质ToolStripMenuItem1.Name = "无损品质ToolStripMenuItem1";
            this.无损品质ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.无损品质ToolStripMenuItem1.Text = "无损品质";
            this.无损品质ToolStripMenuItem1.Click += new System.EventHandler(this.无损品质ToolStripMenuItem1_Click);
            // 
            // 下载全部ToolStripMenuItem
            // 
            this.下载全部ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标准品质ToolStripMenuItem2,
            this.普通品质ToolStripMenuItem2,
            this.高品质ToolStripMenuItem2,
            this.无损品质ToolStripMenuItem2});
            this.下载全部ToolStripMenuItem.Name = "下载全部ToolStripMenuItem";
            this.下载全部ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.下载全部ToolStripMenuItem.Text = "下载全部";
            this.下载全部ToolStripMenuItem.Click += new System.EventHandler(this.下载全部ToolStripMenuItem_Click);
            // 
            // 标准品质ToolStripMenuItem2
            // 
            this.标准品质ToolStripMenuItem2.Name = "标准品质ToolStripMenuItem2";
            this.标准品质ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.标准品质ToolStripMenuItem2.Text = "标准品质";
            this.标准品质ToolStripMenuItem2.Click += new System.EventHandler(this.标准品质ToolStripMenuItem2_Click);
            // 
            // YoutubeListContextMenu
            // 
            this.YoutubeListContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.YoutubeListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_DownloadMP3});
            this.YoutubeListContextMenu.Margin = new System.Windows.Forms.Padding(20, 0, 0, 40);
            this.YoutubeListContextMenu.Name = "YoutubeListContextMenu";
            this.YoutubeListContextMenu.Size = new System.Drawing.Size(101, 26);
            // 
            // toolStripMenuItem_DownloadMP3
            // 
            this.toolStripMenuItem_DownloadMP3.Name = "toolStripMenuItem_DownloadMP3";
            this.toolStripMenuItem_DownloadMP3.Size = new System.Drawing.Size(100, 22);
            this.toolStripMenuItem_DownloadMP3.Text = "下载";
            this.toolStripMenuItem_DownloadMP3.Click += new System.EventHandler(this.toolStripMenuItem_DownloadMP3_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 626);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 55;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // btn_pasteURL
            // 
            this.btn_pasteURL.Location = new System.Drawing.Point(212, 3);
            this.btn_pasteURL.Name = "btn_pasteURL";
            this.btn_pasteURL.Size = new System.Drawing.Size(75, 23);
            this.btn_pasteURL.TabIndex = 13;
            this.btn_pasteURL.Text = "粘贴网址";
            this.btn_pasteURL.UseVisualStyleBackColor = true;
            this.btn_pasteURL.Click += new System.EventHandler(this.btn_pasteURL_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 648);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RayMusicDownloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.MusicTools.ResumeLayout(false);
            this.MusicTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loding)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.设置.ResumeLayout(false);
            this.设置.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Youtube)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.YoutubeListContextMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem 高品质ToolStripMenuItem2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MusicTools;
        private System.Windows.Forms.PictureBox loding;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TabPage 设置;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton gm_gs;
        private System.Windows.Forms.RadioButton gs_gm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton fugai;
        private System.Windows.Forms.RadioButton tiaoguo;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DownloadLujing;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ProgressBar progressBar_MP3;
        private System.Windows.Forms.Label label_percent_MP3download;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Youtube_GetMusicList;
        private System.Windows.Forms.TextBox txtB_Youtube_URL;
        private System.Windows.Forms.ToolStripMenuItem 无损品质ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 普通品质ToolStripMenuItem2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制IDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标准品质ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 普通品质ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 高品质ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 无损品质ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载所选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标准品质ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 普通品质ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 高品质ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 无损品质ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 下载全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标准品质ToolStripMenuItem2;
        private System.Windows.Forms.DataGridView dataGridView_Youtube;
        private System.Windows.Forms.Button btn_unSelectAll;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button btn_Youtube_DownloadMp3;
        private System.Windows.Forms.ContextMenuStrip YoutubeListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DownloadMP3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioBtn_Playlist;
        private System.Windows.Forms.RadioButton radioBtn_Single;
        private System.Windows.Forms.Button btn_Test;
        private System.Windows.Forms.Button btn_pasteURL;
    }
}