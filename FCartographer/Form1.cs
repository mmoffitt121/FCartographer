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
    /// Used to interface with windows forms, holds program data.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Current project 
        /// </summary>
        private Project project;

        /// <summary>
        /// Graphics to interface with project
        /// </summary>
        private Graphics g;

        /// <summary>
        /// Boolean to store if use has mouse down on canvas
        /// </summary>
        private bool painting;

        /// <summary>
        /// Holds current selected brush
        /// </summary>
        BrushPreset terrain_brushpreset;

        /// <summary>
        /// Array of possible brushes for the user to use
        /// </summary>
        private IList<BrushPreset> brushes;

        /// <summary>
        /// Value of how zoomed in the canvas is
        /// </summary>
        private float zoom;


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Mouse Control
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Integers depicting the previous mouse location one frame before
        /// </summary>
        private int? xprime = null;
        private int? yprime = null;

        /// <summary>
        /// Integers depicting the previous mouse location at the beginning of the brush stroke
        /// </summary>
        private int? xbegin = null;
        private int? ybegin = null;

        /// <summary>
        /// Fires when the mouse clicks on the canvas
        /// </summary>
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (project.CurrentLayer() != null)
            {
                painting = true;
            }
            else
            {
                painting = false;
            }
            xbegin = e.X;
            ybegin = e.Y;
        }

        /// <summary>
        /// Fires when the mouse releases
        /// </summary>
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
            xprime = null;
            yprime = null;
            if (project.CurrentLayer() != null)
            {
                project.CurrentLayer().Render();
                RenderGraphics(project.GetGraphics());
            }

        }

        /// <summary>
        /// Fires when the mouse moves
        /// </summary>
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

        /// <summary>
        /// Brush tool
        /// Draws on the canvas based on user mouse args variable e
        /// </summary>
        private void BrushTool(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                project.Draw(terrain_brushpreset, e);
                project.DrawTemp(terrain_brushpreset, e, g);
                xprime = e.X;
                yprime = e.Y;

                // RenderGraphics(project.GetGraphics());
            }
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Rendering
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Draws rendered graphics to the canvas
        /// Input: Bitmap display -> Already rendered graphics to display to user
        /// </summary>
        private void RenderGraphics(Bitmap display)
        {
            g.DrawImage(display, 0, 0);
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Initializes Form1
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            NewProject(500, 500);
        }

        /// <summary>
        /// Creates a new project
        /// Input:  int width -> Project width
        ///         int height -> Project height
        /// </summary>
        public void NewProject(int width, int height)
        {
            // Settings Initialization
            ProjectSettings settings = new ProjectSettings();

            // Control Initialization
            painting = false;

            // Canvas Initialization
            Canvas.Width = width;
            Canvas.Height = height;
            SetScrollMargin(100);
            SetScrollIncrement(50);
            SetScrollbarDimensions();
            CenterCanvas();

            // Project Initialization
            project = new Project(width, height);
            project.AddLayer(Layer.LayerType.NationMap);

            // Brush Initialization
            terrain_brushpreset = new BrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, Color.FromArgb(255, 20, 20, 20), true);

            // Canvas Interface Initialization
            g = Canvas.CreateGraphics();

            // Layer Control Initialization
            DisplayLayers();

            ReadySettingsPanels(project.CurrentLayer());
        }
    }
}
