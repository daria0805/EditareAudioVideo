using Emgu.CV;
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
        int TotalFrame, FrameNo;
        double Fps;
        bool IsReadingFrame;
        VideoCapture capture;
        private object beta_textbox;
        private object numericUpDown1;

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

            pictureBox1.Image = Class1.ConvertGreyImage(My_Image).AsBitmap();
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
            string a = alpha_textBox.Text;
            float alfa = float.Parse(a);
            a = beta_textBox.Text;
            int beta = int.Parse(a);
            pictureBox1.Image = Class1.Brightness(My_Image, alfa, beta).AsBitmap();
        }

        private void Gamma_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Class1.Gamma(My_Image, 20).AsBitmap();

        }

        private void Resize_Click(object sender, EventArgs e)
        {

            pictureBox1.Image = Class1.Resize(My_Image, 2).AsBitmap();
        }

        private void Rotate_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = (Class1.Rotate(My_Image, 90)).AsBitmap();
        }

        private async void BlendingImage_Click(object sender, EventArgs e)
        {
            List<Image<Bgr, byte>> listImages = Class1.GetImage(@"C:\Users\daria\Documents\GitHub\EditareAudioVideo", "*.png");

            List<Bitmap> listImagesReturn = Class1.BlendingImage(listImages);

            for (int i = 0; i < listImagesReturn.Count; i++)
            {
                pictureBox1.Image = listImagesReturn[i];
                await Task.Delay(25);

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

        private void ChangeRedChannel_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Class1.ChangeRedChannel(My_Image).AsBitmap();
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