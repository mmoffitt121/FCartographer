using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using FCartographer.Window;

namespace FCartographer.FileHandling
{
    /// <summary>
    /// Class that handles the creation of a new project
    /// </summary>
    public static class NewProjectHandler
    {
        /// <summary>
        /// Creates a new project
        /// </summary>
        /// <param name="project"></param>
        public static Project CreateProject()
        {
            Project project;
            using (NewProjectWindow pwindow = new NewProjectWindow())
            {
                if (pwindow.ShowDialog() == DialogResult.OK)
                {

                }

                project = new Project(1, 1);
            }

            return project;
        }
    }
}