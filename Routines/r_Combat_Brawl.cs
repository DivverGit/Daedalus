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
    static class r_Combat_Brawl
    {
        // Variables
        private static bool initComplete = false;

        static r_Combat_Brawl()
        {
            // Init
        }

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

            ManageHiSlotModules();
        }

        private static float orbitRange = 0.0f;
        private static long orbitTargetID;
        public static void ManageHiSlotModules()
        {
            // If we have targets locked
            if (c_Targets.targetsLockedIDs.Count > 0)
            {
                // Get locked target at index zero
                Entity target = f_Entities.GetEntityByID(c_Targets.targetsLockedIDs[0]);

                // Calibrate falloff, optimal and orbit ranges
                orbitRange = Daedalus.DaedalusUI.orbitRange();

                if(target.IsValid)
                {
                    // If we have targets locked
                    if (target.IsActiveTarget)
                    {
                        // Let's orbit target zero
                        if (orbitTargetID != target.ID)
                        {
                            orbitTargetID = target.ID;
                            target.Orbit(Convert.ToInt32(orbitRange));
                        }
                        c_Modules.WeaponPulse(target);
                    }
                    // Target is not the active target so let's make it
                    else if (!target.IsActiveTarget) target.MakeActiveTarget();
                }
            }
        }
    }
}
