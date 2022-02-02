using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class ContourRenderer : Renderer
    {
        /// <summary>
        /// Color to draw contour lines
        /// </summary>
        public Color color;

        /// <summary>
        /// Renders contour lines onto internal data
        /// </summary>
        public override void Render()
        {
            RenderContour();
        }

        private void RenderContour()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width;
            int hei = GetData().Height;

            for (int i = 0; i < wid * hei * 4; i += 4)
            {
                int v = inp[i];

                bool tocolor = false;
                while (true)
                {
                    // North
                    int loc = i - wid * 4;
                    if ((loc > 0))
                    {
                        // North
                        if (!(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                        // NW
                        loc -= 4;
                        if ((loc > 0) && !(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                        // NE
                        loc += 8;
                        if ((loc > 0) && !(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                    }

                    // Mid
                    loc = i;

                    // W
                    loc -= 4;
                    if ((loc > 0) && !(inp[loc] == v))
                    {
                        tocolor = true;
                        break;
                    }

                    // E
                    loc += 8;
                    if ((loc < wid * hei * 4) && !(inp[loc] == v))
                    {
                        tocolor = true;
                        break;
                    }

                    // South
                    loc = i + wid * 4 - 4;

                    if ((loc < wid * hei * 4))
                    {
                        // South East
                        if (!(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                        // South
                        loc += 4;
                        if ((loc < wid * hei * 4) && !(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                        // South West
                        loc += 4;
                        if ((loc < wid * hei * 4) && !(inp[loc] == v))
                        {
                            tocolor = true;
                            break;
                        }

                    }

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
        /// Contour renderer constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public ContourRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            color = Color.FromArgb(255, 0, 0, 0);
        }
    }
}