using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;

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
        public float angle;

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

                int[,] adj = new int[,] { { -1, -1}, { -1, -1}};

                // Build matrix of adjacent bytes
                adj[1, 1] = inp[i];

                // Check if down valid
                bool downvalid = i + wid < inp.Length;
                bool rightvalid = i % wid != wid - 4;

                adj[0, 0] = inp[i];

                if (downvalid)
                {
                    adj[0, 1] = inp[i + wid];
                }

                if (rightvalid)
                {
                    adj[1, 0] = inp[i + 4];
                }

                if (downvalid && rightvalid)
                {
                    adj[1, 1] = inp[i + wid + 4];
                }

                // X and Y of current pixel vector

                float x = ((adj[0, 0] + adj[1, 0]) / 2 - (adj[0, 1] + adj[1, 1]) / 2) * intensity;
                float y = ((adj[0, 0] + adj[0, 1]) / 2 - (adj[1, 0] + adj[1, 1]) / 2) * intensity;

                // X and Y of light source vector

                float xl = MathF.Cos((angle + 90) * MathF.PI / 180);
                float yl = MathF.Sin((angle + 90) * MathF.PI / 180);

                // Projection magnitude of pixel vector and light source vector

                float xf = (x * xl + y * yl) * xl;
                float yf = (x * xl + y * yl) * yl;
                float magnitude = MathF.Sqrt(MathF.Pow(xf, 2) + MathF.Pow(yf, 2));

                // Direction of pixel vector in relation to light source vector (Whether the magnitude is positive or negative)

                int dir;
                if (MathF.Abs(xf + xl) < MathF.Abs(xf))
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;
                }

                // Write to output

                outp[i + 3] = 255;//(byte)(Math.Clamp(dir * magnitude, 0, 255));
                outp[i + 2] = (byte)Lerper.Lerp(Math.Clamp(dir * magnitude + 128, 0, 255), outp[i + 2], 1 - opacity);
                outp[i + 1] = (byte)Lerper.Lerp(Math.Clamp(dir * magnitude + 128, 0, 255), outp[i + 1], 1 - opacity);
                outp[i + 0] = (byte)Lerper.Lerp(Math.Clamp(dir * magnitude + 128, 0, 255), outp[i + 0], 1 - opacity);
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// GradientTerrainShader constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public GradientTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            intensity = 30;
            angle = -30f;
        }
    }
}