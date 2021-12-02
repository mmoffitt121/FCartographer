using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Abstract class that holds the base data for all layertypes.
    /// </summary>
    public abstract class Layer : IDisposable
    {
        private String name;
        //private bool visible;

        private int width;
        private int height;

        private Bitmap data;
        private Bitmap tempdata;

        private LayerType type;

        /// <summary>
        /// Graphics Object for interfacing with layer data.
        /// </summary>
        public Graphics data_g;

        /// <summary>
        /// Graphics Object for interfacing with temporary layer data.
        /// </summary>
        public Graphics g;

        private bool disposedValue;

        /// <summary>
        /// Returns the width of the layer.
        /// </summary>
        public int GetWidth()
        {
            return width;
        }

        /// <summary>
        /// Returns the Height.
        /// </summary>
        public int GetHeight()
        {
            return height;
        }

        /// <summary>
        /// Overridden in subclasses, called to composite changes and render output.
        /// </summary>
        public virtual void Render()
        {

        }

        /// <summary>
        /// Returns the base data of the bitmap.
        /// </summary>
        public Bitmap GetData()
        {
            return data;
        }

        /// <summary>
        /// Returns the tempdata, where changes are temporarily stored before being applied to the base data.
        /// </summary>
        public Bitmap GetTempData()
        {
            return tempdata;
        }

        /// <summary>
        /// Sets the type of the layer.
        /// </summary>
        public void SetType(LayerType input)
        {
            type = input;
        }

        /// <summary>
        /// Returns the type of the layer
        /// </summary>
        public new LayerType GetType()
        {
            return type;
        }

        /// <summary>
        /// Sets the name of the layer
        /// </summary>
        public void SetName(string _name)
        {
            name = _name;
        }

        /// <summary>
        /// Returns the name of the layer
        /// </summary>
        public string Name()
        {
            return name;
        }

        /// <summary>
        /// Overridden in subclasses, called to draw to data using input brush.
        /// </summary>
        public virtual void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {

        }

        /// <summary>
        /// Overridden in subclasses, called to draw to temp data using input brush.
        /// </summary>
        public virtual void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {

        }

        /// <summary>
        /// Overridden in subclasses, sets the color of the layer.
        /// </summary>
        public virtual void SetColor(Color _color)
        {

        }

        /// <summary>
        /// Overridden in subclasses, sets the size of internal layer brush and pen.
        /// </summary>
        public virtual void SetSize(int _size)
        {

        }

        /// <summary>
        /// Overridden in subclasses, changes internal layer values based on selected input brush.
        /// </summary>
        public virtual void UpdateBrushOptions(BrushPreset brushPreset)
        {

        }

        /// <summary>
        /// Overridden in subclasses, called to fill a region in data.
        /// </summary>
        public virtual void Fill(MouseEventArgs e, BrushPreset brush)
        {

        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y.
        /// </summary>
        public Layer(int x, int y)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            tempdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name.
        /// </summary>
        public Layer(int x, int y, string _name)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            tempdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
            SetName(_name);
        }

        /// <summary>
        /// Type enum, expresses the type of the layer.
        /// </summary>
        public enum LayerType
        {
            /// <summary>
            /// HeightMap layer, also known as Terrain Layer.
            /// </summary>
            HeightMap,

            /// <summary>
            /// Ocean layer, displays an ocean at a specified height.
            /// </summary>
            Ocean,

            /// <summary>
            /// NationMap, holds nation data.
            /// </summary>
            NationMap,

            /// <summary>
            /// Subdivision, for other subdivisions aside from NationMap.
            /// </summary>
            Subdivision
        }

        /// <summary>
        /// Inherits IDisposable, needs to be overridden in all subclasses.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    data.Dispose();
                    tempdata.Dispose();

                    g.Dispose();
                    data_g.Dispose();
                }
                disposedValue = true;
            }
        }

        /// <summary>
        /// Function to call for disposal.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}