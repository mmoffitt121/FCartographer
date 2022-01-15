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

        public override void Generate()
        {
            SimulateErosion();
        }

        private void SimulateErosion()
        {

        }

        /// <summary>
        /// ErosionSimulator constructor
        /// </summary>
        /// <param name="_data"></param>
        public ErosionSimulator(Bitmap _data) : base(_data)
        {

        }
    }
}