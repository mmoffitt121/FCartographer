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
    /// Layer that contains water information and renders water layers.
    /// </summary>
    public class WaterLayer : Layer
    {
        /// <summary>
        /// Level at which water is displayed.
        /// </summary>
        public byte level;

        /// <summary>
        /// Water render color 1
        /// </summary>
        public Color color1;
        /// <summary>
        /// Water render color 2
        /// </summary>
        public Color color2;
        /// <summary>
        /// Water render color 3
        /// </summary>
        public Color color3;

        /// <summary>
        /// Layer that holds the height data, used as a mask
        /// </summary>
        public HeightLayer heightlayer;

        private WaterWavesRenderer wwr;

        private HeightLayer terrain;

        private NoiseGenerator ngen;
        private Bitmap noise;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.Clear(color1);

            if (ToRender())
            {
                render_g.Clear(Color.FromArgb(0, 0, 0, 0));
                wwr.SetTerrain(terrain);
                wwr.level = level;
                wwr.Render();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="layers"></param>
        public override void FormConnections(IList<Layer> layers, int i)
        {
            terrain = null;

            for (int j = 0; j < layers.Count; j++)
            {
                if (layers[i].GetType() == Layer.LayerType.HeightMap)
                {
                    terrain = (HeightLayer)layers[i];
                    break;
                }

                if (j > i)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public WaterLayer(int x, int y) : base(x, y, "Nations Layer", "Nations Layer Description")
        {
            SetType(LayerType.Ocean);
            SetName("Water layer");

            level = 50;
            color1 = Color.FromArgb(255, 10, 30, 60);

            noise = new Bitmap(GetData());

            ngen = new NoiseGenerator(noise);
            ngen.SetScale(1);
            ngen.SetOctives(6);
            ngen.SetPersistance(0.9);
            ngen.Generate();

            wwr = new WaterWavesRenderer(noise, GetOutData());

            Render();
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public WaterLayer(int x, int y, string _name) : base(x, y, _name, "Nations Layer", "Nations Layer Description")
        {
            SetType(LayerType.Ocean);

            level = 50;
            color1 = Color.FromArgb(255, 10, 30, 60);

            wwr = new WaterWavesRenderer(GetData(), GetOutData());

            noise = new Bitmap(GetData());

            ngen = new NoiseGenerator(noise);
            ngen.SetScale(1);
            ngen.SetOctives(6);
            ngen.SetPersistance(0.9);
            ngen.Generate();

            wwr = new WaterWavesRenderer(noise, GetOutData());

            Render();
        }
    }
}