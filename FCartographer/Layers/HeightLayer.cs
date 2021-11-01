using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    public class HeightLayer : Layer
    {
        private TerrainShader shader;

        public new void Render()
        {

        }

        public HeightLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.HeightMap);
        }
    }
}