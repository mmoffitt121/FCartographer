using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// Layer that holds maskable textures
    /// </summary>
    public class TextureLayer : Layer
    {
        //private TerrainShader shader;
        private List<Texture> textures;
        private int selected;

        private Pen pen;

        private Color brushcolor;

        /// <summary>
        /// Override void that composits temp data to the layer.
        /// </summary>
        public override void Render()
        {
            data_g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            data_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            data_g.DrawImage(GetTempData(), 0, 0, GetData().Width, GetData().Height);
            g.Clear(Color.FromArgb(0, 0, 0, 0));

            if (ToRender())
            {
                render_g.Clear(Color.FromArgb(0, 0, 0, 0));
            }
        }

        /// <summary>
        /// Override void that Draws on a temporary layer. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void Draw(BrushPreset brush, MouseEventArgs e, int? xprime, int? yprime)
        {
            DrawToCanvas(brush, e, g, xprime, yprime);
        }

        /// <summary>
        /// Override void that Draws on the display canvas. Bitmap is cleared when drawing is complete.
        /// </summary>
        public override void DrawTemp(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            DrawToCanvas(brush, e, gr, xprime, yprime);
        }

        /// <summary>
        /// Fills contiguous region with pixels of selected nation.
        /// </summary>
        public override void Fill(MouseEventArgs e, BrushPreset brush)
        {
            AreaSelector.FillAreaContiguous(GetData(), new Point(e.X, e.Y), brush);
            //g.DrawImage(fillregion, 0, 0, fillregion.Width, fillregion.Height);
            Render();
        }

        /// <summary>
        /// Generalized draw to canvas function, used by both Draw() and DrawTemp(). Used to draw on canvas based
        /// on input brush settings, as well as mouse location and movement.
        /// </summary>
        public void DrawToCanvas(BrushPreset brush, MouseEventArgs e, Graphics gr, int? xprime, int? yprime)
        {
            int size = brush.GetSize();
            gr.InterpolationMode = InterpolationMode.NearestNeighbor;
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;

            if (xprime != null && yprime != null)
            {
                gr.DrawLine(pen, (int)xprime, (int)yprime, e.X, e.Y);
            }
            gr.DrawImage(brush.GetImage(), e.X - size / 2, e.Y - size / 2, size, size);
        }

        /// <summary>
        /// Override void that sets the internal layer saved color.
        /// </summary>
        public override void SetColor(Color _color)
        {
            brushcolor = _color;
            pen.Color = brushcolor;
        }

        /// <summary>
        /// Override void that initializes the internal layer saved color without interacting with the layer's 
        /// internal pen.
        /// </summary>
        public void InitializeColor(Color _color)
        {
            brushcolor = _color;
        }

        /// <summary>
        /// Override void that sets the internal layer saved pen.
        /// </summary>
        public override void SetSize(int _size)
        {
            pen.Width = _size;
        }

        /// <summary>
        /// Grabs internal brush options from the input layer.
        /// </summary>
        public override void UpdateBrushOptions(BrushPreset brushPreset)
        {
            SetSize(brushPreset.GetSize());
            SetColor(brushPreset.GetColor());
        }

        // ---========================================================---
        // Nation Handling
        // ---========================================================---

        /// <summary>
        /// Creates new nation with random data color.
        /// </summary>
        public void NewTexture()
        {
            textures.Add(new Texture(GetData().Width, GetData().Height));
        }

        /// <summary>
        /// Returns the amount of items in the intenal nation list
        /// </summary>
        public int GetTextureCount()
        {
            return textures.Count;
        }

        /// <summary>
        /// Returns the index of the selected nation
        /// </summary>
        public int GetSelected()
        {
            return selected;
        }

        /// <summary>
        /// Changes the index of layer to be selected
        /// </summary>
        public void SelectTexture(int i)
        {
            selected = i;
        }

        /// <summary>
        /// Checks if an index is selected
        /// </summary>
        public bool IsSelected(int i)
        {
            return selected == i;
        }

        /// <summary>
        /// Gets a nation by it's index in the nations list. If index too high, return null.
        /// </summary>
        public Texture GetTexture(int i)
        {
            if (i < textures.Count)
            {
                return textures[i];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Unnamed constructor, creates layer of size x and y. Inherits base constructor.
        /// </summary>
        public TextureLayer(int x, int y) : base(x, y, "Nations Layer", "Nations Layer Description")
        {
            SetType(LayerType.Texture);
            SetName("Nation layer");

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 20);
            pen.Width = 20;

            textures = new List<Texture>();
            NewTexture();
        }

        /// <summary>
        /// Named constructor, creates layer of size x and y, and an input name. Inherits base constructor.
        /// </summary>
        public TextureLayer(int x, int y, string _name) : base(x, y, _name, "Nations Layer", "Nations Layer Description")
        {
            SetType(LayerType.Texture);

            InitializeColor(Color.FromArgb(255, 200, 0, 255));
            pen = new Pen(brushcolor, 30);
            pen.Width = 20;

            textures = new List<Texture>();
            NewTexture();
        }
    }
}
