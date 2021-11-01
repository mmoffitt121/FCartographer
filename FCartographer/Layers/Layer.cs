using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    public class Layer
    {
        private String name;

        private int width;
        private int height;

        private Bitmap data;

        private LayerType type;

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