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
    public partial class LayerSettingsWindow : Form
    {
        private Layer layer;
        private Form1 parentform;

        /// <summary>
        /// Constructor that takes layer to change settings of and parent form as input
        /// </summary>
        /// <param name="_layer"></param>
        /// <param name="_parentform"></param>
        public LayerSettingsWindow(Layer _layer, Form1 _parentform)
        {
            InitializeComponent();

            layer = _layer;
            parentform = _parentform;
        }
    }
}
