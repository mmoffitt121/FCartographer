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
        private bool painting;

        // Height Data
        private Graphics height_data_graphics;
        private Bitmap height_data;

        // Display to user
        private Graphics display_graphics;
        private Bitmap display_data;

        public Form1()
        {
            InitializeComponent();

            painting = false;

            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

            // Height Editing Initialization
            height_data = new Bitmap(Canvas.Width, Canvas.Height);
            height_data_graphics = Graphics.FromImage(height_data);
            height_data_graphics.FillRectangle(brush, 0, 0, Canvas.Width, Canvas.Height);

            // Height Editing Initialization
            display_data = new Bitmap(Canvas.Width, Canvas.Height);
            display_graphics = Canvas.CreateGraphics();
            display_graphics.FillRectangle(brush, 0, 0, Canvas.Width, Canvas.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            height_data.Save("Output.png", System.Drawing.Imaging.ImageFormat.Png);
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

                FastRender();
            }
        }

        private void FastRender()
        {


            // Canvas.DrawToBitmap(bmp, new Rectangle(0, 0, Canvas.Width, Canvas.Height));
            /*for (int i = 1; i < Canvas.Width-1; i++)
            {
                for (int j = 1; j < Canvas.Height-1; j++)
                {
                    int shade = bmp.GetPixel(i, j).R;// - bmp.GetPixel(i, j).R;
                    shade = (shade + 255) / 2;
                    new_bmp.SetPixel(i, j, Color.FromArgb(255, shade, shade, shade));
                }
            }*/

            display_graphics.DrawImage(height_data, 0, 0);
        }
    }
}
