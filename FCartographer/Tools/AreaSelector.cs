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
    public static class AreaSelector
    {
        /// <summary>
        /// Returns a graphics path outlining a specific area on a bitmap.
        /// </summary>
        public static GraphicsPath SelectArea(Bitmap bitmap, Point start, int tolerance)
        {
            IList<Point> points = new List<Point>();

            byte[] image = ImageTypeConverter.BmpToByte(bitmap);

            System.Diagnostics.Debug.WriteLine(image[0] + " " + image[1]);

            /*int direction = 2;
            Point curpos = start;

            while (true)
            {
                if 
            }*/

            GraphicsPath outpath = new GraphicsPath();

            return outpath;
        }

        public static bool IsValid(Color tocheck, Color index, int tolerance)
        {
            if (index.R - tocheck.R <= tolerance && index.G - tocheck.G <= tolerance && index.B - tocheck.B <= tolerance)
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