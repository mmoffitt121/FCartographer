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
        /// <summary>
        /// Renders the contour of the terrain layer
        /// </summary>
        public ContourRenderer ctr;

        /// <summary>
        /// Fast light shader
        /// </summary>
        public GradientTerrainShader gts;

        /// <summary>
        /// Slow light shader
        /// </summary>
        public RayTerrainShader rts;

        /// <summary>
        /// Layer that controls the water rendering
        /// </summary>
        public WaterLayer waterlayer;

        /// <summary>
        /// Determines if contour renderer is used
        /// </summary>
        public bool render_contour;
        /// <summary>
        /// Determines if gradient renderer is used
        /// </summary>
        public bool render_gradient;
        /// <summary>
        /// determines if ray renderer is used
        /// </summary>
        public bool render_rays;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));

            if (ToRender())
            {
                if (render_rays)
                {
                    float direction = (-rts.direction) * MathF.PI / 180;
                    float angle = (rts.angle + 90) * MathF.PI / 180;

                    int wid = GetData().Width;
                    int hei = GetData().Height;

                    double longestray = Math.Min(255 * Math.Tan(angle), Math.Sqrt(wid * wid + hei * hei));

                    int dx = (int)(longestray * Math.Cos(direction));
                    int dy = (int)(longestray * Math.Sin(direction));

                    if (dx < 0)
                    {
                        rx0 = Math.Max(rx0 + dx, 0);
                    }
                    else
                    {
                        rx1 = Math.Min(rx1 + dx, wid);
                    }

                    if (dy < 0)
                    {
                        ry0 = Math.Max(ry0 + dy, 0);
                    }
                    else
                    {
                        ry1 = Math.Min(ry1 + dy, hei);
                    }
                }

                render_g.DrawRectangle(new Pen(Color.White), rx0, ry0, rx1 - rx0 - 1, ry1 - ry0 - 1);
                if (render_contour)
                {
                    ctr.Render(rx0, ry0, rx1, ry1);
                }
                
                if (render_gradient)
                {
                    gts.opacity = 0.5f;
                    gts.Render(rx0, ry0, rx1, ry1);
                }
                
                if (render_rays)
                {
                    rts.opacity = 0.5f;
                    rts.Render(rx0, ry0, rx1, ry1);
                }

                if (waterlayer != null)
                {
                    waterlayer.Render(rx0, ry0, rx1, ry1);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layers"></param>
        /// <param name="i"></param>
        public override void FormConnections(IList<Layer> layers, int i)
        {
            waterlayer = null;

            for (int j = i; j < layers.Count; j++)
            {
                if (layers[j].GetType() == Layer.LayerType.Ocean)
                {
                    waterlayer = (WaterLayer)layers[j];
                    break;
                }
            }
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
            base.Draw(brush, e, xprime, yprime);
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

        private void Construct()
        {
            SetType(LayerType.HeightMap);

            data_g.Clear(Color.FromArgb(255, 0, 0, 0));

            ctr = new ContourRenderer(GetData(), GetOutData());
            gts = new GradientTerrainShader(GetData(), GetOutData());
            rts = new RayTerrainShader(GetData(), GetOutData());

            render_contour = true;
            render_gradient = false;
            render_rays = true;
            Render();
        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public HeightLayer(int x, int y) : base(x, y, "Terrain Layer", "Terrain Layer Description")
        {
            Construct();
            SetName("Terrain layer");
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public HeightLayer(int x, int y, string _name) : base(x, y, _name, "Terrain Layer", "Terrain Layer Description")
        {
            Construct();
        }
    }
}