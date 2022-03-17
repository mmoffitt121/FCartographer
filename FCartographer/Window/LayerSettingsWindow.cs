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
    /// <summary>
    /// Window that controls layer settings
    /// </summary>
    public partial class LayerSettingsWindow : Form
    {
        private Layer layer;
        private Form1 parentform;

        private bool savechanges;

        private bool old_torender;

        // Layer Info

        private string layername;

        private string old_layername;

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

        private bool gradientlighting_enabled;
        private float gintensity;
        private int gambient;
        private int gpersistence;
        private float gdirection;
        private int gflatten;
        private int gvectormode;
        private Color gcolor;

        private bool old_gradientlighting_enabled;
        private float old_gintensity;
        private int old_gambient;
        private int old_gpersistence;
        private float old_gdirection;
        private int old_gflatten;
        private int old_gvectormode;
        private Color old_gcolor;



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

            // Layer Info

            layername = layer.Name();
            old_layername = layer.Name();
            nameBox.Text = layername;

            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    string[] tokeep = { "Ray Lighting", "Gradient Lighting", "Contour Lines", "Layer Info" };
                    RemoveAllOtherTabs(tokeep);

                    HeightLayer lyr = (HeightLayer)layer;

                    // Ray lighting

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

                    // Gradient lighting

                    gradientlighting_enabled = lyr.render_gradient;
                    gintensity = lyr.gts.intensity;
                    gambient = lyr.gts.ambient;
                    gpersistence = lyr.gts.persistance;
                    gdirection = lyr.gts.angle;
                    gflatten = lyr.gts.flatten;
                    gvectormode = lyr.gts.vectormode;
                    gcolor = lyr.gts.lightcolor;

                    old_gradientlighting_enabled = lyr.render_gradient;
                    old_gintensity = lyr.gts.intensity;
                    old_gambient = lyr.gts.ambient;
                    old_gpersistence = lyr.gts.persistance;
                    old_gdirection = lyr.gts.angle;
                    old_gflatten = lyr.gts.flatten;
                    old_gvectormode = lyr.gts.vectormode;
                    old_gcolor = lyr.gts.lightcolor;

                    gradientLightingEnabled.Checked = gradientlighting_enabled;
                    gIntensitySlider.Value = (int)(gintensity * 100);
                    gAmbientSlider.Value = gambient;
                    gPersistanceSlider.Value = gpersistence;
                    gDirectionSlider.Value = (int)gdirection;
                    gFlattenSlider.Value = gflatten;
                    gVectorModeSlider.Value = gvectormode;
                    gColorPanel.BackColor = gcolor;

                    gIntensityDisplay.Text = (int)(gintensity * 100) + " %";
                    gAmbientDisplay.Text = gambient + "";
                    gPersistanceDisplay.Text = gpersistence + "";
                    gDirectionDisplay.Text = (int)gdirection + "";
                    gFlattenDisplay.Text = gflatten + "";
                    gVectorModeDisplay.Text = gvectormode + 1 + "";

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
        // Settings
        // ---

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            layername = nameBox.Text;
        }

        // Ray

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

        // Gradient

        private void gradientLightingEnabled_CheckedChanged(object sender, EventArgs e)
        {
            gradientlighting_enabled = gradientLightingEnabled.Checked;
        }

        private void gIntensitySlider_Scroll(object sender, EventArgs e)
        {
            gintensity = ((float)gIntensitySlider.Value) / 100;
            gIntensityDisplay.Text = (int)(gintensity * 100) + " %";
        }

        private void gAmbientSlider_Scroll(object sender, EventArgs e)
        {
            gambient = gAmbientSlider.Value;
            gAmbientDisplay.Text = gambient + "";
        }

        private void gPersistanceSlider_Scroll(object sender, EventArgs e)
        {
            gpersistence = gPersistanceSlider.Value;
            gPersistanceDisplay.Text = gpersistence + "";
        }

        private void gDirectionSlider_Scroll(object sender, EventArgs e)
        {
            gdirection = gDirectionSlider.Value;
            gDirectionDisplay.Text = gdirection + "";
        }

        private void gFlattenSlider_Scroll(object sender, EventArgs e)
        {
            gflatten = gFlattenSlider.Value;
            gFlattenDisplay.Text = gflatten + "";
        }

        private void gVectorModeSlider_Scroll(object sender, EventArgs e)
        {
            gvectormode = gVectorModeSlider.Value;
            gVectorModeDisplay.Text = gvectormode + 1 + "";
        }

        private void gColorPanel_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = gColorPanel.BackColor;

            cd.ShowDialog();

            gColorPanel.BackColor = cd.Color;
            gcolor = cd.Color;
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
            layer.SetName(old_layername);

            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    HeightLayer lyr = (HeightLayer)layer;

                    // Ray

                    lyr.render_rays = old_raylighting_enabled;
                    lyr.rts.intensity = old_intensity;
                    lyr.rts.ambient = old_ambient;
                    lyr.rts.dropoff = old_dropoff;
                    lyr.rts.direction = old_direction;
                    lyr.rts.angle = old_angle;
                    lyr.rts.lightcolor = old_raycolor;

                    // Gradient

                    lyr.render_gradient = old_gradientlighting_enabled;
                    lyr.gts.intensity = old_gintensity;
                    lyr.gts.ambient = old_gambient;
                    lyr.gts.persistance = old_gpersistence;
                    lyr.gts.angle = old_gdirection;
                    lyr.gts.flatten = old_gflatten;
                    lyr.gts.vectormode = old_gvectormode;
                    lyr.gts.lightcolor = old_gcolor;

                    lyr.SetToRender(true);
                    lyr.Render();
                    lyr.SetToRender(old_torender);
                    parentform.RenderGraphics(parentform.project.GetGraphics());
                    break;
            }
        }

        private void SetAndRender()
        {
            layer.SetName(nameBox.Text);

            switch (layer.GetType())
            {
                case Layer.LayerType.HeightMap:
                    HeightLayer lyr = (HeightLayer)layer;

                    // Ray

                    lyr.render_rays = raylighting_enabled;
                    lyr.rts.intensity = intensity;
                    lyr.rts.ambient = ambient;
                    lyr.rts.dropoff = dropoff;
                    lyr.rts.direction = direction;
                    lyr.rts.angle = angle;
                    lyr.rts.lightcolor = raycolor;

                    // Gradient

                    lyr.render_gradient = gradientlighting_enabled;
                    lyr.gts.intensity = gintensity;
                    lyr.gts.ambient = gambient;
                    lyr.gts.persistance = gpersistence;
                    lyr.gts.angle = gdirection;
                    lyr.gts.flatten = gflatten;
                    lyr.gts.vectormode = gvectormode;
                    lyr.gts.lightcolor = gcolor;

                    lyr.SetToRender(true);
                    lyr.Render();
                    lyr.SetToRender(old_torender);
                    parentform.RenderGraphics(parentform.project.GetGraphics());
                    break;
            }
        }
    }
}
