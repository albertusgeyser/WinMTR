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
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();        
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Send results to service provider . . .
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

        bool mtr_start = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (mtr_start == true)
            {
                mtr_start = false;
                button1.Text = "Start MTR";
                object BI = global::WinMTR.Properties.Resources.ResourceManager.GetObject("Play");
                button1.Image = (Image)BI;
            }
            else if (mtr_start == false)
            {
                mtr_start = true;
                button1.Text = "Stop MTR";
                object BI = global::WinMTR.Properties.Resources.ResourceManager.GetObject("Stop");
                button1.Image = (Image)BI;
            }
        }

        private void DetailToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (DetailToolStripMenuItem.Checked) { splitContainer1.Panel1Collapsed = false; }
            else { splitContainer1.Panel1Collapsed = true; }
        }

        private void GraphToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (GraphToolStripMenuItem.Checked) { splitContainer1.Panel2Collapsed = false; }
            else { splitContainer1.Panel2Collapsed = true; }
        }
    }
}
