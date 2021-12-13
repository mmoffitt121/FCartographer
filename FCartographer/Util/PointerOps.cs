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
    /// Class holding pointer helper conversion functions. Uses unsafe functions.
    /// </summary>
    public static class PointerOps
    {
        /// <summary>
        /// Converts a point on a bitmap to a pointer in memory.
        /// </summary>
        public static unsafe byte* PointToPointer(int x, int y, byte* top, int pixelsiz, int stride)
        {
            return top + y * stride + x * pixelsiz;
        }

        /// <summary>
        /// Converts a pointer to a pixel on a bitmap to a point object.
        /// </summary>
        public static unsafe Point PointerToPoint(byte* ptr, byte* top, int stride, int pixelsiz)
        {
            return new Point((int)(((ptr - top) % stride) / pixelsiz), (int)(((ptr - top) - (ptr - top) % stride) / (stride)));
        }

        /// <summary>
        /// Detects if a color is equal to a byte* pixel on a bitmap.
        /// </summary>
        public static unsafe bool IsValid(byte* clr, Color index)
        {
            if (index.R - clr[2] == 0 && index.G - clr[1] == 0 && index.B - clr[0] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Changes the color of a point on a bitmap.
        /// </summary>
        public static unsafe void ChangeColor(byte* outtop, int x, int y, Color clr, int pixelsiz, int stride)
        {
            byte* ptr = PointToPointer(x, y, outtop, pixelsiz, stride);
            ptr[0] = clr.B;
            ptr[1] = clr.G;
            ptr[2] = clr.R;
            ptr[3] = 255;
        }
    }
}