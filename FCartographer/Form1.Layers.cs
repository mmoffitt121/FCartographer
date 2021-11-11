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
    public partial class Form1 : Form
    {
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
