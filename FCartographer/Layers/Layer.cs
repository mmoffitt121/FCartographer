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
        private Bitmap tempdata;

        private LayerType type;

        public Graphics data_g;
        public Graphics g;

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
            tempdata = new Bitmap(x, y);
            data_g = Graphics.FromImage(data);
            g = Graphics.FromImage(tempdata);
        }

        public enum LayerType
        {
            HeightMap,
            Ocean,
            NationMap,
            Subdivision
        }
    }
}