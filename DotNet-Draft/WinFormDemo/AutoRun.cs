using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class AutoRun : System.Windows.Forms.Form
    {
        public AutoRun()
        {
            InitializeComponent();
        }

        protected Config config;

        private void btnSelectFiles_Click(object sender, EventArgs e)
        {
            DialogResult dialogRes = openFileDialog1.ShowDialog();
            if (DialogResult.OK == dialogRes)
            {
                String[] files = openFileDialog1.FileNames;
                foreach (string item in files)
                {
                    lvFiles.Items.Add(item);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblCopyRes.Text = "";
            try
            {
                DialogResult dialogRes = folderBrowserDialog1.ShowDialog();
                if (DialogResult.OK == dialogRes)
                {
                    txtDstPath.Text = folderBrowserDialog1.SelectedPath;
                    foreach (ListViewItem item in lvFiles.Items)
                    {
                        FileInfo fi = new FileInfo(item.Text);
                        File.Copy(item.Text, txtDstPath.Text + "\\    " + fi.Name, true);
                    }
                }
                lblCopyRes.BackColor = Color.White;
                lblCopyRes.ForeColor = Color.Green;
                lblCopyRes.Text = "拷贝成功!!!";
            }
            catch (Exception)
            {
                lblCopyRes.BackColor = Color.Red;
                lblCopyRes.ForeColor = Color.Yellow;
                lblCopyRes.Text = "拷贝Error!!!文件已存在";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string jsonConfig = File.ReadAllText("config.json");

            config = Newtonsoft.Json.JsonConvert.DeserializeObject<Config>(jsonConfig);
        }

        private void btnStep0_Click(object sender, EventArgs e)
        {
            Process.Start(config.CompareToolPath, config.Dir_Org + "  " + config.Dir_Before);
        }

        private void btnStep1_Click(object sender, EventArgs e)
        {
            List<string> fourfiles = config.FourPath;
            foreach (string item in fourfiles)
            {
                FileInfo fi = new FileInfo(item);
                File.Copy(item.Trim(), Path.Combine(config.VipSbusPath, fi.Name.Trim()), true);
            }
        }

        private void btnStep2_Click(object sender, EventArgs e)
        {
            List<string> threefiles = config.ThreePath;
            foreach (string item in threefiles)
            {
                FileInfo fi = new FileInfo(item);
                File.Copy(item.Trim(), Path.Combine(config.GipSbusPath, fi.Name.Trim()), true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
