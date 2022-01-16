using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    /// <summary>
    /// Layer that holds and interfaces with data for heightmaps.
    /// </summary>
    public class HeightLayer : Layer
    {
        //private TerrainShader shader;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));
        }

        /// <summary>
        /// Override void that Draws on a temporary layer. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        /// <summary>
        /// Override void that Draws on the display canvas. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        /// <summary>
        /// Will fill a region, unimplemented.
        /// </summary>
        public override void Fill(MouseEventArgs e, BrushPreset brush)
        {
            
        }

        /// <summary>
        /// Override void that sets the internal layer saved color.
        /// </summary>
        public override void SetColor(Color _color)
        {

        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public HeightLayer(int x, int y) : base(x, y, "Terrain Layer", "Terrain Layer Description")
        {
            SetType(LayerType.HeightMap);
            SetName("Terrain layer");
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public HeightLayer(int x, int y, string _name) : base(x, y, _name, "Terrain Layer", "Terrain Layer Description")
        {
            SetType(LayerType.HeightMap);
        }
    }
}