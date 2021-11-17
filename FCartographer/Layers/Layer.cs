using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FCartographer
{
    public class Layer : IDisposable
    {
        private String name;
        private bool visible;

        private int width;
        private int height;

        private Bitmap data;
        private Bitmap tempdata;

        private LayerType type;

        public Graphics data_g;
        public Graphics g;

        private bool disposedValue;

        public virtual void Render()
        {

        }

        public Bitmap GetData()
        {
            return data;
        }

        public Bitmap GetTempData()
        {
            return tempdata;
        }

        public void SetType(LayerType input)
        {
            type = input;
        }

        public LayerType GetType()
        {
            return type;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        public string Name()
        {
            return name;
        }

        public virtual void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {

        }

        public virtual void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {

        }

        public virtual void SetColor(Color _color)
        {

        }

        public virtual void SetSize(int _size)
        {

        }

        public virtual void UpdateBrushOptions(BrushPreset brushPreset)
        {

        }

        public virtual void Fill(MouseEventArgs e, BrushPreset brush)
        {

        }

        public Layer(int x, int y)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            tempdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
        }

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

        public enum LayerType
        {
            HeightMap,
            Ocean,
            NationMap,
            Subdivision
        }

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

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}