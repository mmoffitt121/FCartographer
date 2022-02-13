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
    public class WaterWavesRenderer : Renderer
    {
        /// <summary>
        /// Angle at which sunlight comes from
        /// </summary>
        private float lightangle;
        /// <summary>
        /// Level at which the water sits on the terrain
        /// </summary>
        public byte level;
        private HeightLayer terrain;

        /// <summary>
        /// Average water color
        /// </summary>
        public Color c1;
        /// <summary>
        /// Darkest water color
        /// </summary>
        public Color c2;   
        /// <summary>
        /// Third water color
        /// </summary>
        public Color c3;

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
                System.Diagnostics.Debug.WriteLine("Found Terrain");
                MaskWater();
            }
        }

        /// <summary>
        /// Masks and renders the water according to an internal sun
        /// </summary>
        public void RenderWater()
        {
            GradientTerrainShader shader = new GradientTerrainShader(GetData(), GetOutput());
            shader.angle = lightangle;

            ColorHSL lightcolorHSL = ColorHSL.FromARGB(lightcolor);

            ColorHSL brightside = ColorHSL.FromARGB(c1);

            brightside.L = (float)Lerper.Lerp(brightside.L, lightcolorHSL.L, brightness);

            shader.lightcolor = brightside.ToARGB();
            shader.Render();
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
        /// <param name="_lightangle"></param>
        public void SetAngle(float _lightangle)
        {
            lightangle = _lightangle;
            Render();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public WaterWavesRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            c1 = Color.CadetBlue;
            c2 = Color.BlueViolet;
            c3 = Color.CornflowerBlue;

            lightcolor = Color.FromArgb(255, 255, 255, 240);
            brightness = 0.9f;
            SetAngle(45);
        }
    }
}
