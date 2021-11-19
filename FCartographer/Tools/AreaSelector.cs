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
        /// Returns a graphics path outlining a specific area on a bitmap.
        /// 
        /// Selection is contiguous, meaning only one region will be selected.
        /// 
        /// Algorithm:
        ///     Scan east/down and west/up from clicked point.
        ///     Run into wall? Run blind man algorithm
        ///         If clicked point found in region
        ///             Output[0] = region
        ///         else
        ///             Output.add region
        ///     Continue scanning until impossible
        /// 
        /// Returns list of GraphicsPath objects, the first being the surrounding (include) path, and all 
        /// subsequent being island (exclude) paths.
        /// </summary>
        public static unsafe IList<GraphicsPath> SelectAreaContiguous(Bitmap bitmap, Point start, int tolerance)
        {
            IList<GraphicsPath> pathlist = new List<GraphicsPath>();

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.DontCare);

            int x1 = start.X;
            int x2 = start.X;
            int y1 = start.Y;
            int y2 = start.Y;
            System.Diagnostics.Debug.WriteLine(x1 + " " + x2);
            /*while (true)
            {
                if ()
            }*/

            GraphicsPath outpath = new GraphicsPath();
            pathlist.Add(outpath);

            bitmap.UnlockBits(data);

            return pathlist;
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