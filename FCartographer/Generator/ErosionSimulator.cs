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

        private int drops;
        private int droplifetime;

        private byte[] bytedata;

        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;
            drops = width * height;
            droplifetime = 30;

            SimulateErosion();
            BitmapDataConverter.DrawImage(data, bytedata);
        }

        private void SimulateErosion()
        {
            bytedata = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());
            for (int i = 0; i < drops; i++)
            {
                SimulateDroplet(GetRandom().Next(0, width), GetRandom().Next(0, height));
            }

            
        }

        private void SimulateDroplet(int x, int y)
        {
            float dx = 0;
            float dy = 0;
            float v = 0;
            float vol = 1;
            float sed = 0;

            for (int i = 0; i < droplifetime; i++)
            {

            }
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