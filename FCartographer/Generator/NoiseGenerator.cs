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
    /// Generator base class, used to generate layers.
    /// </summary>
    public class NoiseGenerator : Generator
    {
        /// <summary>
        /// Parameter determining how many octives down to render.
        /// </summary>
        public int octives;
        /// <summary>
        /// Noise mode
        /// </summary>
        public NoiseMode noisemode;

        /// <summary>
        /// Scale at which to render
        /// </summary>
        public int scale;

        private int[] perlinhash;

        private int width;
        private int height;

        /// <summary>
        /// Noise persistence as octives increase
        /// </summary>
        public double persistence;

        /// <summary>
        /// Whether or not noise tiles in repetition
        /// </summary>
        public int repeat;

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
                    BitmapDataConverter.DrawImage(data, PerlinNoise());
                    break;
                case NoiseMode.White:
                    BitmapDataConverter.DrawImage(data, WhiteNoise());
                    break;
            }
        }

        private byte[] WhiteNoise()
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
        private byte[] PerlinNoise()
        {
            byte[] outputarray = new byte[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double total = 0;
                    double freq = 1;
                    double amp = 1;
                    double max = 0;
                    for (int k = scale; k < scale + octives; k++)
                    {
                        total += PerlinPoint((double)i / 200 * freq, (double)j / 200 * freq) * amp;

                        max += amp;

                        amp *= persistence;
                        freq *= 2;
                    }
                    outputarray[j * width + i] = (byte)(total * 255 / max);
                }
            }

            return outputarray;
        }

        /// <summary>
        /// Function that calculates a single point of perlin noise
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private double PerlinPoint(double x, double y)
        {
            if (repeat > 0)
            {
                x %= repeat;
                y %= repeat;
            }

            int xi = (int)x & 255;
            int yi = (int)y & 255;

            double xf = x - (int)x;
            double yf = y - (int)y;

            double u = Fade(xf);
            double v = Fade(yf);

            int oo, oi, io, ii;

            oo = PerlinHash(PerlinHash(xi) + yi);
            oi = PerlinHash(PerlinHash(xi) + Increment(yi));
            io = PerlinHash(PerlinHash(Increment(xi)) + yi);
            ii = PerlinHash(PerlinHash(Increment(xi)) + Increment(yi));

            return (Lerp(Lerp(Gradient(oo, xf, yf), Gradient(io, xf - 1, yf), u), Lerp(Gradient(oi, xf, yf - 1), Gradient(ii, xf - 1, yf - 1), u), v) + 1) / 2;
        }

        // Perlin noise helper functions

        private static double Gradient(int hash, double x, double y)
        {
            switch (hash & 0x3)
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
            }
        }

        private static double Fade(double a)
        {
            return a * a * a  * (a * (a * 6 - 15) + 10);
        }

        private static double Lerp(double a, double b, double x)
        {
            return a + x * (b - a);
        }

        private int PerlinHash(int i)
        {
            return perlinhash[i % perlinhash.Length];
        }

        private int Increment(int toinc)
        {
            toinc++;
            if (repeat > 0)
            {
                toinc %= repeat;
            }

            return toinc;
        }

        /// <summary>
        /// Randomizes the perlin noise based on an input seed.
        /// </summary>
        public void Randomize(int size)
        {
            perlinhash = new int[size];
            for (int i = 0; i < size; i++)
            {
                perlinhash[i] = i;
            }

            Shuffle(perlinhash, GetRandom());
        }

        /// <summary>
        /// Randomizes the perlin noise based on an input seed.
        /// </summary>
        public void Randomize()
        {
            int size = 256;

            perlinhash = new int[size];
            for (int i = 0; i < size; i++)
            {
                perlinhash[i] = i;
            }

            Shuffle(perlinhash, GetRandom());
        }

        /// <summary>
        /// Shuffles an integer array
        /// </summary>
        /// <param name="toshuffle"></param>
        /// <param name="rand"></param>
        public void Shuffle(int[] toshuffle, Random rand)
        {
            for (int i = 0; i < toshuffle.Length; i++)
            {
                Swap(toshuffle, i, rand.Next(0, toshuffle.Length));
            }
        }

        /// <summary>
        /// Swaps two elements in an integer array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void Swap(int[] arr, int x, int y)
        {
            int temp = arr[x];
            arr[x] = arr[y];
            arr[y] = arr[x];
        }

        /// <summary>
        /// Sets the amount of octives to use in the noise generation
        /// </summary>
        /// <param name="_octives"></param>
        public void SetOctives(int _octives)
        {
            octives = _octives;
        }

        /// <summary>
        /// Sets the persistence value of lower levels of noise
        /// </summary>
        /// <param name="_persistence"></param>
        public void SetPersistance(double _persistence)
        {
            persistence = _persistence;
        }

        /// <summary>
        /// Sets the scale of the noise
        /// </summary>
        /// <param name="_scale"></param>
        public void SetScale(int _scale)
        {
            scale = _scale;
        }

        /// <summary>
        /// Sets whether the noise repeats
        /// </summary>
        /// <param name="_repeat"></param>
        public void SetRepeat(int _repeat)
        {
            repeat = _repeat;
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public NoiseGenerator(Bitmap _data) : base(_data)
        {
            octives = 5;
            persistence = 0.2;
            noisemode = NoiseMode.Perlin;

            SetRandom(new Random(1));
            Randomize();
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param><param name="rand"></param>
        public NoiseGenerator(Bitmap _data, Random rand) : base(_data)
        {
            octives = 5;
            persistence = 0.2;
            noisemode = NoiseMode.Perlin;

            SetRandom(rand);
            Randomize();
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