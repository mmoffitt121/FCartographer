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
    /// Holds data for brushes used on nation layers
    /// </summary>
    public class NationsBrushPreset : BrushPreset
    {
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // BrushPreset constructor
        /// <summary>
        /// Constructor for Nation layer-specific brushes. Ensures the brush's hardness.
        /// </summary>
        public NationsBrushPreset(string brushpath, int siz, int opac, Color clr, bool _solidify) : base(brushpath, siz, opac, clr, true)
        {

        }
    }
}