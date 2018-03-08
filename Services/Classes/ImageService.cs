using Contracts.Classes;
using Services.Interfaces;
using DataAcquisition.Interfaces;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Services.Classes
{
    public class ImageService : IImageService
    {
        private readonly IImageAcquisition _imageAcquisition;

        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }

        public CameraImageResponse GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = _imageAcquisition.GetXRAYImage(cameraImageCaptureRequest);
            string base64image = cameraImageResponse.Base64;
            MemoryStream stream = new MemoryStream();

            GreyscaleImage(FromBase64Converter(base64image)).Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageStreamByteArray = stream.ToArray();
            cameraImageResponse.Base64 = ToBase64Converter(imageStreamByteArray);
            return cameraImageResponse;

        }

        public CameraImageResponse GetPerviewImage()
        {
            var cameraImageResponse = _imageAcquisition.GetPerviewImage();

            return cameraImageResponse;
        }


        public string ToBase64Converter(byte[] imageBytes)
        {
            string base64string = System.Convert.ToBase64String(imageBytes);
            return base64string;
        }
        public Bitmap GreyscaleImage(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int greyColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    pixelColor = Color.FromArgb(greyColor, greyColor, greyColor);
                    image.SetPixel(x, y, pixelColor);

                }
            }
            return image;
        }
        public Bitmap BlackAndWhiteImage(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    int BWColor;
                    if ((pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 115)
                        BWColor = 255;
                    else
                        BWColor = 0;
                    pixelColor = Color.FromArgb(BWColor, BWColor, BWColor);

                    image.SetPixel(x, y, pixelColor);

                }
            }
            return image;
        }
        public Bitmap FromBase64Converter(string image)
        {
            byte[] imageBytes = System.Convert.FromBase64String(image);
            Bitmap convertedImage;
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                convertedImage = new Bitmap(ms);
            }
            return convertedImage;
        }
    }
}
