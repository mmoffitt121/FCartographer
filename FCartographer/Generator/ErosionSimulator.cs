using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.ExceptionServices;
using FCartographer.ErosionSimulation;
using System.Diagnostics;

namespace FCartographer
{
    /// <summary>
    /// Erosion simulator class, simulates erosion on a heightmap.
    /// </summary>
    public class ErosionSimulator : Generator
    {
        /// <summary>
        /// Performs erosion simulation 
        /// </summary>
        public override void Generate()
        {
            Bitmap data = GetData();

            int width = data.Width;
            int height = data.Height;

            byte[] bytedata = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());
            float[] map = new float[width * height];

            for (int i = 0; i < width * height; i++)
            {
                map[i] = (float)(bytedata[i]) / 255;
            }

            Erosion e = new Erosion();
            e.SetSeed(GetRandom().Next(0, 2147483646));
            map = e.Erode(map, width, height, width * height * 2);

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