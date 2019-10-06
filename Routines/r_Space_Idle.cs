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
    static class r_Space_Idle
    {
        private static bool initComplete = false;
        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
            }

            if(f_Entities.GetEntityMode(Daedalus.me.ToEntity) == EntityMode.Warping)    c_Routines.activeRoutine = Routine.Space_Warp;
            else
            {
                c_Targets.Pulse();
                c_Status.Pulse();
                c_Modules.PropulsionPulse();
            }
        }
    }
}
