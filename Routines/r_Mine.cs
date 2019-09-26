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
    static class r_Mine
    {
        // Variables
        public static List<Entity> AsteroidsInRange = new List<Entity>();

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                GetAsteroidsInRange();
                if (f_Inventory.GetDronesGroup() != "Mining Drone")   m_CombatDroneController.Pulse();
                if (AsteroidsInRange.Count > 0)
                {
                    m_MiningLaserController.Pulse();
                    if (f_Inventory.GetDronesGroup() == "Mining Drone")   m_MiningDroneController.Pulse();
                }
            }
        }

        public static void GetAsteroidsInRange()
        {
            List<Entity> AsteroidsToProcess = new List<Entity>();
            AsteroidsToProcess = f_Entities.GetAsteroids();
            AsteroidsInRange = new List<Entity>();

            foreach(Entity Asteroid in AsteroidsToProcess)
            {
                if(f_Entities.DistanceBetween(Daedalus.me.ToEntity, Asteroid) < 15000)
                {
                    AsteroidsInRange.Add(Asteroid);
                }
            }
        }
    }
}
