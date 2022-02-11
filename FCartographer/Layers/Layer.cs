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
    public abstract class Layer/* : IDisposable*/
    {
        private String name;
        //private bool visible;

        private int width;
        private int height;

        private Bitmap data;
        private Bitmap tempdata;
        private Bitmap outdata;

        private LayerType type;

        /// <summary>
        /// The name of the type of layer
        /// </summary>
        public readonly string typename;

        /// <summary>
        /// Describes the type of layer
        /// </summary>
        public readonly string typedescription;

        /// <summary>
        /// Graphics Object for interfacing with layer data.
        /// </summary>
        public Graphics data_g;

        /// <summary>
        /// Graphics Object for interfacing with temporary layer data.
        /// </summary>
        public Graphics g;

        /// <summary>
        /// Graphics object for interfacing with 
        /// </summary>
        public Graphics render_g;

        private bool visible;
        private bool torender;

        /// <summary>
        /// Holds all layer connections.
        /// 
        /// Can be empty
        /// </summary>
        public Layer[] connections;

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
        /// Returns whether the layer will be rendered or not
        /// </summary>
        /// <returns></returns>
        public bool ToRender()
        {
            return torender;
        }

        /// <summary>
        /// Sets whether the layer will be rendered or not
        /// </summary>
        /// <param name="_torender"></param>
        public void SetToRender(bool _torender)
        {
            torender = _torender;
        }

        /// <summary>
        /// Toggles whether layer is rendered
        /// </summary>
        public void ToggleRender()
        {
            torender = !torender;
            if (torender)
            {
                Render();
            }
        }

        /// <summary>
        /// Returns whether the layer will be visible or not
        /// </summary>
        /// <returns></returns>
        public bool Visible()
        {
            return visible;
        }

        /// <summary>
        /// Sets whether the layer will be rendered or not
        /// </summary>
        /// <param name="_visible"></param>
        public void SetVisible(bool _visible)
        {
            visible = _visible;
        }

        /// <summary>
        /// Toggles whether the layer is visible
        /// </summary>
        public void ToggleVisible()
        {
            visible = !visible;
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
        /// Returns reference to the post-rendering data
        /// </summary>
        /// <returns></returns>
        public Bitmap GetOutData()
        {
            return outdata;
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
        /// Forms the necessary connections with other layers.
        /// </summary>
        public virtual void FormConnections(Layer[] layers)
        {

        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y.
        /// </summary>
        public Layer(int x, int y, string _typename, string _typedesc)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            tempdata = new Bitmap(x, y);
            outdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
            render_g = Graphics.FromImage(outdata);

            SetVisible(true);
            SetToRender(false);

            typename = _typename;
            typedescription = _typedesc;

        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name.
        /// </summary>
        public Layer(int x, int y, string _name, string _typename, string _typedesc)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            tempdata = new Bitmap(x, y);
            outdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
            render_g = Graphics.FromImage(outdata);
            SetName(_name);

            SetVisible(true);
            SetToRender(false);

            typename = _typename;
            typedescription = _typedesc;
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
            Subdivision,

            /// <summary>
            /// Reference, for imported images/annotations/sketches
            /// </summary>
            Reference
        }
    }
}