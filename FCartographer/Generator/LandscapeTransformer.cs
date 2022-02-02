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
    public class LandscapeTransformer : Generator
    {
        private int width;
        private int height;

        /// <summary>
        /// Specifies minimum value for heightmap to have
        /// </summary>
        public int min;
        /// <summary>
        /// Specifies maximum value for heightmap to have
        /// </summary>
        public int max;

        /// <summary>
        /// Overwritable function that performs the layer processes.
        /// </summary>
        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;

            Maximize();
        }

        private void Maximize()
        {
            byte[] bytes = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());

            int oldmin = 255;
            int oldmax = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < oldmin)
                {
                    oldmin = bytes[i];
                }
                if (bytes[i] > oldmax)
                {
                    oldmax = bytes[i];
                }
            }

            if (oldmin > oldmax)
            {
                return;
            }

            oldmin++;
            oldmax++;

            int newmin = min + 1;
            int newmax = max + 1;

            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = (byte)(((float)(bytes[i] - oldmin)) / (oldmax - oldmin) * (newmax - newmin) + newmin);
            }

            BitmapDataConverter.DrawImage(GetData(), bytes);
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public LandscapeTransformer(Bitmap _data) : base(_data)
        {
            min = 0;
            max = 255;
        }
    }
}