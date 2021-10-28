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
    public partial class Form1 : Form
    {
        private BrushType tool;
        private bool painting;

        private int height_brush_size;
        private int height_brush_strength;
        private int height_brush_height;

        // Display to user
        private Graphics display_graphics;
        private Bitmap display_data;

        public Form1()
        {
            InitializeComponent();

            painting = false;

            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            // Height Data Initialization
            height_data = new Bitmap(Canvas.Width, Canvas.Height);
            height_data_graphics = Graphics.FromImage(height_data);
            height_data_graphics.FillRectangle(brush, 0, 0, Canvas.Width, Canvas.Height);

            // Height Display Initialization
            display_data = new Bitmap(Canvas.Width, Canvas.Height);
            display_graphics = Canvas.CreateGraphics();
            display_graphics.FillRectangle(brush, 0, 0, Canvas.Width, Canvas.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height_data.Save("Output.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private enum BrushType
        {
            elevationbrush
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Mouse Control
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            painting = true;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            painting = false;
            xprime = null;
            yprime = null;
        }

        private int? xprime = null;
        private int? yprime = null;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            ElevationBrushTool(sender, e);
        }

        enum ToolUsed
        {
            ElevationBrush,
            ElevationSmoothenBrush
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Elevation Data and Graphics
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private Graphics height_data_graphics;
        private Bitmap height_data;

        private int drawcounter = 0;
        private void ElevationBrushTool(object sender, MouseEventArgs e)
        {
            if (painting)
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(StrengthControl.Value, HeightControl.Value, HeightControl.Value, HeightControl.Value));
                // Pen pen = new Pen(Color.FromArgb(StrengthControl.Value, 32, 32, 32), SizeControl.Value);
                // graphics.DrawLine(pen, new Point(xprime ?? e.X, yprime ?? e.Y), new Point(e.X, e.Y));
                height_data_graphics.FillEllipse(brush, e.X - SizeControl.Value / 2, e.Y - SizeControl.Value / 2, SizeControl.Value, SizeControl.Value);

                xprime = e.X;
                yprime = e.Y;

                drawcounter++;
                if (drawcounter == 2)
                {
                    drawcounter = 0;
                    FastRender(e.X - SizeControl.Value / 2, e.Y - SizeControl.Value / 2, SizeControl.Value, SizeControl.Value);
                }
            }
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Rendering
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void FastRender(int x_start, int y_start, int width, int height)
        {
            Console.WriteLine("Hello?");
            /*for (int i = x_start; i < width; i++)
            {
                for (int j = y_start; j < height; j++)
                {*/
            for (int i = 0; i < Canvas.Width; i++)
            {
                for (int j = 0; j < Canvas.Height; j++)
                {
                    int shade = 25;
                    //int shade = height_data.GetPixel(i, j).R - height_data.GetPixel(i-1, j-1).R;
                    shade = (shade + 255) / 2;

                    display_data.SetPixel(i, j, Color.FromArgb(255, shade, shade, shade));
                }
            }

            display_data.SetPixel(1, 1, Color.Black);
            display_graphics.DrawImage(display_data, 0, 0);
        }
    }
}
