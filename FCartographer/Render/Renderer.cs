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
        private Bitmap data;
        private Bitmap output;

        /// <summary>
        /// 0 if default
        /// 1 if accelerated by CPU only
        /// 2 if accelerated by OpenCL
        /// 3 if accelerated by CUDA
        /// </summary>
        public static int rendermode = 3;

        /// <summary>
        /// Number between 0 and 1 that controls the opacity of the layer
        /// </summary>
        public float opacity;

        /// <summary>
        /// Responsible for rendering layer based on input data.
        /// </summary>
        public virtual void Render()
        {

        }

        /// <summary>
        /// Responsible for rendering layer based on input data.
        /// </summary>
        public virtual void Render(int x0, int y0, int x1, int y1)
        {

        }

        /// <summary>
        /// Returns the base data held in the renderer
        /// </summary>
        /// <returns></returns>
        public Bitmap GetData()
        {
            return data;
        }

        /// <summary>
        /// Returns the output data held in the renderer
        /// </summary>
        /// <returns></returns>
        public Bitmap GetOutput()
        {
            return output;
        }

        /// <summary>
        /// Renderer constructor, passes a reference of the data to render into the renderer object.
        /// </summary>
        public Renderer(Bitmap _data, Bitmap _output)
        {
            data = _data;
            output = _output;
            opacity = 1f;
        }
    }
}