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
    /// Holds data for brushes used on terrain layers
    /// </summary>
    public class TerrainBrushPreset : BrushPreset
    {
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Brush preset constructor.
        /// </summary>
        public TerrainBrushPreset(string brushpath, int siz, int opac, Color clr, bool _solidify) : base(brushpath, siz, opac, clr, false)
        {
            
        }
    }
}