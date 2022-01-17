using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace FCartographer
{
    /// <summary>
    /// Generator base class, used to generate layers. Will use unsafe functions.
    /// </summary>
    public class LandGenerator : Generator
    {
        /// <summary>
        /// Overwritable function that performs the layer processes.
        /// </summary>
        public override void Generate()
        {
            // Debug.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
            NoiseGenerator noisegen = new NoiseGenerator(GetData(), GetRandom());
            noisegen.SetOctives(10);
            noisegen.SetPersistance(0.4);
            noisegen.Generate();

            // Debug.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);

            ErosionSimulator erosiongen = new ErosionSimulator(GetData());
            erosiongen.SetRandom(GetRandom());
            erosiongen.Generate();

            // Debug.WriteLine(Process.GetCurrentProcess().PrivateMemorySize64);
        }

        /// <summary>
        /// Generator constructor
        /// </summary>
        /// <param name="_data"></param>
        public LandGenerator(Bitmap _data) : base(_data)
        {

        }
    }
}