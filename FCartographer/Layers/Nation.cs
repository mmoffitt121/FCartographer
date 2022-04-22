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
    /// 
    /// Tip: All colors should have Alpha value of 255.
    /// </summary>
    public class Nation : CompositeLayerItem
    {
        private Color datacolor;
        private Color displaycolor;

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
        /// Nation constructor, builds nation of random color and new name.
        /// </summary>
        public Nation(List<Nation> nations)
        {
            // Setting name
            SetName("New Nation");

            // Setting unique data color & display color

            List<Color> colors = new List<Color>();

            foreach (Nation n in nations)
            {
                colors.Add(n.GetDataColor());
            }

            if (colors.Count >= 255*255*255)
            {
                SetDataColor(Color.FromArgb(255, 0, 0, 0));
            }
            else
            {
                Random rand = new Random();
                while (true)
                {
                    Color clr = Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));

                    foreach (Color c in colors)
                    {
                        if (c.R == clr.R && c.G == clr.G && c.B == clr.B)
                        {
                            continue;
                        }
                    }

                    SetDataColor(clr);
                    SetColor(clr);
                    break;
                }
            }
        }

        public Nation(List<CompositeLayerItem> nations)
        {
            // Setting name
            SetName("New Nation");

            // Setting unique data color & display color

            List<Color> colors = new List<Color>();

            foreach (Nation n in nations)
            {
                colors.Add(n.GetDataColor());
            }

            if (colors.Count >= 255 * 255 * 255)
            {
                SetDataColor(Color.FromArgb(255, 0, 0, 0));
            }
            else
            {
                Random rand = new Random();
                while (true)
                {
                    Color clr = Color.FromArgb(255, rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));

                    foreach (Color c in colors)
                    {
                        if (c.R == clr.R && c.G == clr.G && c.B == clr.B)
                        {
                            continue;
                        }
                    }

                    SetDataColor(clr);
                    SetColor(clr);
                    break;
                }
            }
        }
    }
}