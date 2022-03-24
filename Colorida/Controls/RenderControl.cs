using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Colorida.Controls
{
    public class RenderControl
    {
        public FrameworkElement frameworkelement;

        BitmapSource bitmap;

        public Size SizeControl
        {
            get;set;
        } = Size.Empty;

        public int DPI_X
        {
            get; set;
        } = 96;
        public int DPI_Y
        {
            get; set;
        } = 96;
        public RenderControl()
        {
            // Хачу Жрать!

        }
        public RenderControl(FrameworkElement element)
        {
            frameworkelement = element;
            SizeUpdate();
        }
        public RenderControl(FrameworkElement visual , Size size)
        {
            frameworkelement = visual;
            SizeControl = size;
            SizeUpdate();
        }
        public void SizeUpdate()
        {
            if (frameworkelement.Width > 0 && frameworkelement.Height > 0)
                SizeControl = new Size(frameworkelement.Width, frameworkelement.Height);
            if (frameworkelement.ActualWidth > 0 && frameworkelement.ActualHeight > 0)
                SizeControl = new Size(frameworkelement.ActualWidth, frameworkelement.ActualHeight);
        }
        public void Render()
        {
            if (frameworkelement == null)
                return;
            frameworkelement.Measure(SizeControl);
            frameworkelement.Arrange(new Rect(SizeControl));
            RenderTargetBitmap bmp = new RenderTargetBitmap(
                (int)SizeControl.Width,
                (int)SizeControl.Height,
                DPI_X, DPI_Y, PixelFormats.Pbgra32);
            bmp.Render(frameworkelement);
            bitmap = BitmapFrame.Create(bmp);
        }
        public Color GetColorPoint(Point point)
        {
            return GetColorPoint((int)point.X, (int)point.Y);
        }
        public Color GetColorPoint( int x , int y)
        {
            try
            {
                byte[] pixels = new byte[4];
                int stride = (bitmap.PixelWidth * bitmap.Format.BitsPerPixel + 7) / 8;
                bitmap.CopyPixels(new Int32Rect(x, y, 1, 1), pixels, stride, 0);
                return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
             
            }
            catch (Exception)
            {

                return Color.FromArgb(255, 255, 255, 255);
            }
        }

    }
}
