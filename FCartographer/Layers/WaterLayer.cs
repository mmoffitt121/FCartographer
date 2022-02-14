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
        /// Color of incident light
        /// </summary>
        public Color lightcolor;

        /// <summary>
        /// Layer that holds the height data, used as a mask
        /// </summary>
        public HeightLayer heightlayer;

        /// <summary>
        /// 0 = basic shadowed water
        /// 1 = advanced shadowed transparent depth water
        /// </summary>
        public int mode;

        private WaterWavesRenderer wwr;
        private RayWaterShader rws;

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
                switch (mode)
                {
                    case 0:
                        wwr.SetTerrain(terrain);
                        if (terrain == null)
                        {
                            wwr.SetAngle(45);
                        }
                        else
                        {
                            wwr.SetAngle(terrain.gts.angle);
                        }
                        
                        wwr.level = level;
                        wwr.c1 = color1;
                        wwr.Render();
                        break;
                    case 1:
                        rws.SetTerrain(terrain);
                        if (terrain == null)
                        {
                            rws.SetAngles(45, -45);
                        }
                        else
                        {
                            rws.SetAngles(terrain.rts.direction, terrain.rts.angle);
                        }

                        rws.level = level;
                        rws.c1 = color1;
                        rws.Render();
                        break;
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
            terrain = null;

            System.Diagnostics.Debug.WriteLine("Forming Connections");

            for (int j = 0; j < layers.Count; j++)
            {
                if (j > i)
                {
                    break;
                }

                if (layers[j].GetType() == Layer.LayerType.HeightMap)
                {
                    System.Diagnostics.Debug.WriteLine("Connected with terrain");
                    terrain = (HeightLayer)layers[j];
                    break;
                }
            }
        }

        /// <summary>
        /// Creates the noise for the water layer. 
        /// </summary>
        public void RenderNoise()
        {
            ngen = new NoiseGenerator(noise);
            ngen.SetScale(1);
            ngen.SetOctives(6);
            ngen.SetPersistance(0.5);
            ngen.SetRepeat(25);
            ngen.Generate();
        }

        private void Construct()
        {
            SetType(LayerType.Ocean);

            level = 50;
            color1 = Color.FromArgb(255, 19, 42, 41);

            noise = new Bitmap(GetData());

            RenderNoise();

            wwr = new WaterWavesRenderer(noise, GetOutData());
            rws = new RayWaterShader(noise, GetOutData());

            mode = 1;

            Render();
        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public WaterLayer(int x, int y) : base(x, y, "Nations Layer", "Nations Layer Description")
        {
            SetName("Water layer");
            Construct();
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public WaterLayer(int x, int y, string _name) : base(x, y, _name, "Nations Layer", "Nations Layer Description")
        {
            Construct();
        }
    }
}