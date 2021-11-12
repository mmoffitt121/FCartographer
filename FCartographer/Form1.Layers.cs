using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Partial Class: Form1
    /// This part of Form1 is used for Layer control
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Adds a layer to the project
        /// </summary>
        private void AddLayer_Click(object sender, EventArgs e)
        {
            if (LayerToAdd.Text.Equals("Nations"))
            {
                project.AddLayer(Layer.LayerType.NationMap);
            }
            if (LayerToAdd.Text.Equals("Terrain"))
            {
                project.AddLayer(Layer.LayerType.HeightMap);
            }

            ReadySettingsPanels(project.CurrentLayer());

            DisplayLayers();
        }

        /// <summary>
        /// Places a panel for each layer in the layer pane for user navigation.
        /// Also places references to each layer panel object in List of layer display objects.
        /// </summary>
        public void DisplayLayers()
        {
            ClearLayerPane();

            if (project.GetLayerCount() == 0)
            {
                return;
            }

            for (int i = project.GetLayerCount() - 1; i >= 0; i--)
            {
                // The Base Panel
                Panel panel = new Panel()
                {
                    //Location = new Point(10, 10),
                    BackColor = Color.NavajoWhite,
                    BorderStyle = BorderStyle.FixedSingle,
                    Dock = DockStyle.None,
                    Anchor = (AnchorStyles.Left | AnchorStyles.Right),
                    Width = 155,
                    Height = 50,

                    TabIndex = i
                };

                // Panel that displays Layer Type Icon
                Panel icon = new Panel()
                {
                    BackColor = Color.BlanchedAlmond,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(2, 2),
                    Width = 44,
                    Height = 44
                };

                // Text that displays layer's name
                Label text = new Label()
                {
                    Text = project.GetLayer(i).Name(),
                    ForeColor = Color.DarkRed,
                    Location = new Point(48, 2)
                };

                Button delbutton = new Button()
                {
                    Location = new Point(137, 2),
                    BackColor = Color.DarkRed,
                    Width = 15,
                    Height = 15
                };

                Button upbutton = new Button()
                {
                    Location = new Point(137, 17),
                    Width = 15,
                    Height = 15
                };

                Button downbutton = new Button()
                {
                    Location = new Point(137, 32),
                    Width = 15,
                    Height = 15
                };

                text.Click += LayerPanelChild_Select;
                icon.Click += LayerPanelChild_Select;

                delbutton.Click += DeleteLayer_Click;
                upbutton.Click += LayerUp_Click;
                downbutton.Click += LayerDown_Click;

                panel.Controls.Add(delbutton);
                panel.Controls.Add(upbutton);
                panel.Controls.Add(downbutton);
                panel.Controls.Add(text);
                panel.Controls.Add(icon);

                panel.Click += LayerPanel_Select;

                LayerPane.Controls.Add(panel);
            }

            DisplaySelectedLayer();
        }

        private void ClearLayerPane()
        {
            for (int i = LayerPane.Controls.Count - 1; i >= 0; i--)
            {
                LayerPane.Controls[i].Dispose();
            }
        }

        private void LayerPanelChild_Select(object sender, EventArgs e)
        {
            Control csender;
            try
            {
                csender = (Control)sender;
                LayerPanel_Select(csender.Parent, e);
            }
            catch
            {
                return;
            }
        }

        private void LayerPanel_Select(object sender, EventArgs e)
        {
            Panel psender;
            try
            {
                psender = (Panel)sender;
            }
            catch
            {
                return;
            }

            int indx = psender.TabIndex;

            project.SelectLayer(indx);
            DisplaySelectedLayer();
        }

        private void DisplaySelectedLayer()
        {
            for (int i = 0; i < LayerPane.Controls.Count; i++)
            {
                LayerPane.Controls[i].BackColor = Color.NavajoWhite;
            }
            LayerPane.Controls[LayerPane.Controls.Count - project.GetCurrentIndex() - 1].BackColor = Color.White;

        }

        private void DeleteLayer_Click(object sender, EventArgs e)
        {
            Control csender;
            try
            {
                csender = (Control)sender;
                project.DeleteLayer(csender.Parent.TabIndex);

                if (project.GetLayerCount() - 1 >= 0)
                {
                    project.SelectLayer(Math.Clamp(csender.Parent.TabIndex, 0, project.GetLayerCount() - 1));
                }

                DisplayLayers();
                RenderGraphics(project.GetGraphics());
            }
            catch
            {
                return;
            }
        }

        private void LayerUp_Click(object sender, EventArgs e)
        {
            Control csender;
            try
            {
                csender = (Control)sender;
                project.SwapLayers(csender.Parent.TabIndex, Math.Clamp(csender.Parent.TabIndex + 1, 0, LayerPane.Controls.Count - 1));
                project.SelectLayer(Math.Clamp(Math.Clamp(csender.Parent.TabIndex + 1, 0, LayerPane.Controls.Count - 1), 0, LayerPane.Controls.Count - 1));
                DisplayLayers();
                RenderGraphics(project.GetGraphics());
            }
            catch
            {
                return;
            }
        }

        private void LayerDown_Click(object sender, EventArgs e)
        {
            Control csender;
            try
            {
                csender = (Control)sender;
                project.SwapLayers(csender.Parent.TabIndex, Math.Clamp(csender.Parent.TabIndex - 1, 0, LayerPane.Controls.Count - 1));
                project.SelectLayer(Math.Clamp(Math.Clamp(csender.Parent.TabIndex - 1, 0, LayerPane.Controls.Count - 1), 0, LayerPane.Controls.Count - 1));
                DisplayLayers();
                RenderGraphics(project.GetGraphics());
            }
            catch
            {
                return;
            }
        }
    }
}
