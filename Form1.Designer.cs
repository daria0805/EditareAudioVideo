﻿namespace WindowsFormsApp1
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
            this.LoadImage = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GreyImage = new System.Windows.Forms.Button();
            this.Histogram = new System.Windows.Forms.Button();
            this.alpha_textBox = new System.Windows.Forms.TextBox();
            this.beta_textBox = new System.Windows.Forms.TextBox();
            this.Brightness = new System.Windows.Forms.Button();
            this.Gamma = new System.Windows.Forms.Button();
            this.gamma_textBox = new System.Windows.Forms.TextBox();
            this.Resize = new System.Windows.Forms.Button();
            this.Rotate = new System.Windows.Forms.Button();
            this.BlendingImage = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.VideoCapture = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(76, 61);
            this.LoadImage.Margin = new System.Windows.Forms.Padding(4);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(147, 73);
            this.LoadImage.TabIndex = 0;
            this.LoadImage.Text = "LoadImage\r\n";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(474, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(798, 568);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // GreyImage
            // 
            this.GreyImage.Location = new System.Drawing.Point(76, 143);
            this.GreyImage.Margin = new System.Windows.Forms.Padding(4);
            this.GreyImage.Name = "GreyImage";
            this.GreyImage.Size = new System.Drawing.Size(147, 64);
            this.GreyImage.TabIndex = 2;
            this.GreyImage.Text = "GreyImage\r\n";
            this.GreyImage.UseVisualStyleBackColor = true;
            this.GreyImage.Click += new System.EventHandler(this.GreyImage_Click);
            // 
            // Histogram
            // 
            this.Histogram.Location = new System.Drawing.Point(76, 215);
            this.Histogram.Margin = new System.Windows.Forms.Padding(4);
            this.Histogram.Name = "Histogram";
            this.Histogram.Size = new System.Drawing.Size(147, 64);
            this.Histogram.TabIndex = 5;
            this.Histogram.Text = "Histogram";
            this.Histogram.UseVisualStyleBackColor = true;
            this.Histogram.Click += new System.EventHandler(this.Histogram_Click);
            // 
            // alpha_textBox
            // 
            this.alpha_textBox.Location = new System.Drawing.Point(74, 290);
            this.alpha_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.alpha_textBox.Name = "alpha_textBox";
            this.alpha_textBox.Size = new System.Drawing.Size(145, 22);
            this.alpha_textBox.TabIndex = 6;
            // 
            // beta_textBox
            // 
            this.beta_textBox.Location = new System.Drawing.Point(72, 320);
            this.beta_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.beta_textBox.Name = "beta_textBox";
            this.beta_textBox.Size = new System.Drawing.Size(145, 22);
            this.beta_textBox.TabIndex = 7;
            // 
            // Brightness
            // 
            this.Brightness.Location = new System.Drawing.Point(74, 347);
            this.Brightness.Margin = new System.Windows.Forms.Padding(4);
            this.Brightness.Name = "Brightness";
            this.Brightness.Size = new System.Drawing.Size(147, 60);
            this.Brightness.TabIndex = 8;
            this.Brightness.Text = "Brightness";
            this.Brightness.UseVisualStyleBackColor = true;
            this.Brightness.Click += new System.EventHandler(this.Brightness_Click);
            // 
            // Gamma
            // 
            this.Gamma.Location = new System.Drawing.Point(72, 445);
            this.Gamma.Margin = new System.Windows.Forms.Padding(4);
            this.Gamma.Name = "Gamma";
            this.Gamma.Size = new System.Drawing.Size(147, 60);
            this.Gamma.TabIndex = 9;
            this.Gamma.Text = "Gamma";
            this.Gamma.UseVisualStyleBackColor = true;
            this.Gamma.Click += new System.EventHandler(this.Gamma_Click);
            // 
            // gamma_textBox
            // 
            this.gamma_textBox.Location = new System.Drawing.Point(74, 415);
            this.gamma_textBox.Margin = new System.Windows.Forms.Padding(4);
            this.gamma_textBox.Name = "gamma_textBox";
            this.gamma_textBox.Size = new System.Drawing.Size(145, 22);
            this.gamma_textBox.TabIndex = 11;
            // 
            // Resize
            // 
            this.Resize.Location = new System.Drawing.Point(76, 529);
            this.Resize.Margin = new System.Windows.Forms.Padding(4);
            this.Resize.Name = "Resize";
            this.Resize.Size = new System.Drawing.Size(147, 58);
            this.Resize.TabIndex = 12;
            this.Resize.Text = "Resize\r\n";
            this.Resize.UseVisualStyleBackColor = true;
            this.Resize.Click += new System.EventHandler(this.Resize_Click);
            // 
            // Rotate
            // 
            this.Rotate.Location = new System.Drawing.Point(78, 604);
            this.Rotate.Margin = new System.Windows.Forms.Padding(4);
            this.Rotate.Name = "Rotate";
            this.Rotate.Size = new System.Drawing.Size(145, 57);
            this.Rotate.TabIndex = 14;
            this.Rotate.Text = "Rotate\r\n";
            this.Rotate.UseVisualStyleBackColor = true;
            this.Rotate.Click += new System.EventHandler(this.Rotate_Click);
            // 
            // BlendingImage
            // 
            this.BlendingImage.Location = new System.Drawing.Point(280, 61);
            this.BlendingImage.Margin = new System.Windows.Forms.Padding(4);
            this.BlendingImage.Name = "BlendingImage";
            this.BlendingImage.Size = new System.Drawing.Size(135, 73);
            this.BlendingImage.TabIndex = 16;
            this.BlendingImage.Text = "BlendingImage\r\n";
            this.BlendingImage.UseVisualStyleBackColor = true;
            this.BlendingImage.Click += new System.EventHandler(this.BlendingImage_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(280, 143);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(135, 64);
            this.button9.TabIndex = 17;
            this.button9.Text = "ChangeColorSpace";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.ChangeColorSpace_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "alpha=\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 320);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "beta=";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 415);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "gamma=";
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(278, 290);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(137, 64);
            this.button10.TabIndex = 21;
            this.button10.Text = "WritingToVideo\r\n";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.WritingToVideo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(796, 643);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 22;
            // 
            // VideoCapture
            // 
            this.VideoCapture.Location = new System.Drawing.Point(280, 215);
            this.VideoCapture.Name = "VideoCapture";
            this.VideoCapture.Size = new System.Drawing.Size(135, 64);
            this.VideoCapture.TabIndex = 23;
            this.VideoCapture.Text = "VideoCapture";
            this.VideoCapture.UseVisualStyleBackColor = true;
            this.VideoCapture.Click += new System.EventHandler(this.VideoCapture_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1637, 723);
            this.Controls.Add(this.VideoCapture);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.BlendingImage);
            this.Controls.Add(this.Rotate);
            this.Controls.Add(this.Resize);
            this.Controls.Add(this.gamma_textBox);
            this.Controls.Add(this.Gamma);
            this.Controls.Add(this.Brightness);
            this.Controls.Add(this.beta_textBox);
            this.Controls.Add(this.alpha_textBox);
            this.Controls.Add(this.Histogram);
            this.Controls.Add(this.GreyImage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoadImage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button GreyImage;
        private System.Windows.Forms.Button Histogram;
        private System.Windows.Forms.TextBox alpha_textBox;
        private System.Windows.Forms.TextBox beta_textBox;
        private System.Windows.Forms.Button Brightness;
        private System.Windows.Forms.Button Gamma;
        private System.Windows.Forms.TextBox gamma_textBox;
        private System.Windows.Forms.Button Resize;
        private System.Windows.Forms.Button Rotate;
        private System.Windows.Forms.Button BlendingImage;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button VideoCapture;
    }
}

