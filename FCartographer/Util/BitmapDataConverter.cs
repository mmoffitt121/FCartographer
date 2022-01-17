using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace FCartographer
{
    /// <summary>
    /// Responsible for converting bitmaps to different data types and vice versa.
    /// </summary>
    public static unsafe class BitmapDataConverter
    {
        /// <summary>
        /// Converts greyscale bitmap to byte array
        /// </summary>
        public static unsafe byte[] GreyscaleBitmapToByteArray(Bitmap bitmap)
        {
            BitmapData dat = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            byte* top = (byte*)dat.Scan0.ToPointer();
            int pixsiz = Image.GetPixelFormatSize(dat.PixelFormat) / 8;
            int stride = dat.Stride;

            int width = dat.Width;
            int height = dat.Height;

            byte[] output = new byte[bitmap.Width * bitmap.Height];

            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    output[j * bitmap.Width + i] = top[(j * bitmap.Width + i) * pixsiz];
                }
            }

            bitmap.UnlockBits(dat);

            return output;
        }

        /// <summary>
        /// Draws a byte array onto a bitmap
        /// </summary>
        /// <param name="data"></param>
        /// <param name="bytes"></param>
        public static unsafe void DrawImage(Bitmap data, byte[] bytes)
        {
            BitmapData dat = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), ImageLockMode.ReadWrite, data.PixelFormat);
            byte* top = (byte*)dat.Scan0.ToPointer();
            int pixsiz = Image.GetPixelFormatSize(dat.PixelFormat) / 8;
            int stride = dat.Stride;

            int width = dat.Width;
            int height = dat.Height;

            byte clr;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    clr = bytes[j * width + i];
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }
            }

            data.UnlockBits(dat);
        }

        /// <summary>
        /// Converts bitmap to byte array
        /// </summary>
        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            BitmapData dat = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
            IntPtr top = dat.Scan0;
            int bytecount = dat.Stride * bitmap.Height;

            byte[] output = new byte[bitmap.Width * bitmap.Height * 4];

            Marshal.Copy(top, output, 0, bytecount);

            bitmap.UnlockBits(dat);

            return output;
        }
    }
}