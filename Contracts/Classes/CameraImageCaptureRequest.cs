using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Classes
{
    public class CameraImageCaptureRequest
    {
        public int light;
        public int contrast;
        public bool negative;
        public string patientName;
        public string userName;
        public string imageDate;
        public string imageTime;
        public int machineID;
    }
}
