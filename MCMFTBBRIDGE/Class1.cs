using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCManager;
using MCManager.Plugin_API;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace MCMFTBBRIDGE
{
    public class MCMFTBBridge : IPlugin
    {
        public static string ftbpath = Data.appdatafolder + "ftb.jar";
        public const string ftburl = "http://www.creeperrepo.net/direct/FTB2/3ff3931ca8a4859ea55c71c084a5eef0/launcher%5EFTB_Launcher.jar";
        MainWindow mainwnd;
        ComboBox cbxMCStart;
        bool downloaded = false;

        public void Start(MainWindow mainwnd)
        {
            this.mainwnd = mainwnd;
            if (!File.Exists(ftbpath))
            {
                WebClient wc = new WebClient();
                wc.DownloadFileAsync(new Uri(ftburl), ftbpath);
                wc.DownloadFileCompleted += wc_DownloadFileCompleted;
            }
            TabPage t = mainwnd.GetTab("tabBackups");
            Control[] cbx = t.Controls.Find("cbxMCStart",true);
            if (cbx.Length > 0)
            {
                ComboBox cbxMCStart = cbx[0] as ComboBox;
                this.cbxMCStart = cbxMCStart;
                cbxMCStart.Items.Add("Start FTB");
                cbxMCStart.SelectedIndexChanged += cbxMCStart_SelectedIndexChanged;
            }
        }

        void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            downloaded = true;
            MessageBox.Show("Feed the beast launcher downloaded!");
        }

        void cbxMCStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxMCStart.SelectedItem as string == "Start FTB" && downloaded)
            {
                Process j = new Process();
                j.StartInfo.FileName = "java.exe";
                j.StartInfo.Arguments = "-jar \"" + ftbpath + "\"";
                j.Start();
            }
        }

        public void Stop()
        {
            return;
        }
    }
}
