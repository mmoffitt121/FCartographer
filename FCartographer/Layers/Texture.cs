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
        private Bitmap mask;
        private Bitmap texture;

        private Generator gen;

        public Bitmap GetTexture()
        {
            return texture;
        }

        public void SetTexture(Bitmap _texture)
        {
            texture = new Bitmap(_texture);
        }

        public void SetGenerator(int genmode)
        {
            switch (genmode)
            {
                case 0:
                    gen = new DirtTextureGenerator(texture);
                    break;
            }
        }

        public Generator GetGenerator()
        {
            return gen;
        }

        public void GenerateTexture()
        {
            if (gen != null)
            {
                gen.Generate();
            }
        }

        public void InitializeTexture(int genmode, int wid, int hei)
        {
            SetTexture(new Bitmap(wid, hei));
            SetGenerator(genmode);
            GenerateTexture();
        }

        public void UpdateTexture()
        {
            GenerateTexture();
        }
    }
}
