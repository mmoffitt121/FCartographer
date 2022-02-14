using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FCartographer.ColorUtility
{
    /// <summary>
    /// Class that handles color converisons
    /// </summary>
    public struct ColorHSL
    {
        /// <summary>
        /// Alpha value of color, range = 0 -> 255
        /// </summary>
        public byte A;
        /// <summary>
        /// Hue value of color, range = 1 -> 360
        /// </summary>
        public int H;
        /// <summary>
        /// Saturation value of color, range = 0 -> 1
        /// </summary>
        public double S;
        /// <summary>
        /// Lightness value of color, range = 0 -> 1
        /// </summary>
        public double L;

        /// <summary>
        /// Converts hsl to rgb
        /// </summary>
        /// <returns></returns>
        public Color ToARGB()
        {
            if (S == 0)
            {
                return Color.FromArgb(A, (byte)(L * 255), (byte)(L * 255), (byte)(L * 255));
            }

            double v1;
            double v2;
            float hue = (float)H / 360;

            if (L < 0.5)
            {
                v2 = L * (1 + S);
            }
            else
            {
                v2 = (L + S) - (L * S);
            }

            v1 = 2 * L - v2;

            byte r = (byte)(255 * ConvertHueToRGB(v1, v2, hue + (1.0f / 3)));
            byte g = (byte)(255 * ConvertHueToRGB(v1, v2, hue));
            byte b = (byte)(255 * ConvertHueToRGB(v1, v2, hue - (1.0f / 3)));

            return Color.FromArgb(A, r, g, b);

        }

        private double ConvertHueToRGB(double v1, double v2, double h)
        {
            if (h < 0)
            {
                h += 1;
            }

            if (h > 1)
            {
                h -= 1;
            }

            if (6 * h < 1)
            {
                return v1 + (v2 - v1) * 6 * h;
            }

            if (2 * h < 1)
            {
                return v2;
            }

            if (3 * h < 2)
            {
                return (v1 + (v2 - v1) * ((2.0f / 3) - h) * 6);
            }

            return v1;
        }

        /// <summary>
        /// Returns an hsl type color from an rgb type color
        /// </summary>
        /// <param name="a"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static ColorHSL FromARGB(byte a, byte _r, byte _g, byte _b)
        {
            double r = ((double)_r) / 255;
            double g = ((double)_g) / 255;
            double b = ((double)_b) / 255;

            double min = Math.Min(r, Math.Min(g, b));
            double max = Math.Max(r, Math.Max(g, b));
            double d = max - min;

            int hue;
            double saturation;
            double lightness = (min + max) / 2;

            if (max == 0 || d == 0) // if the max or range equals zero, the hue and saturation should be 0. The color is white/grey/black.
            {
                return new ColorHSL(a, 0, 0, lightness);
            }

            if (d == 0)
            {
                saturation = 1;
            }
            else
            {
                saturation = ((double)d) / (1 - Math.Abs(2 * lightness - 1));
            }

            if (r == max)
            {
                hue = (int)(60 * (((double)(g - b)) / d % 6));
            }
            else if (g == max)
            {
                hue = (int)(60 * (2 + (((double)(b - r)) / d)));
            }
            else
            {
                hue = (int)(60 * (4 + (((double)(r - g)) / d)));
            }

            return new ColorHSL(a, hue, saturation, lightness);
        }

        /// <summary>
        /// Returns an hsl type color from an rgb type color
        /// </summary>
        /// <param name="clr"></param>
        /// <returns></returns>
        public static ColorHSL FromARGB(Color clr)
        {
            return FromARGB(clr.A, clr.R, clr.G, clr.B);
        }

        /// <summary>
        /// Struct constructor, each param corresponds to a hsl color value
        /// </summary>
        /// <param name="a"></param>
        /// <param name="h"></param>
        /// <param name="s"></param>
        /// <param name="l"></param>
        public ColorHSL(byte a, int h, double s, double l)
        {
            A = a;
            H = h;
            S = s;
            L = l;
        }
    }
}