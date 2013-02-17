using MCManager;
using MCManager.Plugin_API;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace MCM_Plugins
{
    public class Updater : IUpdater
    {
        string path;
        const string LocalVersion = "0.11";

        public bool CheckForUpdates()
        {
            WebClient wc = new WebClient();
            string version = wc.DownloadString("https://raw.github.com/Northcode/MCM-Plugins/master/MCM-Plugins/Backup_Jar.cs");
            string localversion = LocalVersion;
            return version == localversion;
        }

        public string GetLocalPath()
        {
            return path;
        }

        public string GetUpdatePath()
        {
            return "https://github.com/Northcode/MCM-Plugins/raw/master/MCM-Plugins/bin/Release/MCM-Plugins.dll";
        }

        public void SetPath(string file)
        {
            path = file;
        }
    }
}
