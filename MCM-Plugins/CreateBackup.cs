using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MCM_Plugins
{
    public partial class CreateBackup : Form
    {
        bool browseIsDir;
        public CreateBackup(string head, string label1, string label2, string label3, string textBox1, string textBox2, string textBox3, bool browseIsDir)
        {
            InitializeComponent();
            this.Text = head;
            this.label1.Text = label1;
            this.label2.Text = label2;
            this.label3.Text = label3;
            this.textBox1.Text = textBox1;
            this.textBox2.Text = textBox2;
            this.textBox3.Text = textBox3;
        }

        public string name
        {
            get { return textBox1.Text; }
        }

        public string description
        {
            get { return textBox2.Text; }
        }

        public string path
        {
            get { return textBox3.Text; }
        }
    }
}
