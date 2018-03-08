using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Classes
{
    public class CameraImageCaptureRequest
    {
        protected int light;
        protected int contrast;
        protected bool blackWhite;
        protected string patientName;
        protected string user;
        protected string imageDate;
        protected string imageTime;
    }
}
