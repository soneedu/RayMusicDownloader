using System;
using System.Windows.Forms;

namespace MusicDownloader
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }

  
    }
}