using Contracts.Classes;
using DataAcquisition.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DataAcquisition.Classes
{
    public class ConnectionAcquisition : IConnectionAcquisition
    {
        public ConnectionDetailsResponse GetDetails()
        {
            var connectionDetailsResponse = new ConnectionDetailsResponse
            {
            DeviceName = "X-Ray-/" + Environment.MachineName,
            IpAddress = GetLocalIPAddress(),
            Version = 1,
        };

            return connectionDetailsResponse;
        }

        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
