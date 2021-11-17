using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Partial Class: Form1
    /// This part of Form1 controls the elevation brush settings
    /// </summary>
    public partial class Form1 : Form
    {
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Elevation Brush
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Sets the opacity for the Terrain Brush from Terrain Brush strength Slider
        /// </summary>
        private void StrengthControl_Scroll(object sender, EventArgs e)
        {
            terrain_brushpreset.SetOpacity(StrengthControl.Value);
            UpdateLayerBrushes();
        }

        /// <summary>
        /// Sets the size for the Terrain Brush from Terrain Brush size Slider
        /// </summary>
        private void SizeControl_Scroll(object sender, EventArgs e)
        {
            terrain_brushpreset.SetSize(SizeControl.Value);
            UpdateLayerBrushes();
        }

        /// <summary>
        /// Sets the Target Height for the Terrain Brush from Terrain Brush size Slider
        /// </summary>
        private void HeightControl_Scroll(object sender, EventArgs e)
        {
            terrain_brushpreset.SetColor(HeightControl.Value, HeightControl.Value, HeightControl.Value);
            UpdateLayerBrushes();
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Nation Brush
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Initializes Form1
        /// </summary>
        private void NationsSizeControl_Scroll(object sender, EventArgs e)
        {
            nations_brushpreset.SetSize(NationsSizeControl.Value);
            UpdateLayerBrushes();
        }
    }
}
