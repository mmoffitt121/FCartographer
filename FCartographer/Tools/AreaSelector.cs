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
        public static List<GraphicsPath> SelectAreaContiguous(Bitmap bitmap, Point start, int tolerance)
        {
            IList<GraphicsPath> pathlist = new List<GraphicsPath>();
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