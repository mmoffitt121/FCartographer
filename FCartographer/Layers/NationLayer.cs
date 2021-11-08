using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FCartographer
{
    public class NationLayer : Layer
    {
        private TerrainShader shader;
        private List<Nation> nations;

        public override void Render()
        {
            data_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        public override void Draw(BrushPreset brush, MouseEventArgs e)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr)
        {
            int size = brush.GetSize();
            gr.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public NationLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.NationMap);
        }
    }
}