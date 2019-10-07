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
    static class r_Combat_Idle
    {
        private static bool initComplete = false;
        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
                Daedalus.DaedalusUI.newConsoleMessage("Switched to Routine.Combat_Idle");
            }

            if(f_Entities.GetEntityMode(Daedalus.me.ToEntity) != EntityMode.Warping)
            {
                if (c_Targets.redAlert)
                {
                    initComplete = false;
                    c_Routines.activeRoutine = Routine.Combat_Active;
                }
                c_Targets.Pulse();
                c_Status.Pulse();
            }
        }
    }
}
