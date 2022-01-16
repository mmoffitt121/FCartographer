using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.ExceptionServices;
using FCartographer.ErosionSimulation;

namespace FCartographer
{
    /// <summary>
    /// Landscape generator class, used to generate a custom landscape based on a seed, and user defined options. Will use unsafe functions.
    /// </summary>
    public unsafe class ErosionSimulator : Generator
    {
        private int width;
        private int height;

        private byte[] bytedata;
        private float[] map;

        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;

            bytedata = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());
            map = new float[width * height];

            for (int i = 0; i < width * height; i++)
            {
                map[i] = (float)(bytedata[i]) / 255;
            }

            Erosion e = new Erosion();
            map = e.Erode(map, width, width * height * 4);

            for (int i = 0; i < width * height; i++)
            {
                bytedata[i] = (byte)(map[i] * 255);
            }

            BitmapDataConverter.DrawImage(data, bytedata);
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