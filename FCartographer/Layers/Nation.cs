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
        private Color datacolor;
        private Color displaycolor;
        private string name;

        /// <summary>
        /// Color mutator
        /// </summary>
        public void SetColor(Color _color)
        {
            displaycolor = _color;
        }

        /// <summary>
        /// Color accessor
        /// </summary>
        public Color GetColor()
        {
            return displaycolor;
        }

        /// <summary>
        /// Data Color mutator
        /// </summary>
        public void SetDataColor(Color _color)
        {
            datacolor = _color;
        }

        /// <summary>
        /// Data color accessor
        /// </summary>
        public Color GetDataColor()
        {
            return datacolor;
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