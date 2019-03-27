using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDownloader
{
    /// <summary>
    /// 调用外部窗体
    /// </summary>
    /// <param name="text"></param>
    delegate void ProcessingCallback(string processing);

    class HttpMultiThreadDownload
    {
        const int _bufferSize = 5120;
        public Form1 frm { get; set; }
        public int ThreadId { get; set; }             // 线程 ID                 
        public string Url { get; set; }               // 文件 Url

        public HttpMultiThreadDownload(Form1 form, int threadId)
        {
            frm = form;
            ThreadId = threadId;
//            Url = frm.Url;
        }
        /// <summary>
        /// 析构方法
        /// </summary>
        ~HttpMultiThreadDownload()
        {
            if (!frm.InvokeRequired)
            {
                frm.Dispose();
            }
        }
        /// <summary>
        /// 接收
        /// </summary>
        public void receive()
        {
            string filename = frm.fileNames[ThreadId];     // 线程临时文件
            byte[] buffer = new byte[_bufferSize];         // 接收缓冲区
            int readSize = 0;                              // 接收字节数
            FileStream fs = new FileStream(filename, System.IO.FileMode.Create);
            Stream ns = null;

            Console.WriteLine("线程[" + ThreadId.ToString() + "] 开始接收......");
 
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.AddRange(frm.StartPos[ThreadId], frm.StartPos[ThreadId] + frm.fileSize[ThreadId]);
                ns = request.GetResponse().GetResponseStream();
                readSize = ns.Read(buffer, 0, _bufferSize);
                Console.WriteLine("线程[" + ThreadId.ToString() + "] 正在接收 " + readSize);
                while (readSize > 0)
                {
                    fs.Write(buffer, 0, readSize);
                    readSize = ns.Read(buffer, 0, _bufferSize);
//                    Console.WriteLine("线程[" + ThreadId.ToString() + "] 正在接收 " + readSize);
                }
                fs.Close();
                ns.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
                fs.Close();
            }
            Console.WriteLine("进程[" + ThreadId.ToString() + "] 结束!");
            frm.threadStatus[ThreadId] = true;
        }
        private void SetListBox(string processing)
        {
//            if (frm.lst_processing.InvokeRequired)
//            {
//                ProcessingCallback d = new ProcessingCallback(SetListBox);
//                frm.Invoke(d, new object[] { processing });
//            }
//            else
//            {
//                frm.lst_processing.Items.Add(processing);
//            }
        }
    }
}
