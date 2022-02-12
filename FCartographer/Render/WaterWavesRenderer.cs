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
    /// Render class that renders optionally lit water.
    /// </summary>
    public class WaterWavesRenderer : Renderer
    {
        public float lightangle;
        public byte level;
        private HeightLayer terrain;

        /// <summary>
        /// First water color
        /// </summary>
        public Color c1;
        /// <summary>
        /// Second water color
        /// </summary>
        public Color c2;   
        /// <summary>
        /// Third water color
        /// </summary>
        public Color c3;

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
            GradientTerrainShader shader = new GradientTerrainShader(GetData(), GetOutput());
            shader.angle = lightangle;
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
        /// Constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public WaterWavesRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {
            lightangle = 45;
        }
    }
}
