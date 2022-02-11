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
        /// <summary>
        /// Override Render function
        /// </summary>
        public override void Render()
        {
            
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_data"></param>
        /// <param name="_output"></param>
        public WaterWavesRenderer(Bitmap _data, Bitmap _output) : base(_data, _output)
        {

        }
    }
}
