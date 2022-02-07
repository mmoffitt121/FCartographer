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
    public class RayTerrainShader : Renderer
    {
        /// <summary>
        /// Intensity of light source
        /// </summary>
        public int intensity;
        /// <summary>
        /// Angle of light source
        /// </summary>
        public float direction;
        /// <summary>
        /// Vertical angle of light source
        /// </summary>
        public float angle;

        /// <summary>
        /// How much the light drops off around corners;
        /// </summary>
        public float dropoff;

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

            float dx = MathF.Cos((180 + direction) * MathF.PI / 180) * MathF.Sin((/*180 + */angle) * MathF.PI / 180);
            float dy = MathF.Sin((180 + direction) * MathF.PI / 180) * MathF.Sin((/*180 + */angle) * MathF.PI / 180);
            float dh = MathF.Cos((/*180 + */angle) * MathF.PI / 180);

            dropoff = 0.9f;
            direction = 180f;

            for (int i = 0; i < wid * hei; i += 4)
            {
                float x = i % wid / 4;
                float y = i / wid;
                float h = inp[i];
                float luminosity = 1f;
                while (x < wid / 4 && x >= 0 && y < hei && y >= 0 && h <= 255 && h >= 0 && luminosity > 0)
                {
                    //Debug.WriteLine(h + " " + inp[wid * (int)y + 4 * (int)x]);
                    if (luminosity > 1 + dropoff * (h - inp[wid * (int)y + 4 * (int)x]))
                    {
                        luminosity = 1 + dropoff * (h - inp[wid * (int)y + 4 * (int)x]);
                    }

                    x += dx;
                    y += dy;
                    h += dh;
                }

                //Debug.WriteLine(luminosity + " --- ");

                // Write to output

                outp[i + 3] = 255;//(byte)(Math.Clamp(dir * magnitude, 0, 255));
                outp[i + 2] = (byte)Lerper.Lerp(Math.Clamp(255 * luminosity, 0, 255), outp[i + 2], 1 - opacity);
                outp[i + 1] = (byte)Lerper.Lerp(Math.Clamp(255 * luminosity, 0, 255), outp[i + 1], 1 - opacity);
                outp[i + 0] = (byte)Lerper.Lerp(Math.Clamp(255 * luminosity, 0, 255), outp[i + 0], 1 - opacity);
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// GradientTerrainShader constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public RayTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            intensity = 30;
            angle = -30f;
            direction = -10f;
            dropoff = 0.5f;
        }
    }
}