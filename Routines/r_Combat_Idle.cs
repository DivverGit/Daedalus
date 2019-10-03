using Daedalus.Functions;
using Daedalus.Modules;
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
            if (m_TargetController.redAlert) m_RoutineController.activeRoutine = Routine.Combat_Brawl;
            m_TargetController.Pulse();
            m_StatusController.Pulse();
        }
    }
}
