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
            c_Modules.PropulsionPulse();

            ManageHiSlotModules();
        }

        private static float optimalRange = 0.0f;
        private static float falloffRange = 0.0f;
        private static float orbitRange = 0.0f;
        private static long orbitTargetID;
        private static float distanceToTarget;
        private static float engageRange = 0.0f;
        public static void ManageHiSlotModules()
        {
            // If we have targets locked
            if (c_Targets.targetsLockedIDs.Count > 0)
            {
                // Get locked target at index zero
                Entity target = f_Entities.GetEntityByID(c_Targets.targetsLockedIDs[0]);

                // Calibrate falloff, optimal and orbit ranges
                falloffRange = f_Modules.getModuleFalloffRange(SlotType.HiSlot, 0);
                optimalRange = f_Modules.getModuleOptimalRange(SlotType.HiSlot, 0);
                orbitRange = optimalRange;

                distanceToTarget = (float)f_Entities.DistanceFromPlayerToEntity(target);
                engageRange = optimalRange + falloffRange;

                // If we have targets locked
                if (target.IsActiveTarget)
                {
                    // Let's orbit target zero
                    if (orbitTargetID != target.ID)
                    {
                        orbitTargetID = target.ID;
                        Daedalus.DaedalusUI.newConsoleMessage("Orbiting " + target.Name);
                        target.Orbit(Convert.ToInt32(orbitRange));
                    }

                    // Let's fire if in engagement range
                    List<IModule> modules = f_Modules.GetHiSlotModules();
                    foreach (IModule module in modules)
                    {
                        if (module.IsValid && !module.IsActive && !module.IsReloadingAmmo)
                        {
                            if (distanceToTarget < engageRange) module.Activate();
                        }
                    }
                }
                // Target is not the active target so let's make it
                else if (!target.IsActiveTarget) target.MakeActiveTarget();
            }
        }
    }
}
