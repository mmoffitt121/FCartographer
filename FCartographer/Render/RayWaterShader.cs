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
            // Rendering waves

            GradientTerrainShader shader = new GradientTerrainShader(GetData(), GetOutput());

            ColorHSL lightcolorHSL = ColorHSL.FromARGB(lightcolor);

            ColorHSL brightside = ColorHSL.FromARGB(c1);
            ColorHSL darkside = ColorHSL.FromARGB(c1);

            brightside.H = (brightside.H + 40) % 360;
            brightside.L = Math.Clamp(brightside.L + 0.15, 0, 1);

            darkside.H = (darkside.H - 40) % 360;
            darkside.L = Math.Clamp(darkside.L - 0.15, 0, 1);

            System.Diagnostics.Debug.WriteLine(brightside.ToString() + " + " + darkside.ToString());

            Color lightercolor = brightside.ToARGB();
            Color darkercolor = darkside.ToARGB();

            shader.Render();

            // Rendering water shading

            byte[] inp = BitmapDataConverter.BitmapToByteArray(GetData());
            byte[] outp = BitmapDataConverter.BitmapToByteArray(GetOutput());

            int wid = GetData().Width * 4;
            int hei = GetData().Height;
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
