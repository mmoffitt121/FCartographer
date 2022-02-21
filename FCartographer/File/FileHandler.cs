using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FCartographer.FileHandling
{
    /// <summary>
    /// Class that handles file dialogues and file IO
    /// </summary>
    public static class FileHandler
    {
        /// <summary>
        /// Opens and adds a heightmap as a terrain layer from disk
        /// </summary>
        /// <param name="project"></param>
        public static void OpenHeightMap(Project project)
        {
            using (OpenFileDialog filedialog = new OpenFileDialog())
            {
                filedialog.InitialDirectory = "c:\\";
                filedialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                filedialog.FilterIndex = 0;
                filedialog.RestoreDirectory = true;

                if (filedialog.ShowDialog() == DialogResult.OK)
                {
                    string filepath = filedialog.FileName;

                    Bitmap bitmap = (Bitmap)Image.FromFile(filepath);

                    HeightLayer lyr = (HeightLayer)project.AddLayer(Layer.LayerType.HeightMap);
                    lyr.data_g.DrawImage(bitmap, 0, 0);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Gets a file path using a file dialog. Returns empty string if no file selected.
        /// </summary>
        /// <returns></returns>
        public static string GetFilePath()
        {
            using (OpenFileDialog filedialog = new OpenFileDialog())
            {
                filedialog.InitialDirectory = "c:\\";
                filedialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                filedialog.FilterIndex = 0;
                filedialog.RestoreDirectory = true;

                if (filedialog.ShowDialog() == DialogResult.OK)
                {
                    return filedialog.FileName;
                }
                else
                {
                    return "";
                }
            }
        }
    }
}