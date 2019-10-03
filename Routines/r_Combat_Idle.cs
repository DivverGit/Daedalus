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
        // Variables
        private static bool initComplete = false;

        static r_Combat_Idle()
        {
            // Init
        }

        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
            }
            if(f_Entities.GetEntityMode(Daedalus.me.ToEntity) != "Warping")
            {
                if (c_Targets.redAlert) c_Routines.activeRoutine = Routine.Combat_Brawl;
                c_Targets.Pulse();
                c_Status.Pulse();
            }
        }
    }
}
