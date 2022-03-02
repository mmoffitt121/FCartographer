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

        private RayWaterShader rws;

        private HeightLayer terrain;

        private NoiseGenerator ngen;
        private LandscapeTransformer ltrans;
        private Bitmap noise;

        /// <summary>
        /// Whether or not to render waves
        /// </summary>
        public bool render_waves;
        /// <summary>
        /// Whether or not to render ray-based shadows and lighting
        /// </summary>
        public bool render_rays;
        /// <summary>
        /// Whether or not to render the depth of the water
        /// </summary>
        public bool render_depth;
        /// <summary>
        /// Whether or not to render the reflection of the sun on the waves
        /// </summary>
        public bool render_sun_reflection;

        /// <summary>
        /// Determines how high a wave will be, range = 0 - 128
        /// </summary>
        public int waveamplitude;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.Clear(color1);

            if (ToRender())
            {
                render_g.Clear(Color.FromArgb(0, 0, 0, 0));
                rws.SetTerrain(terrain);
                if (terrain == null)
                {
                    rws.SetAngles(45, -45);
                }
                else
                {
                    rws.SetAngles(terrain.rts.direction, terrain.rts.angle);
                }

                rws.render_waves = render_waves;
                rws.render_rays = render_waves;
                rws.render_depth = render_depth;
                rws.render_sun_reflection = render_sun_reflection;

                rws.level = level;
                rws.c1 = color1;
                rws.Render();
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

            for (int j = i; j >= 0; j--)
            {
                if (layers[j].GetType() == Layer.LayerType.HeightMap)
                {
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
            ngen.SetScale(5);
            ngen.SetOctives(6);
            ngen.SetPersistance(0.5);
            ngen.SetRepeat(25);
            ngen.Generate();

            ltrans.min = 0;
            ltrans.max = waveamplitude * 2;
            ltrans.Generate();
        }

        private void Construct()
        {
            SetType(LayerType.Ocean);

            level = 100;
            waveamplitude = 100;
            color1 = Color.FromArgb(255, 80, 100, 100);

            noise = new Bitmap(GetData());
            ngen = new NoiseGenerator(noise);
            ltrans = new LandscapeTransformer(noise);

            RenderNoise();

            rws = new RayWaterShader(noise, GetOutData());

            render_waves = true;
            render_rays = true;
            render_depth = true;
            render_sun_reflection = true;

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