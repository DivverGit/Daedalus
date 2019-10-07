using System.Collections.Generic;
using EVE.ISXEVE;
using Daedalus.Data;
using Daedalus.Functions;
using System.Linq;

namespace Daedalus.Controllers
{
    static class c_Targets
    {
        #region Variables
        private static List<Entity> enemyNpcEntities = new List<Entity>();
        private static List<EnemyNPC> enemyNpcEntitiesInRange = new List<EnemyNPC>();
        private static List<EnemyNPC> priorityNpcEntitiesInRange = new List<EnemyNPC>();
        private static List<EnemyNPC> existingTargets = new List<EnemyNPC>();
        public static List<EnemyNPC> optimalTargets = new List<EnemyNPC>();
        private static double maxTargetRange;
        private static double maxMeTargetsLocked;
        private static double maxShipTargetsLocked;
        public static bool redAlert = false;
        #endregion

        public static void Pulse()
        {
            enemyNpcEntities = f_Entities.GetNpcEntities(f_Entities.AllEntities());
            enemyNpcEntitiesInRange = GetEnemiesInRange(false);
            priorityNpcEntitiesInRange = GetEnemiesInRange(true);
            if (enemyNpcEntities.Count > 0)
            {
                redAlert = true;
                if (c_Routines.activeRoutine == Routine.Combat_Active) DoTargeting();
            }
            else
            {
                redAlert = false;
            }
        }
        public static void DoTargeting()
        {
            maxTargetRange = Daedalus.myShip.MaxTargetRange;
            maxMeTargetsLocked = Daedalus.me.MaxLockedTargets;
            maxShipTargetsLocked = Daedalus.myShip.MaxLockedTargets;

            // Step 1: If priority targets within targeting range
            if (priorityNpcEntitiesInRange.Count > 0)
            {
                optimalTargets = priorityNpcEntitiesInRange
                        .Where(t => !t.entity.IsMoribund)
                        .OrderBy(t => t.distance)
                        .Take((int)System.Math.Min(maxMeTargetsLocked, maxShipTargetsLocked))
                        .ToList();
                Daedalus.DaedalusUI.setTargetsList(optimalTargets);
            }
            // Step 2: If no priority within targeting range but still targets within targeting range
            else if (priorityNpcEntitiesInRange.Count == 0 && enemyNpcEntitiesInRange.Count > 0)
            {
                if (UI.selectedTargetingProfile == TargetingProfile.byClass)
                {
                    optimalTargets = enemyNpcEntitiesInRange
                            .Where(t => !t.entity.IsMoribund)
                            .OrderBy(t => t.shipClassOrder)
                            .ThenBy(t => t.distance)
                            .Take((int)System.Math.Min(maxMeTargetsLocked, maxShipTargetsLocked))
                            .ToList();
                    Daedalus.DaedalusUI.setTargetsList(optimalTargets);
                }
                else if (UI.selectedTargetingProfile == TargetingProfile.byDistance)
                {
                    optimalTargets = enemyNpcEntitiesInRange
                            .Where(t => !t.entity.IsMoribund)
                            .OrderBy(t => t.distance)
                            .Take((int)System.Math.Min(maxMeTargetsLocked, maxShipTargetsLocked))
                            .ToList();
                    Daedalus.DaedalusUI.setTargetsList(optimalTargets);
                }
            }
            // Step 3: If no targets within targeting range then if targets outside of it, approach the nearest one
            else if (enemyNpcEntitiesInRange.Count == 0 && enemyNpcEntities.Count > 0)
            {
                if (f_Entities.GetEntityMode(Daedalus.me.ToEntity) != EntityMode.Approaching) f_Movement.Approach(enemyNpcEntities[0]);
            }

            // Step 4: Unlock any locked targets that are not optimal targets
            List<Entity> lockedTargets = Daedalus.me.GetTargets();
            foreach (Entity target in lockedTargets)
            {
                bool found = false;
                foreach (EnemyNPC enemyNPC in optimalTargets)
                {
                    if (enemyNPC.entity.ID == target.ID) found = true;
                }
                if (!found) target.UnlockTarget();
            }

            // Step 5: Lock optimal targets
            foreach (EnemyNPC optimalTarget in optimalTargets)
            {
                if (!optimalTarget.entity.IsLockedTarget && !optimalTarget.entity.BeingTargeted) optimalTarget.entity.LockTarget();
            }
        }
        private static List<EnemyNPC> GetEnemiesInRange(bool priorityOnly)
        {
            List<EnemyNPC> toReturn = new List<EnemyNPC>();
            List<Entity> entities = new List<Entity>();
            if (!priorityOnly) entities = f_Entities.GetEntitiesWithinDistance(enemyNpcEntities, maxTargetRange);
            else
            {
                entities = f_Entities.GetEntitiesWithinDistance(enemyNpcEntities, maxTargetRange, d_Priority_Targets.All);
            }

            foreach (Entity entity in entities)
            {
                toReturn.Add(new EnemyNPC(f_Entities.GetDistanceBetween(entity), entity, d_NPC_Classes.GetNpcClass(entity.GroupID)));
            }
            return toReturn;
        }
    }

    public class EnemyNPC
    {
        public double distance { get; set; }
        public Entity entity { get; set; }
        public string shipClass { get; set; }
        public int shipClassOrder { get; set; }
        public EnemyNPC(double aDistance, Entity aEntity, string aShipClass)
        {
            distance = aDistance;
            entity = aEntity;
            shipClass = aShipClass;
            shipClassOrder = d_NPC_Classes.GetNpcClassOrder(aShipClass);
        }
    }
}
