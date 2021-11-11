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
    /// This part of Form1 controls the visibility of the panels
    /// </summary>
    public partial class Form1 : Form
    {
        private void ReadySettingsPanels(Layer layer)
        {
            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    DisableAllSettingsPanels();
                    SetElevationSettingsActive(true);
                    break;
                case Layer.LayerType.NationMap:
                    DisableAllSettingsPanels();
                    SetNationsSettingsActive(true);
                    break;
                default:
                    break;
            }
        }

        private void DisableAllSettingsPanels()
        {
            SetElevationSettingsActive(false);
            SetNationsSettingsActive(false);
        }

        private void SetElevationSettingsActive(bool active)
        {
            if (active)
            {
                panel2.Controls.Add(ElevationSettings);
            }
            else
            {
                panel2.Controls.Remove(ElevationSettings);
            }
        }

        private void SetNationsSettingsActive(bool active)
        {
            if (active)
            {
                panel2.Controls.Add(NationsSettings);
            }
            else
            {
                panel2.Controls.Remove(NationsSettings);
            }
        }
    }
}
