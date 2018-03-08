using ContractLibrary.Models;
using Newtonsoft.Json;
using ServicesLibrary.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RTGClientv1.Controllers
{
    public class RtgParametersController : ApiController
    {
        private readonly IImageService _imageService;


        public RtgParametersController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/RtgParameters
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RtgParameters/5
        public string Get(int id)
        {
            return "value";
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // POST: api/RtgParameters
        public RtgParametersRequest Post([FromBody]RtgParametersRequest rtgParametersRequest)
        {
            //string url = @"http://localhost:3000/profile";
            //var json = new WebClient().DownloadString(url);
            string output = JsonConvert.SerializeObject(rtgParametersRequest);
            //File.WriteAllText(@"C:\Users\hudzipau\Desktop\RTG project\jsonTest.txt", output);
            return rtgParametersRequest;
        }

        // PUT: api/RtgParameters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RtgParameters/5
        public void Delete(int id)
        {
        }
    }
}
