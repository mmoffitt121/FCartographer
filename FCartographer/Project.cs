using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Holds project data including dimensions, layers, and data interfaces.
    /// </summary>
    public class Project
    {
        //private String name;

        private IList<Layer> layers;

        private int current;

        private Graphics g;

        private int width, height;

        /// <summary>
        /// Adds nameless layer based on input type enum value
        /// </summary>
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
                case Layer.LayerType.Ocean:
                    layers.Add(new WaterLayer(width, height));
                    break;
                default:
                    break;
            }

            SelectLayer(layers.Count - 1);
        }

        /// <summary>
        /// Adds named layer based on input type enum value and input name
        /// </summary>
        public void AddLayer(Layer.LayerType type, string _name)
        {
            switch (type)
            {
                case Layer.LayerType.HeightMap:
                    layers.Add(new HeightLayer(width, height, _name));
                    break;
                case Layer.LayerType.NationMap:
                    layers.Add(new NationLayer(width, height, _name));
                    break;
                case Layer.LayerType.Ocean:
                    layers.Add(new WaterLayer(width, height, _name));
                    break;
                default:
                    break;
            }

            SelectLayer(layers.Count - 1);
        }

        /// <summary>
        /// Disposes of layer at specified index
        /// </summary>
        public void DeleteLayer(int to_delete)
        {
            try
            {
                Layer layer = layers[to_delete];
                layers.RemoveAt(to_delete);
                //layer.Dispose();
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Swaps order of two layers
        /// </summary>
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

        /// <summary>
        /// Sets size of project canvas
        /// </summary>
        public void SetCanvasSize(int x, int y)
        {
            width = x; 
            height = y;
        }

        /// <summary>
        /// Selects layer of specified index
        /// </summary>
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

        /// <summary>
        /// Calls the specified layer's Draw() function
        /// </summary>
        public void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            try
            {
                layers[current].Draw(brush, e, xprime, yprime);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Calls the specified layer's DrawTemp() function
        /// </summary>
        public void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            try
            {
                layers[current].DrawTemp(brush, e, gr, xprime, yprime);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Calls specified layer's Fill() function, which fills a region with the user-selected color
        /// </summary>
        public void Fill(MouseEventArgs e, BrushPreset brush)
        {
            try
            {
                layers[current].Fill(e, brush);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Returns the currently selected layer
        /// </summary>
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

        /// <summary>
        /// Gets the index of the current selected layer
        /// </summary>
        public int GetCurrentIndex()
        {
            return current;
        }

        /// <summary>
        /// Returns layer at a specific index
        /// </summary>
        public Layer GetLayer(int i)
        {
            try
            {
                return layers[i];
            }
            catch (IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Returns amount of layers
        /// </summary>
        public int GetLayerCount()
        {
            return layers.Count;
        }

        /// <summary>
        /// Returns all layers rendered and composited.
        /// </summary>
        public Bitmap GetGraphics()
        {
            return CompositeLayers();
        }

        public void UpdateConnections()
        {
            for (int i = 0; i < layers.Count; i++)
            {
                layers[i].FormConnections();
            }
        }

        private Bitmap output;
        private Graphics outg;

        /// <summary>
        /// Composits layers together
        /// </summary>
        private Bitmap CompositeLayers()
        {
            outg.Clear(Color.White);

            for (int i = 0; i < layers.Count; i++)
            {
                if (!layers[i].Visible())
                {
                    continue;
                }
                if (layers[i].ToRender())
                {
                    outg.DrawImage(layers[i].GetOutData(), 0, 0, width, height);
                }
                else
                {
                    outg.DrawImage(layers[i].GetData(), 0, 0, width, height);
                }
                
            }

            return output;
        }

        /// <summary>
        /// Constructor, creates project object of specified width and height
        /// </summary>
        public Project(int w, int h)
        {
            SetCanvasSize(w, h);
            layers = new List<Layer>();
            output = new Bitmap(width, height);
            outg = Graphics.FromImage(output);
            current = -1;
        }
    }
}