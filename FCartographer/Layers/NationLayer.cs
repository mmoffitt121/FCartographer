using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Layer that holds and interfaces with data for nation maps.
    /// </summary>
    public class NationLayer : Layer
    {
        private TerrainShader shader;
        private List<Nation> nations;

        private Pen pen;

        private Color brushcolor;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        /// <summary>
        /// Override void that Draws on a temporary layer. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            DrawToCanvas(brush, e, g, xprime, yprime);
        }

        /// <summary>
        /// Override void that Draws on the display canvas. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            DrawToCanvas(brush, e, gr, xprime, yprime);
        }

        /// <summary>
        /// Fills contiguous region with pixels of selected nation.
        /// </summary>
        public override void Fill(MouseEventArgs e, BrushPreset brush)
        {
            using (Bitmap fillregion = AreaSelector.FillAreaContiguous(GetData(), new Point(e.X, e.Y), 0, brush))
            {
                g.DrawImage(fillregion, 0, 0, fillregion.Width, fillregion.Height);
            }

            Render();
        }

        /// <summary>
        /// Generalized draw to canvas function, used by both Draw() and DrawTemp(). Used to draw on canvas based
        /// on input brush settings, as well as mouse location and movement.
        /// </summary>
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

        /// <summary>
        /// Override void that sets the internal layer saved color.
        /// </summary>
        public override void SetColor(Color _color)
        {
            brushcolor = _color;
            pen.Color = brushcolor;
        }

        /// <summary>
        /// Override void that initializes the internal layer saved color without interacting with the layer's 
        /// internal pen.
        /// </summary>
        public void InitializeColor(Color _color)
        {
            brushcolor = _color;
        }

        /// <summary>
        /// Override void that sets the internal layer saved pen.
        /// </summary>
        public override void SetSize(int _size)
        {
            pen.Width = _size;
        }

        /// <summary>
        /// Grabs internal brush options from the input layer.
        /// </summary>
        public override void UpdateBrushOptions(BrushPreset brushPreset)
        {
            SetSize(brushPreset.GetSize());
            SetColor(brushPreset.GetColor());
        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public NationLayer(int x, int y) : base(x, y)
        {
            SetType(LayerType.NationMap);
            SetName("Nation layer");

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 20);
            pen.Width = 20;
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public NationLayer(int x, int y, string _name) : base(x, y, _name)
        {
            SetType(LayerType.NationMap);

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 30);
            pen.Width = 20;
        }
    }
}