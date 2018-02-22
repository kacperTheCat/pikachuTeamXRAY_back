using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RTGMachinev1.Models;

namespace RTGMachinev1.Controllers
{
    public class ConnectionInfoController : ApiController
    {
        // GET: api/ConnectionInfo
        public ConnectionInfo Get()
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            return connectionInfo;
        }

        // GET: api/ConnectionInfo/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConnectionInfo
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ConnectionInfo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ConnectionInfo/5
        public void Delete(int id)
        {
        }
    }
}
