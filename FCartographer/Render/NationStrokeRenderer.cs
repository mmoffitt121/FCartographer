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
    /// Renderer class, used to render parts of layers. Will usually utilize unsafe functions.
    /// </summary>
    public class NationStrokeRenderer : Renderer
    {
        /// <summary>
        /// Constructor, takes bitmap for reading
        /// </summary>
        /// <param name="_data"></param>
        public NationStrokeRenderer(Bitmap _data) : base(_data)
        {

        }
    }
}