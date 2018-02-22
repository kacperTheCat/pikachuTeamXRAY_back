using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Web;

namespace RTGMachinev1.Models
{
    public class ConnectionInfo
    {
        public string DeviceName { get; set; }
        public string IpAddress { get; set; }
        public int Version { get; set; }

        public ConnectionInfo()
        {
            DeviceName = Environment.MachineName;
            IpAddress = GetLocalIPAddress();
            Version = 1;
        }
        public static string GetLocalIPAddress()
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