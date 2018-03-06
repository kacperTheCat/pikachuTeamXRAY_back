using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        [TestInitialize]
        public void Initialize()
        {
            _imageAcquisition = new ImageAcquisition();
        }

        [TestMethod]
        public void GetImageTest()
        {
            var cameraImageResponse = new ImageService(_imageAcquisition);

            var result = cameraImageResponse.GetImage();
            var resultBase64Length = result.Base64.Length % 4;

            result.Base64.Should().NotBeNull();
            resultBase64Length.Should().Be(0);
        }
    }
}
