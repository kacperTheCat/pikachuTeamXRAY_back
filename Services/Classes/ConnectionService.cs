using Contracts.Classes;
using DataAcquisition.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class ConnectionService : IConnectionService
    {
        private readonly IConnectionAcquisition _connectionAcquisition;

        public ConnectionService(IConnectionAcquisition connectionAcquisition)
        {
            _connectionAcquisition = connectionAcquisition;
        }
        public ConnectionDetailsResponse GetDetails()
        {
            var connectionDetailseResponse = _connectionAcquisition.GetDetails();

            return connectionDetailseResponse;
        }
    }
}
