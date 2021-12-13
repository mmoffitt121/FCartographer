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
using FCartographer.Window;

namespace FCartographer
{
    /// <summary>
    /// This part of Form one handles interaction with the landscape generation menu.
    /// </summary>
    public partial class Form1 : Form
    {
        private LandscapeGeneratorWindow landgenmenu;

        private void landscapeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (landgenmenu == null)
            {
                landgenmenu = new LandscapeGeneratorWindow(this);
            }

            landgenmenu.StartPosition = FormStartPosition.Manual;
            landgenmenu.Location = new Point(this.Location.X + this.Width / 2 - layermenu.Width / 2, this.Location.Y + this.Height / 2 - layermenu.Height / 2);
            landgenmenu.ShowDialog();

            ReadySettingsPanels(project.CurrentLayer());

            DisplayLayers();
        }
    }
}
