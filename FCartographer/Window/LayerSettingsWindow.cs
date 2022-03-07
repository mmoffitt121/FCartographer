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

        private bool savechanges;

        private bool old_torender;

        // Ray Lighting

        private bool raylighting_enabled;
        private float intensity;
        private int ambient;
        private float dropoff;
        private float direction;
        private float angle;
        private Color raycolor;

        private bool old_raylighting_enabled;
        private float old_intensity;
        private int old_ambient;
        private float old_dropoff;
        private float old_direction;
        private float old_angle;
        private Color old_raycolor;

        // Gradient Lighting



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

            old_torender = layer.ToRender();

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
                    raycolor = lyr.rts.lightcolor;

                    old_raylighting_enabled = lyr.render_rays;
                    old_intensity = lyr.rts.intensity;
                    old_ambient = lyr.rts.ambient;
                    old_dropoff = lyr.rts.dropoff;
                    old_direction = lyr.rts.direction;
                    old_angle = lyr.rts.angle;
                    old_raycolor = lyr.rts.lightcolor;

                    intensitySlider.Value = (int)(intensity * 100);
                    ambientSlider.Value = ambient;
                    dropOffSlider.Value = (int)(dropoff * 100);
                    directionSlider.Value = (int)direction;
                    angleSlider.Value = (int)angle;
                    rayLightingEnabled.Checked = raylighting_enabled;
                    rayColorPanel.BackColor = raycolor;

                    intensityDisplay.Text = (int)(intensity * 100) + " %";
                    ambientDisplay.Text = ambient + "";
                    dropoffDisplay.Text = (int)(dropoff * 100) + " %";
                    directionDisplay.Text = direction + "";
                    angleDisplay.Text = angle + "";

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

        // ---
        // Ray Lighting Settings
        // ---

        private void rayLightingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            raylighting_enabled = rayLightingEnabled.Checked;
        }

        private void intensitySlider_Scroll(object sender, EventArgs e)
        {
            intensity = ((float)intensitySlider.Value) / 100;
            intensityDisplay.Text = (int)(intensity * 100) + " %";
        }

        private void ambientSlider_Scroll(object sender, EventArgs e)
        {
            ambient = ambientSlider.Value;
            ambientDisplay.Text = ambient + "";
        }

        private void dropOffSlider_Scroll(object sender, EventArgs e)
        {
            dropoff = ((float)dropOffSlider.Value) / 100;
            dropoffDisplay.Text = (int)(dropoff * 100) + " %";
        }

        private void directionSlider_Scroll(object sender, EventArgs e)
        {
            direction = directionSlider.Value;
            directionDisplay.Text = direction + "";
        }

        private void angleSlider_Scroll(object sender, EventArgs e)
        {
            angle = angleSlider.Value;
            angleDisplay.Text = angle + "";
        }

        private void rayColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = rayColorPanel.BackColor;

            cd.ShowDialog();

            rayColorPanel.BackColor = cd.Color;
            raycolor = cd.Color;
        }

        // ---
        // Applying Changes
        // ---

        private void cancelButton_Click(object sender, EventArgs e)
        {
            savechanges = false;
            Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            savechanges = true;
            Close();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            SetAndRender();
        }

        /// <summary>
        /// What happens when the form closes. If savechanges is set to true, the changes in the form will be applied. If not, values reset to when form opened
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason != CloseReason.UserClosing)
            {
                return;
            }

            if (savechanges)
            {
                SetAndRender();
            }
            else
            {
                ResetAndRender();
            }
        }

        private void ResetAndRender()
        {
            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    HeightLayer lyr = (HeightLayer)layer;

                    lyr.render_rays = old_raylighting_enabled;
                    lyr.rts.intensity = old_intensity;
                    lyr.rts.ambient = old_ambient;
                    lyr.rts.dropoff = old_dropoff;
                    lyr.rts.direction = old_direction;
                    lyr.rts.angle = old_angle;
                    lyr.rts.lightcolor = old_raycolor;

                    lyr.SetToRender(true);
                    lyr.Render();
                    lyr.SetToRender(old_torender);
                    parentform.RenderGraphics(parentform.project.GetGraphics());
                    break;
            }
        }

        private void SetAndRender()
        {
            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    HeightLayer lyr = (HeightLayer)layer;

                    lyr.render_rays = raylighting_enabled;
                    lyr.rts.intensity = intensity;
                    lyr.rts.ambient = ambient;
                    lyr.rts.dropoff = dropoff;
                    lyr.rts.direction = direction;
                    lyr.rts.angle = angle;
                    lyr.rts.lightcolor = raycolor;

                    lyr.SetToRender(true);
                    lyr.Render();
                    lyr.SetToRender(old_torender);
                    parentform.RenderGraphics(parentform.project.GetGraphics());
                    break;
            }
        }
    }
}
