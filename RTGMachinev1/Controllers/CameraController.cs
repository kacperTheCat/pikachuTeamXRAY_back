using System.Web.Http;
using Services.Interfaces;
using Contracts.Classes;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace CameraControl.Areas.HelpPage.Controllers
{
    public class CameraController : ApiController
    {
        private readonly IImageService _imageService;


        public CameraController(IImageService imageService)
        {
            _imageService = imageService;
           
        }

        // GET: api/Camera
        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public CameraImageResponse GetPerviewImage()
        {
            var cameraImageResponse = _imageService.GetPreviewImage();

            return cameraImageResponse;
        }

        [HttpPost]
        [Route("api/Camera/Capture")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public CameraImageResponse GetXRAYImage([FromBody]CameraImageCaptureRequest cameraImageCaptureRequest)
        {
            CameraImageResponse cameraImageResponse = new CameraImageResponse();           
            if (RTGMachine.busy == false)
            {
                cameraImageResponse = _imageService.GetXRAYImage(cameraImageCaptureRequest);
            }
            else
            {
                cameraImageResponse.errorMessage = "Camera is busy";
            }
            return cameraImageResponse;
        }

        
    }
}
