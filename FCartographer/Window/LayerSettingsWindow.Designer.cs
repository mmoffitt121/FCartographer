
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
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
            this.waterLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            this.contourRenderTab.SuspendLayout();
            this.gradientLightingTab.SuspendLayout();
            this.rayLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropOffSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).BeginInit();
            this.tabGroup.SuspendLayout();
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
            this.gradientLightingTab.Controls.Add(this.checkBox2);
            this.gradientLightingTab.Controls.Add(this.label5);
            this.gradientLightingTab.Location = new System.Drawing.Point(4, 24);
            this.gradientLightingTab.Name = "gradientLightingTab";
            this.gradientLightingTab.Padding = new System.Windows.Forms.Padding(3);
            this.gradientLightingTab.Size = new System.Drawing.Size(425, 520);
            this.gradientLightingTab.TabIndex = 1;
            this.gradientLightingTab.Text = "Gradient Lighting";
            this.gradientLightingTab.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(404, 6);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.UseVisualStyleBackColor = true;
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
            this.rayLightingTab.ResumeLayout(false);
            this.rayLightingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angleSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.directionSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dropOffSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.intensitySlider)).EndInit();
            this.tabGroup.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox checkBox2;
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
    }
}