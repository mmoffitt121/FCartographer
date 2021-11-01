using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    public class Project
    {
        private String name;

        private IList<Layer> layers;
        private IList<BrushPreset> brushes;

        private int current;

        private Graphics g;

        private int width, height;

        public void AddLayer(LayerType type)
        {
            switch (type)
            {
                case 0:
                    layers.Add(new HeightLayer(width, height));
                    break;
                default:
                    break;
            }

            SelectLayer(layers.Count - 1);
        }

        public void AddBrushPreset(string filename)
        {

        }

        public void SetCanvasSize(int x, int y)
        {
            width = x; 
            height = y;
        }

        public void SelectLayer(int layer)
        {
            g = Graphics.FromImage(layers[layer].GetData());
            current = layer;
        }

        public void Draw(BrushPreset brush, MouseEventArgs e)
        {

            int size = brush.GetSize();
            g.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        public Layer CurrentLayer()
        {
            return layers[current];
        }

        public Project(int w, int h)
        {
            SetCanvasSize(w, h);
            layers = new List<Layer>();
            output = new Bitmap(width, height);
            outg = Graphics.FromImage(output);
        }

        public Bitmap GetGraphics()
        {
            return CompositeLayers();
        }

        private Bitmap output;
        private Graphics outg;

        private Bitmap CompositeLayers()
        {
            outg.Clear(Color.White);

            for (int i = 0; i < layers.Count; i++)
            {
                outg.DrawImage(layers[i].GetData(), 0, 0, width, height);
            }

            return output;
        }
    }
}