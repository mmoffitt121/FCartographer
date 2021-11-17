using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    public class HeightLayer : Layer
    {
        private TerrainShader shader;

        public override void Render()
        {
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        public override void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void SetColor(Color _color)
        {

        }

        public HeightLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.HeightMap);
            SetName("Terrain layer");
        }

        public HeightLayer(int x, int y, string _name) : base(x, y, _name)
        {
            SetType(LayerType.HeightMap);
        }
    }
}