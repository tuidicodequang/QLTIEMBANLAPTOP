namespace QLTIEMBANLAPTOP
{
    partial class ItemSanPham
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelTenSP = new System.Windows.Forms.Label();
            this.labelGiaSP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QLTIEMBANLAPTOP.Properties.Resources.gigabyteg5_png;
            this.pictureBox1.Location = new System.Drawing.Point(19, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(168, 138);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelTenSP
            // 
            this.labelTenSP.AutoSize = true;
            this.labelTenSP.Location = new System.Drawing.Point(34, 154);
            this.labelTenSP.Name = "labelTenSP";
            this.labelTenSP.Size = new System.Drawing.Size(44, 16);
            this.labelTenSP.TabIndex = 1;
            this.labelTenSP.Text = "label1";
            // 
            // labelGiaSP
            // 
            this.labelGiaSP.AutoSize = true;
            this.labelGiaSP.Location = new System.Drawing.Point(34, 184);
            this.labelGiaSP.Name = "labelGiaSP";
            this.labelGiaSP.Size = new System.Drawing.Size(44, 16);
            this.labelGiaSP.TabIndex = 2;
            this.labelGiaSP.Text = "label1";
            // 
            // ItemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelGiaSP);
            this.Controls.Add(this.labelTenSP);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ItemSanPham";
            this.Size = new System.Drawing.Size(216, 223);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTenSP;
        private System.Windows.Forms.Label labelGiaSP;
    }
}
