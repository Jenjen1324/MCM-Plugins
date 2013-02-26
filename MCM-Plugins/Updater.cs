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
        const string LocalVersion = "0.3";

        public bool CheckForUpdates()
        {
            Config c = DataHolder.GetConfig("mcmp");
            if (c == null)
            {
                c = new Config("mcmp");
                //ADD CONFIG ITEMS
                DataHolder.AddConfig(c);
            }


            bool auto = !((bool)DataHolder.GetConfig().Get("autoupdate"));

            if (c.Get("Auto Update") == null)
            {
                c.Set("Auto Update", Config.Type.Bool, true);
            }

            if ((bool)c.Get("Auto Update") || auto)
            {
                WebClient wc = new WebClient();
                string version = wc.DownloadString("https://raw.github.com/Northcode/MCM-Plugins/master/MCM-Plugins/ver.txt");
                string localversion = LocalVersion;
                return version != localversion;
            }
            else
            {
                return false;
            }
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
