using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCartographer
{
    /// <summary>
    /// This part of Form1 is used for choosing what tool is selected
    /// </summary>
    public partial class Form1 : Form
    {
        ToolSelected current_tool;

        /// <summary>
        /// Sets the current selected tool enum
        /// </summary>
        private void SetCurrentTool(ToolSelected _tool)
        {
            current_tool = _tool;
        }

        /// <summary>
        /// Returns the current selected tool
        /// </summary>
        private ToolSelected GetCurrentTool()
        {
            return current_tool;
        }

        /// <summary>
        /// Selects the brush tool, event listener
        /// </summary>
        private void BrushSelect_Click(object sender, EventArgs e)
        {
            SetCurrentTool(ToolSelected.brush);
            ResetToolButtonColors();
            BrushSelect.BackColor = Color.White;
        }

        /// <summary>
        /// Selects the fill tool, event listener
        /// </summary>
        private void FillSelect_Click(object sender, EventArgs e)
        {
            SetCurrentTool(ToolSelected.fill);
            ResetToolButtonColors();
            FillSelect.BackColor = Color.White;
        }

        /// <summary>
        /// Sets tool buttons to default color
        /// </summary>
        private void ResetToolButtonColors()
        {
            BrushSelect.BackColor = Color.BlanchedAlmond;
            FillSelect.BackColor = Color.BlanchedAlmond;
        }

        /// <summary>
        /// Enum that holds each type of tool in the program
        /// </summary>
        public enum ToolSelected
        {
            /// <summary>
            /// Brush tool
            /// </summary>
            brush,

            /// <summary>
            /// Fill tool
            /// </summary>
            fill
        }
    }
}
