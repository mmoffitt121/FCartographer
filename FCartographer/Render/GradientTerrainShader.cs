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
    public class GradientTerrainShader : Renderer
    {
        /// <summary>
        /// Intensity of light source
        /// </summary>
        public int intensity;
        /// <summary>
        /// Angle of light source
        /// </summary>
        public int angle;

        /// <summary>
        /// Render override function
        /// </summary>
        public override void Render()
        {
            RenderShadows();
        }

        private void RenderShadows()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            for (int i = 0; i < wid * hei; i += 4)
            {
                int v = inp[i];

                bool major;
                bool minor;

                int[,] adj = new int[,] { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };

                // Build matrix of adjacent bytes
                adj[1, 1] = inp[i];

                // Check if up and down valid
                bool upvalid = i - wid > 0;
                bool downvalid = i + wid < inp.Length;

                if (upvalid)
                {
                    adj[1, 0] = inp[i - wid];
                }

                if (downvalid)
                {
                    adj[1, 2] = inp[i + wid];
                }

                if (i % wid > 0)  // Check if left valid
                {
                    adj[0, 1] = inp[i - 4];

                    if (upvalid)
                    {
                        adj[0, 0] = inp[i - wid - 4];
                    }

                    if (downvalid)
                    {
                        adj[0, 2] = inp[i + wid - 4];
                    }
                }

                if (i % wid != wid - 4)  // Check if right valid
                {
                    adj[2, 1] = inp[i + 4];

                    if (upvalid)
                    {
                        adj[2, 0] = inp[i - wid + 4];
                    }

                    if (downvalid)
                    {
                        adj[2, 2] = inp[i + wid + 4];
                    }
                }
            }
        }

        /// <summary>
        /// GradientTerrainShader constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public GradientTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {

        }
    }
}