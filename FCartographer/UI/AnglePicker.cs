using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Shader responsible for terrain layers
    /// </summary>
    public class AnglePicker : Panel
    {
        /// <summary>
        /// Float that represents the picked angle.
        /// </summary>
        public float angle;
    }
}