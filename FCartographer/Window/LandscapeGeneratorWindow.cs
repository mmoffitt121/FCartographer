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
    /// <summary>
    /// Window that handles the user's interface with the landscape generator.
    /// </summary>
    public partial class LandscapeGeneratorWindow : Form
    {
        Form1 parentform;

        /// <summary>
        /// Generates a random seed for the landscape generator, called the first time the window is opened.
        /// </summary>
        public string GenerateRandomSeed()
        {
            Random rand = new Random();
            string seed = "";

            for (int i = 0; i < 25; i++)
            {
                seed += rand.Next(10);
            }

            return seed;
        }

        /// <summary>
        /// Activates the generator.
        /// </summary>
        private void GenerateButton_Click(object sender, EventArgs e)
        {
            // Initialize layers

            parentform.project.AddLayer(Layer.LayerType.HeightMap);
            parentform.project.CurrentLayer().SetName(layerNameField.Text);

            // Get data for generation

            string seed = seedBox.Text;

            int min, max;
            try
            {
                min = Math.Clamp(Int32.Parse(MinHeightField.Text), 0, 255);
                max = Math.Clamp(Int32.Parse(MaxHeightField.Text), min, 255);
            }
            catch
            {
                min = 0;
                max = 255;
            }

            // End

            Close();
        }

        /// <summary>
        /// Gives user a random seed when button pressed.
        /// </summary>
        private void randomSeedButton_Click(object sender, EventArgs e)
        {
            seedBox.Text = GenerateRandomSeed();
        }

        /// <summary>
        /// Constructor, takes parent form as argument for interaction.
        /// </summary>
        public LandscapeGeneratorWindow(Form1 _parent)
        {
            InitializeComponent();
            parentform = _parent;

            seedBox.Text = GenerateRandomSeed();
        }
    }
}
