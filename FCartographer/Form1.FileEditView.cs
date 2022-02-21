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
using FCartographer.FileHandling;

namespace FCartographer
{
    /// <summary>
    /// This part of Form1 is used for the bar at the top of the form, handling File, Edit, View, etc.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Create new file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Project newproject = NewProjectHandler.CreateProject();
            if (newproject != null)
            {
                project = newproject;
            }

            InitializeProjectSettings();
            RenderGraphics(project.GetGraphics());
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Quit
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Saving
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project.GetGraphics().Save("Output.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Importing
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void heightMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileHandler.OpenHeightMap(project);

            ReadySettingsPanels(project.CurrentLayer());
            DisplayLayers();
        }
    }
}
