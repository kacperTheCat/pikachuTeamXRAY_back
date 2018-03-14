using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.Classes;
using DataAcquisition.Classes;
using DataAcquisition.Interfaces;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Classes;

namespace Tests.DataAcquisitionTests
{
    [TestClass]
    public class ImageAcquisitionTests
    {
        private IImageAcquisition _imageAcquisition;
        public Random rnd;
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
            cameraImageCaptureRequest.patientName = "Jan Kowalski";
            cameraImageCaptureRequest.userName = "Paweł Nowak";
            var result = _imageAcquisition.GetXRAYImage(cameraImageCaptureRequest);
            result.Should().NotBeNull();
        }

        //[TestMethod]
        //public void GetImageTest()
        //{
        //    var cameraImageResponse = new ImageService(_imageAcquisition);

        //    var result = cameraImageResponse.GetImage();
        //    var resultBase64Length = result.Base64.Length % 4;

        //    result.Base64.Should().NotBeNull();
        //    resultBase64Length.Should().Be(0);
        //}
    }
}
