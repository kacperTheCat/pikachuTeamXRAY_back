using RTGMachinev1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RTGMachinev1.Controllers
{
    public class ConnectionStatusController : ApiController
    {
        // GET: api/ConnectionStatus
        public ConnectionStatus Get()
        {
            ConnectionStatus connectionStatus = new ConnectionStatus();
            return connectionStatus;
        }
    }
}
