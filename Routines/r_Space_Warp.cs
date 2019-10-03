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
        // Variables
        private static bool initComplete = false;

        static r_Space_Warp()
        {
            // Init
        }

        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
            }
            if (f_Entities.GetEntityMode(Daedalus.me.ToEntity) != "Warping")
            {
                c_Routines.activeRoutine = Routine.Space_Idle;
            }
            else
            {
                c_Status.Pulse();
            }
        }
    }
}
