using DataAcquisition.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using System.Drawing.Imaging;
using Contracts.Classes;
using DataAcquisition.Classes;

namespace Services.Classes.Tests
{
    [TestClass()]
    public class ImageServiceTests
    {
        private IImageService _imageService;
        private IImageAcquisition _imageAcquisition;
        private MemoryStream stream;
        private Random rnd;
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
            _imageService = new ImageService(_imageAcquisition);
        }
        [TestMethod()]
        public void GetXRAYImageTest()
        {
            rnd = new Random();
            CameraImageCaptureRequest cameraImageCaptureRequest = new CameraImageCaptureRequest();
            cameraImageCaptureRequest.contrast = rnd.Next(0, 100);
            cameraImageCaptureRequest.light = rnd.Next(0, 100);
            cameraImageCaptureRequest.imageDate = DateTime.Now.ToShortDateString();
            cameraImageCaptureRequest.imageTime = DateTime.Now.ToShortTimeString();
            int negative = rnd.Next(0, 1);
            if (negative == 1)
                cameraImageCaptureRequest.negative = true;
            else
                cameraImageCaptureRequest.negative = false;
            cameraImageCaptureRequest.patientName = "Jan Kowalski";
            cameraImageCaptureRequest.userName = "Paweł Nowak";
            var result = _imageService.GetXRAYImage(cameraImageCaptureRequest);
            result.Should().NotBeNull();
            //            Assert.Fail();
        }

        [TestMethod()]
        public void FromBase64ConverterTest()
        {
            string file = File.ReadAllText(@"C: \Users\rymszmon\source\Converter\sadpepe.txt");
            Bitmap image;
            image = _imageService.FromBase64Converter(file);
            image.Should().NotBeNull();
            //Assert.Fail();
        }

        [TestMethod()]
        public void ToBase64ConverterTest()
        {
            stream = new MemoryStream();
            Bitmap image = new Bitmap(@"C: \Users\rymszmon\source\Converter\sadpepe.jpg");
            image.Save(stream, ImageFormat.Bmp);

            byte[] imageBytes = stream.ToArray();
            string result = _imageService.ToBase64Converter(imageBytes);
            int l1 = result.Length;

            result.Should().NotBeNull();
            //            Assert.Fail();
        }

        [TestMethod()]
        public void GetPreviewImageTest()
        {
            var result = _imageService.GetPreviewImage();
            result.Should().NotBeNull();
//            Assert.Fail();
        }
    }
}