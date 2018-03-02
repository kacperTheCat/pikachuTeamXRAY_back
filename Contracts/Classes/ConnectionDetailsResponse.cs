using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Classes
{
    public class ConnectionDetailsResponse
    {
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public int Version { get; set; }
    }
}
