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
    /// Class that lerps your inputs
    /// </summary>
    public static class Lerper
    {
        /// <summary>
        /// Lerps your inputs
        /// </summary>
        /// <param name="a">Value 1</param>
        /// <param name="b">Value 2</param>
        /// <param name="x">Higher values pull the result closer to value 2</param>
        /// <returns></returns>
        public static double Lerp(double a, double b, double x)
        {
            return a + x * (b - a);
        }
    }
}