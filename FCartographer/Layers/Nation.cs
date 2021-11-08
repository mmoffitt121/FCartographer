using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    public class Nation
    {
        private Color color;
        private string name;

        public void SetColor(Color _color)
        {
            color = _color;
        }

        public Color GetColor()
        {
            return color;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        public string GetName()
        {
            return name;
        }
    }
}