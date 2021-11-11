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
    /// This part of Form1 is used for Layer control
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Adds a layer to the project
        /// </summary>
        private void AddLayer_Click(object sender, EventArgs e)
        {
            if (LayerToAdd.Text.Equals("Nations"))
            {
                project.AddLayer(Layer.LayerType.NationMap);
            }
            if (LayerToAdd.Text.Equals("Terrain"))
            {
                project.AddLayer(Layer.LayerType.HeightMap);
            }
            ReadySettingsPanels(project.CurrentLayer());
        }

        /// <summary>
        /// Places a panel for each layer in the layer pane for user navigation.
        /// </summary>
        public void DisplayLayers()
        {
            Panel paneltemp = new Panel() { Location = new Point(10, 10) };
            Controls.Add(paneltemp);

            for (int i = 0; i < project.GetLayerCount(); i++)
            {

            }
        }
    }
}
