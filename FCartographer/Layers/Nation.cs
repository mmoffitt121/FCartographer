using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Class that holds the data for a particular nation.
    /// </summary>
    public class Nation
    {
        private Color color;
        private string name;

        /// <summary>
        /// Color mutator
        /// </summary>
        public void SetColor(Color _color)
        {
            color = _color;
        }

        /// <summary>
        /// Color accessor
        /// </summary>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// Name mutator
        /// </summary>
        public void SetName(string _name)
        {
            name = _name;
        }

        /// <summary>
        /// Name accessor
        /// </summary>
        public string GetName()
        {
            return name;
        }
    }
}