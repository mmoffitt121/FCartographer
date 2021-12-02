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
                    Location = new Point(48, 2),
                    Width = 90
                };

                // Delete Button
                Button delbutton = new Button()
                {
                    Location = new Point(137, 2),
                    BackColor = Color.DarkRed,
                    Width = 15,
                    Height = 15
                };

                // Move Layer Up Button
                Button upbutton = new Button()
                {
                    Location = new Point(137, 17),
                    Width = 15,
                    Height = 15
                };

                // Move Layer Down Button
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

                NationPane.Controls.Add(panel);
            }

            DisplaySelectedLayer();
            UpdateLayerBrushes();
        }

        /// <summary>
        /// Calls Dispose() on every Natoin Panel in the viewer
        /// </summary>
        private void ClearNationsPane()
        {
            for (int i = NationPane.Controls.Count - 1; i >= 0; i--)
            {
                NationPane.Controls[i].Dispose();
            }
        }
    }
}