using AForge.Video;
using AForge.Video.DirectShow;
using Contracts.Classes;
using DataAcquisition.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisition.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        MemoryStream stream = new MemoryStream();
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public Bitmap bitmap;

        public CameraImageResponse GetImage()
        {

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            //videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.NewFrame += video_NewFrame;
            videoSource.Start();

            videoSource.WaitForStop();

            byte[] imageStreamByteArray = stream.ToArray();
            string imageBase64String = Convert.ToBase64String(imageStreamByteArray);

            CameraImageResponse cameraImageResponse = new CameraImageResponse();
            cameraImageResponse.Id = 1;
            cameraImageResponse.Base64 = imageBase64String;
            return cameraImageResponse;
        }

        private void video_NewFrame(object sender,
        NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.Save(stream, ImageFormat.Jpeg);

            if (bitmap != null)
                videoSource.SignalToStop();
        }
    }
}
