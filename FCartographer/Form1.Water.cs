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
    /// This part of Form1 handles water layers and their settings.
    /// </summary>
    public partial class Form1 : Form
    {
        private WaterLayer waterlayer;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            waterLevelValue.Text = waterLevelTrackbar.Value + "";
            if (waterlayer != null)
            {
                waterlayer.level = (byte)waterLevelTrackbar.Value;
            }
        }

        private void SetWaterLayerReference()
        {
            try
            {
                waterlayer = (WaterLayer)project.CurrentLayer();
            }
            catch
            {
                waterlayer = null;
            }
        }

        private void UpdateWaterControls()
        {
            if (waterlayer != null)
            {
                waterLevelValue.Text = waterlayer.level + "";
                waterLevelTrackbar.Value = waterlayer.level;
            }
        }
    }
}