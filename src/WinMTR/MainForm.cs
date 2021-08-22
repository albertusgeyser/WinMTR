using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinMTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show About Form . . .
            AboutForm aboutForm = new AboutForm();
            aboutForm.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show Settings Form . . .
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();        
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Quit WinMTR . . . 
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Send results to selected service provider . . .
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://url");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{\"user\":\"test\"," +
                              "\"password\":\"bla\"}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }
    }
}
