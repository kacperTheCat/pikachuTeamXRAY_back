using Contracts.Classes;
using Contracts.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IImageService : ICameraImage
    {
        Bitmap FromBase64Converter(string image);       
        Bitmap GreyscaleImage(Bitmap image);
        string ToBase64Converter(byte[] imageBytes);
        Bitmap Negative(Bitmap image);
        
        Bitmap Brightness(Bitmap image, int brightness);
        Bitmap Contrast(Bitmap image, int contrast);

    }
}
