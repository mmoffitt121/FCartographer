
namespace FCartographer.Window
{
    partial class LandscapeGeneratorWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.seedLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.seedBox = new System.Windows.Forms.TextBox();
            this.randomSeedButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.MaxHeightField = new System.Windows.Forms.TextBox();
            this.MinHeightField = new System.Windows.Forms.TextBox();
            this.MinHeightLabel = new System.Windows.Forms.Label();
            this.MaxHeightLabel = new System.Windows.Forms.Label();
            this.layerNameField = new System.Windows.Forms.TextBox();
            this.layerNameLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 705F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.seedLabel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.layerNameField, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.layerNameLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.4359F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.5641F));
            this.tableLayoutPanel3.Controls.Add(this.GenerateButton, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(85, 456);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(705, 32);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(513, 3);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(189, 26);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // seedLabel
            // 
            this.seedLabel.AutoSize = true;
            this.seedLabel.Location = new System.Drawing.Point(13, 205);
            this.seedLabel.Margin = new System.Windows.Forms.Padding(3);
            this.seedLabel.Name = "seedLabel";
            this.seedLabel.Size = new System.Drawing.Size(32, 15);
            this.seedLabel.TabIndex = 2;
            this.seedLabel.Text = "Seed";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.58405F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.415955F));
            this.tableLayoutPanel4.Controls.Add(this.seedBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.randomSeedButton, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(85, 202);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(702, 29);
            this.tableLayoutPanel4.TabIndex = 4;
            // 
            // seedBox
            // 
            this.seedBox.Location = new System.Drawing.Point(3, 3);
            this.seedBox.Name = "seedBox";
            this.seedBox.Size = new System.Drawing.Size(665, 23);
            this.seedBox.TabIndex = 1;
            // 
            // randomSeedButton
            // 
            this.randomSeedButton.Location = new System.Drawing.Point(674, 3);
            this.randomSeedButton.Name = "randomSeedButton";
            this.randomSeedButton.Size = new System.Drawing.Size(25, 23);
            this.randomSeedButton.TabIndex = 3;
            this.randomSeedButton.Text = "R";
            this.randomSeedButton.UseVisualStyleBackColor = true;
            this.randomSeedButton.Click += new System.EventHandler(this.randomSeedButton_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Controls.Add(this.MaxHeightField, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.MinHeightField, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.MinHeightLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.MaxHeightLabel, 2, 0);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(85, 170);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(702, 32);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // MaxHeightField
            // 
            this.MaxHeightField.Location = new System.Drawing.Point(528, 3);
            this.MaxHeightField.Name = "MaxHeightField";
            this.MaxHeightField.Size = new System.Drawing.Size(171, 23);
            this.MaxHeightField.TabIndex = 0;
            this.MaxHeightField.Text = "255";
            // 
            // MinHeightField
            // 
            this.MinHeightField.Location = new System.Drawing.Point(178, 3);
            this.MinHeightField.Name = "MinHeightField";
            this.MinHeightField.Size = new System.Drawing.Size(169, 23);
            this.MinHeightField.TabIndex = 1;
            this.MinHeightField.Text = "0";
            // 
            // MinHeightLabel
            // 
            this.MinHeightLabel.AutoSize = true;
            this.MinHeightLabel.Location = new System.Drawing.Point(3, 3);
            this.MinHeightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.MinHeightLabel.Name = "MinHeightLabel";
            this.MinHeightLabel.Size = new System.Drawing.Size(99, 15);
            this.MinHeightLabel.TabIndex = 2;
            this.MinHeightLabel.Text = "Minimum Height";
            // 
            // MaxHeightLabel
            // 
            this.MaxHeightLabel.AutoSize = true;
            this.MaxHeightLabel.Location = new System.Drawing.Point(353, 3);
            this.MaxHeightLabel.Margin = new System.Windows.Forms.Padding(3);
            this.MaxHeightLabel.Name = "MaxHeightLabel";
            this.MaxHeightLabel.Size = new System.Drawing.Size(101, 15);
            this.MaxHeightLabel.TabIndex = 3;
            this.MaxHeightLabel.Text = "Maximum Height";
            // 
            // layerNameField
            // 
            this.layerNameField.Location = new System.Drawing.Point(88, 13);
            this.layerNameField.Name = "layerNameField";
            this.layerNameField.Size = new System.Drawing.Size(699, 23);
            this.layerNameField.TabIndex = 6;
            this.layerNameField.Text = "NewLayer";
            // 
            // layerNameLabel
            // 
            this.layerNameLabel.AutoSize = true;
            this.layerNameLabel.Location = new System.Drawing.Point(13, 13);
            this.layerNameLabel.Margin = new System.Windows.Forms.Padding(3);
            this.layerNameLabel.Name = "layerNameLabel";
            this.layerNameLabel.Size = new System.Drawing.Size(39, 15);
            this.layerNameLabel.TabIndex = 7;
            this.layerNameLabel.Text = "Name";
            // 
            // LandscapeGeneratorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LandscapeGeneratorWindow";
            this.Text = "LandscapeGeneratorWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button GenerateButton;
        private System.Windows.Forms.TextBox seedBox;
        private System.Windows.Forms.Label seedLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button randomSeedButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TextBox MaxHeightField;
        private System.Windows.Forms.TextBox MinHeightField;
        private System.Windows.Forms.Label MinHeightLabel;
        private System.Windows.Forms.Label MaxHeightLabel;
        private System.Windows.Forms.TextBox layerNameField;
        private System.Windows.Forms.Label layerNameLabel;
    }
}