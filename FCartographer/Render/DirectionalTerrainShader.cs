using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    /// <summary>
    /// Shader that extends terrainshader, shades terrain based on input direction.
    /// </summary>
    public class DirectionalTerrainShader : TerrainShader
    {
        public DirectionalTerrainShader(Bitmap _data, Bitmap _output) : base(_data, _output)
        {

        }
    }
}