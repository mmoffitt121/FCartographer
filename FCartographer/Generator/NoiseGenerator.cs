using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    /// <summary>
    /// Generator base class, used to generate layers. Will use unsafe functions.
    /// </summary>
    public class NoiseGenerator : Generator
    {
        private int octives;
        private NoiseMode noisemode;

        private int width;
        private int height;

        /// <summary>
        /// Overwritable function that performs the layer processes.
        /// </summary>
        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;

            switch (noisemode)
            {
                case NoiseMode.Perlin:
                    DrawNoise(data, PerlinNoise());
                    break;
                case NoiseMode.White:
                    DrawNoise(data, WhiteNoise());
                    break;
            }
        }

        private unsafe void DrawNoise(Bitmap data, byte[] noise)
        {
            BitmapData dat = data.LockBits(new Rectangle(0, 0, data.Width, data.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, data.PixelFormat);
            byte* top = (byte*)dat.Scan0.ToPointer();
            int pixsiz = Image.GetPixelFormatSize(dat.PixelFormat) / 8;
            int stride = dat.Stride;

            int width = dat.Width;
            int height = dat.Height;

            byte clr;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    clr = noise[j * width + i];
                    PointerOps.ChangeColor(top, i, j, Color.FromArgb(255, clr, clr, clr), pixsiz, stride);
                }
            }

            data.UnlockBits(dat);
        }

        private unsafe byte[] WhiteNoise()
        {
            byte[] noise = new byte[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    noise[j * width + i] = (Byte)(GetRandom().Next(0, 255));
                }
            }

            return noise;
        }

        /// <summary>
        /// Perlin noise function
        /// </summary>
        /// <returns></returns>
        private unsafe byte[] PerlinNoise()
        {
            byte[] outputarray = new byte[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    outputarray[j * width + i] = (byte)(255 * PerlinPoint((double)i/200, (double)j/200));
                }
            }

            return outputarray;
        }

        private double PerlinPoint(double x, double y)
        {
            int x0 = (int)x & 255;
            int y0 = (int)y & 255;

            double xfloat = x - (int)x;
            double yfloat = y - (int)y;

            double xfaded = Fade(xfloat);
            double yfaded = Fade(yfloat);

            int oo, oi, io, ii;

            oo = PerlinHash(PerlinHash(x0) + y0);
            oi = PerlinHash(PerlinHash(x0) + y0 + 1);
            io = PerlinHash(PerlinHash(x0 + 1) + y0);
            ii = PerlinHash(PerlinHash(x0 + 1) + y0 + 1);

            return Lerp(Lerp(Gradient(oo, xfloat, yfloat), Gradient(oi, xfloat-1, yfloat), xfaded), Lerp(Gradient(io, xfloat, yfloat-1), Gradient(ii, xfloat-1, yfloat-1), xfaded), yfaded);
        }

        private double Gradient(int hash, double x, double y)
        {
            /*switch (hash & 0x3)
            {
                case 0:
                    return x + y;
                case 1:
                    return x - y;
                case 2:
                    return -x + y;
                case 3:
                    return -x - y;
                default:
                    return 0;
            }*/
            Point[] grads = new Point[] {new Point(0, 1), new Point(1, 1), new Point(1, 0), new Point(1, -1), new Point(0, -1), new Point(-1, -1), new Point(-1, 0), new Point(-1, 1)};
            return grads[hash%8].X * x + grads[hash%8].Y * y;
        }

        private double Fade(double a)
        {
            return a * a * a  * (a * (a * 6 - 15) + 10);
        }

        private double Lerp(double a, double b, double c)
        {
            return c * (b - a) + a;
        }

        /// <summary>
        /// Hash table for Perlin hash function
        /// </summary>
        private static int[] hash =
        {
            151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        /// <summary>
        /// Grabs hash value
        /// </summary>
        private int PerlinHash(int i)
        {
            return hash[i%256];
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public NoiseGenerator(Bitmap _data) : base(_data)
        {
            octives = 5;
            noisemode = NoiseMode.Perlin;
        }

        /// <summary>
        /// Enum for type of noise to generate
        /// </summary>
        public enum NoiseMode
        {
            /// <summary>
            /// Perlin Noise setting, layered
            /// </summary>
            Perlin,

            /// <summary>
            /// White Noise setting
            /// </summary>
            White
        }
    }
}