using System;
using System.IO;
using MCM_Plugins;
using MCManager;
using MCManager.Backups;

namespace MCManager
{
    internal class Format_Jar : IBackupFormat
    {
        private byte signature = 0x01;

        public IBackup Load(string file)
        {
            BinaryReader br = new BinaryReader(new FileStream(file, FileMode.Open));
            br.ReadByte();
            string name = br.ReadString();
            string desc = br.ReadString();
            Backup_Jar backup = new Backup_Jar(name, desc, file);
            br.Close();
            return backup;
        }

        public void Save(string file, IBackup backup)
        {
            byte[] jardata = (backup as Backup_Jar).GetData();
            BinaryWriter bw = new BinaryWriter(new FileStream(file, FileMode.OpenOrCreate));
            bw.Write(signature);
            bw.Write(backup.GetName());
            bw.Write(backup.GetDescription());
            bw.Write(jardata);
            bw.Close();
        }

        public byte getSignature()
        {
            return 0x01;
        }

        public IBackup CreateBackup()
        {
            CreateBackup cb = new CreateBackup("Create new JarBackup", "Name:", "Description:", "File:", "", "", Data.minecraftbin + "minecraft.jar", false);
            if (cb.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (File.Exists(cb.path))
                {
                    if (cb.name != "")
                    {
                        Backup_Jar backup = new Backup_Jar(cb.name, cb.description, Data.backupdir + cb.name + ".backup");
                        BinaryWriter bw = new BinaryWriter(new FileStream(backup.GetFilePath(), FileMode.OpenOrCreate));
                        bw.Write(signature);
                        bw.Write(backup.GetName());
                        bw.Write(backup.GetDescription());
                        bw.Write(File.ReadAllBytes(Data.minecraftbin + "minecraft.jar"));
                        bw.Close();
                        return backup;
                    }
                    else
                    {
                        ErrorReporter.Error("You have to enter a name for the backup!");
                        return null;
                    }
                }
                else
                {
                    ErrorReporter.Error("Invalid file!");
                    return null;
                }
            }
            return null;
        }

        public string GetFormatName()
        {
            return "Jar backup";
        }
    }
}