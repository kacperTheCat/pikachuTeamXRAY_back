using ContractLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractLibrary.Interfaces
{
    interface IRtgParameters
    {
        RtgParametersRequest postRtgParameters();
    }
}
