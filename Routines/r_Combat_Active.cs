using Daedalus.Functions;
using Daedalus.Controllers;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daedalus.Properties;

namespace Daedalus.Routines
{
    static class r_Combat_Active
    {
        private static bool initComplete = false;
        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
                Daedalus.DaedalusUI.newConsoleMessage("Switched to Routine.Combat_Active");
            }

            if (!c_Targets.redAlert) c_Routines.activeRoutine = Routine.Combat_Idle;

            c_Modules.Pulse();
            c_Status.Pulse();
            c_Targets.Pulse();

            DoCombat();
        }

        private static long orbitTargetID;
        public static void DoCombat()
        {
            List<EnemyNPC> targets = c_Targets.optimalTargets;
            if (targets.Count > 0)
            {
                Entity primaryTarget = targets[0].entity;

                if (primaryTarget.IsLockedTarget)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("r_Combat_Active: Primary is locked");
                    if (primaryTarget.IsActiveTarget)
                    {
                        if (orbitTargetID != primaryTarget.ID)
                        {
                            orbitTargetID = primaryTarget.ID;
                            f_Movement.Orbit(primaryTarget, Convert.ToInt32(UI.orbitRange));
                        }
                        Daedalus.DaedalusUI.newConsoleMessage("r_Combat_Active: OffensePulse()");
                        c_Modules.OffensePulse(primaryTarget);
                    }
                    else if (!primaryTarget.IsActiveTarget)
                    {
                        Daedalus.DaedalusUI.newConsoleMessage("r_Combat_Active: Making primary active");
                        primaryTarget.MakeActiveTarget();
                    }
                }
                else if (primaryTarget.BeingTargeted) return;
            }
        }
    }
}
