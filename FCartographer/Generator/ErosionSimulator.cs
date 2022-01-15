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
    public unsafe class ErosionSimulator : Generator
    {
        private int width;
        private int height;

        /// <summary>
        /// Specifies the number of drops to simulate on the image
        /// </summary>
        public int drops;
        /// <summary>
        /// User-input multiplier for number of drops
        /// </summary>
        public int dropsmodifier = 1;
        /// <summary>
        /// How many iterations a drop lasts
        /// </summary>
        public int droplifetime = 25;

        /// <summary>
        /// Max sediment carried by a droplet
        /// </summary>
        public int sedcapfactor = 3;

        private double minsed = 0.01;

        /// <summary>
        /// Speed at which erosion takes place
        /// </summary>
        public double erosionspeed = 0.3;
        /// <summary>
        /// Speed at which depositing takes place
        /// </summary>
        public double depositspeed = 0.3;
        /// <summary>
        /// Inertia of drop
        /// </summary>
        public double inertia = 0.05;
        /// <summary>
        /// Speed at which the drop evaporates
        /// </summary>
        public double evaporatespeed = 0.01;
        /// <summary>
        /// Gravitational force on drop
        /// </summary>
        public double gravity = 4;

        private byte[] bytedata;

        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;
            drops = width * height * dropsmodifier;

            SimulateErosion();
            BitmapDataConverter.DrawImage(data, bytedata);
        }

        private void SimulateErosion()
        {
            bytedata = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());
            for (int i = 0; i < drops; i++)
            {
                SimulateDroplet(GetRandom().NextDouble() * width, GetRandom().NextDouble() * height);
            }

            
        }

        private void SimulateDroplet(double xpos, double ypos)
        {
            double dx = 0;
            double dy = 0;
            double v = 0;
            double vol = 1;
            double sed = 0;

            for (int i = 0; i < droplifetime; i++)
            {
                int xpixel = (int)xpos;
                int ypixel = (int)ypos;
                double xoffset = xpos - xpixel;
                double yoffset = ypos - ypixel;

                int maplocation = ypixel * width + xpixel;

                // Height and gradient calculation

                GradAndHeight gh = CalculateHeightAndGradient(xpos, ypos);

                // Calculates the drop's direction and position
                dx = (dx * inertia - gh.gx * (1 - inertia));
                dy = (dy * inertia - gh.gy * (1 - inertia));
                double len = Math.Sqrt(dx * dx + dy * dy);
                if (len != 0)
                {
                    dx /= len;
                    dy /= len;
                }
                xpos += dx;
                ypos += dy;

                // Breaks if droplet has fallen out of map, or is no longer moving
                if ((dx == 0 && dy == 0) || xpos < 0 || xpos >= width - 1 || ypos < 0 || ypos >= height - 1)
                {
                    break;
                }

                // Calculate change in height
                double dh = CalculateHeightAndGradient(xpos, ypos).height - gh.height;

                // Sediment simulation
                double sedcap = Math.Max(dh * v * vol * sedcapfactor, minsed);

                if (sed > sedcap || dh > 0)
                {
                    double deposit = (dh > 0) ? Math.Min(dh, sed) : (sed - sedcap) * depositspeed;
                    sed -= deposit;

                    int cons = 2;
                    bytedata[maplocation] += (byte)(cons * deposit * (1 - xoffset) * (1 - yoffset));
                    bytedata[(int)Math.Clamp(maplocation + 1, 0, width * height - 1)] += (byte)(cons * deposit * xoffset * (1 - yoffset));
                    bytedata[(int)Math.Clamp(maplocation + width, 0, width * height - 1)] += (byte)(cons * deposit * (1 - xoffset) * yoffset);
                    bytedata[(int)Math.Clamp(maplocation + width + 1, 0, width * height - 1)] += (byte)(cons * deposit * xoffset * yoffset);
                }
                else
                {
                    double erode = Math.Min(sedcap - sed * erosionspeed, -dh);

                    /* erosion here */
                    sed += 1;
                }
                v = Math.Sqrt(v * v + dh * gravity);
                vol *= (1 - evaporatespeed);
            }
        }

        private GradAndHeight CalculateHeightAndGradient(double xpos, double ypos)
        {
            int xpixel = (int)xpos;
            int ypixel = (int)ypos;
            double xoffset = xpos - xpixel;
            double yoffset = ypos - ypixel;

            int maplocation = ypixel * width + xpixel;

            float h, gradx, grady;

            float hnw = bytedata[maplocation];
            float hne = bytedata[(int)Math.Clamp(maplocation + 1, 0, width * height - 1)];
            float hsw = bytedata[(int)Math.Clamp(maplocation + width, 0, width * height - 1)];
            float hse = bytedata[(int)Math.Clamp(maplocation + width + 1, 0, width * height - 1)];

            gradx = (hne - hnw) * (1 - ypixel) + (hse - hsw) * ypixel;
            grady = (hsw - hnw) * (1 - xpixel) + (hse - hne) * xpixel;

            h = hnw * (1 - xpixel) * (1 - ypixel) + hne * xpixel * (1 - ypixel) + hsw * (1 - xpixel) * ypixel + hse * xpixel * ypixel;

            return new GradAndHeight() 
            { 
                height = h, gx = gradx, gy = grady 
            };
        }

        private class GradAndHeight
        {
            public float height;
            public float gx;
            public float gy;
        }

        /// <summary>
        /// ErosionSimulator constructor
        /// </summary>
        /// <param name="_data"></param>
        public ErosionSimulator(Bitmap _data) : base(_data)
        {
            droplifetime = 30;
            dropsmodifier = 1;
        }
    }
}