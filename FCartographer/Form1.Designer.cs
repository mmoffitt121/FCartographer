
namespace FCartographer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Canvas = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.ElevationSettings = new System.Windows.Forms.Panel();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightControl = new System.Windows.Forms.TrackBar();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeControl = new System.Windows.Forms.TrackBar();
            this.StrengthLabel = new System.Windows.Forms.Label();
            this.StrengthControl = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.ElevationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthControl)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(457, 231);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(821, 509);
            this.Canvas.TabIndex = 0;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 961);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(39, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ElevationSettings
            // 
            this.ElevationSettings.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ElevationSettings.Controls.Add(this.HeightLabel);
            this.ElevationSettings.Controls.Add(this.HeightControl);
            this.ElevationSettings.Controls.Add(this.SizeLabel);
            this.ElevationSettings.Controls.Add(this.SizeControl);
            this.ElevationSettings.Controls.Add(this.StrengthLabel);
            this.ElevationSettings.Controls.Add(this.StrengthControl);
            this.ElevationSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElevationSettings.Location = new System.Drawing.Point(0, 0);
            this.ElevationSettings.Name = "ElevationSettings";
            this.ElevationSettings.Size = new System.Drawing.Size(109, 961);
            this.ElevationSettings.TabIndex = 0;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.HeightLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.HeightLabel.Location = new System.Drawing.Point(9, 108);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(45, 17);
            this.HeightLabel.TabIndex = 6;
            this.HeightLabel.Text = "Height";
            // 
            // HeightControl
            // 
            this.HeightControl.Location = new System.Drawing.Point(1, 127);
            this.HeightControl.Maximum = 255;
            this.HeightControl.Name = "HeightControl";
            this.HeightControl.Size = new System.Drawing.Size(104, 45);
            this.HeightControl.TabIndex = 5;
            this.HeightControl.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.SizeLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SizeLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SizeLabel.Location = new System.Drawing.Point(10, 56);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(31, 17);
            this.SizeLabel.TabIndex = 4;
            this.SizeLabel.Text = "Size";
            // 
            // SizeControl
            // 
            this.SizeControl.Location = new System.Drawing.Point(2, 76);
            this.SizeControl.Maximum = 100;
            this.SizeControl.Name = "SizeControl";
            this.SizeControl.Size = new System.Drawing.Size(104, 45);
            this.SizeControl.TabIndex = 3;
            this.SizeControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SizeControl.Value = 15;
            // 
            // StrengthLabel
            // 
            this.StrengthLabel.AutoSize = true;
            this.StrengthLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.StrengthLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StrengthLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.StrengthLabel.Location = new System.Drawing.Point(10, 5);
            this.StrengthLabel.Name = "StrengthLabel";
            this.StrengthLabel.Size = new System.Drawing.Size(56, 17);
            this.StrengthLabel.TabIndex = 2;
            this.StrengthLabel.Text = "Strength";
            // 
            // StrengthControl
            // 
            this.StrengthControl.Location = new System.Drawing.Point(2, 25);
            this.StrengthControl.Maximum = 50;
            this.StrengthControl.Name = "StrengthControl";
            this.StrengthControl.Size = new System.Drawing.Size(104, 45);
            this.StrengthControl.TabIndex = 1;
            this.StrengthControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.StrengthControl.Value = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.ElevationSettings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1596, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(109, 961);
            this.panel2.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1705, 961);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Canvas);
            this.Name = "Form1";
            this.Text = "FCartographer";
            this.panel1.ResumeLayout(false);
            this.ElevationSettings.ResumeLayout(false);
            this.ElevationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthControl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel ElevationSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar StrengthControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label StrengthLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TrackBar SizeControl;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TrackBar HeightControl;
    }
}

