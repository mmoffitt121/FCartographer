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

        private void SetCurrentTool(ToolSelected _tool)
        {
            current_tool = _tool;
        }

        private ToolSelected GetCurrentTool()
        {
            return current_tool;
        }

        private void BrushSelect_Click(object sender, EventArgs e)
        {
            SetCurrentTool(ToolSelected.brush);
            ResetToolButtonColors();
            BrushSelect.BackColor = Color.White;
        }

        private void FillSelect_Click(object sender, EventArgs e)
        {
            SetCurrentTool(ToolSelected.fill);
            ResetToolButtonColors();
            FillSelect.BackColor = Color.White;
        }

        private void ResetToolButtonColors()
        {
            BrushSelect.BackColor = Color.BlanchedAlmond;
            FillSelect.BackColor = Color.BlanchedAlmond;
        }

        public enum ToolSelected
        {
            brush,
            fill
        }
    }
}
