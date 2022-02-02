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
    /// Renderer class, used to render parts of layers. Will usually utilize unsafe functions.
    /// </summary>
    public class NationFillRenderer : Renderer
    {
        /// <summary>
        /// Holds the transparency of the nation
        /// </summary>
        public byte alpha;

        /// <summary>
        /// Renders the stroke layer
        /// </summary>
        public override void Render()
        {
            RenderStroke();
        }

        private void RenderStroke()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width;
            int hei = GetData().Height;

            for (int i = 0; i < wid * hei * 4; i += 4)
            {
                if (inp[i + 3] != 0)
                {
                    outp[i + 3] = 100;
                    outp[i + 2] = inp[i + 2];
                    outp[i + 1] = inp[i + 1];
                    outp[i + 0] = inp[i + 0];
                }
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// Constructor, takes bitmap for reading
        /// </summary>
        public NationFillRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            alpha = 100;
        }
    }
}