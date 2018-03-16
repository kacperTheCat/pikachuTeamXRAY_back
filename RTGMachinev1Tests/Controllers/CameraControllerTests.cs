using Microsoft.VisualStudio.TestTools.UnitTesting;
using CameraControl.Areas.HelpPage.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using System.IO;
using Services.Classes;
using DataAcquisition.Interfaces;
using Contracts.Classes;
using FluentAssertions;
using DataAcquisition.Classes;

namespace CameraControl.Areas.HelpPage.Controllers.Tests
{
    [TestClass()]
    public class CameraControllerTests
    {
        private IImageService _imageService;
        private IImageAcquisition _imageAcquisition;
        private CameraController _cameraController;
        private MemoryStream stream;
        private Random rnd;
        [TestInitialize]
        public void Initialize()
        {

            _imageAcquisition = new ImageAcquisition();
            _imageService = new ImageService(_imageAcquisition);
            _cameraController = new CameraController(_imageService);
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

            CameraImageCaptureRequest cameraImageCaptureRequest1 = new CameraImageCaptureRequest();
            cameraImageCaptureRequest1.contrast = rnd.Next(0, 100);
            cameraImageCaptureRequest1.light = rnd.Next(0, 100);
            cameraImageCaptureRequest1.imageDate = DateTime.Now.ToShortDateString();
            cameraImageCaptureRequest1.imageTime = DateTime.Now.ToShortTimeString();
            int negative1 = rnd.Next(0, 1);
            if (negative1 == 1)
                cameraImageCaptureRequest1.negative = true;
            else
                cameraImageCaptureRequest1.negative = false;
            cameraImageCaptureRequest.patientName = "Ewa Kowalska";
            cameraImageCaptureRequest.userName = "Paweł Nowakowski";
            var result = _cameraController.GetXRAYImage(cameraImageCaptureRequest);
            RTGMachine.busy.Should().Be(true);
            var result1 = _cameraController.GetXRAYImage(cameraImageCaptureRequest1);
            result.Base64.Should().NotBeNull();
            result.errorMessage.Should().BeNull();
            result1.Base64.Should().BeNull();
            result1.errorMessage.Should().Be("Camera is busy");
            System.Threading.Thread.Sleep(10000);
            result1 = _cameraController.GetXRAYImage(cameraImageCaptureRequest1);
            result1.Base64.Should().NotBeNull();
            result1.errorMessage.Should().BeNull();
            //            Assert.Fail();
        }

        [TestMethod()]
        public void GetPerviewImageTest()
        {
            var result = _cameraController.GetPerviewImage();
            result.Should().NotBeNull();
            //Assert.Fail();
        }
    }
}