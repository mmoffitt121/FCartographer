using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FCartographer
{
    public class Texture
    {
        public string name;
        public int opacity;
        private Bitmap mask;
        private Bitmap texture;

        private Generator gen;
        private Bitmap thumbnail;

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
                    gen = null;
                    break;
                case 1:
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
            else
            {
                Graphics.FromImage(texture).Clear(Color.Black);
            }
        }

        public void UpdateTexture()
        {
            GenerateTexture();
        }

        public Texture(int wid, int hei)
        {
            // Setting name
            name = "New Texture";

            mask = new Bitmap(wid, hei);
            texture = new Bitmap(wid, hei);

            Graphics.FromImage(mask).Clear(Color.Black);
            Graphics.FromImage(texture).Clear(Color.Black);
        }
    }
}
