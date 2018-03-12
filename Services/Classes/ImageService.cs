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
        public Bitmap image;
        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }

        public CameraImageResponse GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            
                var cameraImageResponse = _imageAcquisition.GetXRAYImage(cameraImageCaptureRequest);
                string base64image = cameraImageResponse.Base64;
                MemoryStream stream = new MemoryStream();

                int brightness = cameraImageCaptureRequest.light;
                int contrast = cameraImageCaptureRequest.contrast;
                if(cameraImageCaptureRequest.negative == true)
                {
                    Negative(Brightness(Contrast(GreyscaleImage(FromBase64Converter(base64image)), contrast), brightness)).Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    Brightness(Contrast(GreyscaleImage(FromBase64Converter(base64image)), contrast), brightness).Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                
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
        public Bitmap MedianFilter(Bitmap image)
        {
            Color temp;
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                   // Color imagepixel = image.GetPixel(x, y);
                    Color[] pixelColors = { image.GetPixel(x-1, y-1), image.GetPixel(x, y-1), image.GetPixel(x+1, y-1),
                                            image.GetPixel(x-1, y), image.GetPixel(x, y), image.GetPixel(x+1, y),
                                            image.GetPixel(x-1, y+1), image.GetPixel(x, y+1), image.GetPixel(x+1, y+1)};
                    for(int p=0; p<9; p++)
                    {
                        for(int k=0; k<9; k++)
                        {
                            if(k!=0)
                            {
                                if (pixelColors[k - 1].A < pixelColors[k].A)
                                {
                                    temp = pixelColors[k - 1];
                                    pixelColors[k - 1] = pixelColors[k];                                  
                                    pixelColors[k] = temp;
                                }
                                   
                            }                                

                        }
                        
                    }
                    image.SetPixel(x, y, pixelColors[4]);   
                }
            }
            return image;
        }
        public Bitmap Negative(Bitmap image)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    color = Color.FromArgb(255 - color.R, 255-color.G, 255-color.B);
                    image.SetPixel(x, y, color);
                    //pixelColor = Color.FromArgb(greyColor, greyColor, greyColor);
                    
                }
            }
                    return image;
        }
        public Bitmap Brightness(Bitmap image, int brightness)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = image.GetPixel(x, y);
                    color = Color.FromArgb((int)Truncate(color.R + brightness), (int)Truncate(color.G + brightness), (int)Truncate(color.B + brightness));
                    image.SetPixel(x, y, color);
                }
            }
            return image;
        }
        public Bitmap Contrast(Bitmap image, double contrast)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    double factor = (259.0 * (contrast + 255.0)) / (255.0 * (259.0 - contrast));
                    Color color = image.GetPixel(x, y);
                    double newRed = Truncate((factor * (color.R - 128) + 128));
                    double newGreen = Truncate((factor * (color.G - 128) + 128));
                    double newBlue = Truncate((factor * (color.B - 128) + 128));
                    color = Color.FromArgb((int)newRed, (int)newGreen, (int)newBlue);
                    image.SetPixel(x, y, color);
                }
            }
            return image;
        }

        double Truncate(double value)
        {
            if (value < 0) return 0;
            if (value > 255) return 255;

            return value;
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
