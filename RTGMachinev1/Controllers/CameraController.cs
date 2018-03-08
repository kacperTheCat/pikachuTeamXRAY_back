﻿using System.Web.Http;
using Services.Interfaces;
using Contracts.Classes;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace CameraControl.Areas.HelpPage.Controllers
{
    public class CameraController : ApiController
    {
        private readonly IImageService _imageService;

        public CameraController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/Camera
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public CameraImageResponse GetPerview()
        {
            var cameraImageResponse = _imageService.GetPerview();

            return cameraImageResponse;
        }

        [HttpPost]
        [Route("api/Camera/Capture")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public CameraImageResponse GetImage([FromBody]CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            var cameraImageResponse = _imageService.GetImage(cameraImageCaptureRequest);
            return cameraImageResponse;
        }

        //Filtry obrazu
        //TODO: podzielic, filtry
        //bool BlackAndWhite = false, Greyscale = false, changeColor = false;
        //    for (int x = 0; x < bitmap.Width; x++)
        //    {
        //        for (int y = 0; y < bitmap.Height; y++)
        //        {
        //            if (changeColor == true)
        //            {
        //                Color pixelColor = bitmap.GetPixel(x, y);
        //                if (BlackAndWhite == true)
        //                {
        //                    int BWColor;
        //                    if ((pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 115)
        //                        BWColor = 255;
        //                    else
        //                        BWColor = 0;
        //                    pixelColor = Color.FromArgb(BWColor, BWColor, BWColor);
        //                }
        //                if (Greyscale == true)
        //                {
        //                    int greyColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
        //                    pixelColor = Color.FromArgb(greyColor, greyColor, greyColor);
        //                }

        //                bitmap.SetPixel(x, y, pixelColor);
        //            }


        //        }
        //    }

    }
}
