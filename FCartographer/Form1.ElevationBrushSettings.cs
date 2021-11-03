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
        private void StrengthControl_Scroll(object sender, EventArgs e)
        {
            brushpreset.SetOpacity(StrengthControl.Value);
        }

        private void SizeControl_Scroll(object sender, EventArgs e)
        {
            brushpreset.SetSize(SizeControl.Value);
        }

        private void HeightControl_Scroll(object sender, EventArgs e)
        {
            brushpreset.SetColor(HeightControl.Value, HeightControl.Value, HeightControl.Value);
        }
    }
}
