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
using System.Drawing.Imaging;
using RTGMachinev1.Models;

namespace RTGMachinev1.Models
{
    public class Base64Converter
    {
        public string imageBase64String;
        public Base64Converter(MemoryStream stream)
        {
            byte[] imageStreamByteArray = stream.ToArray();
            imageBase64String = Convert.ToBase64String(imageStreamByteArray);
        }
    }
}