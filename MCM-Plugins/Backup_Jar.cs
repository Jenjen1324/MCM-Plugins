using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCManager.Backups;

namespace MCManager
{
    internal class Backup_Jar : IBackup
    {
        private string name;
        private string desc;
        private string file;

        public void Extract()
        {
            try
            {
                byte[] jardata = GetData();
                File.WriteAllBytes(Data.minecraftbin + "minecraft.jar", jardata);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error while loading backup: " + name + "\r\n Tech info: " + ex.ToString());
            }
        }

        public byte[] GetData()
        {
            string path = file;
            BinaryReader br = new BinaryReader(new FileStream(path, FileMode.Open));
            br.ReadByte();
            br.ReadString();
            int len = br.ReadInt32();
            byte[] jardata = br.ReadBytes(len);
            br.Close();
            return jardata;
        }

        public string GetName()
        {
            return name;
        }

        public string GetDescription()
        {
            return desc;
        }

        public string GetBackupType()
        {
            return "minecraft jar";
        }

        public Backup_Jar(string name, string desc, string file)
        {
            this.name = name;
            this.desc = desc;
            this.file = file;
        }

        public IBackupFormat GetFormat()
        {
            return new Format_Jar();
        }

        public string GetFilePath()
        {
            return file;
        }
    }
}