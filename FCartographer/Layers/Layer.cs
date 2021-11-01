using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    public class Layer
    {
        public String name;

        private int width;
        private int height;

        private Bitmap data;

        public void Draw()
        {

        }

        public Bitmap GetData()
        {
            return data;
        }

        public Layer(int x, int y)
        {
            width = x;
            height = y;
            data = new Bitmap(x, y);
        }
    }

    public enum LayerType
    {
        HeightMap,
        Ocean,
        Subdivision
    }
}