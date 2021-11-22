using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FCartographer
{
    /// <summary>
    /// Responsible for selecting an area on canvas based on color difference
    /// </summary>
    public static class AreaSelector
    {
        /// <summary>
        /// Returns a bitmap object filled based on mouse location and layer data.
        /// 
        /// Selection is contiguous, meaning only one region will be selected.
        /// 
        /// Utilizes scan line algorithm.
        /// 
        /// Generates image to overlay onto original image.
        /// </summary>
        public static unsafe Bitmap FillAreaContiguous(Bitmap bitmap, Point start, int tolerance, BrushPreset brush)
        {
            IList<GraphicsPath> pathlist = new List<GraphicsPath>();

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            Bitmap output = new Bitmap(bitmap.Width, bitmap.Height);
            Color clr = brush.GetColor();

            byte* imgtop = (byte*)data.Scan0.ToPointer();

            int pixelsiz = Image.GetPixelFormatSize(data.PixelFormat) / 8;
            System.Diagnostics.Debug.WriteLine(pixelsiz);

            /*int x1 = start.X;
            int x2 = start.X;
            int y1 = start.Y;
            int y2 = start.Y;*/

            //byte* pixel = imgtop + start.X * data.Stride + start.Y * pixelsiz;
            //pixel[1] = 255;

            for (int i = 0; i < data.Height; i++)
            {
                for (int j = 0; j < data.Width; j++)
                {
                    byte* pixel = imgtop + i * data.Stride + j * pixelsiz;
                    pixel[0] = 255;
                    pixel[1] = 0;
                    pixel[2] = 0;
                    pixel[3] = 255;
                }
            }

            /*while (true)
            {
                if ()
            }*/

            bitmap.UnlockBits(data);

            return output;
        }

        public static bool IsValid(Color tocheck, Color index, int tolerance)
        {
            if (Math.Abs(index.R - tocheck.R) <= tolerance && Math.Abs(index.G - tocheck.G) <= tolerance && Math.Abs(index.B - tocheck.B) <= tolerance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}