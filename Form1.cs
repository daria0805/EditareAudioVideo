﻿using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Image<Gray, byte> imgOutput;
        private Image<Bgr, Byte> My_Image;
        private Image<Gray, byte> gray_image;
        private Image<Bgr, Byte> gamma__Picture;
        private Image<Bgr, Byte> resized_image;
        private Image<Bgr, Byte>rotate_image;
        Rectangle rect; Point StartROI; bool MouseDown;

        public Form1()
        {
            InitializeComponent();
        }

        public object Openfile { get; private set; }


        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                Image image = pictureBox1.Image = My_Image.ToBitmap();

            }
        }

        private void GreyImage_Click(object sender, EventArgs e)
        {
                
                gray_image = My_Image.Convert<Gray, byte>();
                pictureBox1.Image = gray_image.AsBitmap();
                gray_image[0, 0] = new Gray(200);
                
        }

        private void Histogram_Click(object sender, EventArgs e)
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(My_Image, 255);
            v.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Brightness_Click(object sender, EventArgs e)
        {
            float alpha = float.Parse(this.alpha_textBox.Text);
            float beta = float.Parse(beta_textBox.Text);
            imgOutput = new Image<Gray, Byte>(gray_image.Width, gray_image.Height);
            for (int i = 0; i < gray_image.Height; i++)
                for (int j = 0; j < gray_image.Width; j++)
                {
                    var formula = gray_image[i, j].Intensity * alpha + beta;
                    imgOutput[i, j] = new Gray(formula);
                }
            pictureBox1.Image = imgOutput.AsBitmap();
        }

        private void Gamma_Click(object sender, EventArgs e)
        {
            float gamma = float.Parse(gamma_textBox.Text);
            gamma__Picture = My_Image;
            gamma__Picture._GammaCorrect(gamma);
            pictureBox1.Image = gamma__Picture.AsBitmap();

        }

        private void Resize_Click(object sender, EventArgs e)
        {
            
            resized_image = new Image<Bgr, Byte>(My_Image.Width, My_Image.Height);
            resized_image = My_Image.Resize(256, 128, Emgu.CV.CvEnum.Inter.Nearest);
            pictureBox1.Image = resized_image.AsBitmap();
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            rotate_image = new Image<Bgr, Byte>(My_Image.Width, My_Image.Height);
            rotate_image = My_Image.Rotate(90, new Bgr(255, 255, 255));
            pictureBox1.Image = rotate_image.AsBitmap();
        }

        private async void BlendingImage_Click(object sender, EventArgs e)
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\daria\Documents\GitHub\EditareAudioVideo", "*.png");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    pictureBox1.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }

        }

        private void ChangeColorSpace_Click(object sender, EventArgs e)
        {
            Image<Bgr, Byte> outputImage = new Image<Bgr, byte>(My_Image.Size);
            My_Image.CopyTo(outputImage);
            var data = outputImage.Data;
            for (int i = 0; i < outputImage.Width; i++)
            {
                for (int j = 0; j < outputImage.Height; j++)
                {
                    data[j, i, 0] = 0;
                    data[j, i, 1] = 0;
                }
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
            int height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
            rect = new Rectangle(Math.Min(StartROI.X, e.X),
            Math.Min(StartROI.Y, e.Y), width, height);
            Refresh();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
            if (pictureBox1.Image == null || rect == Rectangle.Empty)
            {
                return;
            }
            var img = new Bitmap(pictureBox1.Image).ToImage<Bgr, byte>();
            img.ROI = rect;
            var imgROI = img.Copy();
            pictureBox1.Image = imgROI.ToBitmap();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red, 1))
                {
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }

        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            StartROI = e.Location;
        }

        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;

        private void WritingToVideo_Click(object sender, EventArgs e)
        {
            VideoCapture capture = new VideoCapture(@"C:\Users\daria\Documents\GitHub\EditareAudioVideo");

            int Fourcc = Convert.ToInt32(capture.Get(CapProp.FourCC));
            int Width = Convert.ToInt32(capture.Get(CapProp.FrameWidth));
            int Height = Convert.ToInt32(capture.Get(CapProp.FrameHeight));
            var Fps = capture.Get(CapProp.Fps);
            var TotalFrame = capture.Get(CapProp.FrameCount);


            string destionpath = @"C:\Users\daria\Documents\GitHub\EditareAudioVideo\Do. Or do not. There is no try.mp4";
            using (VideoWriter writer = new VideoWriter(destionpath, Fourcc, Fps, new Size(Width, Height), true))
            {
                Image<Bgr, byte> logo = new Image<Bgr, byte>(@"C:\Users\daria\Documents\GitHub\EditareAudioVideo\logo.png");
                Mat m = new Mat();

                var FrameNo = 1;
                while (FrameNo < TotalFrame)
                {
                    capture.Read(m);
                    Image<Bgr, byte> img = m.ToImage<Bgr, byte>();
                    img.ROI = new Rectangle(Width - logo.Width - 30, 10, logo.Width, logo.Height);
                    logo.CopyTo(img);

                    img.ROI = Rectangle.Empty;

                    writer.Write(img.Mat);
                    FrameNo++;
                }
            }
        }

        private void VideoCapture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                capture = new VideoCapture(ofd.FileName);
                Mat m = new Mat();
                capture.Read(m);
                pictureBox1.Image = m.ToBitmap();

                TotalFrame = (int)capture.Get(CapProp.FrameCount);
                Fps = capture.Get(CapProp.Fps);
                FrameNo = 1;
                NumericUpDown numericUpDown1 = new NumericUpDown();

                numericUpDown1.Value = FrameNo;
                numericUpDown1.Minimum = 0;
                numericUpDown1.Maximum = TotalFrame;

            }

            if (capture == null)
            {
                return;
            }
            IsReadingFrame = true;
            ReadAllFrames();

        }

        private async void ReadAllFrames()
        {

            Mat m = new Mat();
            while (IsReadingFrame == true && FrameNo < TotalFrame)
            {
                FrameNo += 1;
                var mat = capture.QueryFrame();
                pictureBox1.Image = mat.ToBitmap();
                await Task.Delay(1000 / Convert.ToInt16(Fps));
                label4.Text = FrameNo.ToString() + "/" + TotalFrame.ToString();
            }
        }


    }
}
    

