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
    /// This part of Form1 handles rendering interaction
    /// </summary>
    public partial class Form1 : Form
    {
        private void renderLayerButton_Click(object sender, EventArgs e)
        {
            project.CurrentLayer().Render();
            RenderGraphics(project.GetGraphics());
        }
    }
}