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

        private static long movementTargetID;
        public static void DoCombat()
        {
            List<EnemyNPC> targets = c_Targets.optimalTargets;
            if (targets.Count > 0)
            {
                Entity primaryTarget = targets[0].entity;

                if (primaryTarget.IsLockedTarget)
                {
                    if (primaryTarget.IsActiveTarget)
                    {
                        if (movementTargetID != primaryTarget.ID)
                        {
                            movementTargetID = primaryTarget.ID;

                            int movementRange = Convert.ToInt32(Settings.Default.movementRange);
                            switch (Settings.Default.movementIndex)
                            {
                                case 0:
                                    f_Movement.KeepAtRange(primaryTarget, movementRange);
                                    break;
                                case 1:
                                    f_Movement.Orbit(primaryTarget, movementRange);
                                    break;
                            }
                        }
                        c_Modules.OffensePulse(primaryTarget);
                    }
                    else if (!primaryTarget.IsActiveTarget)
                    {
                        primaryTarget.MakeActiveTarget();
                    }
                }
                else if (primaryTarget.BeingTargeted) return;
            }
        }
    }
}
