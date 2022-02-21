
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
            this.tabGroup = new System.Windows.Forms.TabControl();
            this.rayLightingTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.ambientDisplay = new System.Windows.Forms.Label();
            this.intensityDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.enabledControl = new System.Windows.Forms.Label();
            this.lightIntensityLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.gradientLightingTab = new System.Windows.Forms.TabPage();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contourRenderTab = new System.Windows.Forms.TabPage();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.previewButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabGroup.SuspendLayout();
            this.rayLightingTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.gradientLightingTab.SuspendLayout();
            this.contourRenderTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGroup
            // 
            this.tabGroup.Controls.Add(this.rayLightingTab);
            this.tabGroup.Controls.Add(this.gradientLightingTab);
            this.tabGroup.Controls.Add(this.contourRenderTab);
            this.tabGroup.Controls.Add(this.tabPage1);
            this.tabGroup.Location = new System.Drawing.Point(12, 45);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.SelectedIndex = 0;
            this.tabGroup.Size = new System.Drawing.Size(433, 548);
            this.tabGroup.TabIndex = 0;
            // 
            // rayLightingTab
            // 
            this.rayLightingTab.Controls.Add(this.label9);
            this.rayLightingTab.Controls.Add(this.label8);
            this.rayLightingTab.Controls.Add(this.label4);
            this.rayLightingTab.Controls.Add(this.label3);
            this.rayLightingTab.Controls.Add(this.trackBar3);
            this.rayLightingTab.Controls.Add(this.ambientDisplay);
            this.rayLightingTab.Controls.Add(this.intensityDisplay);
            this.rayLightingTab.Controls.Add(this.label2);
            this.rayLightingTab.Controls.Add(this.trackBar2);
            this.rayLightingTab.Controls.Add(this.checkBox1);
            this.rayLightingTab.Controls.Add(this.enabledControl);
            this.rayLightingTab.Controls.Add(this.lightIntensityLabel);
            this.rayLightingTab.Controls.Add(this.trackBar1);
            this.rayLightingTab.Location = new System.Drawing.Point(4, 24);
            this.rayLightingTab.Name = "rayLightingTab";
            this.rayLightingTab.Padding = new System.Windows.Forms.Padding(3);
            this.rayLightingTab.Size = new System.Drawing.Size(425, 520);
            this.rayLightingTab.TabIndex = 0;
            this.rayLightingTab.Text = "Ray Lighting";
            this.rayLightingTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(379, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "10 %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dropoff";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(82, 136);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(266, 45);
            this.trackBar3.TabIndex = 8;
            this.trackBar3.TickFrequency = 5;
            // 
            // ambientDisplay
            // 
            this.ambientDisplay.AutoSize = true;
            this.ambientDisplay.Location = new System.Drawing.Point(379, 85);
            this.ambientDisplay.Name = "ambientDisplay";
            this.ambientDisplay.Size = new System.Drawing.Size(32, 15);
            this.ambientDisplay.TabIndex = 7;
            this.ambientDisplay.Text = "20 %";
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
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(82, 85);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(266, 45);
            this.trackBar2.TabIndex = 4;
            this.trackBar2.TickFrequency = 5;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(404, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.UseVisualStyleBackColor = true;
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
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(82, 34);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(266, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.TickFrequency = 5;
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 520);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(404, 6);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(15, 14);
            this.checkBox4.TabIndex = 6;
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 4);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 15);
            this.label7.TabIndex = 5;
            this.label7.Text = "Enabled";
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(16, 599);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 1;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(370, 599);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(289, 599);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Direction";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 247);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Angle";
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
            this.Name = "LayerSettingsWindow";
            this.Text = "Layer Settings";
            this.tabGroup.ResumeLayout(false);
            this.rayLightingTab.ResumeLayout(false);
            this.rayLightingTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.gradientLightingTab.ResumeLayout(false);
            this.gradientLightingTab.PerformLayout();
            this.contourRenderTab.ResumeLayout(false);
            this.contourRenderTab.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabGroup;
        private System.Windows.Forms.TabPage rayLightingTab;
        private System.Windows.Forms.TabPage gradientLightingTab;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lightIntensityLabel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label enabledControl;
        private System.Windows.Forms.Label ambientDisplay;
        private System.Windows.Forms.Label intensityDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TabPage contourRenderTab;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}