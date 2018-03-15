using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Classes
{
    public static class RTGMachine
    {
        public static bool busy = false;        
        public static System.Timers.Timer aTimer;
        public static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            busy = false;
        }
        
    }
}
