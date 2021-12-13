using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.ExceptionServices;

namespace FCartographer
{
    /// <summary>
    /// Landscape generator class, used to generate a custom landscape based on a seed, and user defined options. Will use unsafe functions.
    /// </summary>
    public unsafe class LandscapeGenerator : Generator
    {
        private Bitmap data;
        private List<Point> points;

        private byte* top;
        private int pixsiz;
        private int stride;

        private int width;
        private int height;

        private Random rand;

        private int density;
        private int steepness;

        /// <summary>
        /// Populates points on the bitmap for generation
        /// </summary>
        public void PopulatePoints(int _density, int seed)
        {
            if (density < 0)
            {
                return;
            }

            density = _density;

            Random rand = new Random(seed);

            for (int i = 0; i < data.Width; i++)
            {
                for (int j = 0; j < data.Height; j++)
                {
                    if (rand.Next(density) == 0)
                    {
                        points.Add(new Point(i, j));
                    }
                }
            }
        }

        /// <summary>
        /// Draws points for debug use
        /// </summary>
        public void DrawPoints()
        {
            using (Graphics g = Graphics.FromImage(data))
            {
                foreach (Point pt in points)
                {
                    g.DrawEllipse(new Pen(Color.FromArgb(255, 255, 255, 255)), pt.X - 2, pt.Y - 2, 4, 4);
                }
            }
        }

        /// <summary>
        /// Draws points for debug use of specified color
        /// </summary>
        public void DrawPoints(Color clr)
        {
            using (Graphics g = Graphics.FromImage(data))
            {
                foreach (Point pt in points)
                {
                    g.DrawEllipse(new Pen(clr), pt.X - 2, pt.Y - 2, 4, 4);
                }
            }
        }

        /// <summary>
        /// Generates mountains on internal bitmap
        /// </summary>
        public unsafe void GenerateMountains(int _steepness, int seed)
        {
            BitmapData dat = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, data.PixelFormat);
            top = (byte*)dat.Scan0.ToPointer();
            pixsiz = Image.GetPixelFormatSize(dat.PixelFormat) / 8;
            stride = dat.Stride;

            width = dat.Width;
            height = dat.Height;

            steepness = _steepness;

            rand = new Random(seed);

            // Draws initial lines between points

            Point cur1, cur2;

            while (points.Count > 1)
            {
                // Get the closest adjacent point
                cur1 = points[0];
                cur2 = points[1];
                for (int i = 1; i < points.Count; i++)
                {
                    // Subtraction of distance formulas
                    if (Math.Sqrt(Math.Pow(points[i].X - cur1.X, 2) + Math.Pow(points[i].Y - cur1.Y, 2)) < Math.Sqrt(Math.Pow(cur2.X - cur1.X, 2) + Math.Pow(cur2.Y - cur1.Y, 2)))
                    {
                        cur2 = points[i];
                    }
                }

                if (Math.Sqrt(Math.Pow(cur2.X - cur1.X, 2) + Math.Pow(cur2.Y - cur1.Y, 2)) > density / 5)
                {
                    points.Remove(cur1);
                    continue;
                }

                // Draws lines between the points.

                if (Math.Abs(cur2.Y - cur1.Y) < Math.Abs(cur2.X - cur1.X))
                {
                    if (cur1.X > cur2.X)
                    {
                        DrawRidgeLow(cur2.X, cur2.Y, cur1.X, cur1.Y);
                    }
                    else
                    {
                        DrawRidgeLow(cur1.X, cur1.Y, cur2.X, cur2.Y);
                    }
                }
                else
                {
                    if (cur1.Y > cur2.Y)
                    {
                        DrawRidgeHigh(cur2.X, cur2.Y, cur1.X, cur1.Y);
                    }
                    else
                    {
                        DrawRidgeHigh(cur1.X, cur1.Y, cur2.X, cur2.Y);
                    }
                }

                points.Remove(cur1);
            }

            data.UnlockBits(dat);

            //DrawPoints(Color.Red);
        }

        private unsafe void DrawRidgeLow(int x0, int y0, int x1, int y1)
        {
            int x, y, d, dx, dy, chg;

            dx = x1 - x0;
            dy = y1 - y0;

            if (dy < 0)
            {
                chg = -1;
                dy = -dy;
            }
            else
            {
                chg = 1;
            }

            d = (2 * dy) - dx;
            y = y0;


            int xdeviation = 0;
            int ydeviation = 0;
            int xp;
            int yp;

            for (x = x0; x <= x1; x++)
            {
                xdeviation = Math.Clamp(Math.Clamp(xdeviation + rand.Next(-1, 2), -16, 16), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                ydeviation = Math.Clamp(Math.Clamp(ydeviation + rand.Next(-1, 2), -16, 16), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                xp = Math.Clamp(x + xdeviation, 0, height - 1);
                yp = Math.Clamp(y + ydeviation, 0, width - 1);
                PointerOps.ChangeColor(top, xp, yp, Color.White, pixsiz, stride);

                ExpandMountain(xp, yp);

                if (d > 0)
                {
                    y = y + chg;
                    d = d + (2 * (dy - dx));
                }
                else
                {
                    d = d + 2 * dy;
                }
            }
        }

        private unsafe void DrawRidgeHigh(int x0, int y0, int x1, int y1)
        {
            int x, y, d, dx, dy, chg;

            dx = x1 - x0;
            dy = y1 - y0;

            if (dx < 0)
            {
                chg = -1;
                dx = -dx;
            }
            else
            {
                chg = 1;
            }

            d = (2 * dx) - dy;
            x = x0;

            int xdeviation = 0;
            int ydeviation = 0;
            int xp;
            int yp;

            for (y = y0; y <= y1; y++)
            {
                xdeviation = Math.Clamp(Math.Clamp(xdeviation + rand.Next(-1, 2), -12, 12), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                ydeviation = Math.Clamp(Math.Clamp(ydeviation + rand.Next(-1, 2), -12, 12), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                xp = Math.Clamp(x + xdeviation, 0, height - 1);
                yp = Math.Clamp(y + ydeviation, 0, width - 1);
                PointerOps.ChangeColor(top, xp, yp, Color.White, pixsiz, stride);

                ExpandMountain(xp, yp);

                if (d > 0)
                {
                    x = x + chg;
                    d = d + (2 * (dx - dy));
                }
                else
                {
                    d = d + 2 * dx;
                }
            }
        }

        /// <summary>
        /// Expands given point, making a mountain shape on the image.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public unsafe void ExpandMountain(int x, int y)
        {
            int w = width - 1;
            int h = height - 1;

            int radius = 1;
            while (radius < 30)
            {
                int i, j, clr;
                for (i = Math.Clamp(x - radius+1, 0, w); i <= Math.Clamp(x + radius, 0, w); i++)
                {
                    j = Math.Clamp(y - radius, 0, h);
                    clr = Math.Clamp(PointerOps.PointToPointer(i, Math.Clamp(j + 1, 0, h), top, pixsiz, stride)[0] - 10, 0, 255);
                    //clr = 255;
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                    
                    j = Math.Clamp(y + radius, 0, h);
                    clr = Math.Clamp(PointerOps.PointToPointer(i, Math.Clamp(j - 1, 0, h), top, pixsiz, stride)[0] - 10, 0, 255);
                    //clr = 255;
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                }

                for (j = Math.Clamp(y - radius+1, 0, h); j <= Math.Clamp(y + radius, 0, w); j++)
                {
                    i = Math.Clamp(x - radius, 0, w);
                    clr = Math.Clamp(PointerOps.PointToPointer(Math.Clamp(i + 1, 0, w), j, top, pixsiz, stride)[0] - 10, 0, 255);
                    //clr = 255;
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }

                    i = Math.Clamp(x + radius, 0, w);
                    clr = Math.Clamp(PointerOps.PointToPointer(Math.Clamp(i - 1, 0, w), j, top, pixsiz, stride)[0] - 10, 0, 255);
                    //clr = 255;
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                }

                i = Math.Clamp(x - radius, 0, w);
                j = Math.Clamp(y - radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i + 1, j + 1,  top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                i = Math.Clamp(x + radius, 0, w);
                j = Math.Clamp(y - radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i - 1, j + 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                i = Math.Clamp(x - radius, 0, w);
                j = Math.Clamp(y + radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i + 1, j - 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                i = Math.Clamp(x + radius, 0, w);
                j = Math.Clamp(y + radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i - 1, j - 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                radius++;
            }
        }

        /// <summary>
        /// Fills image to given height
        /// </summary>
        public void Flatten(int height)
        {
            using (Graphics g = Graphics.FromImage(data))
            {
                g.Clear(Color.FromArgb(255, height, height, height));
            }
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public LandscapeGenerator(Bitmap _data)
        {
            data = _data;
            points = new List<Point>();
        }
    }
}