using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FCartographer
{
    internal class Texture
    {
        public string name;
        public int opacity;
        private Bitmap texture;

        public Bitmap GetTexture()
        {
            return texture;
        }
    }
}
