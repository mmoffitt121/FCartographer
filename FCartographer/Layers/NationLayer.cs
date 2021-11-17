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
            DrawToCanvas(brush, e, g, xprime, yprime);
        }

        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            DrawToCanvas(brush, e, gr, xprime, yprime);
        }

        public override void Fill(MouseEventArgs e, BrushPreset brush)
        {
            // convert to two using statements shortly
            GraphicsPath gpath = new GraphicsPath();
            gpath.AddLine(new Point(20, 20), new Point(20, 200));
            gpath.AddLine(new Point(20, 200), new Point(200, 200));
            gpath.AddLine(new Point(200, 200), new Point(200, 20));
            gpath.AddLine(new Point(200, 20), new Point(20, 20));
            using (SolidBrush fillbrush = new SolidBrush(brushcolor))
            {
                g.FillPath(fillbrush, gpath);
            }
                
            //g.DrawImage(brush.GetImage(), e.X, e.Y, 500, 500);
        }

        public void DrawToCanvas(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
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
            pen.Color = brushcolor;
        }

        public void InitializeColor(Color _color)
        {
            brushcolor = _color;
        }

        public override void SetSize(int _size)
        {
            pen.Width = _size;
        }

        public override void UpdateBrushOptions(BrushPreset brushPreset)
        {
            SetSize(brushPreset.GetSize());
            SetColor(brushPreset.GetColor());
        }

        public NationLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.NationMap);
            SetName("Nation layer");

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 20);
            pen.Width = 20;
        }

        public NationLayer(int x, int y, string _name) : base(x, y, _name)
        {
            SetType(LayerType.NationMap);

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 30);
            pen.Width = 20;
        }
    }
}