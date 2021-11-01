using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

namespace FCartographer
{
    public class BrushPreset
    {
        private Bitmap source_bitmap;
        private Bitmap output_bitmap;

        private int size;
        private int opacity;

        public void SetImage(string brushpath, int input_opacity)
        {
            source_bitmap = (Bitmap)Image.FromFile(brushpath);
            opacity = input_opacity;
            CalculateOutputBrush();
        }

        public void SetImage(Bitmap input)
        {
            source_bitmap = new Bitmap(input);
            CalculateOutputBrush();
        }

        public void SetImage(string brushpath)
        {
            source_bitmap = (Bitmap)Image.FromFile(brushpath);
            CalculateOutputBrush();
        }

        public Bitmap GetImage()
        {
            return output_bitmap;
        }

        public void SetSize(int input)
        {
            size = input;
        }

        public int GetSize()
        {
            return size;
        }

        public void SetOpacity(int input)
        {
            opacity = input;
            CalculateOutputBrush();
        }

        public int GetOpacity()
        {
            return opacity;
        }

        public void CalculateOutputBrush()
        {
            ColorMatrix cmatrix = new ColorMatrix();
            cmatrix.Matrix33 = (float)GetOpacity() / 255;

            var attributes = new ImageAttributes();
            attributes.SetColorMatrix(cmatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            output_bitmap = new Bitmap(source_bitmap.Width, source_bitmap.Height);
            Graphics g = Graphics.FromImage(output_bitmap);

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.DrawImage(source_bitmap, new Rectangle(0, 0, source_bitmap.Width, source_bitmap.Height), 0, 0, source_bitmap.Width, source_bitmap.Height, GraphicsUnit.Pixel, attributes);
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // BrushPreset constructor
        public BrushPreset(string brushpath)
        {
            try
            {
                SetImage(brushpath, 255);
                SetSize(10);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No Brush Found!");
            }
        }

        public BrushPreset(string brushpath, int size)
        {
            try
            {
                SetImage(brushpath, 255);
                SetSize(size);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No Brush Found!");
            }
        }

        public BrushPreset(string brushpath, int size, int opacity)
        {
            try
            {
                SetImage(brushpath, opacity);
                SetSize(size);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No Brush Found!");
            }
        }
    }
}