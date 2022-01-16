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
    public class Renderer
    {
        Bitmap data;

        /// <summary>
        /// Responsible for rendering layer based on input data.
        /// </summary>
        public virtual void Render()
        {

        }

        /// <summary>
        /// Renderer constructor, passes a reference of the data to render into the renderer object.
        /// </summary>
        /// <param name="_data"></param>
        public Renderer(Bitmap _data)
        {
            data = _data;
        }
    }
}