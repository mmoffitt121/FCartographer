using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCartographer.Window
{
    public partial class WarningBox : Form
    {
        public WarningBox(string warning)
        {
            InitializeComponent();

            descriptionBox.Text = warning;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
