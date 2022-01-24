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
                int a = inp[i + 3];
                int r = inp[i + 2];
                int g = inp[i + 1];
                int b = inp[i];

                bool tocolor = false;
                while (true)
                {
                    // North
                    int loc = i - wid * 4;
                    if ((loc > 0))
                    {
                        // North
                        if (!(inp[loc + 3] == a && inp[loc + 2] == r && inp[loc + 1] == g && inp[loc + 0] == b))
                        {
                            tocolor = true;
                            break;
                        }

                        loc -= 4;
                        if ((loc > 0) && !(inp[loc + 3] == a && inp[loc + 2] == r && inp[loc + 1] == g && inp[loc + 0] == b))
                        {
                            tocolor = true;
                            break;
                        }

                        loc += 8;
                        if ((loc > 0 && loc % (wid * 4) != 0) && !(inp[loc + 3] == a && inp[loc + 2] == r && inp[loc + 1] == g && inp[loc + 0] == b))
                        {
                            tocolor = true;
                            break;
                        }

                    }

                    // Mid
                    loc = i;

                    // South
                    loc = i + wid * 4;

                    break;
                }

                if (tocolor)
                {
                    outp[i + 3] = color.A;
                    outp[i + 2] = color.R;
                    outp[i + 1] = color.G;
                    outp[i + 0] = color.B;
                }
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
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