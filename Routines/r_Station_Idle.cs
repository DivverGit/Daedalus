using Daedalus.Functions;
using Daedalus.Controllers;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Routines
{
    static class r_Station_Idle
    {
        private static bool initComplete = false;
        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
                Daedalus.DaedalusUI.newConsoleMessage("Switched to Routine.Station_Idle");
            }

            c_Status.Pulse();
        }
    }
}
