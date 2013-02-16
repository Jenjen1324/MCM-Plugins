using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCManager.Backups;

namespace MCM_Plugins
{
    class Format_LoginInfo : IBackupFormat
    {
        public IBackup CreateBackup()
        {
            throw new NotImplementedException();
        }

        public string GetFormatName()
        {
            throw new NotImplementedException();
        }

        public IBackup Load(string file)
        {
            throw new NotImplementedException();
        }

        public void Save(string file, IBackup backup)
        {
            throw new NotImplementedException();
        }

        public byte getSignature()
        {
            throw new NotImplementedException();
        }
    }
}
