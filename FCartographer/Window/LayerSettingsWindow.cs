using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCartographer.Window
{
    public partial class LayerSettingsWindow : Form
    {
        private Layer layer;
        private Form1 parentform;

        private bool raylighting_enabled;
        private float intensity;
        private int ambient;
        private float dropoff;
        private float direction;
        private float angle;

        /// <summary>
        /// Constructor that takes layer to change settings of and parent form as input
        /// </summary>
        /// <param name="_layer"></param>
        /// <param name="_parentform"></param>
        public LayerSettingsWindow(Layer _layer, Form1 _parentform)
        {
            InitializeComponent();

            layer = _layer;
            parentform = _parentform;

            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    string[] tokeep = { "Ray Lighting", "Gradient Lighting", "Contour Lines" };
                    RemoveAllOtherTabs(tokeep);

                    HeightLayer lyr = (HeightLayer)layer;

                    raylighting_enabled = lyr.render_rays;
                    intensity = lyr.rts.intensity;
                    ambient = lyr.rts.ambient;
                    dropoff = lyr.rts.dropoff;
                    direction = lyr.rts.direction;
                    angle = lyr.rts.angle;
                    break;
            }
        }

        private void RemoveAllOtherTabs(string[] tokeep)
        {
            List<TabPage> toremove = new List<TabPage>();
            foreach (TabPage t in tabGroup.TabPages)
            {
                bool keep = false;
                foreach (string s in tokeep)
                {
                    if (t.Text.Equals(s))
                    {
                        keep = true;
                        break;
                    }
                }

                if (!keep)
                {
                    toremove.Add(t);
                }
            }

            foreach (TabPage t in toremove)
            {
                tabGroup.TabPages.Remove(t);
            }
        }

        private void rayColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = rayColorPanel.BackColor;

            cd.ShowDialog();

            rayColorPanel.BackColor = cd.Color;
        }
    }
}
