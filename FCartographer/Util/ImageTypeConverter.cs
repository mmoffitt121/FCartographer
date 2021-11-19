using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    /// <summary>
    /// Responsible for selecting an area on canvas based on color difference
    /// </summary>
    public static class ImageTypeConverter
    {
        /// <summary>
        /// Converts bitmap to byte array
        /// </summary>
        public static byte[] BmpToByte(Bitmap bitmap)
        {
            ImageConverter conv = new ImageConverter();
            return (byte[])conv.ConvertTo(bitmap, typeof(byte[]));
        }
    }
}