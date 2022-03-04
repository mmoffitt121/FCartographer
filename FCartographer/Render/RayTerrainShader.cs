using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using OpenCL;

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
        /// Intensity of ambient light source, range = 0 - 255
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
        /// Color of the light
        /// </summary>
        public Color lightcolor;

        /// <summary>
        /// Render override function
        /// </summary>
        public override void Render()
        {
            OpenCLRenderShadows();
            //RenderShadows();
        }

        private void RenderShadows()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            float dx = MathF.Cos((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dy = MathF.Sin((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dh = MathF.Cos((angle + 90) * MathF.PI / 180);     

            float amb = ((float)ambient) / 255;

            byte lr = lightcolor.R;
            byte lg = lightcolor.G;
            byte lb = lightcolor.B;

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

                outp[i + 3] = 255;
                outp[i + 2] = (byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255);
                outp[i + 1] = (byte)Math.Clamp(amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255, 0, 255);
                outp[i + 0] = (byte)Math.Clamp(amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255, 0, 255);
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        private void OpenCLRenderShadows()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            float dx = MathF.Cos((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dy = MathF.Sin((180 - direction) * MathF.PI / 180) * MathF.Sin((angle + 90) * MathF.PI / 180);
            float dh = MathF.Cos((angle + 90) * MathF.PI / 180);

            float amb = ((float)ambient) / 255;

            byte lr = lightcolor.R;
            byte lg = lightcolor.G;
            byte lb = lightcolor.B;

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

                outp[i + 3] = 255;
                outp[i + 2] = (byte)Math.Clamp(amb * outp[i + 2] + luminosity * lr * intensity * ((float)outp[i + 2]) / 255, 0, 255);
                outp[i + 1] = (byte)Math.Clamp(amb * outp[i + 1] + luminosity * lg * intensity * ((float)outp[i + 1]) / 255, 0, 255);
                outp[i + 0] = (byte)Math.Clamp(amb * outp[i + 0] + luminosity * lb * intensity * ((float)outp[i + 0]) / 255, 0, 255);
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
            lightcolor = Color.FromArgb(255, 255, 255, 255);

            dropoff = 0.1f;
            direction = 20f;
            angle = 360f - 30f;
            bias = 0;
            intensity = 0.6f;
            ambient = 100;
        }
    }
}