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
        private Point canvas_location;

        private int scrollmargin;

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Setting Canvas Location
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void UpdateCanvasLocation()
        {
            Canvas.Location = canvas_location;
        }

        private void SetCanvasLocation(int x, int y)
        {
            canvas_location.X = x;
            canvas_location.Y = y;
            UpdateCanvasLocation();
        }

        private void SetCanvasXLocation(int x)
        {
            canvas_location.X = x;
            UpdateCanvasLocation();
        }

        private void SetCanvasYLocation(int y)
        {
            canvas_location.Y = y;
            UpdateCanvasLocation();
        }

        private void CenterCanvas()
        {
            VerticalScroll.Value = 0;
            HorizontalScroll.Value = 0;
            SetCanvasYLocation((int)((float)CanvasHolder.Height / 2 - (float)(Canvas.Height / 2)) - VerticalScroll.Value);
            SetCanvasXLocation((int)((float)CanvasHolder.Width / 2 - (float)(Canvas.Width / 2)) - HorizontalScroll.Value);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Vertical Scroll
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void ScrollVertically(object sender, ScrollEventArgs e)
        {
            SetCanvasYLocation((int)((float)CanvasHolder.Height / 2 - (float)(Canvas.Height / 2)) - VerticalScroll.Value);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Horizontal Scroll
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void ScrollHorizontally(object sender, ScrollEventArgs e)
        {
            SetCanvasXLocation((int)((float)CanvasHolder.Width / 2 - (float)(Canvas.Width / 2)) - HorizontalScroll.Value);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Setting Scrollbar Dimensions
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        private void SetScrollbarDimensions()
        {
            HorizontalScroll.Minimum = (int)(-1 * Canvas.Width / 2) - scrollmargin;
            HorizontalScroll.Maximum = (int)(Canvas.Width / 2) + HorizontalScroll.LargeChange + scrollmargin;

            VerticalScroll.Minimum = (int)(-1 * Canvas.Height / 2) - scrollmargin;
            VerticalScroll.Maximum = (int)(Canvas.Height / 2) + VerticalScroll.LargeChange + scrollmargin;
        }

        private void SetScrollIncrement(int _increment)
        {
            HorizontalScroll.SmallChange = _increment;
            VerticalScroll.SmallChange = _increment;
            HorizontalScroll.LargeChange = _increment * 10;
            VerticalScroll.LargeChange = _increment * 10;
        }

        private void SetScrollMargin(int _scrollmargin)
        {
            scrollmargin = _scrollmargin;
        }

        private void HorizontalScroll_ValueChanged(object sender, EventArgs e)
        {
            RenderGraphics(project.GetGraphics());
        }

        private void VerticalScroll_ValueChanged(object sender, EventArgs e)
        {
            RenderGraphics(project.GetGraphics());
        }
    }
}
