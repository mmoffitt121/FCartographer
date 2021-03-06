using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace FCartographer
{
    /// <summary>
    /// BrushPreset Class, holds brush data. Brush data should be imported by file, and saved when created.
    /// </summary>
    public class BrushPreset
    {
        private Bitmap source_bitmap;
        private Bitmap output_bitmap;

        private int size;
        private int opacity;
        private Color color;

        private bool solidify;

        /// <summary>
        /// Brush image mutator, image, opacity, and color overload
        /// </summary>
        public void SetImage(string brushpath, int input_opacity, Color clr)
        {
            source_bitmap = (Bitmap)Image.FromFile(brushpath);
            if (source_bitmap == null)
            {
                source_bitmap = new Bitmap(255, 255);
            }
            CalculateOutputBrush();
        }

        /// <summary>
        /// Brush image mutator, image overload
        /// </summary>
        public void SetImage(Bitmap input)
        {
            source_bitmap = new Bitmap(input);
            if (source_bitmap == null)
            {
                source_bitmap = new Bitmap(255, 255);
            }
            CalculateOutputBrush();
        }

        /// <summary>
        /// Brush image mutator, brush path location overload
        /// </summary>
        public void SetImage(string brushpath)
        {
            source_bitmap = (Bitmap)Image.FromFile(brushpath);
            if (source_bitmap == null)
            {
                source_bitmap = new Bitmap(255, 255);
            }
            CalculateOutputBrush();
        }

        /// <summary>
        /// Brush image accessor
        /// </summary>
        public Bitmap GetImage()
        {
            return output_bitmap;
        }

        /// <summary>
        /// Aize value mutator
        /// </summary>
        public void SetSize(int input)
        {
            size = input;
        }

        /// <summary>
        /// Color value mutator, int triplet overload
        /// </summary>
        public void SetColor(int r, int g, int b)
        {
            color = Color.FromArgb(255, r, g, b);
            CalculateOutputBrush();
        }

        /// <summary>
        /// Color value mutator, Color type overload
        /// </summary>
        public void SetColor(Color clr)
        {
            color = Color.FromArgb(clr.A, clr.R, clr.G, clr.B);
            CalculateOutputBrush();
        }

        /// <summary>
        /// Size value mutator
        /// </summary>
        public Color GetColor()
        {
            return color;
        }

        /// <summary>
        /// Size value accessor
        /// </summary>
        public int GetSize()
        {
            return size;
        }

        /// <summary>
        /// Opacity value mutator
        /// </summary>
        public void SetOpacity(int input)
        {
            opacity = input;
            CalculateOutputBrush();
        }

        /// <summary>
        /// Opacity value accessor
        /// </summary>
        public int GetOpacity()
        {
            return opacity;
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Brush Color Calculation
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// Calculates the color and opacity of the output brush
        /// </summary>
        public virtual void CalculateOutputBrush()
        {

            ColorMatrix cmatrix = new ColorMatrix();
            cmatrix.Matrix40 = (float)color.R / 255;           // Sets red value
            cmatrix.Matrix41 = (float)color.G / 255;           // Sets green value
            cmatrix.Matrix42 = (float)color.B / 255;           // Sets blue value
            cmatrix.Matrix33 = (float)GetOpacity() / 255;    // Sets opacity

            if (solidify)
            {
                cmatrix.Matrix33 = 2555;
            }

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cmatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            
            //output_bitmap = new Bitmap(source_bitmap.Width, source_bitmap.Height);
            if (output_bitmap == null)
            {
                return;
            }
            Graphics output_g = Graphics.FromImage(output_bitmap);
            output_g.Clear(Color.FromArgb(0, 0, 0, 0));

            output_g.InterpolationMode = InterpolationMode.NearestNeighbor;
            output_g.SmoothingMode = SmoothingMode.None; // AntiAlias;
            output_g.DrawImage(source_bitmap, new Rectangle(0, 0, source_bitmap.Width, source_bitmap.Height), 0, 0, source_bitmap.Width, source_bitmap.Height, GraphicsUnit.Pixel, attributes);
        }

        /// <summary>
        /// Sets if the brush is to have hard edges
        /// </summary>
        public void SetSolidify(Boolean _solidify)
        {
            solidify = _solidify;
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        /// <summary>
        /// BrushPreset Constructor
        /// </summary>
        public BrushPreset(string brushpath, int siz, int opac, Color clr, bool _solidify)
        {
            try
            {
                source_bitmap = (Bitmap)Image.FromFile(brushpath);
                if (source_bitmap == null)
                {
                    source_bitmap = new Bitmap(255, 255);
                }
                output_bitmap = new Bitmap(source_bitmap);
                opacity = opac;
                color = clr;
                size = siz;
                SetSolidify(_solidify);
                CalculateOutputBrush();
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No Brush Found!");
            }
        }
    }
}