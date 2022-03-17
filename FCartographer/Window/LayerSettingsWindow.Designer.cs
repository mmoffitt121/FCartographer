
namespace FCartographer.Window
{
    partial class LayerSettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.previewButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.waterLightingTab = new System.Windows.Forms.TabPage();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.wavesEnabled = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contourRenderTab = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gradientLightingTab = new System.Windows.Forms.TabPage();
            this.gColorPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.gFlattenDisplay = new System.Windows.Forms.Label();
            this.gDirectionDisplay = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gFlattenSlider = new System.Windows.Forms.TrackBar();
            this.label16 = new System.Windows.Forms.Label();
            this.gDirectionSlider = new System.Windows.Forms.TrackBar();
            this.gPersistanceDisplay = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.gPersistanceSlider = new System.Windows.Forms.TrackBar();
            this.gAmbientDisplay = new System.Windows.Forms.Label();
            this.gIntensityDisplay = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.gAmbientSlider = new System.Windows.Forms.TrackBar();
            this.label22 = new System.Windows.Forms.Label();
            this.gIntensitySlider = new System.Windows.Forms.TrackBar();
            this.gradientLightingEnabled = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rayLightingTab = new System.Windows.Forms.TabPage();
            this.rayColorPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.angleDisplay = new System.Windows.Forms.Label();
            this.directionDisplay = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.angleSlider = new System.Windows.Forms.TrackBar();
            this.label15 = new System.Windows.Forms.Label();
            this.directionSlider = new System.Windows.Forms.TrackBar();
            this.dropoffDisplay = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dropOffSlider = new System.Windows.Forms.TrackBar();
            this.ambientDisplay = new System.Windows.Forms.Label();
            this.intensityDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ambientSlider = new System.Windows.Forms.TrackBar();
            this.rayLightingEnabled = new System.Windows.Forms.CheckBox();
            this.enabledControl = new System.Windows.Forms.Label();
            this.lightIntensityLabel = new System.Windows.Forms.Label();
            this.intensitySlider = new System.Windows.Forms.TrackBar();
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.gVectorModeDisplay = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.gVectorModeSlider = new System.Windows.Forms.TrackBar();
            this.waterLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.contourRenderTab.SuspendLayout();
            this.gradientLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFlattenSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gDirectionSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPersistanceSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAmbientSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIntensitySlider)).BeginInit();
            this.rayLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropOffSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gVectorModeSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(16, 599);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 1;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(370, 599);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(289, 599);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Layer Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(341, 23);
            this.textBox1.TabIndex = 5;
            // 
            // waterLightingTab
            // 
            this.waterLightingTab.Controls.Add(this.trackBar4);
            this.waterLightingTab.Controls.Add(this.label12);
            this.waterLightingTab.Controls.Add(this.label11);
            this.waterLightingTab.Controls.Add(this.wavesEnabled);
            this.waterLightingTab.Controls.Add(this.label7);
            this.waterLightingTab.Location = new System.Drawing.Point(4, 24);
            this.waterLightingTab.Name = "waterLightingTab";
            this.waterLightingTab.Padding = new System.Windows.Forms.Padding(3);
            this.waterLightingTab.Size = new System.Drawing.Size(425, 520);
            this.waterLightingTab.TabIndex = 3;
            this.waterLightingTab.Text = "Water";
            this.waterLightingTab.UseVisualStyleBackColor = true;
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(82, 41);
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(306, 45);
            this.trackBar4.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(394, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(25, 15);
            this.label12.TabIndex = 8;
            this.label12.Text = "255";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 15);
            this.label11.TabIndex = 7;
            this.label11.Text = "Level";
            // 
            // wavesEnabled
            // 
            this.wavesEnabled.AutoSize = true;
            this.wavesEnabled.Location = new System.Drawing.Point(404, 6);
            this.wavesEnabled.Name = "wavesEnabled";
            this.wavesEnabled.Size = new System.Drawing.Size(15, 14);
            this.wavesEnabled.TabIndex = 6;
            this.wavesEnabled.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Enable Waves";
            // 
            // contourRenderTab
            // 
            this.contourRenderTab.Controls.Add(this.checkBox3);
            this.contourRenderTab.Controls.Add(this.label6);
            this.contourRenderTab.Location = new System.Drawing.Point(4, 24);
            this.contourRenderTab.Name = "contourRenderTab";
            this.contourRenderTab.Padding = new System.Windows.Forms.Padding(3);
            this.contourRenderTab.Size = new System.Drawing.Size(425, 520);
            this.contourRenderTab.TabIndex = 2;
            this.contourRenderTab.Text = "Contour Lines";
            this.contourRenderTab.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(404, 6);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(15, 14);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Enabled";
            // 
            // gradientLightingTab
            // 
            this.gradientLightingTab.Controls.Add(this.gVectorModeDisplay);
            this.gradientLightingTab.Controls.Add(this.label24);
            this.gradientLightingTab.Controls.Add(this.gVectorModeSlider);
            this.gradientLightingTab.Controls.Add(this.gColorPanel);
            this.gradientLightingTab.Controls.Add(this.label4);
            this.gradientLightingTab.Controls.Add(this.gFlattenDisplay);
            this.gradientLightingTab.Controls.Add(this.gDirectionDisplay);
            this.gradientLightingTab.Controls.Add(this.label13);
            this.gradientLightingTab.Controls.Add(this.gFlattenSlider);
            this.gradientLightingTab.Controls.Add(this.label16);
            this.gradientLightingTab.Controls.Add(this.gDirectionSlider);
            this.gradientLightingTab.Controls.Add(this.gPersistanceDisplay);
            this.gradientLightingTab.Controls.Add(this.label18);
            this.gradientLightingTab.Controls.Add(this.gPersistanceSlider);
            this.gradientLightingTab.Controls.Add(this.gAmbientDisplay);
            this.gradientLightingTab.Controls.Add(this.gIntensityDisplay);
            this.gradientLightingTab.Controls.Add(this.label21);
            this.gradientLightingTab.Controls.Add(this.gAmbientSlider);
            this.gradientLightingTab.Controls.Add(this.label22);
            this.gradientLightingTab.Controls.Add(this.gIntensitySlider);
            this.gradientLightingTab.Controls.Add(this.gradientLightingEnabled);
            this.gradientLightingTab.Controls.Add(this.label5);
            this.gradientLightingTab.Location = new System.Drawing.Point(4, 24);
            this.gradientLightingTab.Name = "gradientLightingTab";
            this.gradientLightingTab.Padding = new System.Windows.Forms.Padding(3);
            this.gradientLightingTab.Size = new System.Drawing.Size(425, 520);
            this.gradientLightingTab.TabIndex = 1;
            this.gradientLightingTab.Text = "Gradient Lighting";
            this.gradientLightingTab.UseVisualStyleBackColor = true;
            // 
            // gColorPanel
            // 
            this.gColorPanel.BackColor = System.Drawing.Color.DimGray;
            this.gColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gColorPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gColorPanel.Location = new System.Drawing.Point(327, 353);
            this.gColorPanel.Name = "gColorPanel";
            this.gColorPanel.Size = new System.Drawing.Size(85, 29);
            this.gColorPanel.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 15);
            this.label4.TabIndex = 35;
            this.label4.Text = "Color";
            // 
            // gFlattenDisplay
            // 
            this.gFlattenDisplay.AutoSize = true;
            this.gFlattenDisplay.Location = new System.Drawing.Point(380, 236);
            this.gFlattenDisplay.Name = "gFlattenDisplay";
            this.gFlattenDisplay.Size = new System.Drawing.Size(25, 15);
            this.gFlattenDisplay.TabIndex = 34;
            this.gFlattenDisplay.Text = "360";
            // 
            // gDirectionDisplay
            // 
            this.gDirectionDisplay.AutoSize = true;
            this.gDirectionDisplay.Location = new System.Drawing.Point(381, 185);
            this.gDirectionDisplay.Name = "gDirectionDisplay";
            this.gDirectionDisplay.Size = new System.Drawing.Size(25, 15);
            this.gDirectionDisplay.TabIndex = 33;
            this.gDirectionDisplay.Text = "360";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 236);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 15);
            this.label13.TabIndex = 32;
            this.label13.Text = "Angle";
            // 
            // gFlattenSlider
            // 
            this.gFlattenSlider.Location = new System.Drawing.Point(83, 236);
            this.gFlattenSlider.Maximum = 360;
            this.gFlattenSlider.Name = "gFlattenSlider";
            this.gFlattenSlider.Size = new System.Drawing.Size(266, 45);
            this.gFlattenSlider.TabIndex = 31;
            this.gFlattenSlider.TickFrequency = 0;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 185);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(55, 15);
            this.label16.TabIndex = 30;
            this.label16.Text = "Direction";
            // 
            // gDirectionSlider
            // 
            this.gDirectionSlider.Location = new System.Drawing.Point(83, 185);
            this.gDirectionSlider.Maximum = 360;
            this.gDirectionSlider.Name = "gDirectionSlider";
            this.gDirectionSlider.Size = new System.Drawing.Size(266, 45);
            this.gDirectionSlider.TabIndex = 29;
            this.gDirectionSlider.TickFrequency = 0;
            // 
            // gPersistanceDisplay
            // 
            this.gPersistanceDisplay.AutoSize = true;
            this.gPersistanceDisplay.Location = new System.Drawing.Point(380, 134);
            this.gPersistanceDisplay.Name = "gPersistanceDisplay";
            this.gPersistanceDisplay.Size = new System.Drawing.Size(32, 15);
            this.gPersistanceDisplay.TabIndex = 28;
            this.gPersistanceDisplay.Text = "10 %";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 134);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 15);
            this.label18.TabIndex = 27;
            this.label18.Text = "Persistence";
            // 
            // gPersistanceSlider
            // 
            this.gPersistanceSlider.Location = new System.Drawing.Point(83, 134);
            this.gPersistanceSlider.Maximum = 100;
            this.gPersistanceSlider.Name = "gPersistanceSlider";
            this.gPersistanceSlider.Size = new System.Drawing.Size(266, 45);
            this.gPersistanceSlider.TabIndex = 26;
            this.gPersistanceSlider.TickFrequency = 0;
            // 
            // gAmbientDisplay
            // 
            this.gAmbientDisplay.AutoSize = true;
            this.gAmbientDisplay.Location = new System.Drawing.Point(380, 83);
            this.gAmbientDisplay.Name = "gAmbientDisplay";
            this.gAmbientDisplay.Size = new System.Drawing.Size(25, 15);
            this.gAmbientDisplay.TabIndex = 25;
            this.gAmbientDisplay.Text = "255";
            // 
            // gIntensityDisplay
            // 
            this.gIntensityDisplay.AutoSize = true;
            this.gIntensityDisplay.Location = new System.Drawing.Point(381, 32);
            this.gIntensityDisplay.Name = "gIntensityDisplay";
            this.gIntensityDisplay.Size = new System.Drawing.Size(32, 15);
            this.gIntensityDisplay.TabIndex = 24;
            this.gIntensityDisplay.Text = "50 %";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 83);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 15);
            this.label21.TabIndex = 23;
            this.label21.Text = "Ambient";
            // 
            // gAmbientSlider
            // 
            this.gAmbientSlider.Location = new System.Drawing.Point(83, 83);
            this.gAmbientSlider.Maximum = 255;
            this.gAmbientSlider.Name = "gAmbientSlider";
            this.gAmbientSlider.Size = new System.Drawing.Size(266, 45);
            this.gAmbientSlider.TabIndex = 22;
            this.gAmbientSlider.TickFrequency = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 15);
            this.label22.TabIndex = 21;
            this.label22.Text = "Intensity";
            // 
            // gIntensitySlider
            // 
            this.gIntensitySlider.Location = new System.Drawing.Point(83, 32);
            this.gIntensitySlider.Maximum = 100;
            this.gIntensitySlider.Name = "gIntensitySlider";
            this.gIntensitySlider.Size = new System.Drawing.Size(266, 45);
            this.gIntensitySlider.TabIndex = 20;
            this.gIntensitySlider.TickFrequency = 0;
            // 
            // gradientLightingEnabled
            // 
            this.gradientLightingEnabled.AutoSize = true;
            this.gradientLightingEnabled.Location = new System.Drawing.Point(404, 6);
            this.gradientLightingEnabled.Name = "gradientLightingEnabled";
            this.gradientLightingEnabled.Size = new System.Drawing.Size(15, 14);
            this.gradientLightingEnabled.TabIndex = 4;
            this.gradientLightingEnabled.UseVisualStyleBackColor = true;
            this.gradientLightingEnabled.CheckedChanged += new System.EventHandler(this.gradientLightingEnabled_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Enabled";
            // 
            // rayLightingTab
            // 
            this.rayLightingTab.Controls.Add(this.rayColorPanel);
            this.rayLightingTab.Controls.Add(this.label9);
            this.rayLightingTab.Controls.Add(this.angleDisplay);
            this.rayLightingTab.Controls.Add(this.directionDisplay);
            this.rayLightingTab.Controls.Add(this.label14);
            this.rayLightingTab.Controls.Add(this.angleSlider);
            this.rayLightingTab.Controls.Add(this.label15);
            this.rayLightingTab.Controls.Add(this.directionSlider);
            this.rayLightingTab.Controls.Add(this.dropoffDisplay);
            this.rayLightingTab.Controls.Add(this.label3);
            this.rayLightingTab.Controls.Add(this.dropOffSlider);
            this.rayLightingTab.Controls.Add(this.ambientDisplay);
            this.rayLightingTab.Controls.Add(this.intensityDisplay);
            this.rayLightingTab.Controls.Add(this.label2);
            this.rayLightingTab.Controls.Add(this.ambientSlider);
            this.rayLightingTab.Controls.Add(this.rayLightingEnabled);
            this.rayLightingTab.Controls.Add(this.enabledControl);
            this.rayLightingTab.Controls.Add(this.lightIntensityLabel);
            this.rayLightingTab.Controls.Add(this.intensitySlider);
            this.rayLightingTab.Location = new System.Drawing.Point(4, 24);
            this.rayLightingTab.Name = "rayLightingTab";
            this.rayLightingTab.Padding = new System.Windows.Forms.Padding(3);
            this.rayLightingTab.Size = new System.Drawing.Size(425, 520);
            this.rayLightingTab.TabIndex = 0;
            this.rayLightingTab.Text = "Ray Lighting";
            this.rayLightingTab.UseVisualStyleBackColor = true;
            // 
            // rayColorPanel
            // 
            this.rayColorPanel.BackColor = System.Drawing.Color.DimGray;
            this.rayColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rayColorPanel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rayColorPanel.Location = new System.Drawing.Point(319, 289);
            this.rayColorPanel.Name = "rayColorPanel";
            this.rayColorPanel.Size = new System.Drawing.Size(85, 29);
            this.rayColorPanel.TabIndex = 19;
            this.rayColorPanel.Click += new System.EventHandler(this.rayColorPanel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "Color";
            // 
            // angleDisplay
            // 
            this.angleDisplay.AutoSize = true;
            this.angleDisplay.Location = new System.Drawing.Point(379, 238);
            this.angleDisplay.Name = "angleDisplay";
            this.angleDisplay.Size = new System.Drawing.Size(25, 15);
            this.angleDisplay.TabIndex = 16;
            this.angleDisplay.Text = "360";
            // 
            // directionDisplay
            // 
            this.directionDisplay.AutoSize = true;
            this.directionDisplay.Location = new System.Drawing.Point(380, 187);
            this.directionDisplay.Name = "directionDisplay";
            this.directionDisplay.Size = new System.Drawing.Size(25, 15);
            this.directionDisplay.TabIndex = 15;
            this.directionDisplay.Text = "360";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 238);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "Angle";
            // 
            // angleSlider
            // 
            this.angleSlider.Location = new System.Drawing.Point(82, 238);
            this.angleSlider.Maximum = 360;
            this.angleSlider.Name = "angleSlider";
            this.angleSlider.Size = new System.Drawing.Size(266, 45);
            this.angleSlider.TabIndex = 13;
            this.angleSlider.TickFrequency = 0;
            this.angleSlider.Scroll += new System.EventHandler(this.angleSlider_Scroll);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 187);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 15);
            this.label15.TabIndex = 12;
            this.label15.Text = "Direction";
            // 
            // directionSlider
            // 
            this.directionSlider.Location = new System.Drawing.Point(82, 187);
            this.directionSlider.Maximum = 360;
            this.directionSlider.Name = "directionSlider";
            this.directionSlider.Size = new System.Drawing.Size(266, 45);
            this.directionSlider.TabIndex = 11;
            this.directionSlider.TickFrequency = 0;
            this.directionSlider.Scroll += new System.EventHandler(this.directionSlider_Scroll);
            // 
            // dropoffDisplay
            // 
            this.dropoffDisplay.AutoSize = true;
            this.dropoffDisplay.Location = new System.Drawing.Point(379, 136);
            this.dropoffDisplay.Name = "dropoffDisplay";
            this.dropoffDisplay.Size = new System.Drawing.Size(32, 15);
            this.dropoffDisplay.TabIndex = 10;
            this.dropoffDisplay.Text = "10 %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Persistence";
            // 
            // dropOffSlider
            // 
            this.dropOffSlider.Location = new System.Drawing.Point(82, 136);
            this.dropOffSlider.Maximum = 100;
            this.dropOffSlider.Name = "dropOffSlider";
            this.dropOffSlider.Size = new System.Drawing.Size(266, 45);
            this.dropOffSlider.TabIndex = 8;
            this.dropOffSlider.TickFrequency = 0;
            this.dropOffSlider.Scroll += new System.EventHandler(this.dropOffSlider_Scroll);
            // 
            // ambientDisplay
            // 
            this.ambientDisplay.AutoSize = true;
            this.ambientDisplay.Location = new System.Drawing.Point(379, 85);
            this.ambientDisplay.Name = "ambientDisplay";
            this.ambientDisplay.Size = new System.Drawing.Size(25, 15);
            this.ambientDisplay.TabIndex = 7;
            this.ambientDisplay.Text = "255";
            // 
            // intensityDisplay
            // 
            this.intensityDisplay.AutoSize = true;
            this.intensityDisplay.Location = new System.Drawing.Point(380, 34);
            this.intensityDisplay.Name = "intensityDisplay";
            this.intensityDisplay.Size = new System.Drawing.Size(32, 15);
            this.intensityDisplay.TabIndex = 6;
            this.intensityDisplay.Text = "50 %";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ambient";
            // 
            // ambientSlider
            // 
            this.ambientSlider.Location = new System.Drawing.Point(82, 85);
            this.ambientSlider.Maximum = 255;
            this.ambientSlider.Name = "ambientSlider";
            this.ambientSlider.Size = new System.Drawing.Size(266, 45);
            this.ambientSlider.TabIndex = 4;
            this.ambientSlider.TickFrequency = 0;
            this.ambientSlider.Scroll += new System.EventHandler(this.ambientSlider_Scroll);
            // 
            // rayLightingEnabled
            // 
            this.rayLightingEnabled.AutoSize = true;
            this.rayLightingEnabled.Location = new System.Drawing.Point(404, 6);
            this.rayLightingEnabled.Name = "rayLightingEnabled";
            this.rayLightingEnabled.Size = new System.Drawing.Size(15, 14);
            this.rayLightingEnabled.TabIndex = 3;
            this.rayLightingEnabled.UseVisualStyleBackColor = true;
            this.rayLightingEnabled.CheckedChanged += new System.EventHandler(this.rayLightingEnabled_CheckedChanged);
            // 
            // enabledControl
            // 
            this.enabledControl.AutoSize = true;
            this.enabledControl.Location = new System.Drawing.Point(7, 4);
            this.enabledControl.Name = "enabledControl";
            this.enabledControl.Size = new System.Drawing.Size(49, 15);
            this.enabledControl.TabIndex = 2;
            this.enabledControl.Text = "Enabled";
            // 
            // lightIntensityLabel
            // 
            this.lightIntensityLabel.AutoSize = true;
            this.lightIntensityLabel.Location = new System.Drawing.Point(6, 34);
            this.lightIntensityLabel.Name = "lightIntensityLabel";
            this.lightIntensityLabel.Size = new System.Drawing.Size(52, 15);
            this.lightIntensityLabel.TabIndex = 1;
            this.lightIntensityLabel.Text = "Intensity";
            // 
            // intensitySlider
            // 
            this.intensitySlider.Location = new System.Drawing.Point(82, 34);
            this.intensitySlider.Maximum = 100;
            this.intensitySlider.Name = "intensitySlider";
            this.intensitySlider.Size = new System.Drawing.Size(266, 45);
            this.intensitySlider.TabIndex = 0;
            this.intensitySlider.TickFrequency = 0;
            this.intensitySlider.Scroll += new System.EventHandler(this.intensitySlider_Scroll);
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.rayLightingTab);
            this.tabGroup.Controls.Add(this.gradientLightingTab);
            this.tabGroup.Controls.Add(this.contourRenderTab);
            this.tabGroup.Controls.Add(this.waterLightingTab);
            this.tabGroup.Location = new System.Drawing.Point(12, 45);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.Size = new System.Drawing.Size(433, 548);
            this.tabGroup.TabIndex = 0;
            // 
            // gVectorModeDisplay
            // 
            this.gVectorModeDisplay.AutoSize = true;
            this.gVectorModeDisplay.Location = new System.Drawing.Point(379, 287);
            this.gVectorModeDisplay.Name = "gVectorModeDisplay";
            this.gVectorModeDisplay.Size = new System.Drawing.Size(25, 15);
            this.gVectorModeDisplay.TabIndex = 39;
            this.gVectorModeDisplay.Text = "360";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 287);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(38, 15);
            this.label24.TabIndex = 38;
            this.label24.Text = "Angle";
            // 
            // gVectorModeSlider
            // 
            this.gVectorModeSlider.Location = new System.Drawing.Point(82, 287);
            this.gVectorModeSlider.Maximum = 360;
            this.gVectorModeSlider.Name = "gVectorModeSlider";
            this.gVectorModeSlider.Size = new System.Drawing.Size(266, 45);
            this.gVectorModeSlider.TabIndex = 37;
            this.gVectorModeSlider.TickFrequency = 0;
            // 
            // LayerSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 634);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.tabGroup);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayerSettingsWindow";
            this.Text = "Layer Settings";
            this.waterLightingTab.ResumeLayout(false);
            this.waterLightingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            this.contourRenderTab.ResumeLayout(false);
            this.contourRenderTab.PerformLayout();
            this.gradientLightingTab.ResumeLayout(false);
            this.gradientLightingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gFlattenSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gDirectionSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gPersistanceSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gAmbientSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIntensitySlider)).EndInit();
            this.rayLightingTab.ResumeLayout(false);
            this.rayLightingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropOffSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).EndInit();
            this.tabGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gVectorModeSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TabPage waterLightingTab;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox wavesEnabled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage contourRenderTab;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage gradientLightingTab;
        private System.Windows.Forms.CheckBox gradientLightingEnabled;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage rayLightingTab;
        private System.Windows.Forms.Panel rayColorPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label angleDisplay;
        private System.Windows.Forms.Label directionDisplay;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TrackBar angleSlider;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar directionSlider;
        private System.Windows.Forms.Label dropoffDisplay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar dropOffSlider;
        private System.Windows.Forms.Label ambientDisplay;
        private System.Windows.Forms.Label intensityDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar ambientSlider;
        private System.Windows.Forms.CheckBox rayLightingEnabled;
        private System.Windows.Forms.Label enabledControl;
        private System.Windows.Forms.Label lightIntensityLabel;
        private System.Windows.Forms.TrackBar intensitySlider;
        private System.Windows.Forms.TabControl tabGroup;
        private System.Windows.Forms.Panel gColorPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label gFlattenDisplay;
        private System.Windows.Forms.Label gDirectionDisplay;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar gFlattenSlider;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TrackBar gDirectionSlider;
        private System.Windows.Forms.Label gPersistanceDisplay;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TrackBar gPersistanceSlider;
        private System.Windows.Forms.Label gAmbientDisplay;
        private System.Windows.Forms.Label gIntensityDisplay;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TrackBar gAmbientSlider;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TrackBar gIntensitySlider;
        private System.Windows.Forms.Label gVectorModeDisplay;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TrackBar gVectorModeSlider;
    }
}