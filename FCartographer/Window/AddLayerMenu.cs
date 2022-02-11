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
            
            if (LayerToAdd.SelectedIndex.Equals(1))
            {
                parentform.project.AddLayer(Layer.LayerType.NationMap, NameOfNewLayer.Text);
            }
            if (LayerToAdd.SelectedIndex.Equals(0))
            {
                parentform.project.AddLayer(Layer.LayerType.HeightMap, NameOfNewLayer.Text);
            }
            if (LayerToAdd.SelectedIndex.Equals(2))
            {
                parentform.project.AddLayer(Layer.LayerType.Ocean, NameOfNewLayer.Text);
            }

            parentform.RenderGraphics(parentform.project.GetGraphics());

            Close();
        }

        /// <summary>
        /// Closes window
        /// </summary>
        private void CancelCreateLayerButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LayerToAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void AddLayerMenu_Shown(object sender, EventArgs e)
        {
            UpdateDescription();
        }

        private void UpdateDescription()
        {
            if (LayerToAdd.SelectedIndex.Equals(1))
            {
                NameOfNewLayer.Text = "New Nation Layer";
                DescriptionBox.Text = "A nation layer is a layer where the user can draw and render colored, outlined, and/or textured regions of space on the canvas.";
            }
            if (LayerToAdd.SelectedIndex.Equals(0))
            {
                NameOfNewLayer.Text = "New Terrain Layer";
                DescriptionBox.Text = "A terrain layer is a layer that represents a given height on an image.";
            }
            if (LayerToAdd.SelectedIndex.Equals(2))
            {
                NameOfNewLayer.Text = "New Water Layer";
                DescriptionBox.Text = "A water layer creates and renders a sea of water at a specified height based on a Terrain Layer. To reference a Terrain Layer, a Water Layer must be above it in the layer heiarchy.";
            }
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
