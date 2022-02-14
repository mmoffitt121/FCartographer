using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using FCartographer.ColorUtility;

namespace FCartographer
{
    /// <summary>
    /// Render class that renders optionally lit water.
    /// </summary>
    public class RayWaterShader : Renderer
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
        /// Level at which the water sits on the terrain
        /// </summary>
        public byte level;
        private HeightLayer terrain;

        /// <summary>
        /// Color of water
        /// </summary>
        public Color c1;

        /// <summary>
        /// Color of incident light
        /// </summary>
        public Color lightcolor;

        /// <summary>
        /// Float between 0 and 1 that dictates how bright the incident light is
        /// </summary>
        public float brightness;

        /// <summary>
        /// Override Render function
        /// </summary>
        public override void Render()
        {
            RenderWater();
            if (terrain != null)
            {
                MaskWater();
            }
        }

        /// <summary>
        /// Masks and renders the water according to an internal sun
        /// </summary>
        public void RenderWater()
        {
            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;

            for (int i = 0; i < wid * hei; i += 4)
            {
                int[,] adj = new int[,] { { -1, -1 }, { -1, -1 } };

                // Build matrix of adjacent bytes

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
                outp[i + 2] = (byte)Lerper.Lerp(Lerper.Lerp(lightcolor.R, darkcolor.R, Math.Clamp(dir * magnitude + 128, 0, 255) / 256), outp[i + 2], 1 - opacity);
                outp[i + 1] = (byte)Lerper.Lerp(Lerper.Lerp(lightcolor.G, darkcolor.G, Math.Clamp(dir * magnitude + 128, 0, 255) / 256), outp[i + 1], 1 - opacity);
                outp[i + 0] = (byte)Lerper.Lerp(Lerper.Lerp(lightcolor.B, darkcolor.B, Math.Clamp(dir * magnitude + 128, 0, 255) / 256), outp[i + 0], 1 - opacity);
            }
        }

        }

        /// <summary>
        /// Masks water to terrain layer
        /// </summary>
        public void MaskWater()
        {
            byte[] tinp = BitmapDataConverter.BitmapToByteArray(terrain.GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            for (int i = 0; i < outp.Length; i += 4)
            {
                if (tinp[i] > level)
                {
                    outp[i + 3] = 0;
                }
            }

            BitmapDataConverter.DrawImage(GetOutput(), outp, true);
        }

        /// <summary>
        /// Sets the terrain reference for masking
        /// </summary>
        /// <param name="_terrain"></param>
        public void SetTerrain(HeightLayer _terrain)
        {
            terrain = _terrain;
        }

        /// <summary>
        /// Sets the incedent light angle, re-renders
        /// </summary>
        /// <param name="_lightdirection"></param>
        /// <param name="_lightangle"></param>
        public void SetAngles(float _lightdirection, float _lightangle)
        {
            direction = _lightdirection;
            angle = _lightangle;
            Render();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public RayWaterShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            c1 = Color.FromArgb(255, 0, 39, 232);

            lightcolor = Color.FromArgb(255, 120, 130, 140);
            brightness = 0.5f;
            SetAngles(45, -45);
        }
    }
}
