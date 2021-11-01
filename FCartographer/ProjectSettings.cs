using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace FCartographer
{
    public class ProjectSettings
    {
        private int default_height_brush_opacity;
        private int default_height_brush_size;
        private int default_height_brush_height; 

        public ProjectSettings()
        {
            default_height_brush_opacity = 50;
            default_height_brush_size = 30;
            default_height_brush_height = 100;
        }
    }
}