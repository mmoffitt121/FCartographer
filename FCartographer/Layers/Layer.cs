using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FCartographer
{
    public class Layer
    {
        private String name;

        private int width;
        private int height;

        private Bitmap data;

        private LayerType type;

        public Graphics g;

        public void Render()
        {

        }

        public Bitmap GetData()
        {
            return data;
        }

        public void SetType(LayerType input)
        {
            type = input;
        }

        public LayerType GetType()
        {
            return type;
        }

        public virtual void Draw(BrushPreset brush, MouseEventArgs e)
        {

        }

        public virtual void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr)
        {

        }

        public Layer(int x, int y)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
            g = Graphics.FromImage(data);
        }

        public enum LayerType
        {
            HeightMap,
            Ocean,
            Subdivision
        }
    }
}