
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
            this.ToolsPanel = new System.Windows.Forms.Panel();
            this.ElevationSettings = new System.Windows.Forms.Panel();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightControl = new System.Windows.Forms.TrackBar();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.SizeControl = new System.Windows.Forms.TrackBar();
            this.StrengthLabel = new System.Windows.Forms.Label();
            this.StrengthControl = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NationsSettings = new System.Windows.Forms.Panel();
            this.NationsSizeLabel = new System.Windows.Forms.Label();
            this.NationsSizeControl = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Navigation = new System.Windows.Forms.Panel();
            this.LayerToAdd = new System.Windows.Forms.ComboBox();
            this.LayerPane = new System.Windows.Forms.FlowLayoutPanel();
            this.ZoomOut = new System.Windows.Forms.Button();
            this.ZoomIn = new System.Windows.Forms.Button();
            this.AddLayer = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.CanvasHolder = new System.Windows.Forms.Panel();
            this.HorizontalScroll = new System.Windows.Forms.HScrollBar();
            this.VerticalScroll = new System.Windows.Forms.VScrollBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ElevationSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthControl)).BeginInit();
            this.panel2.SuspendLayout();
            this.NationsSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NationsSizeControl)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.Navigation.SuspendLayout();
            this.CanvasHolder.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canvas
            // 
            this.Canvas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Canvas.BackColor = System.Drawing.Color.White;
            this.Canvas.Location = new System.Drawing.Point(303, 199);
            this.Canvas.Name = "Canvas";
            this.Canvas.Size = new System.Drawing.Size(829, 509);
            this.Canvas.TabIndex = 0;
            this.Canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseDown);
            this.Canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseMove);
            this.Canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Canvas_MouseUp);
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ToolsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToolsPanel.Location = new System.Drawing.Point(3, 3);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(70, 893);
            this.ToolsPanel.TabIndex = 1;
            // 
            // ElevationSettings
            // 
            this.ElevationSettings.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ElevationSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ElevationSettings.Controls.Add(this.HeightLabel);
            this.ElevationSettings.Controls.Add(this.HeightControl);
            this.ElevationSettings.Controls.Add(this.SizeLabel);
            this.ElevationSettings.Controls.Add(this.SizeControl);
            this.ElevationSettings.Controls.Add(this.StrengthLabel);
            this.ElevationSettings.Controls.Add(this.StrengthControl);
            this.ElevationSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ElevationSettings.Location = new System.Drawing.Point(0, 0);
            this.ElevationSettings.Name = "ElevationSettings";
            this.ElevationSettings.Size = new System.Drawing.Size(1705, 38);
            this.ElevationSettings.TabIndex = 0;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.HeightLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HeightLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.HeightLabel.Location = new System.Drawing.Point(329, 5);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(45, 17);
            this.HeightLabel.TabIndex = 6;
            this.HeightLabel.Text = "Height";
            // 
            // HeightControl
            // 
            this.HeightControl.Location = new System.Drawing.Point(380, 5);
            this.HeightControl.Maximum = 255;
            this.HeightControl.Name = "HeightControl";
            this.HeightControl.Size = new System.Drawing.Size(104, 45);
            this.HeightControl.TabIndex = 5;
            this.HeightControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.HeightControl.Scroll += new System.EventHandler(this.HeightControl_Scroll);
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.SizeLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SizeLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.SizeLabel.Location = new System.Drawing.Point(182, 5);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(31, 17);
            this.SizeLabel.TabIndex = 4;
            this.SizeLabel.Text = "Size";
            // 
            // SizeControl
            // 
            this.SizeControl.Location = new System.Drawing.Point(219, 5);
            this.SizeControl.Maximum = 100;
            this.SizeControl.Name = "SizeControl";
            this.SizeControl.Size = new System.Drawing.Size(104, 45);
            this.SizeControl.TabIndex = 3;
            this.SizeControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.SizeControl.Value = 15;
            this.SizeControl.Scroll += new System.EventHandler(this.SizeControl_Scroll);
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
            this.StrengthControl.Location = new System.Drawing.Point(72, 5);
            this.StrengthControl.Maximum = 50;
            this.StrengthControl.Name = "StrengthControl";
            this.StrengthControl.Size = new System.Drawing.Size(104, 45);
            this.StrengthControl.TabIndex = 1;
            this.StrengthControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.StrengthControl.Value = 10;
            this.StrengthControl.Scroll += new System.EventHandler(this.StrengthControl_Scroll);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.NationsSettings);
            this.panel2.Controls.Add(this.ElevationSettings);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1705, 38);
            this.panel2.TabIndex = 0;
            // 
            // NationsSettings
            // 
            this.NationsSettings.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.NationsSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NationsSettings.Controls.Add(this.NationsSizeLabel);
            this.NationsSettings.Controls.Add(this.NationsSizeControl);
            this.NationsSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NationsSettings.Location = new System.Drawing.Point(0, 0);
            this.NationsSettings.Name = "NationsSettings";
            this.NationsSettings.Size = new System.Drawing.Size(1705, 38);
            this.NationsSettings.TabIndex = 1;
            // 
            // NationsSizeLabel
            // 
            this.NationsSizeLabel.AutoSize = true;
            this.NationsSizeLabel.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.NationsSizeLabel.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NationsSizeLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.NationsSizeLabel.Location = new System.Drawing.Point(11, 5);
            this.NationsSizeLabel.Name = "NationsSizeLabel";
            this.NationsSizeLabel.Size = new System.Drawing.Size(31, 17);
            this.NationsSizeLabel.TabIndex = 4;
            this.NationsSizeLabel.Text = "Size";
            // 
            // NationsSizeControl
            // 
            this.NationsSizeControl.Location = new System.Drawing.Point(48, 5);
            this.NationsSizeControl.Maximum = 100;
            this.NationsSizeControl.Minimum = 1;
            this.NationsSizeControl.Name = "NationsSizeControl";
            this.NationsSizeControl.Size = new System.Drawing.Size(104, 45);
            this.NationsSizeControl.TabIndex = 3;
            this.NationsSizeControl.TickStyle = System.Windows.Forms.TickStyle.None;
            this.NationsSizeControl.Value = 15;
            this.NationsSizeControl.Scroll += new System.EventHandler(this.NationsSizeControl_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.renderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1705, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripMenuItem1,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(111, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(111, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.windowToolStripMenuItem.Text = "Settings";
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.renderToolStripMenuItem.Text = "Render";
            // 
            // Navigation
            // 
            this.Navigation.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.Navigation.Controls.Add(this.LayerToAdd);
            this.Navigation.Controls.Add(this.LayerPane);
            this.Navigation.Controls.Add(this.ZoomOut);
            this.Navigation.Controls.Add(this.ZoomIn);
            this.Navigation.Controls.Add(this.AddLayer);
            this.Navigation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Navigation.Location = new System.Drawing.Point(1508, 3);
            this.Navigation.Name = "Navigation";
            this.Navigation.Size = new System.Drawing.Size(194, 893);
            this.Navigation.TabIndex = 3;
            // 
            // LayerToAdd
            // 
            this.LayerToAdd.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.LayerToAdd.FormattingEnabled = true;
            this.LayerToAdd.Items.AddRange(new object[] {
            "Terrain",
            "Nations"});
            this.LayerToAdd.Location = new System.Drawing.Point(38, 446);
            this.LayerToAdd.Name = "LayerToAdd";
            this.LayerToAdd.Size = new System.Drawing.Size(109, 23);
            this.LayerToAdd.TabIndex = 3;
            this.LayerToAdd.Text = "Nations";
            // 
            // LayerPane
            // 
            this.LayerPane.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LayerPane.AutoScroll = true;
            this.LayerPane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LayerPane.Location = new System.Drawing.Point(7, 475);
            this.LayerPane.Name = "LayerPane";
            this.LayerPane.Size = new System.Drawing.Size(180, 414);
            this.LayerPane.TabIndex = 2;
            // 
            // ZoomOut
            // 
            this.ZoomOut.Location = new System.Drawing.Point(38, 7);
            this.ZoomOut.Name = "ZoomOut";
            this.ZoomOut.Size = new System.Drawing.Size(25, 25);
            this.ZoomOut.TabIndex = 1;
            this.ZoomOut.Text = "-";
            this.ZoomOut.UseVisualStyleBackColor = true;
            // 
            // ZoomIn
            // 
            this.ZoomIn.Location = new System.Drawing.Point(7, 7);
            this.ZoomIn.Name = "ZoomIn";
            this.ZoomIn.Size = new System.Drawing.Size(25, 25);
            this.ZoomIn.TabIndex = 0;
            this.ZoomIn.Text = "+";
            this.ZoomIn.UseVisualStyleBackColor = true;
            this.ZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZoomIn_Click);
            // 
            // AddLayer
            // 
            this.AddLayer.Location = new System.Drawing.Point(7, 444);
            this.AddLayer.Name = "AddLayer";
            this.AddLayer.Size = new System.Drawing.Size(25, 25);
            this.AddLayer.TabIndex = 4;
            this.AddLayer.Text = "+";
            this.AddLayer.UseVisualStyleBackColor = true;
            this.AddLayer.Click += new System.EventHandler(this.AddLayer_Click);
            // 
            // CanvasHolder
            // 
            this.CanvasHolder.AutoScrollMargin = new System.Drawing.Size(500, 500);
            this.CanvasHolder.Controls.Add(this.HorizontalScroll);
            this.CanvasHolder.Controls.Add(this.VerticalScroll);
            this.CanvasHolder.Controls.Add(this.Canvas);
            this.CanvasHolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CanvasHolder.Location = new System.Drawing.Point(79, 3);
            this.CanvasHolder.Name = "CanvasHolder";
            this.CanvasHolder.Size = new System.Drawing.Size(1423, 893);
            this.CanvasHolder.TabIndex = 4;
            // 
            // HorizontalScroll
            // 
            this.HorizontalScroll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.HorizontalScroll.Location = new System.Drawing.Point(0, 871);
            this.HorizontalScroll.Maximum = 50;
            this.HorizontalScroll.Minimum = -50;
            this.HorizontalScroll.Name = "HorizontalScroll";
            this.HorizontalScroll.Size = new System.Drawing.Size(1405, 22);
            this.HorizontalScroll.TabIndex = 1;
            this.HorizontalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollHorizontally);
            this.HorizontalScroll.ValueChanged += new System.EventHandler(this.HorizontalScroll_ValueChanged);
            // 
            // VerticalScroll
            // 
            this.VerticalScroll.Dock = System.Windows.Forms.DockStyle.Right;
            this.VerticalScroll.Location = new System.Drawing.Point(1405, 0);
            this.VerticalScroll.Maximum = 50;
            this.VerticalScroll.Minimum = -50;
            this.VerticalScroll.Name = "VerticalScroll";
            this.VerticalScroll.Size = new System.Drawing.Size(18, 893);
            this.VerticalScroll.TabIndex = 2;
            this.VerticalScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollVertically);
            this.VerticalScroll.ValueChanged += new System.EventHandler(this.VerticalScroll_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.CanvasHolder, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.Navigation, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ToolsPanel, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 62);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1705, 899);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1705, 961);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "FCartographer";
            this.ElevationSettings.ResumeLayout(false);
            this.ElevationSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrengthControl)).EndInit();
            this.panel2.ResumeLayout(false);
            this.NationsSettings.ResumeLayout(false);
            this.NationsSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NationsSizeControl)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Navigation.ResumeLayout(false);
            this.CanvasHolder.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Canvas;
        private System.Windows.Forms.Panel ElevationSettings;
        private System.Windows.Forms.TrackBar StrengthControl;
        private System.Windows.Forms.Panel ToolsPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label StrengthLabel;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.TrackBar SizeControl;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.TrackBar HeightControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.Panel Navigation;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel CanvasHolder;
        private System.Windows.Forms.Button ZoomOut;
        private System.Windows.Forms.Button ZoomIn;
        private System.Windows.Forms.VScrollBar VerticalScroll;
        private System.Windows.Forms.HScrollBar HorizontalScroll;
        private System.Windows.Forms.FlowLayoutPanel LayerPane;
        private System.Windows.Forms.ComboBox LayerToAdd;
        private System.Windows.Forms.Button AddLayer;
        private System.Windows.Forms.Panel NationsSettings;
        private System.Windows.Forms.Label NationsSizeLabel;
        private System.Windows.Forms.TrackBar NationsSizeControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

