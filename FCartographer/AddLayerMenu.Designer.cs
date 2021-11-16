
namespace FCartographer
{
    partial class AddLayerMenu
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
            this.NameOfNewLayer = new System.Windows.Forms.TextBox();
            this.LayerToAdd = new System.Windows.Forms.ComboBox();
            this.NewLayerNameLabel = new System.Windows.Forms.Label();
            this.NewLayerTypeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.65371F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.08127F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 69.61131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.65371F));
            this.tableLayoutPanel1.Controls.Add(this.NameOfNewLayer, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.LayerToAdd, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.NewLayerNameLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.NewLayerTypeLabel, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 155F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 12F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 261);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NameOfNewLayer
            // 
            this.NameOfNewLayer.BackColor = System.Drawing.Color.NavajoWhite;
            this.NameOfNewLayer.ForeColor = System.Drawing.Color.DarkRed;
            this.NameOfNewLayer.Location = new System.Drawing.Point(73, 43);
            this.NameOfNewLayer.Name = "NameOfNewLayer";
            this.NameOfNewLayer.Size = new System.Drawing.Size(191, 23);
            this.NameOfNewLayer.TabIndex = 0;
            this.NameOfNewLayer.Text = "NewLayer";
            // 
            // LayerToAdd
            // 
            this.LayerToAdd.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.LayerToAdd.FormattingEnabled = true;
            this.LayerToAdd.Items.AddRange(new object[] {
            "Terrain",
            "Nations"});
            this.LayerToAdd.Location = new System.Drawing.Point(73, 17);
            this.LayerToAdd.Name = "LayerToAdd";
            this.LayerToAdd.Size = new System.Drawing.Size(191, 23);
            this.LayerToAdd.TabIndex = 4;
            this.LayerToAdd.Text = "Nations";
            // 
            // NewLayerNameLabel
            // 
            this.NewLayerNameLabel.AutoSize = true;
            this.NewLayerNameLabel.Location = new System.Drawing.Point(19, 46);
            this.NewLayerNameLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.NewLayerNameLabel.Name = "NewLayerNameLabel";
            this.NewLayerNameLabel.Size = new System.Drawing.Size(39, 15);
            this.NewLayerNameLabel.TabIndex = 5;
            this.NewLayerNameLabel.Text = "Name";
            // 
            // NewLayerTypeLabel
            // 
            this.NewLayerTypeLabel.AutoSize = true;
            this.NewLayerTypeLabel.Location = new System.Drawing.Point(19, 20);
            this.NewLayerTypeLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.NewLayerTypeLabel.Name = "NewLayerTypeLabel";
            this.NewLayerTypeLabel.Size = new System.Drawing.Size(31, 15);
            this.NewLayerTypeLabel.TabIndex = 1;
            this.NewLayerTypeLabel.Text = "Type";
            // 
            // AddLayerMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AddLayerMenu";
            this.Text = "Add Layer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox NameOfNewLayer;
        private System.Windows.Forms.Label NewLayerTypeLabel;
        private System.Windows.Forms.ComboBox LayerToAdd;
        private System.Windows.Forms.Label NewLayerNameLabel;
    }
}