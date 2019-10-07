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
            }

            if (!c_Targets.redAlert) c_Routines.activeRoutine = Routine.Combat_Idle;

            c_Status.Pulse();
            c_Targets.Pulse();

            if(c_Modules.afterburners.Count > 0) c_Modules.PropulsionPulse();
            if (c_Modules.armorHardeners.Count > 0 || c_Modules.armorRepairers.Count > 0)   c_Modules.ArmorPulse();
            if (c_Modules.shieldBoosters.Count > 0 || c_Modules.shieldHardeners.Count > 0)  c_Modules.ShieldPulse();

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
                    if (primaryTarget.IsActiveTarget)
                    {
                        if (orbitTargetID != primaryTarget.ID)
                        {
                            orbitTargetID = primaryTarget.ID;
                            f_Movement.Orbit(primaryTarget, Convert.ToInt32(UI.orbitRange));
                        }
                        c_Modules.WeaponsPulse(primaryTarget);
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
