using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCManager.Backups;

namespace MCManager
{
    class Backup_Jar : IBackup
    {

        private string name;
        private string file;

        public void Extract()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }

        public string GetBackupType()
        {
            throw new NotImplementedException();
        }

        public Backup_Jar(string name, string file)
        { 
            this.name = name;
            this.file = file;
        }
    }
}
