
namespace KaretniHra
{
    partial class Form1
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
            this.pictureBoxBalik = new System.Windows.Forms.PictureBox();
            this.pictureBoxHrane = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalik)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHrane)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBalik
            // 
            this.pictureBoxBalik.Image = global::KaretniHra.Properties.Resources.zada;
            this.pictureBoxBalik.Location = new System.Drawing.Point(700, 200);
            this.pictureBoxBalik.Name = "pictureBoxBalik";
            this.pictureBoxBalik.Size = new System.Drawing.Size(100, 150);
            this.pictureBoxBalik.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBalik.TabIndex = 13;
            this.pictureBoxBalik.TabStop = false;
            this.pictureBoxBalik.Click += new System.EventHandler(this.LiznutiKarty);
            // 
            // pictureBoxHrane
            // 
            this.pictureBoxHrane.Location = new System.Drawing.Point(500, 200);
            this.pictureBoxHrane.Name = "pictureBoxHrane";
            this.pictureBoxHrane.Size = new System.Drawing.Size(100, 150);
            this.pictureBoxHrane.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxHrane.TabIndex = 14;
            this.pictureBoxHrane.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.pictureBoxHrane);
            this.Controls.Add(this.pictureBoxBalik);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBalik)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHrane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBoxBalik;
        private System.Windows.Forms.PictureBox pictureBoxHrane;
    }
}

