using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        public Form1()
        {
            InitializeComponent();
        }

        public object Openfile { get; private set; }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog Openfile = new OpenFileDialog();
            if (Openfile.ShowDialog() == DialogResult.OK)
            {
                My_Image = new Image<Bgr, byte>(Openfile.FileName);
                Image image = pictureBox1.Image = My_Image.ToBitmap();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
                
                gray_image = My_Image.Convert<Gray, byte>();
                pictureBox2.Image = gray_image.AsBitmap();
                gray_image[0, 0] = new Gray(200);
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HistogramViewer v = new HistogramViewer();
            v.HistogramCtrl.GenerateHistograms(My_Image, 255);
            v.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float alpha = float.Parse(textBox1.Text);
            float beta = float.Parse(textBox2.Text);
            imgOutput = new Image<Gray, Byte>(gray_image.Width, gray_image.Height);
            for (int i = 0; i < gray_image.Height; i++)
                for (int j = 0; j < gray_image.Width; j++)
                {
                    var formula = gray_image[i, j].Intensity * alpha + beta;
                    imgOutput[i, j] = new Gray(formula);
                }
            pictureBox3.Image = imgOutput.AsBitmap();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            float gamma = float.Parse(textBox3.Text);
            gamma__Picture = My_Image;
            gamma__Picture._GammaCorrect(gamma);
            pictureBox4.Image = gamma__Picture.AsBitmap();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            resized_image = new Image<Bgr, Byte>(My_Image.Width, My_Image.Height);
            resized_image = My_Image.Resize(256, 128, Emgu.CV.CvEnum.Inter.Nearest);
            pictureBox5.Image = resized_image.AsBitmap();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            rotate_image = new Image<Bgr, Byte>(My_Image.Width, My_Image.Height);
            rotate_image = My_Image.Rotate(90, new Bgr(255, 255, 255));
            pictureBox6.Image = rotate_image.AsBitmap();
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            string[] FileNames = Directory.GetFiles(@"C:\Users\Student\source\repos\WindowsFormsApp1", "*.png");
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            for (int i = 0; i < listImages.Count - 1; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    pictureBox7.Image = listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap();
                    await Task.Delay(25);
                }
            }

        }
    }
}
    

