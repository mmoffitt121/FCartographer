using System;
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
    /// Window for adding a new layer with specified settings.
    /// 
    /// This class, when instantiated, takes the parent form as input, and interfaces with the project.
    /// </summary>
    public partial class AddLayerMenu : Form
    {
        /// <summary>
        /// Holds the reference to the parent Form1 object, aka the main program.
        /// </summary>
        private Form1 parentform;

        /// <summary>
        /// Adds a layer based on the layer type name in the LayerToAdd text input box
        /// </summary>
        private void CreateLayerButton_Click(object sender, EventArgs e)
        {
            if (LayerToAdd.Text.Equals("Nations"))
            {
                parentform.project.AddLayer(Layer.LayerType.NationMap, NameOfNewLayer.Text);
            }
            if (LayerToAdd.Text.Equals("Terrain"))
            {
                parentform.project.AddLayer(Layer.LayerType.HeightMap, NameOfNewLayer.Text);
            }

            Close();
        }

        /// <summary>
        /// Closes window
        /// </summary>
        private void CancelCreateLayerButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Constructor, takes parent Form1 as input.
        /// </summary>
        public AddLayerMenu(Form1 _parent)
        {
            InitializeComponent();

            parentform = _parent;
        }
    }
}
