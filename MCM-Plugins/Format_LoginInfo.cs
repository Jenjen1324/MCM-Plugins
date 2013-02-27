using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MCManager.Backups;
using System.IO;
using MCManager;

namespace MCM_Plugins
{
    class Format_LoginInfo : IBackupFormat
    {
        private byte signature = 0x02;

        public IBackup CreateBackup()
        {
            LoginInfo li = DataHolder.GetLoginInfo();
            string displayname_raw = InputBox.Show("Choose a displayname","Displayname:");
            if (displayname_raw != null)
            {
                int i = 1;
                string savepath = "";
                string displayname = displayname_raw.Replace(' ', '-');
                if (!File.Exists(Data.backupdir + displayname))
                {
                    savepath = Data.backupdir + displayname;
                }
                else
                {
                    while (File.Exists(Data.backupdir + displayname + "_" + i.ToString()))
                    {
                        savepath = Data.backupdir + displayname + "_" + i.ToString();
                    }

                }
                Backup_LoginInfo backup = new Backup_LoginInfo(li, displayname_raw, savepath);
                BinaryWriter bw = new BinaryWriter(new FileStream(savepath, FileMode.OpenOrCreate));
                bw.Write(signature);
                bw.Write(li.GetName());
                bw.Write(displayname_raw);
                bw.Write(li.GetPassword());
                bw.Close();
                return backup;
            }
            else
            {
                return null;
            }
        }

        public string GetFormatName()
        {
            return "LoginInfo backup";
        }

        public IBackup Load(string file)
        {
            BinaryReader br = new BinaryReader(new FileStream(file, FileMode.Open));
            br.ReadByte();
            string displayname = br.ReadString();
            int len = br.ReadInt32();
            LoginInfo li = LoginInfo.LoadFromMemory(br.ReadBytes(len));
            Backup_LoginInfo backup = new Backup_LoginInfo(li, displayname, file);
            br.Close();
            return backup;
        }

        public void Save(string file, IBackup backup)
        {
            LoginInfo li = (backup as Backup_LoginInfo).GetLogin();
            BinaryWriter bw = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate));
            bw.Write(signature);
            bw.Write(backup.GetDescription());
            byte[] ldata = li.SaveToMemory();
            bw.Write(ldata.Length);
            bw.Write(ldata);
            bw.Close();
        }

        public byte getSignature()
        {
            return signature;
        }


        public System.Drawing.Image GetImage()
        {
            return null;
        }

        public string GetImageName()
        {
            return null;
        }
    }
}
