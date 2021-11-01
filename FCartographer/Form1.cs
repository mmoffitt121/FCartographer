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
        // Current project
        private Project project;

        // Graphics to interface with project
        private Graphics g;

        // If user has mouse down on canvas
        private bool painting;

        // Current brush
        BrushPreset brushpreset;

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Save Panel
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // Save button
        private void button1_Click(object sender, EventArgs e)
        {
            project.CurrentLayer().GetData().Save("Output.png", System.Drawing.Imaging.ImageFormat.Png);
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Mouse Control
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // Previous mouse location storage
        private int? xprime = null;
        private int? yprime = null;

        // Mouse click on canvas
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
        }

        // Mouse up
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
            xprime = null;
            yprime = null;
        }

        // Mouse moves
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                BrushTool(sender, e);
            }
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Tools
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // -=-= Brush Tool =-=-
        // Parameters: 
        private void BrushTool(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                project.Draw(brushpreset, e);
                xprime = e.X;
                yprime = e.Y;

                RenderGraphics(project.GetGraphics());
            }
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Rendering
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void RenderGraphics(Bitmap display)
        {
            g.DrawImage(display, 0, 0);
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // Form1 Constructor
        // Initializes program
        public Form1()
        {
            InitializeComponent();

            // Settings init
            ProjectSettings settings = new ProjectSettings();

            // Control init
            painting = false;

            // Project init
            project = new Project(Canvas.Width, Canvas.Height);
            project.AddLayer(0);

            // Brush init
            // brushpreset = new BrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50);
            brushpreset = new BrushPreset(@"Tools/Brushes/..png", 20, 50);

            // Canvas interface init
            g = Canvas.CreateGraphics();
        }
    }
}
