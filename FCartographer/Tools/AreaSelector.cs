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
        /// Utilizes seed fill algorithm:
        /// 
        /// Init: Initialize stack of pointers to store pixel locations, target color, y-integer, boolean left and right.
        ///     - Push cursor point into the stack
        /// While stack != empty
        ///     - Pop, set y-integer to popped point
        ///     - While y-integer > 0, and pixel x, y-integer = target color, decrement y-integer
        ///     - increment y-integer
        ///     - left and right = false
        ///     - While y-integer less than height and pixel x, y-integer = targetcolor
        ///         - replace color (x, y1)
        ///         - if !left and x > 0 and pixel(x-1, y-integer) = target
        ///             - push pointer (x-1, yinteger) and left = true
        ///         - else, if left = true and x-1 is 0, and getpixel != target
        ///             - stop moving left
        ///         - Same thing, but going right
        ///     - Return new data
        /// 
        /// Generates image to overlay onto original image.
        /// </summary>
        public static unsafe void FillAreaContiguous(Bitmap bitmap, Point start, BrushPreset brush)
        {
            IList<GraphicsPath> pathlist = new List<GraphicsPath>();

            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, bitmap.PixelFormat);
            //BitmapData outputdata = bitmap.LockBits(new Rectangle(0, 0, output.Width, output.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, output.PixelFormat);

            Color clr = Color.FromArgb(100, 75, 130);// brush.GetColor();

            byte* imgtop = (byte*)data.Scan0.ToPointer();
            //byte* outtop = (byte*)outputdata.Scan0.ToPointer();

            int pixelsiz = Image.GetPixelFormatSize(data.PixelFormat) / 8;
            // System.Diagnostics.Debug.WriteLine(start.X  + " " + start.Y);

            /*int x1 = start.X;
            int x2 = start.X;
            int y1 = start.Y;
            int y2 = start.Y;*/

            // Seed algorithm starts here ---

            Stack<Point> points = new Stack<Point>();

            byte* pixel = imgtop + start.Y * data.Stride + start.X * pixelsiz;
            Color targetcolor = Color.FromArgb(pixel[3], pixel[2], pixel[1], pixel[0]);

            int line;

            bool left;
            bool right;

            points.Push(new Point(start.X, start.Y));
            
            PointerToPoint(pixel, imgtop, data.Stride, pixelsiz);

            while (points.Count > 0)
            {
                Point pt = points.Pop();
                line = pt.Y;
                while (line > 0 && IsValid(PointToPointer(pt.X, line, imgtop, pixelsiz, data.Stride), targetcolor))
                {
                    line--;
                }

                line++;
                left = false;
                right = false;

                while (line < data.Height && IsValid(PointToPointer(pt.X, line, imgtop, pixelsiz, data.Stride), targetcolor))
                {
                    ChangeColor(imgtop, pt.X, line, clr, pixelsiz, data.Stride);

                    // Scanning Left

                    if (!left && pt.X > 0 && IsValid(PointToPointer(pt.X - 1, line, imgtop, pixelsiz, data.Stride), targetcolor))
                    {
                        points.Push(new Point(pt.X - 1, line));
                        left = true;
                    }
                    else if (left && pt.X - 1 >= 0 && !IsValid(PointToPointer(pt.X - 1, line, imgtop, pixelsiz, data.Stride), targetcolor))
                    {
                        left = false;
                    }

                    // Scanning Right

                    if (!right && pt.X < data.Width - 1 && IsValid(PointToPointer(pt.X + 1, line, imgtop, pixelsiz, data.Stride), targetcolor))
                    {
                        points.Push(new Point(pt.X + 1, line));
                        right = true;
                    }
                    else if (right && pt.X < data.Width - 1 && !IsValid(PointToPointer(pt.X + 1, line, imgtop, pixelsiz, data.Stride), targetcolor))
                    {
                        right = false;
                    }
                }
            }

            /*for (int i = 0; i < data.Height; i++)
            {
                for (int j = 0; j < data.Width; j++)
                {
                    byte* pixe = imgtop + i * data.Stride + j * pixelsiz;
                    pixe[0] = 255;
                    pixe[1] = 0;
                    pixe[2] = 0;
                    pixe[3] = 255;
                }
            }*/

            /*while (true)
            {
                if ()
            }*/

            bitmap.UnlockBits(data);
            //output.UnlockBits(outputdata);

            return;
        }

        public static unsafe byte* PointToPointer(int x, int y, byte* top, int pixelsiz, int stride)
        {
            return top + y * stride + x * pixelsiz;
        }

        public static unsafe Point PointerToPoint(byte* ptr, byte* top, int stride, int pixelsiz)
        {
            return new Point((int)(((ptr - top) % stride) / pixelsiz), (int)(((ptr - top) - (ptr - top) % stride) / (stride)));
        }

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

        public static unsafe void ChangeColor(byte* outtop, int x, int y, Color clr, int pixelsiz, int stride)
        {
            System.Diagnostics.Debug.WriteLine(clr.R + " " + clr.G + " " + clr.B + "  -  " + x + " " + y);
            byte* ptr = PointToPointer(x, y, outtop, pixelsiz, stride);
            ptr[0] = clr.B;
            ptr[1] = clr.G;
            ptr[2] = clr.R;
            ptr[3] = 255;
        }
    }
}