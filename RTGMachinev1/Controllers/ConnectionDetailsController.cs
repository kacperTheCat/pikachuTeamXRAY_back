using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RTGMachinev1.Models;

namespace RTGMachinev1.Controllers
{
    public class ConnectionDetailsController : ApiController
    {
        // GET: api/ConnectionDetails
        public ConnectionDetails Get()
        {
            ConnectionDetails connectionInfo = new ConnectionDetails();
            return connectionInfo;
        }
    }
}
