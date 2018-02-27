using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RTGMachinev1.Models
{
    public class ConnectionStatus
    {
        public Boolean ConnectionStatusInformation { get; set; }

        public ConnectionStatus()
        {
            ConnectionStatusInformation = true;
        }
    }
}