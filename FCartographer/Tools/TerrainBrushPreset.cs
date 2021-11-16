using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    public class TerrainBrushPreset : BrushPreset
    {
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // BrushPreset constructor
        public TerrainBrushPreset(string brushpath, int siz, int opac, Color clr, bool _solidify) : base(brushpath, siz, opac, clr, false)
        {
            
        }
    }
}