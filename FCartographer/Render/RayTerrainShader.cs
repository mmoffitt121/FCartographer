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
        public float intensity;
        /// <summary>
        /// Intensity of ambient light source
        /// </summary>
        public int ambient;
        /// <summary>
        /// Angle of light source
        /// </summary>
        public float direction;
        /// <summary>
        /// Vertical angle of light source from horizon.
        /// 
        /// Corresponding values assume direction = 0
        /// 0 = sunset in the west
        /// 45 = afternoon
        /// 90 = noon, sun directly overhead
        /// 135 = morning
        /// 180 = sunrise in the east
        /// </summary>
        public float angle;

        /// <summary>
        /// How much the light drops off around corners;
        /// </summary>
        public float dropoff;
        /// <summary>
        /// Amount of pixels above to account shadows for
        /// </summary>
        public int bias;

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

            float dx = MathF.Cos((180 + direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dy = MathF.Sin((180 + direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dh = MathF.Cos((angle + 90) * MathF.PI / 180);

            dropoff = 0.1f;
            direction = -20f;
            angle = -30f;
            bias = 0;
            intensity = 0.5f;

            byte[] output = new byte[wid * hei];

            float luminosity;
            for (int i = 0; i < wid * hei; i += 4)
            {
                float x = i % wid / 4;
                float y = i / wid;
                float h = inp[i];
                luminosity = 1f;
                while (x < wid / 4 && x >= 0 && y < hei && y >= 0 && h <= 255 && h >= 0 && luminosity > 0)
                {
                    if (luminosity > 1 + dropoff * (h - bias - inp[wid * (int)y + 4 * (int)x]))
                    {
                        luminosity = 1 + dropoff * (h - bias - inp[wid * (int)y + 4 * (int)x]);
                    }

                    x += dx;
                    y += dy;
                    h += dh;
                }

                output[i + 3] = 255;//(byte)(Math.Clamp(dir * magnitude, 0, 255));
                output[i + 2] = (byte)Math.Clamp(255 * luminosity * intensity + ambient, 0, 255);
                output[i + 1] = (byte)Math.Clamp(255 * luminosity * intensity + ambient, 0, 255);
                output[i + 0] = (byte)Math.Clamp(255 * luminosity * intensity + ambient, 0, 255);
            }

            Smoother.AverageSmooth(output, wid, hei, 4);

            for (int i = 0; i < wid * hei; i += 4)
            {
                // Write to output

                outp[i + 3] = 255;//(byte)(Math.Clamp(dir * magnitude, 0, 255));
                outp[i + 2] = (byte)Lerper.Lerp(output[i + 2], outp[i + 2], 1 - opacity);
                outp[i + 1] = (byte)Lerper.Lerp(output[i + 1], outp[i + 1], 1 - opacity);
                outp[i + 0] = (byte)Lerper.Lerp(output[i + 0], outp[i + 0], 1 - opacity);
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
            opacity = 0.5f;

            intensity = 1f;
            ambient = 20;
            
            angle = -30f;
            direction = -10f;
            dropoff = 0.5f;
            bias = 1;
        }
    }
}