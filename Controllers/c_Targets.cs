using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVE.ISXEVE;
using LavishVMAPI;
using Daedalus.Data;
using Daedalus.Functions;

namespace Daedalus.Controllers
{
    static class c_Targets
    {
        // Variables
        private static List<Entity> allEntities = new List<Entity>();
        public static List<Entity> enemyNpcEntities = new List<Entity>();
        public static List<Entity> targets = new List<Entity>();
        public static bool redAlert = false;

        static c_Targets()
        {
            // Init
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                enemyNpcEntities = f_Entities.GetNpcEntities();

                if (enemyNpcEntities.Count > 0)
                {
                    redAlert = true;
                    if(c_Routines.activeRoutine == Routine.Combat_Brawl)   ManageTargetLocks();
                }
                else
                {
                    redAlert = false;
                }
            }
        }

        private static double maxTargetRange;
        private static double maxTargetsLocked;
        public static List<long> targetsLockedIDs = new List<long>();
        public static List<long> targetsLockingIDs = new List<long>();
        public static void ManageTargetLocks()
        {
            maxTargetRange = Daedalus.myShip.MaxTargetRange;
            maxTargetsLocked = Daedalus.me.MaxLockedTargets;

            // Clear and populate targets locked list
            targetsLockedIDs = new List<long>();
            if (Daedalus.me.GetTargets().Count > 0)
            {
                foreach (Entity lockedTarget in Daedalus.me.GetTargets())
                {
                    targetsLockedIDs.Add(lockedTarget.ID);
                    if (targetsLockingIDs.Contains(lockedTarget.ID)) targetsLockingIDs.Remove(lockedTarget.ID);
                }
            }

            // If no targets locked and more than one enemy npc then start locking target
            Entity target;
            if (targetsLockedIDs.Count == 0 && targetsLockingIDs.Count == 0 && enemyNpcEntities.Count > 0)
            {
                target = enemyNpcEntities[0];

                if (!targetsLockingIDs.Contains(target.ID) && f_Entities.DistanceFromPlayerToEntity(target) < maxTargetRange)
                {
                    targetsLockingIDs.Add(target.ID);
                    string npcClass = d_NPC_Classes.getNpcClass(target.GroupID);
                    Daedalus.DaedalusUI.newConsoleMessage("Target is " + target.Name + " (" + npcClass + ")");
                    target.LockTarget();
                }
                else if (f_Entities.GetEntityMode(Daedalus.me.ToEntity) != "Approaching" && !targetsLockingIDs.Contains(target.ID) && f_Entities.DistanceFromPlayerToEntity(target) > maxTargetRange)
                {
                    target.Approach();
                }
            }
        }
    }
}
