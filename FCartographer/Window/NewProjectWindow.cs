using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCartographer.FileHandling;

namespace FCartographer.Window
{
    /// <summary>
    /// Window that handles creating new projects
    /// </summary>
    public partial class NewProjectWindow : Form
    {
        /// <summary>
        /// Name of project to create
        /// </summary>
        public string projectname;

        /// <summary>
        /// Path of heightmap to import
        /// </summary>
        public string heightmappath;
        /// <summary>
        /// Heightmap to import
        /// </summary>
        public Bitmap heightmap;

        /// <summary>
        /// width of new project
        /// </summary>
        public int width;
        /// <summary>
        /// Height of new project
        /// </summary>
        public int height;

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            string path = FileHandler.GetFilePath();
            if (path.Equals(""))
            {
                return;
            }

            heightmappath = path;
            UpdateHeightmap();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            try
            {
                width = Int32.Parse(widthBox.Text);
                
            }
            catch
            {
                WarningBox warnbox = new WarningBox("Invalid width.");
                warnbox.ShowDialog();

                return;
            }

            try
            {
                height = Int32.Parse(heightBox.Text);
                
            }
            catch
            {
                WarningBox warnbox = new WarningBox("Invalid height.");
                warnbox.ShowDialog();

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateHeightmap()
        {
            if (heightmappath.Equals(""))
            {
                heightmapPathBox.Text = "No heightmap selected.";
                heightmap = null;
            }
            else
            {
                heightmapPathBox.Text = heightmappath;
                try
                {
                    Bitmap bitmap = (Bitmap)Image.FromFile(heightmappath);
                    width = bitmap.Width;
                    height = bitmap.Height;
                    widthBox.Text = width + "";
                    heightBox.Text = height + "";
                    heightmap = bitmap;
                }
                catch
                {
                    heightmappath = "";
                    WarningBox warningBox = new WarningBox("The heightmap is invalid.");
                    warningBox.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public NewProjectWindow()
        {
            InitializeComponent();
            heightmappath = "";
            UpdateHeightmap();

            widthBox.Text = "1920";
            heightBox.Text = "1080";
        }

        private void loseFileButton_Click(object sender, EventArgs e)
        {
            heightmappath = "";
            heightmap = null;
            UpdateHeightmap();
        }
    }
}
