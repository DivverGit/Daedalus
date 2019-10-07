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
    static class r_Space_Warp
    {
        private static bool initComplete = false;
        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
                Daedalus.DaedalusUI.newConsoleMessage("Switched to Routine.Space_Warp");
            }

            if (f_Entities.GetEntityMode(Daedalus.me.ToEntity) != EntityMode.Warping)   c_Routines.activeRoutine = Routine.Space_Idle;
            else
            {
                c_Status.Pulse();
            }
        }
    }
}
