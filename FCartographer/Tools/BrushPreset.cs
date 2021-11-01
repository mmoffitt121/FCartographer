using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    public class BrushPreset
    {
        private Bitmap bitmap;

        private int size;
        private int opacity;

        private TextureBrush brush;

        public Bitmap GetImage()
        {
            return bitmap;
        }

        public void SetImage(Bitmap input)
        {
            bitmap = new Bitmap(input);
        }

        public void SetImage(string brushpath)
        {
            bitmap = (Bitmap)Image.FromFile(brushpath);
            SetBrush();
        }

        public TextureBrush GetBrush()
        {
            return brush;
        }

        private void SetBrush()
        {
            brush = new TextureBrush(bitmap);
            brush.WrapMode = System.Drawing.Drawing2D.WrapMode.Clamp;
        }

        public void SetSize(int input)
        {
            size = input;
        }

        public void SetOpacity(int input)
        {
            opacity = input;
        }

        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        // Initialization
        // -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

        // BrushPreset constructor
        public BrushPreset(string brushpath)
        {
            try
            {
                SetImage(brushpath);
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("No Brush Found!");
            }
        }
    }
}