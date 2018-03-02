using System.Web.Http;
using System.Web.Http.Cors;
using Contracts.Classes;
using Services.Interfaces;

namespace RTGMachinev1.Controllers
{
    public class ConnectionDetailsController : ApiController
    {
        private readonly IConnectionService _connectionService;

        public ConnectionDetailsController(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        //GET: api/ConnectionInfo
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ConnectionDetailsResponse GetDetails()
        {
            var connectionDetailsResponse = _connectionService.GetDetails();

            return connectionDetailsResponse;
        }
    }
}
