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

        /// <summary>
        /// Constructor
        /// </summary>
        public NewProjectWindow()
        {
            InitializeComponent();
        }
    }
}
