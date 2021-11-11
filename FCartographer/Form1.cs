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
    /// <summary>
    /// [Form1]
    /// This is Form1
    /// </summary>
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

        // Brush Array
        private IList<BrushPreset> brushes;

        // Zoom Control
        private float zoom;


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Mouse Control
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // Previous mouse location storage
        private int? xprime = null;
        private int? yprime = null;

        private int? xbegin = null;
        private int? ybegin = null;

        // Mouse click on canvas
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
            xbegin = e.X;
            ybegin = e.Y;
        }

        // Mouse up
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
            xprime = null;
            yprime = null;
            project.CurrentLayer().Render();
            RenderGraphics(project.GetGraphics());
        }

        // Mouse moves
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
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
                project.DrawTemp(brushpreset, e, g);
                xprime = e.X;
                yprime = e.Y;

                // RenderGraphics(project.GetGraphics());
            }
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Zoom
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // Zoom In
        private void ZoomIn_Click(object sender, EventArgs e)
        {

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
            NewProject(500, 500);
        }

        public void NewProject(int width, int height)
        {
            // Settings init
            ProjectSettings settings = new ProjectSettings();

            // Control init
            painting = false;

            // Canvas init
            Canvas.Width = width;
            Canvas.Height = height;
            SetScrollMargin(100);
            SetScrollIncrement(50);
            SetScrollbarDimensions();
            CenterCanvas();

            // Project init
            project = new Project(width, height);
            project.AddLayer(Layer.LayerType.NationMap);

            // Brush init
            brushpreset = new BrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, Color.FromArgb(255, 20, 20, 20), true);

            // Canvas interface init
            g = Canvas.CreateGraphics();

            // Layer control init
            DisplayLayers();
        }

        private void ZoomIn_Click(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Click!");
        }
    }
}
