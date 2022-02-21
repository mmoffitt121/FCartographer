using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Class that holds biome information.
    /// </summary>
    public class Biome
    {
        public Color color;
        public string name;

        /// <summary>
        /// Biome constructor
        /// </summary>
        public Biome(List<Nation> nations)
        {
            
        }

        public enum BiomeType
        {
            Plains,
            Mountains,
            Mesas,
            DeepOceans
        }
    }
}