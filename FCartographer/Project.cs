using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Class: Project
    /// This part of Form1 is used for navigating the canvas; zoom, scroll, etc.
    /// </summary>
    public class Project
    {
        private String name;

        private IList<Layer> layers;

        private int current;

        private Graphics g;

        private int width, height;

        public void AddLayer(Layer.LayerType type)
        {
            switch (type)
            {
                case Layer.LayerType.HeightMap:
                    layers.Add(new HeightLayer(width, height));
                    break;
                case Layer.LayerType.NationMap:
                    layers.Add(new NationLayer(width, height));
                    break;
                default:
                    break;
            }

            SelectLayer(layers.Count - 1);
        }

        public void DeleteLayer(int to_delete)
        {
            try
            {
                Layer layer = layers[to_delete];
                layers.RemoveAt(to_delete);
                layer.Dispose();
            }
            catch
            {
                return;
            }
        }

        public void SwapLayers(int s1, int s2)
        {
            try
            {
                Layer temp = layers[s1];
                layers[s1] = layers[s2];
                layers[s2] = temp;
            }
            catch
            {
                return;
            }
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
            try
            {
                g = Graphics.FromImage(layers[layer].GetData());
                current = layer;
            }
            catch
            {
                current = -1;
            }
            
        }

        public void Draw(BrushPreset brush, MouseEventArgs e)
        {
            try
            {
                layers[current].Draw(brush, e);
            }
            catch
            {
                return;
            }
        }

        public void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr)
        {
            try
            {
                layers[current].DrawTemp(brush, e, gr);
            }
            catch
            {
                return;
            }
        }

        public Layer CurrentLayer()
        {
            if (layers.Count < 1)
            {
                return null;
            }

            try
            {
                return layers[current];
            }
            catch
            {
                return null;
            }
            
        }

        public int GetCurrentIndex()
        {
            return current;
        }

        public Layer GetLayer(int i)
        {
            try
            {
                return layers[i];
            }
            catch (IndexOutOfRangeException ex)
            {
                return null;
            }
        }

        public int GetLayerCount()
        {
            return layers.Count;
        }

        public Project(int w, int h)
        {
            SetCanvasSize(w, h);
            layers = new List<Layer>();
            output = new Bitmap(width, height);
            outg = Graphics.FromImage(output);
            current = -1;
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