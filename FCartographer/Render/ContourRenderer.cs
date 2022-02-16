using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class ContourRenderer : Renderer
    {
        /// <summary>
        /// Color to draw minor lines
        /// </summary>
        public Color minorcolor;
        /// <summary>
        /// Color to draw major contour lines
        /// </summary>
        public Color majorcolor;

        /// <summary>
        /// Determines whether the contour lines will be drawn
        /// </summary>
        public bool drawlines;

        /// <summary>
        /// Interval at which lines are drawn
        /// </summary>
        public int minorinterval;
        /// <summary>
        /// Interval at which major lines are drawn
        /// </summary>
        public int majorinterval;

        /// <summary>
        /// Color of higher regions
        /// </summary>
        public Color highcolor;
        /// <summary>
        /// Color that lower regions fade to
        /// </summary>
        public Color lowcolor;

        /// <summary>
        /// Lowest level at which lines are drawn
        /// </summary>
        public int startpoint;

        /// <summary>
        /// Renders contour lines onto internal data
        /// </summary>
        public override void Render()
        {
            RenderContour();
        }

        private void RenderContour()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            for (int i = 0; i < wid * hei; i += 4)
            {
                int v = inp[i];

                bool major;
                bool minor;

                int[,] adj = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };

                // Build matrix of adjacent bytes
                adj[1, 1] = inp[i];

                // Check if up and down valid
                bool upvalid = i - wid > 0;
                bool downvalid = i + wid < inp.Length;

                if (upvalid) 
                {
                    adj[1, 0] = inp[i - wid];
                }

                if (downvalid)
                {
                    adj[1, 2] = inp[i + wid];
                }

                if (i % wid > 0)  // Check if left valid
                {
                    adj[0, 1] = inp[i - 4];

                    if (upvalid)
                    {
                        adj[0, 0] = inp[i - wid - 4];
                    }

                    if (downvalid)
                    {
                        adj[0, 2] = inp[i + wid - 4];
                    }
                }

                if (i % wid != wid - 4)  // Check if right valid
                {
                    adj[2, 1] = inp[i + 4];

                    if (upvalid)
                    {
                        adj[2, 0] = inp[i - wid + 4];
                    }

                    if (downvalid)
                    {
                        adj[2, 2] = inp[i + wid + 4];
                    }
                }

                major = false;
                minor = false;

                foreach (int j in adj)
                {
                    // System.Diagnostics.Debug.WriteLine(j + " " + v);
                    if (v > j && ((int)(v / (minorinterval * majorinterval))) * minorinterval * majorinterval > j)
                    {
                        major = true;
                    }

                    if (v > j && ((int)(v / minorinterval)) * minorinterval > j)
                    {
                        minor = true;
                    }
                }

                if (major)
                {
                    outp[i + 3] = majorcolor.A;
                    outp[i + 2] = majorcolor.R;
                    outp[i + 1] = majorcolor.G;
                    outp[i + 0] = majorcolor.B;
                }
                else if (minor)
                {
                    outp[i + 3] = minorcolor.A;
                    outp[i + 2] = minorcolor.R;
                    outp[i + 1] = minorcolor.G;
                    outp[i + 0] = minorcolor.B;
                }
                else
                {
                    outp[i + 3] = (byte)Math.Clamp(Math.Round(Lerp(lowcolor.A, highcolor.A, ((float)v) / 255), minorinterval), 0, 255);
                    outp[i + 2] = (byte)Math.Clamp(Math.Round(Lerp(lowcolor.R, highcolor.R, ((float)v) / 255), minorinterval), 0, 255);
                    outp[i + 1] = (byte)Math.Clamp(Math.Round(Lerp(lowcolor.G, highcolor.G, ((float)v) / 255), minorinterval), 0, 255);
                    outp[i + 0] = (byte)Math.Clamp(Math.Round(Lerp(lowcolor.B, highcolor.B, ((float)v) / 255), minorinterval), 0, 255);
                }
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        private static double Lerp(double a, double b, double x)
        {
            return a + x * (b - a);
        }

        /// <summary>
        /// Contour renderer constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public ContourRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            majorcolor = Color.FromArgb(255, 0, 0, 0);
            minorcolor = Color.FromArgb(255, 50, 50, 50);

            majorinterval = 4;
            minorinterval = 10;

            highcolor = Color.FromArgb(255, 255, 230, 220);
            lowcolor = Color.FromArgb(255, 100, 60, 30);

            drawlines = true;
        }
    }
}