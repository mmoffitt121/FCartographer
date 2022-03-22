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
    /// This part of Form1 is used for navigating the canvas; zoom, scroll, etc.
    /// </summary>
    public partial class Form1 : Form
    {
        private Point canvas_location;

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Setting Canvas Location
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Applies this class' internal canvas location to the canvas
        /// </summary>
        private void UpdateCanvasLocation()
        {
            Canvas.Location = canvas_location;
        }

        /// <summary>
        /// Sets this class' internal canvas value.
        /// input:  int x -> x value of desired canvas location
        ///         int y -> y value of desired canvas location
        /// </summary>
        private void SetCanvasLocation(int x, int y)
        {
            canvas_location.X = x;
            canvas_location.Y = y;
            UpdateCanvasLocation();
        }

        /// <summary>
        /// Sets the x value of this class' internal canvas value.
        /// input:  int x -> x value of desired canvas location
        /// </summary>
        private void SetCanvasXLocation(int x)
        {
            canvas_location.X = x;
            UpdateCanvasLocation();
        }

        /// <summary>
        /// Sets the y value of this class' internal canvas value.
        /// input:  int y -> y value of desired canvas location
        /// </summary>
        private void SetCanvasYLocation(int y)
        {
            canvas_location.Y = y;
            UpdateCanvasLocation();
        }

        /// <summary>
        /// Centers the canvas.
        /// </summary>
        private void CenterCanvas()
        {
            SetCanvasYLocation(500);
            SetCanvasXLocation(500);
        }

        /// <summary>
        /// Places canvas when resizing window
        /// </summary>
        private void Form1_Resize(object sender, EventArgs e)
        {
            //SetCanvasYLocation(500);
            //SetCanvasXLocation(500);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Zoom
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Zooms in on canvas when button is clicked
        /// </summary>
        private void ZoomIn_Click(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Click!");
        }

        private void CanvasHolder_Scroll(object sender, ScrollEventArgs e)
        {

        }


        /*// -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Vertical Scroll
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Changes canvas y based on scrollbar
        /// </summary>
        private void ScrollVertically(object sender, ScrollEventArgs e)
        {
            SetCanvasYLocation((int)((float)CanvasHolder.Height / 2 - (float)(Canvas.Height / 2)) - VerticalScroll.Value);
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Horizontal Scroll
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Changes canvas x based on scrollbar
        /// </summary>
        private void ScrollHorizontally(object sender, ScrollEventArgs e)
        {
            SetCanvasXLocation((int)((float)CanvasHolder.Width / 2 - (float)(Canvas.Width / 2)) - HorizontalScroll.Value);
        }


        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Setting Scrollbar Dimensions
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Sets the dimension of the scroll bar based on the Canvas width, height, and the LargeChange variable in each.
        /// </summary>
        private void SetScrollbarDimensions()
        {
            HorizontalScroll.Minimum = (int)(-1 * Canvas.Width / 2) - scrollmargin;
            HorizontalScroll.Maximum = (int)(Canvas.Width / 2) + HorizontalScroll.LargeChange + scrollmargin;

            VerticalScroll.Minimum = (int)(-1 * Canvas.Height / 2) - scrollmargin;
            VerticalScroll.Maximum = (int)(Canvas.Height / 2) + VerticalScroll.LargeChange + scrollmargin;
        }

        /// <summary>
        /// Sets the LargeChange and SmallChange values of each scrollbar
        /// </summary>
        private void SetScrollIncrement(int _increment)
        {
            HorizontalScroll.SmallChange = _increment;
            VerticalScroll.SmallChange = _increment;
            HorizontalScroll.LargeChange = _increment * 10;
            VerticalScroll.LargeChange = _increment * 10;
        }

        /// <summary>
        /// Sets how far beyond the canvas the user can scroll
        /// </summary>
        private void SetScrollMargin(int _scrollmargin)
        {
            scrollmargin = _scrollmargin;
        }

        /// <summary>
        /// Re-compiles the graphcis when scrolling horizontally.
        /// </summary>
        private void HorizontalScroll_ValueChanged(object sender, EventArgs e)
        {
            RenderGraphics(project.GetGraphics());
        }

        /// <summary>
        /// Re-compiles the graphcis when scrolling vertically.
        /// </summary>
        private void VerticalScroll_ValueChanged(object sender, EventArgs e)
        {
            RenderGraphics(project.GetGraphics());
        }*/
    }
}
