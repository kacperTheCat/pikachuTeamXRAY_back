using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAcquisition.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcquisition.Interfaces;
using Contracts.Classes;
using FluentAssertions;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace DataAcquisition.Classes.Tests
{
    [TestClass()]
    public class ImageAcquisitionTests
    {
        private IImageAcquisition _imageAcquisition;
        private Random rnd;
        private MemoryStream stream;
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
        }

        [TestMethod]
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

           
            var result = _imageAcquisition.GetXRAYImage(cameraImageCaptureRequest);
            
            result.Base64.Should().NotBeNull();
            result.errorMessage.Should().BeNull();
           
        }

        [TestMethod()]
        public void GetPreviewImageTest()
        {

            var result = _imageAcquisition.GetPreviewImage();
            result.Should().NotBeNull();
        }

        [TestMethod()]
        public void ConvertToBase64Test()
        {
            stream = new MemoryStream();
            Bitmap image = new Bitmap(@"C: \Users\rymszmon\source\webapi\sadpepe.jpg");
            image.Save(stream, ImageFormat.Bmp);

            byte[] imageBytes = stream.ToArray();
            string result = _imageAcquisition.ConvertToBase64(imageBytes);
            int l1 = result.Length;
            
            result.Should().NotBeNull();
         /*   //FileInfo file = new FileInfo(@"C: \Users\rymszmon\source\Converter\sadpepe.txt");
            string file = File.ReadAllText(@"C: \Users\rymszmon\source\Converter\base64String.bs64");
            int l2 = file.Length;
            if (result.Length != file.Length)
                Assert.Fail();*/
        }
    }

}