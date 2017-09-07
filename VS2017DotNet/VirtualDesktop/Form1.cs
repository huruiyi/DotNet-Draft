using Microsoft.Win32;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VirtualDesktop
{
    public partial class Form1 : Form
    {
        private int _lastDesktop;
        private ContextMenu _contextMenu;

        private const string LastFile = "VirtualDesktop.ini";

        public Form1()
        {
            InitializeComponent();
            _lastDesktop = -1;

            timer1.Interval = 50;
            timer1.Start();
        }

        private void ShowHide()
        {
            if (Visible)
            {
                HideForm();
            }
            else
            {
                Show();
            }
        }

        private void LoadSettings()
        {
            if (!File.Exists(LastFile))
            {
                return;
            }

            var last = File.ReadAllLines(LastFile);

            if (last.Length != 2)
            {
                return;
            }

            txtPic1.Text = last[0];
            txtPic2.Text = last[1];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblCopy.Text = "\u00A9 Blondy";

            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Virtual Desktop";
            notifyIcon1.Icon = Properties.Resources._virtual;

            _contextMenu = new ContextMenu();
            _contextMenu.MenuItems.Add("Show/Hide", (s, _) => ShowHide());
            _contextMenu.MenuItems.Add("Exit", (s, _) => Application.Exit());
            notifyIcon1.ContextMenu = _contextMenu;

            LoadSettings();

            HideForm();
        }

        private void HideForm()
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void ChooseFile(TextBox box)
        {
            using (var dlg = new OpenFileDialog
            {
                Filter = "Image files (*.bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp) | *.bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png |All Files (*.*)|*.*",
                InitialDirectory = string.IsNullOrEmpty(box.Text) ? null : Path.GetDirectoryName(box.Text)
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                box.Text = dlg.FileName;
            }
        }

        private int GetDesktopIndex()
        {
            for (int i = 0; i < Desktop.Count; ++i)
            {
                if (Desktop.Current.Equals(Desktop.FromIndex(i)))
                {
                    return i;
                }
            }

            return -1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPic1.Text) || string.IsNullOrEmpty(txtPic2.Text))
            {
                return;
            }

            var index = GetDesktopIndex();
            if (index == -1)
            {
                return;
            }

            if (_lastDesktop == index)
            {
                return;
            }

            SetBackground(index);
            _lastDesktop = index;
        }

        internal sealed class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern int SystemParametersInfo(
                int uAction,
                int uParam,
                String lpvParam,
                int fuWinIni);
        }

        public void SetBackground(int i)
        {
            string pic = null;

            switch (i)
            {
                case 0:
                    pic = txtPic1.Text;
                    break;

                case 1:
                    pic = txtPic2.Text;
                    break;

                case 2:
                    pic = txtPic3.Text;
                    break;

                default:
                    return;
            }

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            // Fill
            key.SetValue(@"PicturePosition", "10");
            key.SetValue(@"TileWallpaper", "0");
            key.SetValue(@"WallpaperStyle", "6");

            key.Close();

            const int setDesktopBackground = 20;
            const int updateIniFile = 1;
            const int sendWindowsIniChange = 2;

            NativeMethods.SystemParametersInfo(
                setDesktopBackground,
                0,
                pic,
                updateIniFile | sendWindowsIniChange);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            File.WriteAllLines(LastFile, new[] { txtPic1.Text, txtPic2.Text });
            HideForm();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFile(txtPic1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            ChooseFile(txtPic2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            ChooseFile(txtPic3);
        }
    }
}