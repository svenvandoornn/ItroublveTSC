using System;
using DiscordFlooder.Class.Design.Rainbow;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;

namespace ItroublveTSC
{
    public partial class Credits : Form
    {
        #region GUI
        public Credits()
        {
            InitializeComponent();
            RainbowTimer.Start();
        }
        private void RainbowTimer_Tick(object sender, EventArgs e)
        {
            Rainbow.RainbowEffect();
            pnlRainbowTop.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
            PnlRainbowDown.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            var frmMain2 = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frmMain2 == null)
            {
                frmMain2 = new frmMain();
            }
            frmMain2.StartPosition = FormStartPosition.Manual;
            frmMain2.Location = Location;
            frmMain2.Show();
            Hide();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            if (File.Exists("TokenStealerCOPY.bin"))
            {
                File.Delete("TokenStealerCOPY.bin");
            }
            if (Directory.Exists(Path.GetTempPath() + "bin_copy"))
            {
                Directory.Delete(Path.GetTempPath() + "bin_copy", true);
            }
            File.Delete(Path.GetTempPath() + "convertedicon.ico");
            Environment.Exit(0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void HeadServerLbl_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse.x = MousePosition.X - Location.X;
            Mouse.y = MousePosition.Y - Location.Y;
        }

        private void HeadServerLbl_MouseMove(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                Mouse.newpoint = MousePosition;
                Mouse.newpoint.X = Mouse.newpoint.X - Mouse.x;
                Mouse.newpoint.Y = Mouse.newpoint.Y - Mouse.y;
                Location = Mouse.newpoint;
            }
        }

        private void HeadLinePnlInf_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse.x = MousePosition.X - Location.X;
            Mouse.y = MousePosition.Y - Location.Y;
        }

        private void HeadLinePnlInf_MouseMove(object sender, MouseEventArgs e)
        {
            bool flag = e.Button == MouseButtons.Left;
            if (flag)
            {
                Mouse.newpoint = MousePosition;
                Mouse.newpoint.X = Mouse.newpoint.X - Mouse.x;
                Mouse.newpoint.Y = Mouse.newpoint.Y - Mouse.y;
                Location = Mouse.newpoint;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var advanced = Application.OpenForms.OfType<Advanced>().FirstOrDefault();
            if (advanced == null)
            {
                advanced = new Advanced();
            }
            advanced.StartPosition = FormStartPosition.Manual;
            advanced.Location = Location;
            advanced.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filesize = Application.OpenForms.OfType<FileSize>().FirstOrDefault();
            if (filesize == null)
            {
                filesize = new FileSize();
            }
            filesize.Show();
            Hide();
        }

        private void FileBtn_Click(object sender, EventArgs e)
        {
            var filestealer = Application.OpenForms.OfType<FileStealer>().FirstOrDefault();
            if (filestealer == null)
            {
                filestealer = new FileStealer();
            }
            filestealer.StartPosition = FormStartPosition.Manual;
            filestealer.Location = Location;
            filestealer.Show();
            Hide();
        }
        #endregion
    }
}
