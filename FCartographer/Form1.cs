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
    /// The main user interface of the program.
    /// 
    /// Holds the canvas, navigation menues, tool menues, and all non-dialogue ui elements used to interface with user projects.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Current project 
        /// </summary>
        public Project project;

        /// <summary>
        /// Graphics to interface with project
        /// </summary>
        private Graphics g;

        /// <summary>
        /// Boolean to store if use has mouse down on canvas
        /// </summary>
        private bool painting;

        /// <summary>
        /// Holds current selected terrain brush
        /// </summary>
        private TerrainBrushPreset terrain_brushpreset;

        /// <summary>
        /// Holds current selected terrain brush
        /// </summary>
        private NationsBrushPreset nations_brushpreset;

        private Bitmap displaybuffer;

        private bool liverendering = false;

        /*
        /// <summary>
        /// Array of possible brushes for the user to use
        /// </summary>
        private IList<BrushPreset> brushes;

        /// <summary>
        /// Value of how zoomed in the canvas is
        /// </summary>
        private float zoom;
        */


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
            if (project.CurrentLayer() != null && GetCurrentTool() == ToolSelected.brush)
            {
                painting = true;
            }
            else
            {
                painting = false;
            }

            if (project.CurrentLayer() != null && GetCurrentTool() == ToolSelected.fill)
            {
                switch (project.CurrentLayer().GetType())
                {
                    case Layer.LayerType.HeightMap:
                        project.Fill(e, terrain_brushpreset);
                        break;
                    case Layer.LayerType.NationMap:
                        project.Fill(e, nations_brushpreset);
                        break;
                    case Layer.LayerType.Biome:
                        project.Fill(e, nations_brushpreset);
                        break;
                }
                
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

                project.CurrentLayer().rx0 = -1;
                project.CurrentLayer().rx1 = -1;
                project.CurrentLayer().ry0 = -1;
                project.CurrentLayer().ry1 = -1;
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
                switch (project.CurrentLayer().GetType())
                {
                    case Layer.LayerType.Texture:
                    case Layer.LayerType.HeightMap:
                        project.Draw(terrain_brushpreset, e, xprime, yprime);
                        project.DrawTemp(terrain_brushpreset, e, g, xprime, yprime);
                        break;
                    case Layer.LayerType.NationMap:
                    case Layer.LayerType.Biome:
                        project.Draw(nations_brushpreset, e, xprime, yprime);
                        project.DrawTemp(nations_brushpreset, e, g, xprime, yprime);
                        break;
                }
                xprime = e.X;
                yprime = e.Y;

                // RenderGraphics(project.GetGraphics());
            }
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Rendering
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(displaybuffer, 0, 0);
        }

        /// <summary>
        /// Draws rendered graphics to the canvas
        /// Input: Bitmap display -> Already rendered graphics to display to user
        /// </summary>
        /// <param name="display"></param>
        public void RenderGraphics(Bitmap display)
        {
            g.DrawImage(display, 0, 0);
            Canvas.Invalidate();
        }

        /// <summary>
        /// Renders a caller-defined region of the canvas
        /// </summary>
        /// <param name="display"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RenderRegion(Bitmap display, int x, int y)
        {
            g.DrawImage(display, x, y);
            Canvas.Invalidate(new Rectangle(x, y, display.Width, display.Height));
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

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
            /*SetScrollMargin(100);
            SetScrollIncrement(50);
            SetScrollbarDimensions();*/
            CenterCanvas();

            displaybuffer = new Bitmap(width, height);

            // Project Initialization
            project = new Project(width, height);
            project.AddLayer(Layer.LayerType.NationMap);

            // Brush Initialization
            NationLayer lyr = (NationLayer)(project.CurrentLayer());
            terrain_brushpreset = new TerrainBrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, Color.FromArgb(255, 20, 20, 20), false);
            nations_brushpreset = new NationsBrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, lyr.GetNation(0).GetDataColor(), true);

            project.AddLayer(Layer.LayerType.HeightMap);

            // Tool Initialization
            BrushSelect_Click(new object(), new EventArgs());

            // Canvas Interface Initialization
            g = Graphics.FromImage(displaybuffer);

            // Layer Control Initialization
            DisplayLayers();
            InitializeLayerAdder();

            ReadySettingsPanels(project.CurrentLayer());
        }

        /// <summary>
        /// Initializes the settings when opening/creating a project
        /// </summary>
        public void InitializeProjectSettings()
        {
            // Settings Initialization
            ProjectSettings settings = new ProjectSettings();

            // Control Initialization
            painting = false;

            // Canvas Initialization
            Canvas.Width = project.width;
            Canvas.Height = project.height;
            /*SetScrollMargin(100);
            SetScrollIncrement(50);
            SetScrollbarDimensions();*/
            CenterCanvas();

            displaybuffer = new Bitmap(Canvas.Width, Canvas.Height);

            // Brush Initialization
            // NationLayer lyr = (NationLayer)(project.CurrentLayer());
            // terrain_brushpreset = new TerrainBrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, Color.FromArgb(255, 20, 20, 20), false);
            // nations_brushpreset = new NationsBrushPreset(@"Tools/Brushes/RadialBrush0.png", 20, 50, lyr.GetNation(0).GetDataColor(), true);

            // Tool Initialization
            BrushSelect_Click(new object(), new EventArgs());

            // Canvas Interface Initialization
            g = Graphics.FromImage(displaybuffer);

            // Layer Control Initialization
            DisplayLayers();
            InitializeLayerAdder();

            ReadySettingsPanels(project.CurrentLayer());
        }

        /// <summary>
        /// Initializes Form1
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            NewProject(1200, 700);
        }
    }
}
