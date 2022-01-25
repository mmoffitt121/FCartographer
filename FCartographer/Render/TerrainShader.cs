using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class TerrainShader : Renderer
    {
        public TerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {

        }
    }
}