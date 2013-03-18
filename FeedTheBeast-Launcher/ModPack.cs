using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeedTheBeast_Launcher
{
    public class ModPack
    {
        public string name { get; set; }
        public string author { get; set; }
        public string version { get; set; }
        public string repoVersion { get; set; }
        public string logo { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string dir { get; set; }
        public string mcVersion { get; set; }
        public string serverPack { get; set; }
        public string description { get; set; }
        public string mods { get; set; }
        public string oldVersions { get; set; }
        public string animation { get; set; }

        public string[] getModsByArray(string mods)
        {
            return mods.Split(new string[] {"; "}, StringSplitOptions.RemoveEmptyEntries);
        }

        public string[] getOldVersionsByArray(string oldVersions)
        {
            return oldVersions.Split(';');
        }

        public string getDownLoadLink(ModPack m)
        {
            throw new NotImplementedException();
        }

        public string getDownloadKey()
        {
            throw new NotImplementedException();
        }
    }
}
