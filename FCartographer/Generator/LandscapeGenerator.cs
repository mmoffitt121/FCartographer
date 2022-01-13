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
    /// 
    /// Defunct, works horribly. Do not use.
    /// </summary>
    /*public unsafe class LandscapeGenerator : Generator
    {
        private Bitmap data;
        private List<Point> points;
        private List<byte> colors;

        private byte* top;
        private int pixsiz;
        private int stride;

        private int width;
        private int height;

        private Random rand;

        private int density;
        private int steepness;
        private int ridgelength;
        private int numbranches;

        private int crackfactor;

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
                        colors.Add((byte)rand.Next(200, 255));
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
        /// Recursively generates sides of mountains
        /// </summary>
        public unsafe void GenerateMountainSides(int x0, int y0, int x1, int y1)
        {

        }

        /// <summary>
        /// Generates mountains on internal bitmap
        /// </summary>
        public unsafe void GenerateMountains(int _steepness, int seed, int _numbranches)
        {
            BitmapData dat = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, data.PixelFormat);
            top = (byte*)dat.Scan0.ToPointer();
            pixsiz = Image.GetPixelFormatSize(dat.PixelFormat) / 8;
            stride = dat.Stride;

            width = dat.Width;
            height = dat.Height;

            steepness = _steepness;
            numbranches = _numbranches;

            rand = new Random(seed);

            // Draws initial lines between points

            Point cur1, cur2;
            byte clr1, clr2;

            while (points.Count > 1)
            {
                // Get the closest adjacent point
                cur1 = points[0];
                cur2 = points[1];
                clr1 = colors[0];
                clr2 = colors[1];
                for (int i = 1; i < points.Count; i++)
                {
                    // Comparison of distance formulas
                    if (Math.Sqrt(Math.Pow(points[i].X - cur1.X, 2) + Math.Pow(points[i].Y - cur1.Y, 2)) < Math.Sqrt(Math.Pow(cur2.X - cur1.X, 2) + Math.Pow(cur2.Y - cur1.Y, 2)))
                    {
                        cur2 = points[i];
                        clr2 = colors[i];
                    }
                }

                if (Math.Sqrt(Math.Pow(cur2.X - cur1.X, 2) + Math.Pow(cur2.Y - cur1.Y, 2)) > density * 3)
                {
                    points.Remove(cur1);
                    colors.Remove(clr1);
                    continue;
                }

                // Draws lines between the points.

                DrawRidge(cur1.X, cur1.Y, cur2.X, cur2.Y, clr1, clr2, 30, 20);

                points.Remove(cur1);
                colors.Remove(clr1);
            }

            data.UnlockBits(dat);

            //DrawPoints(Color.Red);
        }

        private unsafe void DrawRidge(int x0, int y0, int x1, int y1, int clr0, int clr1, int seg, int depth)
        {
            // Base return case
            if (depth < 1)
            {
                return;
            }

            // If segmentation is less than one, return.
            if (seg < 1)
            {
                seg = 1;
            }

            // Initialize values for ridge line division

            double segmentation = LineDistance(x0, y0, x1, y1) / seg;

            double dx = Math.Abs(x0 - x1) / segmentation;
            double dy = Math.Abs(y0 - y1) / segmentation;

            int xx0, xx1, yy0, yy1, xprev, yprev, cc0, cc1, xout0, yout0, xout1, yout1;
            xx0 = x0;
            yy0 = y0;
            cc0 = clr0;
            xout0 = x0;
            yout0 = y0;
            xprev = x0;
            yprev = y0;

            // Divide ridge line, color each segment

            for (int i = 0; i < Math.Sqrt(Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2)) / seg; i++)
            {
                // Calculate position of next point
                xx1 = xx0 + (int)Math.Round(dx);
                yy1 = yy0 + (int)Math.Round(dy);
                xout1 = xx1 + Math.Clamp(rand.Next(-depth, depth + 1), 0, width);
                yout1 = yy1 + Math.Clamp(rand.Next(-depth, depth + 1), 0, height);

                cc1 = Math.Clamp(CalculateRidgeColor(xx0, x0, x1, yy0, y0, y1, clr0, clr1) + rand.Next(-(int)segmentation, (int)segmentation), 0, 255);

                // Draw line between point and previous
                if (Math.Abs(yout1 - yout0) < Math.Abs(xout1 - xout0))
                {
                    if (xout0 > xout1)
                    {
                        DrawRidgeLow(xout1, yout1, xout0, yout0, cc0, cc1);
                    }
                    else
                    {
                        DrawRidgeLow(xout0, yout0, xout1, yout1, cc0, cc1);
                    }
                }
                else
                {
                    if (yout0 > yout1)
                    {
                        DrawRidgeHigh(xout1, yout1, xout0, yout0, cc0, cc1);
                    }
                    else
                    {
                        DrawRidgeHigh(xout0, yout0, xout1, yout1, cc0, cc1);
                    }
                }

                // Secondary ridges at joints

                if (!(xx0 == xprev && yy0 == yprev))
                {
                    int vx1, vy1, vx2, vy2;
                    vx1 = xprev - xx0;
                    vy1 = yprev - yy0;
                    vx2 = xx1 - xx0;
                    vy2 = yy1 - yy0;
                    double angle = Math.Acos((vx1 * vx2 + vy1 * vy2) / (LineDistance(0, 0, vx1, vy1) * LineDistance(0, 0, vx2, vy2))) + 180;

                    int newx = Math.Clamp((int)(10 * seg * Math.Cos(angle)), 0, width-1);
                    int newy = Math.Clamp((int)(10 * seg * Math.Sin(angle)), 0, height-1);

                    int newclr = cc1 - 10;

                    DrawRidge(xx0, yy0, newx, newy, cc0, newclr, (int)(seg / 2), depth - 5);
                }

                // Set values for next point
                xprev = xx0;
                yprev = yy0;
                xout0 = xout1;
                yout0 = yout1;
                xx0 = xx1;
                yy0 = yy1;

            }
        }

        private unsafe void DrawRidgeLow(int x0, int y0, int x1, int y1, int clr0, int clr1)
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

            for (x = x0; x <= x1; x = x + 1)
            {
                xdeviation = Math.Clamp(Math.Clamp(xdeviation + rand.Next(-1, 2), -16, 16), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                ydeviation = Math.Clamp(Math.Clamp(ydeviation + rand.Next(-1, 2), -16, 16), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                xp = Math.Clamp(x + xdeviation, 0, height - 1);
                yp = Math.Clamp(y + ydeviation, 0, width - 1);

                int clr = CalculateRidgeColor(x, x0, x1, y, y0, y1, clr0, clr1);

                PointerOps.ChangeColor(top, xp, yp, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                //ExpandMountainCircular(xp, yp, clr);

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

        private unsafe void DrawRidgeHigh(int x0, int y0, int x1, int y1, int clr0, int clr1)
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

            for (y = y0; y <= y1; y = y + 1)
            {
                xdeviation = Math.Clamp(Math.Clamp(xdeviation + rand.Next(-1, 2), -12, 12), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                ydeviation = Math.Clamp(Math.Clamp(ydeviation + rand.Next(-1, 2), -12, 12), -1 * Math.Abs(x1 - x), Math.Abs(x1 - x));
                xp = Math.Clamp(x + xdeviation, 0, height - 1);
                yp = Math.Clamp(y + ydeviation, 0, width - 1);

                int clr = CalculateRidgeColor(x, x0, x1, y, y0, y1, clr0, clr1);

                PointerOps.ChangeColor(top, xp, yp, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                //ExpandMountainCircular(xp, yp, clr);

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
        /// Calculates the ridge color based on the distance between two points, and the class' internal steepness.
        /// </summary>
        /// <returns></returns>
        public int CalculateRidgeColor(int x, int x0, int x1, int y, int y0, int y1, int c0, int c1)
        {
            if (LineDistance(x0, y0, x1, y1) == 0)
            {
                return c0;
            }
            double remaining = Math.Round(LineDistance(x, y, x1, y1) / LineDistance(x0, y0, x1, y1), 5);
            return Math.Clamp(Math.Abs((int)Math.Round(c0 * remaining + c1 * (1 - remaining))), 1, 255);
        }

        /// <summary>
        /// Returns the double-typed value of the distance between two points
        /// </summary>
        /// <returns></returns>
        public double LineDistance(int x0, int y0, int x1, int y1)
        {
            return Math.Sqrt(Math.Pow(x1 - x0, 2) + Math.Pow(y1 - y0, 2));
        }

        /// <summary>
        /// Expands given point, making a mountain shape on the image.
        /// </summary>
        /*public unsafe void ExpandMountain(int x, int y)
        {
            int w = width - 1;
            int h = height - 1;

            int radius = 1;
            while (radius < 2 * (255 / steepness))
            {
                int i, j, clr;
                for (i = Math.Clamp(x - radius+1, 0, w); i <= Math.Clamp(x + radius, 0, w); i++)
                {
                    // Top of region

                    j = Math.Clamp(y - radius, 0, h);
                    clr = Math.Clamp(PointerOps.PointToPointer(i, Math.Clamp(j + 1, 0, h), top, pixsiz, stride)[0] - steepness, 0, 255);
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                    
                    // Bottom of region

                    j = Math.Clamp(y + radius, 0, h);
                    clr = Math.Clamp(PointerOps.PointToPointer(i, Math.Clamp(j - 1, 0, h), top, pixsiz, stride)[0] - steepness, 0, 255);
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                }

                for (j = Math.Clamp(y - radius+1, 0, h); j <= Math.Clamp(y + radius, 0, w); j++)
                {
                    // Right of region

                    i = Math.Clamp(x - radius, 0, w);
                    clr = Math.Clamp(PointerOps.PointToPointer(Math.Clamp(i + 1, 0, w), j, top, pixsiz, stride)[0] - steepness, 0, 255);
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }

                    // Left of region

                    i = Math.Clamp(x + radius, 0, w);
                    clr = Math.Clamp(PointerOps.PointToPointer(Math.Clamp(i - 1, 0, w), j, top, pixsiz, stride)[0] - steepness, 0, 255);
                    if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                }

                // Top left corner

                i = Math.Clamp(x - radius, 0, w);
                j = Math.Clamp(y - radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i + 1, j + 1,  top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                // Top right corner

                i = Math.Clamp(x + radius, 0, w);
                j = Math.Clamp(y - radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i - 1, j + 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                // Bottom left corner

                i = Math.Clamp(x - radius, 0, w);
                j = Math.Clamp(y + radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i + 1, j - 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                // Bottom right corner

                i = Math.Clamp(x + radius, 0, w);
                j = Math.Clamp(y + radius, 0, h);
                clr = Math.Clamp(PointerOps.PointToPointer(i - 1, j - 1, top, pixsiz, stride)[0] - 10, 0, 255);
                if (clr > PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0])
                {
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }

                radius++;
            }
        }*/
    /*
        private unsafe void ExpandMountainCircular(int x, int y, int _clr)
        {
            int rad = (int)Math.Ceiling((decimal)(_clr / steepness));
            float dist;
            int clr;
            for (int i = Math.Clamp(x - rad, 0, width - 1); i < Math.Clamp(x + rad, 0, width - 1); i++)
            {
                for (int j = Math.Clamp(y - rad, 0, height - 1); j < Math.Clamp(y + rad, 0, height - 1); j++)
                {
                    dist = (float)Math.Sqrt(Math.Pow(i - x, 2) + Math.Pow(j - y, 2));
                    clr = _clr - (int)(dist / rad * 255);
                    if (dist < rad && PointerOps.PointToPointer(i, j, top, pixsiz, stride)[0] < clr)
                    {
                        PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                    }
                }
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
        public LandscapeGenerator(Bitmap _data) : Generator(_data)
        {
            data = _data;
            crackfactor = 10;
            points = new List<Point>();
            colors = new List<byte>();
        }
    }*/
}