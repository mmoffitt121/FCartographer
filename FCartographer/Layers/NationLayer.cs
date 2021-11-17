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

        private Pen pen;

        private Color brushcolor;

        public override void Render()
        {
            data_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        public override void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            if (xprime != null && yprime != null)
            {
                g.DrawLine(pen, (int)xprime, (int)yprime, e.X, e.Y);
            }
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            gr.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            if (xprime != null && yprime != null)
            {
                gr.DrawLine(pen, (int)xprime, (int)yprime, e.X, e.Y);
            }
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public override void SetColor(Color _color)
        {
            brushcolor = _color;
        }

        public override void SetSize(int _size)
        {
            pen.Width = _size;
        }

        public override void UpdateOptions(NationsBrushPreset nationsBrushPreset)
        {
            SetSize(nationsBrushPreset.GetSize());
            SetColor(nationsBrushPreset.GetColor());
        }

        public NationLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.NationMap);
            SetName("Nation layer");

            SetColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 20);
            pen.Width = 20;
        }

        public NationLayer(int x, int y, string _name) : base(x, y, _name)
        {
            SetType(LayerType.NationMap);

            SetColor(Color.FromArgb(255, 0, 0, 0));
            pen = new Pen(brushcolor, 30);
            pen.Width = 20;
        }
    }
}