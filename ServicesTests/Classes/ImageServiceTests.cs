using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;


namespace Services.Classes.Tests
{
    [TestClass()]
    public class ImageServiceTests
    {
       
        [TestMethod()]
        public void GreyscaleImageTest()
        {
            
           /* Bitmap image = new Bitmap(Image.FromFile(@"C:\Users\rymszmon\source\Converter\sadpepe.jpg"));
            Bitmap GreyImage = null;
            ImageService service = new ImageService(_imageAcquisition);
            service.image = service.GreyscaleImage(image);
            service.image.Should().NotBeNull();
            //Assert.Fail();*/
        }
    }
}