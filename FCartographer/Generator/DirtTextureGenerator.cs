using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace FCartographer
{
    /// <summary>
    /// Class that handles generation of dirt
    /// </summary>
    public class DirtTextureGenerator : Generator
    {
        /// <summary>
        /// Generates the dirt texture
        /// </summary>
        public override void Generate()
        {
            NoiseGenerator ngen = new NoiseGenerator(GetData());

            ngen.octives = 5;
            ngen.scale = 0;
            ngen.persistence = 0.5;
            ngen.repeat = 1;

            ngen.SetRandom(GetRandom());
            ngen.Generate();

            /*private int octives;
        private NoiseMode noisemode;

        private int scale;

        private int[] perlinhash;

        private int width;
        private int height;

        private double persistence;

        private int repeat;*/
        }

        /// <summary>
        /// Constructor, takes destination for texture generation
        /// </summary>
        /// <param name="_data"></param>
        public DirtTextureGenerator(Bitmap _data) : base(_data)
        {
            SetRandom(30150831);
        }
    }
}
