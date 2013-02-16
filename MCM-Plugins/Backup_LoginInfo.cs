using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MCManager.Backups;

namespace MCM_Plugins
{
    class Backup_LoginInfo : IBackup
    {
        private string username;
        private string displayname;
        private string password;

        public void Extract()
        {
            throw new NotImplementedException();
        }

        public string GetBackupType()
        {
            throw new NotImplementedException();
        }

        public string GetDescription()
        {
            throw new NotImplementedException();
        }

        public string GetFilePath()
        {
            throw new NotImplementedException();
        }

        public IBackupFormat GetFormat()
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            throw new NotImplementedException();
        }
    }
}
