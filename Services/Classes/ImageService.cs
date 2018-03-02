using Contracts.Classes;
using Services.Interfaces;
using DataAcquisition.Interfaces;
namespace Services.Classes
{
    public class ImageService : IImageService
    {
        private readonly IImageAcquisition _imageAcquisition;

        public ImageService(IImageAcquisition imageAcquisition)
        {
            _imageAcquisition = imageAcquisition;
        }

        public CameraImageResponse GetImage()
        {
            var cameraImageResponse = _imageAcquisition.GetImage();

            return cameraImageResponse;
        }
    }
}
