﻿using AForge.Video;
using AForge.Video.DirectShow;
using Contracts.Classes;
using DataAcquisition.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace DataAcquisition.Classes
{
    public class ImageAcquisition : IImageAcquisition
    {
        MemoryStream stream = new MemoryStream();
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        public Bitmap bitmap;
        

        public CameraImageResponse GetXRAYImage(CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            RTGMachine.busy = true;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += video_NewFrame;

            RTGMachine.aTimer = new System.Timers.Timer(10000);
            RTGMachine.aTimer.Elapsed += RTGMachine.OnTimedEvent;            
            RTGMachine.aTimer.Enabled = true;
            videoSource.Start();

            

            videoSource.WaitForStop();
           

            byte[] imageStreamByteArray = stream.ToArray();

            string imageBase64String = ConvertToBase64(imageStreamByteArray);

            CameraImageResponse cameraImageResponse = new CameraImageResponse();
            cameraImageResponse.Base64 = imageBase64String;                                

            return cameraImageResponse;

        }

        public CameraImageResponse GetPreviewImage()
        {

            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += video_NewFrame;
            videoSource.Start();
            

            videoSource.WaitForStop();

            byte[] imageStreamByteArray = stream.ToArray();

            string imageBase64String = ConvertToBase64(imageStreamByteArray);

            CameraImageResponse cameraImageResponse = new CameraImageResponse();
            cameraImageResponse.Base64 = imageBase64String;

            return cameraImageResponse;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.Save(stream, ImageFormat.Jpeg);
           
            if (bitmap != null)
                videoSource.SignalToStop();
        }

       /* private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            RTGMachine.aTimer.Enabled = false;
            RTGMachine.busy = false;
        }*/

        public string ConvertToBase64(byte[] imageByteArray)
        {
            string imageBase64String = Convert.ToBase64String(imageByteArray);
            return imageBase64String;
        }
    }
}
