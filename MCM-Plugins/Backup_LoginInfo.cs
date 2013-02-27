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
<<<<<<< HEAD
            return displayname;
=======
            return login.GetName();
>>>>>>> aa53c5827ac54899ac642789680a9abb55f5ec68
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
<<<<<<< HEAD
            return login.GetName();
=======
            return displayname;
>>>>>>> aa53c5827ac54899ac642789680a9abb55f5ec68
        }

        public LoginInfo GetLogin()
        {
            return login;
        }

<<<<<<< HEAD
        public Backup_LoginInfo(string name, string displayname, string password, string file)
        {
            this.login = new LoginInfo(name, password);
=======
        public Backup_LoginInfo(LoginInfo loginI, string displayname, string file)
        {
            this.login = loginI;
>>>>>>> aa53c5827ac54899ac642789680a9abb55f5ec68
            this.displayname = displayname;
            this.file = file;
        }
    }
}
