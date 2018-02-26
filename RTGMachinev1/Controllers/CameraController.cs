using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using AForge;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging.Filters;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Web.Hosting;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace CameraControl.Areas.HelpPage.Controllers
{
    public class CameraController : ApiController
    {
        MemoryStream stream = new MemoryStream();
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public Bitmap bitmap;
        // GET: api/Camera
        public HttpResponseMessage Get()
        {            
            var result = new HttpResponseMessage(HttpStatusCode.OK);            
          
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();          

            videoSource.WaitForStop();
          
            result.Content = new ByteArrayContent(stream.ToArray());
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            bool BlackAndWhite = false, Greyscale = false, changeColor = false;
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    if (changeColor == true)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        if (BlackAndWhite == true)
                        {
                            int BWColor;
                            if ((pixelColor.R + pixelColor.G + pixelColor.B) / 3 > 115)
                                BWColor = 255;
                            else
                                BWColor = 0;
                            pixelColor = Color.FromArgb(BWColor, BWColor, BWColor);
                        }
                        if (Greyscale == true)
                        {
                            int greyColor = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                            pixelColor = Color.FromArgb(greyColor, greyColor, greyColor);
                        }

                        bitmap.SetPixel(x, y, pixelColor);
                    }


                }
            }
            byte[] imageBytes = stream.ToArray();
            string base64String = Convert.ToBase64String(imageBytes);
            File.WriteAllBytes(@"C:\Users\rymszmon\source\webapi\CameraControl\tobase64String.bs64", imageBytes);
            byte[] imageDecoded = Convert.FromBase64String(base64String);
            File.WriteAllBytes(@"C:\Users\rymszmon\source\webapi\CameraControl\frombase64String.jpg", imageDecoded);
            bitmap.Dispose();
            bitmap = null;
            return result;            
        }
        
        private void video_NewFrame(object sender,
        NewFrameEventArgs eventArgs)
        {            
            bitmap = (Bitmap)eventArgs.Frame.Clone();            
            bitmap.Save(stream, ImageFormat.Jpeg);

            if (bitmap != null)
                videoSource.SignalToStop();
             
        }

        // GET: api/Camera/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Camera
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Camera/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Camera/5
        public void Delete(int id)
        {
        }
    }
}
