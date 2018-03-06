using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAcquisition.Classes;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataAcquisitionTests
{
    [TestClass]
    public class ConnectionAcquisitionTests
    {

        [TestMethod]
        public void GetLocalIpAddressTest()
        {
            //arange
            var connectionAcquisition = new ConnectionAcquisition();

            //act
            var result = connectionAcquisition.GetLocalIPAddress();

            //assert
            result.Should().BeOfType<string>();
            result.Should().NotBeNull();
            result.Should().Match("*.*.*.*");
        }

        [TestMethod]
        public void GetDetailsTest()
        {
            //arange
            var connectionAcquisition = new ConnectionAcquisition();

            //act
            var result = connectionAcquisition.GetDetails();

            //assert
            result.DeviceName.Should().BeOfType<string>();
            result.DeviceName.Should().StartWith("X-Ray-/");
            result.DeviceName.Should().Contain(Environment.MachineName);

            result.IpAddress.Should().BeOfType<string>();
            result.IpAddress.Should().NotBeNull();
            result.IpAddress.Should().Match("*.*.*.*");

            result.DeviceName.Should().StartWith("X-Ray-/");
            result.DeviceName.Should().BeOfType<string>();
            result.DeviceName.Should().NotBeNull();
        }
    }
}
