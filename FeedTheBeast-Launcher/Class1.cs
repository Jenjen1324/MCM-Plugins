using MCManager.Plugin_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Net;
using System.IO;
using System.Xml;

namespace FeedTheBeast_Launcher
{
    public class Class1 : IPlugin
    {

        public void Start(MCManager.MainWindow mainwnd)
        {
            #region Visuals
            mainwnd.AddTab("FTB");
            ListView listView_FTB_modpacks = new ListView();
            ComboBox comboBox_FTB_version = new ComboBox();
            Button button_FTB_start = new Button();
            TextBox textBox_FTB_packContent = new TextBox();

            mainwnd.Controls.Add(listView_FTB_modpacks);
            mainwnd.Controls.Add(comboBox_FTB_version);
            mainwnd.Controls.Add(button_FTB_start);
            mainwnd.Controls.Add(textBox_FTB_packContent);
            mainwnd.GetTab("FTB").Controls.Add(listView_FTB_modpacks);
            mainwnd.GetTab("FTB").Controls.Add(comboBox_FTB_version);
            mainwnd.GetTab("FTB").Controls.Add(button_FTB_start);
            mainwnd.GetTab("FTB").Controls.Add(textBox_FTB_packContent);
            // 
            // listView_FTB_modpacks
            // 
            listView_FTB_modpacks.Location = new System.Drawing.Point(8, 3);
            listView_FTB_modpacks.Name = "listView_FTB_modpacks";
            listView_FTB_modpacks.Size = new System.Drawing.Size(197, 324);
            listView_FTB_modpacks.TabIndex = 0;
            listView_FTB_modpacks.UseCompatibleStateImageBehavior = false;
            listView_FTB_modpacks.SelectedIndexChanged += new EventHandler(SelectedModChanged);
            // 
            // comboBox_version
            // 
            comboBox_FTB_version.FormattingEnabled = true;
            comboBox_FTB_version.Location = new System.Drawing.Point(211, 3);
            comboBox_FTB_version.Name = "comboBox_version";
            comboBox_FTB_version.Size = new System.Drawing.Size(80, 21);
            comboBox_FTB_version.TabIndex = 1;
            // 
            // button_start
            // 
            button_FTB_start.Location = new System.Drawing.Point(297, 3);
            button_FTB_start.Name = "button_start";
            button_FTB_start.Size = new System.Drawing.Size(75, 21);
            button_FTB_start.TabIndex = 2;
            button_FTB_start.Text = "button3";
            button_FTB_start.UseVisualStyleBackColor = true;
            button_FTB_start.Click += new EventHandler(FTB_Start);
            // 
            // textBox_packContent
            // 
            textBox_FTB_packContent.Location = new System.Drawing.Point(211, 30);
            textBox_FTB_packContent.Multiline = true;
            textBox_FTB_packContent.Name = "textBox_packContent";
            textBox_FTB_packContent.Size = new System.Drawing.Size(161, 297);
            textBox_FTB_packContent.TabIndex = 3;
            #endregion
            GetPackList();


        }

        private void FTB_Start(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void SelectedModChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void UpdateList()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            
        }

        private void GetPackList()
        {
            WebClient wc = new WebClient();
            string xml = wc.DownloadString("http://www.creeperrepo.net/static/FTB2/modpacks.xml");
            StringReader sr = new StringReader(xml);
            XmlReader xmlr = XmlReader.Create(sr);

            // Add some pars magic here
        }
    }
}
