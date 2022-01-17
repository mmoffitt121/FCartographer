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
    public class NationStrokeRenderer : Renderer
    {
        /// <summary>
        /// Holds the width of the stroke
        /// </summary>
        public int stokewidth;
        /// <summary>
        /// Holds the color of the stroke
        /// </summary>
        public Color color;

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
            System.Diagnostics.Debug.WriteLine("HEY");
            System.Diagnostics.Debug.WriteLine(inp[0] + " " + inp[1] + " " + inp[2] + " " + inp[3] + " " + inp[4]);

            int wid = GetData().Width;

            for (int i = 0; i < GetData().Width * GetData().Height * 4; i += 4)
            {
                int a = i + 3;
                int r = i + 2;
                int g = i + 1;
                int b = i;

                // Lotta math to do here
            }
        }

        /// <summary>
        /// Constructor, takes bitmap for reading
        /// </summary>
        public NationStrokeRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            color = Color.FromArgb(255, 0, 0, 0);
        }
    }
}