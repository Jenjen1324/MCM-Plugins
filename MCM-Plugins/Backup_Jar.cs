using MCManager.Backups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MCManager
{
    class Backup_Jar : IBackup
    {

        private string name;
        private string file;

        public void Extract()
        {
            string path = Data.backupdir + file;
            try 
            {
                BinaryReader br = new BinaryReader(new FileStream(path,FileMode.Open));
                br.ReadByte();
                br.ReadString();
                int len = br.ReadInt32();
                byte[] jardata = br.ReadBytes(len);
                File.WriteAllBytes(Data.minecraftbin,jardata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading backup: " + name + "\r\n Tech info: " + ex.ToString());
            }
        }

        public string GetName()
        {
            return name;
        }

        public string GetBackupType()
        {
            return "minecraft jar";
        }

        public Backup_Jar(string name, string file)
        { 
            this.name = name;
            this.file = file;
        }

        public IBackupFormat GetFormat()
        {
            return new Format_Jar();
        }
    }
}
