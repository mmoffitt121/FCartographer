using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    public class HeightLayer : Layer
    {
        private TerrainShader shader;

        public new void Render()
        {

        }

        public override void Draw(BrushPreset brush, MouseEventArgs e)
        {
            int size = brush.GetSize();
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr)
        {
            int size = brush.GetSize();
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public HeightLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.HeightMap);
        }
    }
}