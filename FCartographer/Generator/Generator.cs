using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    /// <summary>
    /// Generator base class, used to generate layers. Will use unsafe functions.
    /// </summary>
    public class Generator
    {
        private Bitmap data;
        private Random rand;

        /// <summary>
        /// Overwritable function that performs the layer processes.
        /// </summary>
        public virtual void Generate()
        {

        }

        /// <summary>
        /// Sets the random number generator to an input seed
        /// </summary>
        /// <param name="seed"></param>
        public void SetRandom(int seed)
        {
            rand = new Random(seed);
        }

        /// <summary>
        /// Sets the random seed
        /// </summary>
        /// <param name="_rand"></param>
        public void SetRandom(Random _rand)
        {
            rand = _rand;
        }

        /// <summary>
        /// Returns the inner random number generator
        /// </summary>
        /// <returns></returns>
        public Random GetRandom()
        {
            return rand;
        }

        /// <summary>
        /// Returns the bitmap data reference stored in the generator
        /// </summary>
        /// <returns></returns>
        public Bitmap GetData()
        {
            return data;
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public Generator(Bitmap _data)
        {
            data = _data;
        }
    }
}