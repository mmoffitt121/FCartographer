using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FCartographer
{
    public class LayerPanelItem : Panel
    {
        private Bitmap icon;
        private string name;
        private Layer.LayerType layertype;

        public LayerPanelItem()
        {

        }
    }
}