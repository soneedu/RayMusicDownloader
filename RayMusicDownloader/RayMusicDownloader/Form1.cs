using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;

namespace MusicDownloader
{
    public partial class Form1 : Form
    {
        public delegate void ShowDatatableDelegate(DataTable dt);

        private string api = "";

        private string[] qqss_music = new string[2];

        private string music_name = "";

        private string music_geshou = "";

        private string music_zhuanji = "";

        private string music_id = "";

        public DataTable Dt;
        public DataTable dgridSourceDt = new DataTable(); 
        public Queue<int> CompleteQueue = new Queue<int>();
        public int completeCounter = 0;

        public bool Flag = true;

        private string source = "";

        private string id = "";

        private string url = "";

        private string mName = "";

        private string mp3Name = "";

        private RegistryKey regkey;

        public List<dynamic> videoIdList = new List<dynamic>();
        public DataTable videoDataTable = new DataTable();

        public ConcurrentDictionary<int, List<string>> VideoConcurrentDic =
            new ConcurrentDictionary<int, List<string>>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //            label4.Parent = progressBar1;
            //		    label4.BackColor = Color.Transparent;
            //            label4.Location = new Point(280, 74);

            try
            {
                comboBox1.SelectedIndex = 1;
                regkey = Registry.CurrentUser.OpenSubKey("Software\\MusicTools");
                if (regkey == null)
                {
                    DownloadLujing.Text = Environment.CurrentDirectory + "\\download\\";
                }
                else
                {
                    if (regkey.GetValue("path") == null)
                    {
                        DownloadLujing.Text = Environment.CurrentDirectory + "\\download\\";
                    }
                    else
                    {
                        DownloadLujing.Text = regkey.GetValue("path").ToString();
                    }

                    if (regkey.GetValue("exist") != null)
                    {
                        if (regkey.GetValue("exist").ToString() == "false")
                        {
                            tiaoguo.Checked = true;
                        }
                        else
                        {
                            fugai.Checked = true;
                        }
                    }

                    if (regkey.GetValue("FileNameFormat") != null)
                    {
                        if (regkey.GetValue("FileNameFormat").ToString() == "gm-gs")
                        {
                            gm_gs.Checked = true;
                        }
                        else
                        {
                            gs_gm.Checked = true;
                        }
                    }

                    regkey.Close();
                }

                //                JObject jObject =
                //                    JObject.Parse(GetJSON("https://gitee.com/s337443501/MusicTools/raw/master/MusicTools.txt"));
                //                JArray jArray = JArray.Parse(jObject["data"].ToString());
                //                JObject jObject2 = JObject.Parse(jArray[0].ToString());
                //                api = jObject2["api"].ToString(); 
                api = @"http://szsylm.com/MKOnlineMusicPlayer/"; // @"http://tools.yijingying.com/MKOnlineMusicPlayer/";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void dgvgeshihua()
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["序号"].Width = 40;
            dataGridView1.Columns["选择"].Width = 40;
        }

        public void ShowDatatable()
        {
            DataTable dataTable = InitDt();
            Invoke(new ShowDatatableDelegate(BindDt), dataTable);
        }

        public void BindDt(DataTable dt)
        {
            dataGridView1.Columns.Clear();
            DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            dataGridViewCheckBoxColumn.HeaderText = "选择";
            dataGridViewCheckBoxColumn.Name = "选择";
            dataGridViewCheckBoxColumn.TrueValue = true;
            dataGridViewCheckBoxColumn.FalseValue = false;
            dataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            dataGridView1.Columns.Add(dataGridViewCheckBoxColumn);
            dataGridView1.DataSource = dt;
            dgvgeshihua();
            loding.Visible = false;
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
            if (source != "tencent")
            {
                标准品质ToolStripMenuItem.Visible = false;
                普通品质ToolStripMenuItem.Visible = false;
                高品质ToolStripMenuItem.Visible = false;
                无损品质ToolStripMenuItem.Visible = false;
                标准品质ToolStripMenuItem1.Visible = false;
                普通品质ToolStripMenuItem1.Visible = false;
                高品质ToolStripMenuItem1.Visible = false;
                无损品质ToolStripMenuItem1.Visible = false;
                标准品质ToolStripMenuItem2.Visible = false;
                普通品质ToolStripMenuItem2.Visible = false;
                高品质ToolStripMenuItem2.Visible = false;
                无损品质ToolStripMenuItem2.Visible = false;
            }
            else
            {
                标准品质ToolStripMenuItem.Visible = true;
                普通品质ToolStripMenuItem.Visible = true;
                高品质ToolStripMenuItem.Visible = true;
                无损品质ToolStripMenuItem.Visible = true;
                标准品质ToolStripMenuItem1.Visible = true;
                普通品质ToolStripMenuItem1.Visible = true;
                高品质ToolStripMenuItem1.Visible = true;
                无损品质ToolStripMenuItem1.Visible = true;
                标准品质ToolStripMenuItem2.Visible = true;
                普通品质ToolStripMenuItem2.Visible = true;
                高品质ToolStripMenuItem2.Visible = true;
                无损品质ToolStripMenuItem2.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == string.Empty || textBox1.Text == null)
            {
                MessageBox.Show("什么都没填，让我获取啥？", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                loding.Visible = true;
                Task.Factory.StartNew(delegate { ShowDatatable(); });
            }
        }

        public DataTable InitDt()
        {
            if (radioButton1.Checked)
            {
                try
                {
                    Dt = null;
                    Dt = new DataTable();
                    Dt.Columns.Add("序号", typeof(int));
                    Dt.Columns.Add("歌曲", typeof(string));
                    Dt.Columns.Add("歌手", typeof(string));
                    Dt.Columns.Add("专辑", typeof(string));
                    Dt.Columns.Add("ID", typeof(string));
                    var songqueryJson = GetJSON(api + "api.php?source=" + source + "&types=search&name=" +
                                                textBox1.Text.Trim() + "&count=200");

                    JArray jArray = JArray.Parse(songqueryJson);
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        JObject jObject = JObject.Parse(jArray[i].ToString());
                        music_name = jObject["name"].ToString();
                        JArray jArray2 = JArray.Parse(jObject["artist"].ToString());
                        music_geshou = null;
                        if (jArray2.Count > 1)
                        {
                            for (int j = 0; j < jArray2.Count; j++)
                            {
                                music_geshou = music_geshou + "/" + jArray2[j].ToString().Trim();
                            }

                            music_geshou = music_geshou.Substring(1);
                        }
                        else
                        {
                            music_geshou = jArray2[0].ToString();
                        }

                        music_zhuanji = jObject["album"].ToString();
                        music_id = jObject["id"].ToString();
                        Dt.Rows.Add(i + 1, music_name, music_geshou, music_zhuanji, music_id);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    Dt = null;
                    Dt = new DataTable();
                    Dt.Columns.Add("序号", typeof(int));
                    Dt.Columns.Add("歌曲", typeof(string));
                    Dt.Columns.Add("歌手", typeof(string));
                    Dt.Columns.Add("专辑", typeof(string));
                    Dt.Columns.Add("ID", typeof(string));
                    JObject jObject2 =
                        JObject.Parse(GetJSON(api + "api.php?source=" + source + "&types=playlist&id=" +
                                              textBox1.Text.Trim()));
                    if (source == "netease")
                    {
                        JArray jArray3 = JArray.Parse(jObject2["playlist"]["tracks"].ToString());
                        for (int k = 0; k < jArray3.Count; k++)
                        {
                            JObject jObject3 = JObject.Parse(jArray3[k].ToString());
                            music_name = jObject3["name"].ToString();
                            JArray jArray4 = JArray.Parse(jObject3["ar"].ToString());
                            JObject jObject4 = JObject.Parse(jArray4[0].ToString());
                            music_geshou = jObject4["name"].ToString();
                            jObject4 = JObject.Parse(jObject3["al"].ToString());
                            music_zhuanji = jObject4["name"].ToString();
                            music_id = jObject3["id"].ToString();
                            Dt.Rows.Add(k + 1, music_name, music_geshou, music_zhuanji, music_id);
                        }
                    }
                    else if (source == "tencent")
                    {
                        JObject jObject5 = JObject.Parse(jObject2["data"].ToString());
                        JArray jArray5 = JArray.Parse(jObject5["cdlist"].ToString());
                        JObject jObject6 = JObject.Parse(jArray5[0].ToString());
                        JArray jArray6 = JArray.Parse(jObject6["songlist"].ToString());
                        for (int l = 0; l < jArray6.Count; l++)
                        {
                            JObject jObject7 = JObject.Parse(jArray6[l].ToString());
                            music_name = jObject7["name"].ToString();
                            JArray jArray7 = JArray.Parse(jObject7["singer"].ToString());
                            JObject jObject8 = JObject.Parse(jArray7[0].ToString());
                            music_geshou = jObject8["name"].ToString();
                            jObject8 = JObject.Parse(jObject7["album"].ToString());
                            music_zhuanji = jObject8["name"].ToString();
                            music_id = jObject7["mid"].ToString();
                            Dt.Rows.Add(l + 1, music_name, music_geshou, music_zhuanji, music_id);
                        }
                    }
                    else if (source == "xiami")
                    {
                        JObject jObject9 = JObject.Parse(jObject2["data"]["data"]["collectDetail"].ToString());
                        JArray jArray8 = JArray.Parse(jObject9["songs"].ToString());
                        for (int m = 0; m < jArray8.Count; m++)
                        {
                            JObject jObject10 = JObject.Parse(jArray8[m].ToString());
                            music_name = jObject10["songName"].ToString();
                            music_geshou = jObject10["singers"].ToString();
                            music_zhuanji = jObject10["albumName"].ToString();
                            music_id = jObject10["songId"].ToString();
                            Dt.Rows.Add(m + 1, music_name, music_geshou, music_zhuanji, music_id);
                        }
                    }
                    else if (source == "kugou")
                    {
                        JObject jObject11 = JObject.Parse(jObject2["data"].ToString());
                        JArray jArray9 = JArray.Parse(jObject11["info"].ToString());
                        for (int n = 0; n < jArray9.Count; n++)
                        {
                            JObject jObject12 = JObject.Parse(jArray9[n].ToString());
                            string[] array = jObject12["filename"].ToString().Split('-');
                            music_name = array[1].Trim();
                            music_geshou = array[0].Trim();
                            music_zhuanji = jObject12["remark"].ToString();
                            if (jObject12["sqhash"].ToString() == "" ||
                                jObject12["sqhash"].ToString() == string.Empty ||
                                jObject12["sqhash"].ToString() == null)
                            {
                                if (jObject12["320hash"].ToString() == "" ||
                                    jObject12["320hash"].ToString() == string.Empty ||
                                    jObject12["320hash"].ToString() == null)
                                {
                                    music_id = jObject12["hash"].ToString();
                                }
                                else
                                {
                                    music_id = jObject12["320hash"].ToString();
                                }
                            }
                            else
                            {
                                music_id = jObject12["sqhash"].ToString();
                            }

                            Dt.Rows.Add(n + 1, music_name, music_geshou, music_zhuanji, music_id);
                        }
                    }
                    else if (source == "baidu")
                    {
                        JArray jArray10 = JArray.Parse(jObject2["content"].ToString());
                        for (int num = 0; num < jArray10.Count; num++)
                        {
                            JObject jObject13 = JObject.Parse(jArray10[num].ToString());
                            music_name = jObject13["title"].ToString();
                            music_geshou = jObject13["author"].ToString();
                            music_zhuanji = jObject13["album_title"].ToString();
                            music_id = jObject13["song_id"].ToString();
                            Dt.Rows.Add(num + 1, music_name, music_geshou, music_zhuanji, music_id);
                        }
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message);
                }
            }

            return Dt;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                DownloadLujing.Text = folderBrowserDialog.SelectedPath + "\\";
                regkey = Registry.CurrentUser.CreateSubKey("Software\\MusicTools");
                regkey.SetValue("path", DownloadLujing.Text);
                regkey.Close();
            }
        }

        public void hxDownload()
        {
            if (!(url == "") && !(url == string.Empty) && url != null)
            {
                return;
            }

            JArray jArray =
                JArray.Parse(GetJSON(api + "api.php?source=netease&types=search&name=" + mName + "&count=1"));
            JObject jObject = JObject.Parse(jArray[0].ToString());
            url = GetMP3URL(GetJSON(api + "api.php?source=netease&types=url&id=" + jObject["id"]));
            if (!(url == "") && !(url == string.Empty) && url != null)
            {
                return;
            }

            jArray = JArray.Parse(GetJSON(api + "api.php?source=tencent&types=search&name=" + mName + "&count=1"));
            jObject = JObject.Parse(jArray[0].ToString());
            url = GetMP3URL(GetJSON(api + "api.php?source=tencent&types=url&id=" + jObject["id"]));
            if (!(url == "") && !(url == string.Empty) && url != null)
            {
                return;
            }

            jArray = JArray.Parse(GetJSON(api + "api.php?source=xiami&types=search&name=" + mName + "&count=1"));
            jObject = JObject.Parse(jArray[0].ToString());
            url = GetMP3URL(GetJSON(api + "api.php?source=xiami&types=url&id=" + jObject["id"]));
            if (!(url == "") && !(url == string.Empty) && url != null)
            {
                return;
            }

            jArray = JArray.Parse(GetJSON(api + "api.php?source=kugou&types=search&name=" + mName + "&count=1"));
            jObject = JObject.Parse(jArray[0].ToString());
            url = GetMP3URL(GetJSON(api + "api.php?source=kugou&types=url&id=" + jObject["id"]));
            if (!(url == "") && !(url == string.Empty) && url != null)
            {
                return;
            }

            jArray = JArray.Parse(GetJSON(api + "api.php?source=baidu&types=search&name=" + mName + "&count=1"));
            jObject = JObject.Parse(jArray[0].ToString());
            url = GetMP3URL(GetJSON(api + "api.php?source=baidu&types=url&id=" + jObject["id"]));
        }

        private void 下载ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            url = GetMP3URL(GetJSON(api + "api.php?source=" + source + "&types=url&id=" + id));
            if (gm_gs.Checked)
            {
                mName = dataGridView1.SelectedRows[0].Cells["歌曲"].Value + " - " +
                        dataGridView1.SelectedRows[0].Cells["歌手"].Value;
            }
            else if (gs_gm.Checked)
            {
                mName = dataGridView1.SelectedRows[0].Cells["歌手"].Value + " - " +
                        dataGridView1.SelectedRows[0].Cells["歌曲"].Value;
            }

            mp3Name = mName + ".mp3";
            mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                .Replace("*", "&")
                .Replace("?", "&")
                .Replace("\"", "&")
                .Replace("|", "&")
                .Replace("<", "&")
                .Replace(">", "&");
            hxDownload();
            if (File.Exists(DownloadLujing.Text + mp3Name))
            {
                if (fugai.Checked)
                {
                    File.Delete(DownloadLujing.Text + mp3Name);
                    DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
                    Process.Start(DownloadLujing.Text);
                }
                else if (tiaoguo.Checked)
                {
                    Process.Start(DownloadLujing.Text);
                }
            }
            else
            {
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
                Process.Start(DownloadLujing.Text);
            }
        }

        private void 标准品质ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tencent_xz("C400", "m4a");
        }

        private void 普通品质ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tencent_xz("M500", "mp3");
        }

        private void 高品质ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tencent_xz("M800", "mp3");
        }

        private void 无损品质ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tencent_xz("F000", "flac");
        }

        public void tencent_xz(string pinzhi, string type)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            url = "http://streamoc.music.tc.qq.com/" + pinzhi + id + "." + type + "?vkey=" + GetQQMusic_vkey() +
                  "&guid=2095717240&fromtag=53";


            if (gm_gs.Checked)
            {
                mName = dataGridView1.SelectedRows[0].Cells["歌曲"].Value + " - " +
                        dataGridView1.SelectedRows[0].Cells["歌手"].Value;
            }
            else if (gs_gm.Checked)
            {
                mName = dataGridView1.SelectedRows[0].Cells["歌手"].Value + " - " +
                        dataGridView1.SelectedRows[0].Cells["歌曲"].Value;
            }

            mp3Name = mName + "." + type;
            mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                .Replace("*", "&")
                .Replace("?", "&")
                .Replace("\"", "&")
                .Replace("|", "&")
                .Replace("<", "&")
                .Replace(">", "&");
            if (File.Exists(DownloadLujing.Text + mp3Name))
            {
                if (fugai.Checked)
                {
                    File.Delete(DownloadLujing.Text + mp3Name);
                    DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
                    Process.Start(DownloadLujing.Text);
                }
                else if (tiaoguo.Checked)
                {
                    Process.Start(DownloadLujing.Text);
                }
            }
            else
            {
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
                Process.Start(DownloadLujing.Text);
            }
        }

        private void 下载所选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            int num = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < num; i++)
            {
                DataGridViewCheckBoxCell dataGridViewCheckBoxCell =
                    (DataGridViewCheckBoxCell) dataGridView1.Rows[i].Cells["选择"];
                if (Convert.ToBoolean(dataGridViewCheckBoxCell.Value))
                {
                    id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    url = GetMP3URL(GetJSON(api + "api.php?source=" + source + "&types=url&id=" + id));
                    if (gm_gs.Checked)
                    {
                        mName = dataGridView1.Rows[i].Cells["歌曲"].Value + " - " +
                                dataGridView1.Rows[i].Cells["歌手"].Value;
                    }
                    else if (gs_gm.Checked)
                    {
                        mName = dataGridView1.Rows[i].Cells["歌手"].Value + " - " +
                                dataGridView1.Rows[i].Cells["歌曲"].Value;
                    }

                    mp3Name = mName + ".mp3";
                    mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                        .Replace("*", "&")
                        .Replace("?", "&")
                        .Replace("\"", "&")
                        .Replace("|", "&")
                        .Replace("<", "&")
                        .Replace(">", "&");
                    hxDownload();
                    if (File.Exists(DownloadLujing.Text + mp3Name))
                    {
                        if (!fugai.Checked)
                        {
                            if (!tiaoguo.Checked)
                            {
                                goto IL_02f9;
                            }

                            continue;
                        }

                        File.Delete(DownloadLujing.Text + mp3Name);
                    }

                    goto IL_02f9;
                }

                continue;
                IL_02f9:
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
            }

            Process.Start(DownloadLujing.Text);
        }

        private void 标准品质ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tencent_xzsx("C400", "m4a");
        }

        private void 普通品质ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tencent_xzsx("M500", "mp3");
        }

        private void 高品质ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tencent_xzsx("M800", "mp3");
        }

        private void 无损品质ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tencent_xzsx("F000", "flac");
        }

        public void tencent_xzsx(string pinzhi, string type)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            int num = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < num; i++)
            {
                DataGridViewCheckBoxCell dataGridViewCheckBoxCell =
                    (DataGridViewCheckBoxCell) dataGridView1.Rows[i].Cells["选择"];
                if (Convert.ToBoolean(dataGridViewCheckBoxCell.Value))
                {
                    id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                    url = "http://streamoc.music.tc.qq.com/" + pinzhi + id + "." + type + "?vkey=" + GetQQMusic_vkey() +
                          "&guid=2095717240&fromtag=53";
                    if (gm_gs.Checked)
                    {
                        mName = dataGridView1.Rows[i].Cells["歌曲"].Value + " - " +
                                dataGridView1.Rows[i].Cells["歌手"].Value;
                    }
                    else if (gs_gm.Checked)
                    {
                        mName = dataGridView1.Rows[i].Cells["歌手"].Value + " - " +
                                dataGridView1.Rows[i].Cells["歌曲"].Value;
                    }

                    mp3Name = mName + "." + type;
                    mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                        .Replace("*", "&")
                        .Replace("?", "&")
                        .Replace("\"", "&")
                        .Replace("|", "&")
                        .Replace("<", "&")
                        .Replace(">", "&");
                    if (File.Exists(DownloadLujing.Text + mp3Name))
                    {
                        if (!fugai.Checked)
                        {
                            if (!tiaoguo.Checked)
                            {
                                goto IL_02f7;
                            }

                            continue;
                        }

                        File.Delete(DownloadLujing.Text + mp3Name);
                    }

                    goto IL_02f7;
                }

                continue;
                IL_02f7:
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
            }

            Process.Start(DownloadLujing.Text);
        }

        private void 下载全部ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                url = GetMP3URL(GetJSON(api + "api.php?source=" + source + "&types=url&id=" + id));
                if (gm_gs.Checked)
                {
                    mName = dataGridView1.Rows[i].Cells["歌曲"].Value + " - " + dataGridView1.Rows[i].Cells["歌手"].Value;
                }
                else if (gs_gm.Checked)
                {
                    mName = dataGridView1.Rows[i].Cells["歌手"].Value + " - " + dataGridView1.Rows[i].Cells["歌曲"].Value;
                }

                mp3Name = mName + ".mp3";
                mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                    .Replace("*", "&")
                    .Replace("?", "&")
                    .Replace("\"", "&")
                    .Replace("|", "&")
                    .Replace("<", "&")
                    .Replace(">", "&");
                hxDownload();
                if (File.Exists(DownloadLujing.Text + mp3Name))
                {
                    if (!fugai.Checked)
                    {
                        if (!tiaoguo.Checked)
                        {
                            goto IL_02a1;
                        }

                        continue;
                    }

                    File.Delete(DownloadLujing.Text + mp3Name);
                }

                IL_02a1:
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
            }

            Process.Start(DownloadLujing.Text);
        }

        private void 标准品质ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tencent_xzqb("C400", "m4a");
        }

        private void 普通品质ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tencent_xzqb("M500", "mp3");
        }

        private void 高品质ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tencent_xzqb("M800", "mp3");
        }

        private void 无损品质ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tencent_xzqb("F000", "flac");
        }

        public void tencent_xzqb(string pinzhi, string type)
        {
            if (!Directory.Exists(DownloadLujing.Text))
            {
                Directory.CreateDirectory(DownloadLujing.Text);
            }

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                id = dataGridView1.Rows[i].Cells["ID"].Value.ToString();
                url = "http://streamoc.music.tc.qq.com/" + pinzhi + id + "." + type + "?vkey=" + GetQQMusic_vkey() +
                      "&guid=2095717240&fromtag=53";
                if (gm_gs.Checked)
                {
                    mName = dataGridView1.Rows[i].Cells["歌曲"].Value + " - " + dataGridView1.Rows[i].Cells["歌手"].Value;
                }
                else if (gs_gm.Checked)
                {
                    mName = dataGridView1.Rows[i].Cells["歌手"].Value + " - " + dataGridView1.Rows[i].Cells["歌曲"].Value;
                }

                mp3Name = mName + "." + type;
                mp3Name = mp3Name.Replace("\\", "&").Replace("/", "&").Replace(":", "&")
                    .Replace("*", "&")
                    .Replace("?", "&")
                    .Replace("\"", "&")
                    .Replace("|", "&")
                    .Replace("<", "&")
                    .Replace(">", "&");
                if (File.Exists(DownloadLujing.Text + mp3Name))
                {
                    if (!fugai.Checked)
                    {
                        if (!tiaoguo.Checked)
                        {
                            goto IL_029f;
                        }

                        continue;
                    }

                    File.Delete(DownloadLujing.Text + mp3Name);
                }

                IL_029f:
                DownloadFile(url, DownloadLujing.Text + mp3Name, progressBar1, label4);
            }

            Process.Start(DownloadLujing.Text);
        }

        public string GetMP3URL(string jsontext)
        {
            JObject jObject = JObject.Parse(jsontext);
            return jObject["url"].ToString();
        }

        public string qqss_json(string jsontext)
        {
            JObject jObject = JObject.Parse(jsontext);
            JObject jObject2 = JObject.Parse(jObject["data"].ToString());
            JObject jObject3 = JObject.Parse(jObject2["song"].ToString());
            JArray jArray = JArray.Parse(jObject3["list"].ToString());
            JObject jObject4 = JObject.Parse(jArray[0].ToString());
            return jObject4["f"].ToString().Split('|')[20];
        }

        public string GetQQMusic_vkey()
        {
            try
            {
                string jSON = GetJSON("http://www.douqq.com/qqmusic/qqapi.php");
                string[] array = jSON.Split('=');
                return array[2].Replace("&uin", "");
            }
            catch
            {
                return null;
            }
        }

        public string GetJSON(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Credentials = CredentialCache.DefaultCredentials;
                webClient.Encoding = Encoding.UTF8;
                string text = webClient.DownloadString(url);
                text.Contains("errcode");
                return text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "服务连接", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return "";
            }
        }

        public void DownloadFile(string URL, string filename, ProgressBar prog, Label baifenbi)
        {
            try
            {
                float num = 0;
                HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(URL);
                HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                int num2 = (int) httpWebResponse.ContentLength;
                if (prog != null)
                {
                    prog.Maximum = num2;
                }

                Stream responseStream = httpWebResponse.GetResponseStream();
                Stream stream = new FileStream(filename, FileMode.Create);
                int num3 = 0;
                byte[] array = new byte[1024];
                int num4 = responseStream.Read(array, 0, array.Length);
                //			    label4.Visible = true;
                while (num4 > 0)
                {
                    num3 = num4 + num3;
                    Application.DoEvents();
                    stream.Write(array, 0, num4);
                    if (prog != null)
                    {
                        prog.Value = num3;
                    }

                    num4 = responseStream.Read(array, 0, array.Length);
                    num = ((float) num3 / num2) * 100;
                    var progText = num.ToString("F0") + "%";
                    //					baifenbi.Text = num.ToString("F2") + "%";
                    //                    Console.WriteLine(num + " : " + num3 + " : " + num2);
                    using (Graphics gr = prog.CreateGraphics())
                    {
                        gr.DrawString(progText,
                            SystemFonts.DefaultFont,
                            Brushes.Black,
                            new PointF(prog.Width / 2 - (gr.MeasureString(progText,
                                                             SystemFonts.DefaultFont).Width / 2.0F),
                                prog.Height / 2 - (gr.MeasureString(progText,
                                                       SystemFonts.DefaultFont).Height / 2.0F)));
                    }

                    Application.DoEvents();
                }

                stream.Close();
                responseStream.Close();
            }
            catch
            {
            }
        }

        public bool GetHttp(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.CreateDefault(new Uri(url));
                httpWebRequest.Method = "HEAD";
                httpWebRequest.Timeout = 1000;
                HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode.ToString() == "OK")
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (dataGridView1.CurrentCell != null)
                {
                    dataGridView1.CurrentCell.Selected = false;
                }

                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell dataGridViewCheckBoxCell =
                    (DataGridViewCheckBoxCell) dataGridView1.Rows[e.RowIndex].Cells["选择"];
                if (Convert.ToBoolean(dataGridViewCheckBoxCell.Value))
                {
                    dataGridViewCheckBoxCell.Value = false;
                }
                else
                {
                    dataGridViewCheckBoxCell.Value = true;
                }
            }
        }

        private void 复制IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            id = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            if (id != "")
            {
                Clipboard.SetDataObject(id);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                source = "netease";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                source = "tencent";
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                source = "xiami";
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                source = "kugou";
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                source = "baidu";
            }
        }

        private void fugai_CheckedChanged(object sender, EventArgs e)
        {
            regkey = Registry.CurrentUser.CreateSubKey("Software\\MusicTools");
            regkey.SetValue("exist", "true");
        }

        private void tiaoguo_CheckedChanged(object sender, EventArgs e)
        {
            regkey = Registry.CurrentUser.CreateSubKey("Software\\MusicTools");
            regkey.SetValue("exist", "false");
        }

        private void gm_gs_CheckedChanged(object sender, EventArgs e)
        {
            regkey = Registry.CurrentUser.CreateSubKey("Software\\MusicTools");
            regkey.SetValue("FileNameFormat", "gm-gs");
        }

        private void gs_gm_CheckedChanged(object sender, EventArgs e)
        {
            regkey = Registry.CurrentUser.CreateSubKey("Software\\MusicTools");
            regkey.SetValue("FileNameFormat", "gs-gm");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (regkey != null)
            {
                regkey.Close();
            }
        }

        private void dataGridView_Youtube_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex != -1 && e.ColumnIndex != -1)
            {
//                if (dataGridView_Youtube.CurrentCell != null)
//                {
//                    dataGridView_Youtube.CurrentCell.Selected = false;
//                }
//                dataGridView_Youtube.Rows[e.RowIndex].Selected = true;
//                dataGridView_Youtube.CurrentCell = dataGridView_Youtube.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (e.RowIndex >= 0)
                {
                    dataGridView_Youtube.ClearSelection();
                    dataGridView_Youtube.Rows[e.RowIndex].Selected = true;
                    dataGridView_Youtube.CurrentCell = dataGridView_Youtube.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    this.YoutubeListContextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void toolStripMenuItem_DownloadMP3_Click(object sender, EventArgs e)

        {
            string videoId = this.dataGridView_Youtube[2, this.dataGridView_Youtube.CurrentCell.RowIndex].Value
                .ToString();
            int index = int.Parse(this.dataGridView_Youtube[0, this.dataGridView_Youtube.CurrentCell.RowIndex].Value.ToString());
//            string url = "https://www.youtube.com/watch?v=" + videoId;
//            DownloadMp3FromYoutube(url, index);
            List<string> vList = new List<string>();
            List<string> iList = new List<string>();

            vList.Add(videoId);
            iList.Add(index.ToString());
            completeCounter = 0;
            CompleteQueue.Clear();
            Dt?.Clear();

            invokeTaskFactory(vList,iList);
        }

        private void useInitailTaskFactory(List<string> videoIdList, List<string> indexList)
        {
            string username = "";
            string password = "";
            //需要处理的清单列表
//            var videoIdList = new List<string>();
            string[] adminPassLs = {username, password};
            var threeParameter = new List<object> {videoIdList.ToArray(), indexList.ToArray()};
            threeParameter.Add(0);
            //调用TaskFactory并初始化
            UseTaskFactory.initail_TaskFactory(threeParameter, doFunc);
//            var maxLength = 4;
//            var channels = videoIdList.Count / maxLength + (videoIdList.Count % maxLength > 0 ? 1 : 0);
        }

        private void doFunc(object myargs)
        {
            var parameter = myargs as List<object>;
            var itemList = parameter[0] as string[];
            var indexList = parameter[1] as string[];
            var index = parameter[2] as string;

            #region 函数要做的工作

            int i = 0;
            foreach (var item in itemList)
            {
                string url = "https://www.youtube.com/watch?v=" + item;
                DownloadMp3FromYoutube(url, int.Parse(indexList[i]));
                i++;
            }

            #endregion
        }

        private async void btn_Youtube_GetMusiclist_Click(object sender, EventArgs e)
        {
            videoIdList.Clear();
            videoDataTable.Clear();
            VideoConcurrentDic.Clear();
            dgridSourceDt.Clear();
            if (videoDataTable.Columns.Count == 0)
            {
                videoDataTable.Columns.Add("No.", typeof(string));
                videoDataTable.Columns.Add("Title", typeof(string));
                videoDataTable.Columns.Add("videoId", typeof(string));
                videoDataTable.Columns.Add("DownloadPercent", typeof(string));
            }

            string url_music_link = txtB_Youtube_URL.Text;

            if (radioBtn_Playlist.Checked)
            {
                if (!url_music_link.Contains("list="))
                {
                    MessageBox.Show("不是一个有效的Youtube Playlist地址！");
                    return;
                }

                MatchCollection m = Regex.Matches(url_music_link, @"list=(\S+)&?");
                string music_id = m[0].Groups[1].Value;
                var playlistId = music_id; //"PLQiKLJnked44DeuQEvb2jVIZu-v_fEgfT"; //;"PLQiKLJnked46hCVpwB40t6BG94MZ6VZXc"
                var apiKey = "AIzaSyBqj3g3EDBI0wD5EdVbK4GaQfaFs5OY3XI";
                await Youtube.Download(playlistId, apiKey, videoDataTable);
            }
            else
            {
                MatchCollection m = Regex.Matches(url_music_link, @"v=([\w|-]+)&?");
                string music_id = m[0].Groups[1].Value;
                List<string> singleMusicRow = new List<string>();
                singleMusicRow.Add("");
                videoDataTable.Rows.Add(new string[]{"0", "你懂的", music_id, ""});
            }

            Console.WriteLine(videoIdList);
//            dataGridView_Youtube.DataSource = videoDataTable;
//            dataGridView_Youtube.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
//            dataGridView_Youtube.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;

            
            //            videoDataTable.ColumnChanging += MyColumnChanging;
//            var thisDt = GetAllDataTableFromDataGridView(dataGridView_Youtube);
            // 将Datatable 转成现成安全的ConcurrentDictionary类型
            VideoConcurrentDic = new ConcurrentDictionary<int, List<string>>(videoDataTable.Rows.OfType<DataRow>().ToDictionary(
                d => int.Parse(d.Field<string>(0)), v => new List<string>{
                    v.Field<string>(0).ToString(),
                    v.Field<string>(1).ToString(),
                    v.Field<string>(2).ToString(),
                    Convert.ToString(v.Field<string>(3))
                }));

            dgridSourceDt = conDic2DataTable(VideoConcurrentDic, videoDataTable);
            //            dataGridView_Youtube.Columns.Clear();

//            var column1 = new DataGridViewCheckBoxColumn();
//            column1.Name = "选择";                         //Name of column
//            column1.HeaderText = "选择";                //Title of column
//            column1.DataPropertyName = "IsChecked";         //Name of filed in database
//            column1.TrueValue = "true";                   //True value
//            column1.FalseValue = "false";               //False Value
//            this.dataGridView_Youtube.Columns.Insert(0,column1);

            dataGridView_Youtube.DataSource = dgridSourceDt;

            dataGridView_Youtube.Show();
//            dataGridView_Youtube.Columns["选择"].Width = 35;
//            dataGridView_Youtube.Columns["选择"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_Youtube.Columns["No."].Width = 10;
            dataGridView_Youtube.Columns["Title"].Width = 100;
            dataGridView_Youtube.Columns["videoId"].Width = 32;
            dataGridView_Youtube.Columns["DownloadPercent"].Width = 50;
            dataGridView_Youtube.Columns["DownloadPercent"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;
            dataGridView_Youtube.Columns["No."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //            dataGridView_Youtube.Update();

        }

        private async void btn_Youtube_DownloadMp3_Click(object sender, EventArgs e)
        {
            //            var worker = new BackgroundWorker();
            //            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            //            worker.RunWorkerAsync();
            // 选择了的DataRow，不一定是完整的videoDataTable
            completeCounter = 0;
            CompleteQueue.Clear();
            Dt?.Clear();

            Dt = GetAllDataTableFromDataGridView(dataGridView_Youtube);
            List<string> vList = Dt.AsEnumerable().Select(r => r.Field<string>("videoId")).ToList();
            List<string> iList = Dt.AsEnumerable().Select(r => r.Field<string>("No.")).ToList();
            invokeTaskFactory(vList, iList);

        }

        private void invokeTaskFactory(List<string> vList, List<string> iList)
        {
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

            useInitailTaskFactory(vList, iList);

            //            int i = 0;
            //            foreach (var item in vList)
            //            {
            //                string url = "https://www.youtube.com/watch?v=" + item;
            //                await DownloadMp3FromYoutube(url, int.Parse(iList[i]) - 1);
            //                i++;
            //            }
            while (CompleteQueue.Count != vList.Count)
            {
                toolStripStatusLabel1.Text = $"进度：{completeCounter} / {vList.Count}";
                Application.DoEvents();
                Thread.Sleep(100);
            }
            toolStripStatusLabel1.Text = $"进度：{completeCounter} / {vList.Count}";
            backgroundWorker1.Dispose();
        }


        private DataTable conDic2DataTable(ConcurrentDictionary<int, List<string>> conDic, DataTable orginalDt)
        {
            // ConcurrentDictionary 转回DataTable
            var conDt = orginalDt.Clone();
            var SortedCustomerData = new SortedDictionary<int,List<string>>(conDic);
            foreach ( var item in SortedCustomerData)
            {
                conDt.Rows.Add(item.Value.ToArray());
            }
            return conDt;
        }

        private bool monitorDataTable(object sender, DoWorkEventArgs e)
        {
            while (Flag)
            {
                dgridSourceDt = conDic2DataTable(VideoConcurrentDic, videoDataTable);
                backgroundWorker1.ReportProgress(1);
                Thread.Sleep(2000);
            }

            return true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = monitorDataTable(backgroundWorker1, e); //运算结果保存在e.Result中
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // The progress percentage is a property of e
            dataGridView_Youtube.DataSource = dgridSourceDt;
//            dataGridView_Youtube.Update();
        }


        public DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                //// I assume you need all your columns.
                dataTable.Columns.Add(column.Name, typeof(string)); //column.CellType
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                //// If the value of the column with the checkbox is true at this row, we add it
                if (Convert.ToBoolean(row.Cells["选择"].Value))
                {
                    object[] values = new object[dataGridView.Columns.Count];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        values[i] = row.Cells[i].Value;
                    }

                    dataTable.Rows.Add(values);
                }
            }

            return dataTable;
        }

        public DataTable GetAllDataTableFromDataGridView(DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                //// I assume you need all your columns.
                dataTable.Columns.Add(column.Name, typeof(string)); //column.CellType
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                //// If the value of the column with the checkbox is true at this row, we add it

                    object[] values = new object[dataGridView.Columns.Count];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        values[i] = row.Cells[i].Value;
                    }

                    dataTable.Rows.Add(values);
                
            }

            return dataTable;
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //            updateDt();
            DownloadMp3FromYoutube(txtB_Youtube_URL.Text, 1);
        }

        private void updateDt(int index, string percent)
        {
            videoDataTable.Rows[index]["DownloadPercent"] = percent;
        }

        private void MyColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            // just to enforce column name representation, forcing to lower
            string colName = e.Column.ColumnName.ToLower();

            // e.Row has the row that had the change for you to work with, validate, etc...

            switch (colName)
            {
                case "DownloadPercent":
                    dataGridView_Youtube.Update();
                    break;

                case "anotherfield":

                    break;
            }
        }

        private async Task DownloadMp3FromYoutube(string youtubeUrl, int index)
        {
//            string urlConverter = "https://distillvideo.com/mp3?url=" + youtubeUrl;
//            myWebClient myWeb = new myWebClient();
//            string content = await myWeb.MakeRequestAsync(urlConverter);
//            MatchCollection m = Regex.Matches(content, ".*data-href=\"(.*.mp3)\" href=\"");
//
//            if (m.Count >0)
//            {
//                string mp3Url = m[0].Groups[1].Value;
//                string mp3Name = mp3Url.Replace(@"https://distillvideo.com/mp3s/", "");
//                Console.WriteLine(mp3Url);
//                DownloadMP3(mp3Url, mp3Name, index);
//            }
//            else
//            {
//                VideoConcurrentDic[index][3] = "无法下载";
//                completeCounter++;
//                CompleteQueue.Enqueue(index);
//            }

            string startUrl = "https://y2mate.com/youtube-to-mp3/";
            string url_prefix_ajax = "https://y2mate.com/mp3/ajax";
            myWebClient myWeb = new myWebClient();
            string content = await myWeb.MakeRequestAsync(startUrl);
            string json_music = await myWeb.MakePostAsync(url_prefix_ajax,
                $"url={youtubeUrl}&t=18s&ajax=1");

            MatchCollection m = Regex.Matches(json_music, @"vtitle = \\.(.+)..;\\r\\n\\r\\n..this..find.*_id:\s?\W?(.+).,.*v_id:..(.+).,.*mp3_type.*");   // data -vtitle=..(.+)..\s+data-vtype=.+\s+_id:.(\w+).,.+\s+v_id:\s.([\w|\s|-]+).,
            var url_Mp3_download = "";
            var videoTitle = "";
            if (m.Count !=0)
            {
                videoTitle = m[0].Groups[1].Value;
                string _id = m[0].Groups[2].Value;
                string v_id = m[0].Groups[3].Value;
                string url_prefix_Convert = "https://y2mate.com/mp3Convert";
                string json_reslut_convert =
                    await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320");

                // 处理CovertMP3时结果为Sorry的问题
                MatchCollection sorry = Regex.Matches(json_reslut_convert, @".+(Sorry, we can not convert this video).");
                if (sorry.Count > 0)
                {
                    VideoConcurrentDic[index][3] = "无法下载";
                    completeCounter++;
                    CompleteQueue.Enqueue(index);
                }
                else
                {
                    m = Regex.Matches(json_reslut_convert, @"<a href=.+(http.?:.+)\\\W?\s?target="); // <a href=.+(http.?:.+_320kbps.mp3).+target=
                    while (m.Count == 0)
                    {

//                        var json_checkdone = await myWeb.MakePostAsync("https://y2mate.com/checkdone2.php",
//                            $"type=youtube&_id={_id}&v_id={v_id}&ajax=1");
//                        m = Regex.Matches(json_checkdone, @"<a href=.+(http.?:.+_320kbps.mp3).+target=");
                        json_reslut_convert =
                            await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320&token=");
                        m = Regex.Matches(json_reslut_convert, @"<a href=.+(http.?:.+)\\\W?\s?target="); //<a href=.+(http.?:.+_320kbps.mp3).+target=
                        Thread.Sleep(500);
                    }
                    if (m.Count > 0)
                    {
                        url_Mp3_download = m[0].Groups[1].Value;
                    }

                    Console.WriteLine(url_Mp3_download);
                    url_Mp3_download = url_Mp3_download.Replace(@"\", "");
                    m = Regex.Matches(url_Mp3_download, $"https?.+y2mate.com - (.+)_{v_id}_320kbps.mp3");
                    var mp3Name = "";
                    // 处理中文名字的视频，文件名为空的问题
                    if (m.Count != 0)
                    {
//                        mp3Name = m[0].Groups[1].Value;
                        mp3Name = Unicode2String(videoTitle);
                    }
                    else
                    {
                        mp3Name = Unicode2String(videoTitle); //v_id;
                    }
                    StringBuilder rBuilder = new StringBuilder(mp3Name);
                    foreach (var rInvalidChar in Path.GetInvalidFileNameChars())
                        rBuilder.Replace(rInvalidChar.ToString(), string.Empty);
                    mp3Name = rBuilder.ToString();
                    Console.WriteLine(mp3Name);
                    DownloadMP3(url_Mp3_download, $"{mp3Name}.mp3", index);
                }
        
            }
            else
            {
                VideoConcurrentDic[index][3] = "无法下载";
                completeCounter++;
                CompleteQueue.Enqueue(index);
            }

        }

        /// Unicode转字符串

        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }



        public void DownloadMP3(string URL, string filename, int index)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    float num = 0;
                    HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(URL);
                    HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
                    int num2 = (int) httpWebResponse.ContentLength;

                    Stream responseStream = httpWebResponse.GetResponseStream();
                    Stream stream = new FileStream(filename, FileMode.Create);
                    int num3 = 0;
                    byte[] array = new byte[1024];
                    int num4 = responseStream.Read(array, 0, array.Length);
                    //			    label4.Visible = true;
                    while (num4 > 0)
                    {
                        num3 = num4 + num3;
                        Application.DoEvents();
                        stream.Write(array, 0, num4);

                        num4 = responseStream.Read(array, 0, array.Length);
                        num = ((float) num3 / num2) * 100;
                        var progText = num.ToString("F0") + "%";
//                        updateDt(index, progText);
                        VideoConcurrentDic[index][3] = progText;
//                        Console.WriteLine($"下载进度: {index} =》 {progText}");
                        //					baifenbi.Text = num.ToString("F2") + "%";
                        //                    Console.WriteLine(num + " : " + num3 + " : " + num2);
                    }

                    stream.Close();
                    responseStream.Close();
                }
                else
                {
//                    updateDt(index, "已下载过了");
                    VideoConcurrentDic[index][3] = "已下载过了";
                }

                completeCounter++;
                CompleteQueue.Enqueue(index);
            }
            catch
            {
            }
        }

        private void dataGridView_Youtube_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell dataGridViewCheckBoxCell =
                    (DataGridViewCheckBoxCell) dataGridView_Youtube.Rows[e.RowIndex].Cells["选择"];
                if (Convert.ToBoolean(dataGridViewCheckBoxCell.Value))
                {
                    dataGridViewCheckBoxCell.Value = false;
                }
                else
                {
                    dataGridViewCheckBoxCell.Value = true;
                }
            }
        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            //遍历datagridview中的每一行，判断是否选中，若为选中，则选中
            for (int i = 0; i < dataGridView_Youtube.Rows.Count; i++)
            {
                if ((Convert.ToBoolean(dataGridView_Youtube.Rows[i].Cells[0].Value) == false))
                {
                    dataGridView_Youtube.Rows[i].Cells[0].Value = "True";
                }
                else
                    continue;
            }
        }

        private void btn_unSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView_Youtube.Rows.Count; i++)
            {
                if ((Convert.ToBoolean(dataGridView_Youtube.Rows[i].Cells[0].Value) == true))
                {
                    dataGridView_Youtube.Rows[i].Cells[0].Value = "False";
                }
                else
                    continue;
            }
        }

        private async void  btn_Test_Click(object sender, EventArgs e)
        {
            var url_youtube = txtB_Youtube_URL.Text;
            string startUrl = "https://y2mate.com/youtube-to-mp3/";
            string url_prefix_ajax = "https://y2mate.com/mp3/ajax";
            myWebClient myWeb = new myWebClient();
            string content = await myWeb.MakeRequestAsync(startUrl);
            string json_music = await myWeb.MakePostAsync(url_prefix_ajax,
                $"url={url_youtube}&t=18s&ajax=1");

            MatchCollection m = Regex.Matches(json_music, @"\s+_id:.(\w+).,.+\s+v_id:\s.([\w|\s|-]+).,");
            string _id = m[0].Groups[1].Value;
            string v_id = m[0].Groups[2].Value;
            string url_prefix_Convert = "https://y2mate.com/mp3Convert";
            string json_reslut_convert =
                await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320");
            var url_Mp3_download = "";
//            m = Regex.Matches(json_reslut_convert, @".+url: .+/(checkdone2.php).+,.+\s+id: \W+(\w+)\W+,");
//            var final_result = "";
//            if (m.Count != 0)
//            {
//                if (m[0].Groups[1].Value.Contains("checkdone2"))
//                {
//                    var id_checkdone = m[0].Groups[2].Value;
//                    final_result = await myWeb.MakePostAsync("https://y2mate.com/checkdone2.php",
//                        $"type=youtube&_id={id_checkdone}&v_id={v_id}&ajax=1");
//                }
//            }
//            else
//            {
//                final_result = json_reslut_convert;
//            }
            m = Regex.Matches(json_reslut_convert, @"<a href=.+(https:.+_320kbps.mp3).+target=");
            while (m.Count == 0)
            {
                json_reslut_convert =
                    await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320");
                m = Regex.Matches(json_reslut_convert, @"<a href=.+(https:.+_320kbps.mp3).+target=");
                Thread.Sleep(2000);
            }
            if (m.Count > 0)
            {
                url_Mp3_download = m[0].Groups[1].Value;
            }

            Console.WriteLine(url_Mp3_download);
        }

        private async Task<string> get_urlMp3DownloadFromY2mate(string url_youtube)
        {
            string startUrl = "https://y2mate.com/youtube-to-mp3/";
            string url_prefix_ajax = "https://y2mate.com/mp3/ajax";
            myWebClient myWeb = new myWebClient();
            string content = await myWeb.MakeRequestAsync(startUrl);
            string json_music = await myWeb.MakePostAsync(url_prefix_ajax,
                $"url={url_youtube}&t=18s&ajax=1");

            MatchCollection m = Regex.Matches(json_music, @"\s+_id:.(\w+).,.+\s+v_id:\s.([\w|\s|-]+).,");
            string _id = m[0].Groups[1].Value;
            string v_id = m[0].Groups[2].Value;
            string url_prefix_Convert = "https://y2mate.com/mp3Convert";
            string json_reslut_convert =
                await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320");
            var url_Mp3_download = "";
            m = Regex.Matches(json_reslut_convert, @"<a href=.+(https:.+_320kbps.mp3).+target=");
            while (m.Count == 0)
            {
                json_reslut_convert =
                    await myWeb.MakePostAsync(url_prefix_Convert, $"type=youtube&_id={_id}&v_id={v_id}&mp3_type=320");
                m = Regex.Matches(json_reslut_convert, @"<a href=.+(https:.+_320kbps.mp3).+target=");
                Thread.Sleep(2000);
            }
            if (m.Count > 0)
            {
                url_Mp3_download = m[0].Groups[1].Value;
            }

            Console.WriteLine(url_Mp3_download);
            return url_Mp3_download;
        }

        private void btn_pasteURL_Click(object sender, EventArgs e)
        {
            IDataObject iData = Clipboard.GetDataObject();
            if (iData.GetDataPresent(DataFormats.Text))
            {//如果剪贴板中的数据是文本格式 
                this.txtB_Youtube_URL.Text = (string)iData.GetData(DataFormats.Text);//检索与指定格式相关联的数据 
            }
            else
            {
                MessageBox.Show("目前剪贴板中数据不可转换为文本", "错误");
            }
        }
    }
}