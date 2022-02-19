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
    public class GreyScaler : Generator
    {
        private int width;
        private int height;

        /// <summary>
        /// Channel for greyscale to be made from.
        /// 
        /// 0 = Alpha channel
        /// 1 = Red channel
        /// 2 = Green channel
        /// 3 = Blue channel
        /// 4 = RGB average
        /// </summary>
        public int mode;

        /// <summary>
        /// Overwritable function that performs the layer processes.
        /// </summary>
        public override void Generate()
        {
            Bitmap data = GetData();

            width = data.Width;
            height = data.Height;

            GreyScale();
        }

        private void GreyScale()
        {
            byte[] bytes = BitmapDataConverter.GreyscaleBitmapToByteArray(GetData());

            switch (mode)
            {
                case 0:
                    for (int i = 0; i < bytes.Length * 4; i++)
                    {
                        bytes[i + 2] = bytes[i + 3];
                        bytes[i + 1] = bytes[i + 3];
                        bytes[i] = bytes[i + 3];

                        bytes[i + 3] = 255;
                    }
                    break;
                case 1:
                    for (int i = 0; i < bytes.Length * 4; i++)
                    {
                        bytes[i + 1] = bytes[i + 2];
                        bytes[i] = bytes[i + 2];

                        bytes[i + 3] = 255;
                    }
                    break;
                case 2:
                    for (int i = 0; i < bytes.Length * 4; i++)
                    {
                        bytes[i + 2] = bytes[i + 1];
                        bytes[i] = bytes[i + 1];

                        bytes[i + 3] = 255;
                    }
                    break;
                case 3:
                    for (int i = 0; i < bytes.Length * 4; i++)
                    {
                        bytes[i + 2] = bytes[i];
                        bytes[i + 1] = bytes[i];

                        bytes[i + 3] = 255;
                    }
                    break;
                case 4:
                    for (int i = 0; i < bytes.Length * 4; i++)
                    {
                        byte avg = (byte)((bytes[i] + bytes[i + 1] + bytes[i + 2]) / 3);

                        bytes[i + 2] = avg;
                        bytes[i + 1] = avg;
                        bytes[i] = avg;

                        bytes[i + 3] = 255;
                    }
                    break;
            }

            BitmapDataConverter.DrawImage(GetData(), bytes);
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public GreyScaler(Bitmap _data) : base(_data)
        {

        }
    }
}