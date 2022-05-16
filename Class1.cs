using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.UI;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using System;
using System.ComponentModel;
using System.Data;

namespace WindowsFormsApp1
{
    class Class1
    {
        public static int TotalFrame, FrameNo;
        public static double Fps;
        public static bool IsReadingFrame;


        public static Image<Gray, Byte> ConvertGreyImage(Image<Bgr, Byte> My_Image)
        {
            Image<Gray, Byte> gray_image = My_Image.Convert<Gray, byte>();
            gray_image[0, 0] = new Gray(200);
            return gray_image;

        }
        public static Image<Bgr, Byte> Gamma(Image<Bgr, Byte> My_Image, double gamma)
        {
            My_Image._GammaCorrect(gamma);
            return My_Image;
        }
        public static Image<Bgr, Byte> Brightness(Image<Bgr, Byte> My_Image, double alfa, int beta)
        {
            return (My_Image.Mul(alfa) + beta);
        }
        public static Image<Bgr, Byte> Resize(Image<Bgr, Byte> My_Image, double alfa)
        {
            return (My_Image.Resize(alfa, Emgu.CV.CvEnum.Inter.Area));
        }
        public static Image<Bgr, Byte> Rotate(Image<Bgr, Byte> My_Image, int angle)
        {
            return My_Image.Rotate(angle, new Bgr(1, 1, 1));
        }
        public static Image<Bgr, Byte> ChangeRedChannel(Image<Bgr, Byte> image)
        {

            Image<Bgr, Byte> outputImage = new Image<Bgr, byte>(image.Size);
            image.CopyTo(outputImage);
            var data = outputImage.Data;
            for (int i = 0; i < outputImage.Width; i++)
            {
                for (int j = 0; j < outputImage.Height; j++)
                {
                    data[j, i, 0] = 0;
                    data[j, i, 1] = 0;
                }
            }
            return outputImage;

        }
        public static List<Image<Bgr, byte>> GetImage(string path, string searchPattern)
        {
            string[] FileNames = Directory.GetFiles(path, searchPattern);
            List<Image<Bgr, byte>> listImages = new List<Image<Bgr, byte>>();
            foreach (var file in FileNames)
            {
                listImages.Add(new Image<Bgr, byte>(file));
            }
            return listImages;
        }

        public static List<Bitmap> BlendingImage(List<Image<Bgr, byte>> listImages)
        {
            List<Bitmap> listImagesReturn = new List<Bitmap>();

            for (int i = 0; i < listImages.Count - 2; i++)
            {
                for (double alpha = 0.0; alpha <= 1.0; alpha += 0.01)
                {
                    listImagesReturn.Add(listImages[i + 1].AddWeighted(listImages[i], alpha, 1 - alpha, 0).AsBitmap());

                }
            }

            return listImagesReturn;

        }
        
    }
}
