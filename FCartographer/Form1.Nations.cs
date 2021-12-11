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
    /// This part of Form1 handles the nation display.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Places a panel for each layer in the layer pane for user navigation.
        /// Also places references to each layer panel object in List of layer display objects.
        /// </summary>
        public void DisplayNations()
        {
            ClearNationsPane();

            Layer lyr = project.CurrentLayer();

            if (lyr.GetType() != Layer.LayerType.NationMap)
            {
                return;
            }

            NationLayer lr = (NationLayer)lyr;

            if (project.GetLayerCount() == 0)
            {
                return;
            }

            for (int i = 0; i < lr.GetNationCount(); i++)
            {
                // The Base Panel
                Panel panel = new Panel()
                {
                    //Location = new Point(10, 10),
                    BackColor = Color.NavajoWhite,
                    BorderStyle = BorderStyle.FixedSingle,
                    Dock = DockStyle.None,
                    Anchor = (AnchorStyles.Left | AnchorStyles.Right),
                    Width = 110,
                    Height = 25,

                    TabIndex = i
                };

                // Panel that displays Layer Type Icon
                Panel icon = new Panel()
                {
                    BackColor = lr.GetNation(i).GetColor(),
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(2, 2),
                    Width = 19,
                    Height = 19
                };

                // Text that displays layer's name
                Label text = new Label()
                {
                    Text = lr.GetNation(i).GetName(),
                    ForeColor = Color.DarkRed,
                    Location = new Point(23, 2),
                    Width = 90
                };

                text.Click += NationPanelChild_Select;
                icon.Click += NationPanelChild_Select;

                panel.Controls.Add(text);
                panel.Controls.Add(icon);

                panel.Click += NationPanel_Select;

                NationPane.Controls.Add(panel);
            }

            DisplaySelectedNation();
        }

        private void NationPanelChild_Select(object sender, EventArgs e)
        {
            Control csender;
            try
            {
                csender = (Control)sender;
                NationPanel_Select(csender.Parent, e);
            }
            catch
            {
                return;
            }
        }

        /// <summary>
        /// Event that fires when a layer pane is clicked. It calls project.SelectLayer() to select the layer clicked.
        /// </summary>
        private void NationPanel_Select(object sender, EventArgs e)
        {
            Panel psender;
            NationLayer lyr;
            try
            {
                psender = (Panel)sender;
                lyr = (NationLayer)(project.CurrentLayer());
            }
            catch
            {
                return;
            }

            lyr.SelectNation(psender.TabIndex);
            nations_brushpreset.SetColor(lyr.GetNation(lyr.GetSelected()).GetDataColor());

            DisplaySelectedNation();
            UpdateLayerBrushes();
        }

        /// <summary>
        /// Calls Dispose() on every Nation Panel in the viewer
        /// </summary>
        private void ClearNationsPane()
        {
            for (int i = NationPane.Controls.Count - 1; i >= 0; i--)
            {
                NationPane.Controls[i].Dispose();
            }
        }

        /// <summary>
        /// Updates the nation gui to highlight the selected nation
        /// </summary>
        public void DisplaySelectedNation()
        {
            NationLayer lyr;
            try
            {
                lyr = (NationLayer)(project.CurrentLayer());
            }
            catch
            {
                return;
            }

            for (int i = 0; i < NationPane.Controls.Count; i++)
            {
                if (lyr.IsSelected(i))
                {
                    System.Diagnostics.Debug.WriteLine(i);
                    NationPane.Controls[i].BackColor = Color.White;
                }
                else
                {
                    NationPane.Controls[i].BackColor = Color.NavajoWhite;
                }
            }
        }
    }
}