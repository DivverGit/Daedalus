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
            if (m_TargetController.redAlert) m_RoutineController.activeRoutine = Routine.Combat_Brawl;
            m_TargetController.Pulse();
            m_StatusController.Pulse();
            Brawl();
        }

        private static bool inActiveFight = false;
        private static long brawlTargetID;
        private static Entity brawlTarget;
        private static float distanceToTarget;
        private static float optimalRange = 1000.0f;
        private static float falloffRange = 1000.0f;
        private static float orbitRange = 2000.0f;
        public static void Brawl()
        {
            if(!inActiveFight)
            {
                brawlTarget = m_TargetController.enemyNpcEntities[0];
                brawlTarget.LockTarget();
                optimalRange = m_StatusController.getModuleOptimalRange(SlotType.HiSlot, 0);
                falloffRange = m_StatusController.getModuleFalloffRange(SlotType.HiSlot, 0);
                orbitRange = optimalRange + (falloffRange / 2);
                brawlTarget.Orbit(Convert.ToInt32(orbitRange));
                inActiveFight = true;
            }
            else if(inActiveFight && brawlTarget.IsValid)
            {
                List<long> targetsLockedIDs = new List<long>();
                foreach(Entity target in Daedalus.me.GetTargets())
                {
                    targetsLockedIDs.Add(target.ID);
                }

                bool brawlTargetLocked = targetsLockedIDs.Contains(brawlTarget.ID);

                if (brawlTargetLocked && brawlTarget.IsActiveTarget)
                {
                    Daedalus.DaedalusUI.newConsoleMessage(brawlTarget.ID.ToString() + " - IsLocked=true && IsActive=true");
                    distanceToTarget = (float)f_Entities.DistanceFromPlayerToEntity(brawlTarget);

                    List<IModule> weapons = f_Modules.GetHiSlotModules();

                    foreach (IModule weapon in weapons)
                    {
                        if (weapon.IsValid && !weapon.IsActive && !weapon.IsReloadingAmmo)
                        {
                            if (distanceToTarget < (optimalRange + falloffRange)) weapon.Activate();
                        }
                    }
                }
                else if (brawlTargetLocked && !brawlTarget.IsActiveTarget)
                {
                    Daedalus.DaedalusUI.newConsoleMessage(brawlTarget.ID.ToString() + " - IsLocked=true && IsActive=false");
                    brawlTarget.MakeActiveTarget();
                }
                else if (!brawlTargetLocked && brawlTarget.StructurePct > 0)
                {
                    Daedalus.DaedalusUI.newConsoleMessage(brawlTarget.ID.ToString() + " - IsLocked=false");
                    brawlTarget.LockTarget();
                }
            }
            else if(brawlTarget.StructurePct <= 0)
            {
                Daedalus.DaedalusUI.newConsoleMessage(brawlTargetID + " is dead");
                inActiveFight = false;
            }
        }
    }
}
