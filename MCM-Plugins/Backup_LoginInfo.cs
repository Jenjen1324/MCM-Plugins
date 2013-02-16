using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MCManager.Backups;
using MCManager;

namespace MCM_Plugins
{
    class Backup_LoginInfo : IBackup
    {
        private LoginInfo login;
        private string displayname;
        private string file;

        public void Extract()
        {
            DataHolder.SetLoginInfo(login);
        }

        public string GetBackupType()
        {
            return "Login Info";
        }

        public string GetDescription()
        {
            return displayname;
        }

        public string GetFilePath()
        {
            return file;
        }

        public IBackupFormat GetFormat()
        {
            return new Format_LoginInfo();
        }

        public string GetName()
        {
            return login.GetName();
        }

        public LoginInfo GetLogin()
        {
            return login;
        }

        public Backup_LoginInfo(string name, string displayname, string password, string file)
        {
            this.login = new LoginInfo(name, password);
            this.displayname = displayname;
            this.file = file;
        }
    }
}
