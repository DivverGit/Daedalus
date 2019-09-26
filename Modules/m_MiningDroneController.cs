using Daedalus.Routines;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Modules
{
    static class m_MiningDroneController
    {
        // Variables
        private static bool ActiveOnTarget = false;
        private static long MiningDronesTargetID = 0;

        static m_MiningDroneController()
        {
            // Init
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                Target();
                Activation();
            }
        }

        public static void Target()
        {
            if (MiningDronesTargetID == 0)
            {
                ActiveOnTarget = false;
                //This IModule doesn't have a target!
                List<Entity> Asteroids = r_Mine.AsteroidsInRange;
                foreach (Entity Asteroid in Asteroids)
                {
                    if (m_MiningLaserController.MiningLaserTargetIDs.IndexOf(Asteroid.ID) == -1)
                    {
                        //We can target this because no other IModules are!
                        Asteroid.LockTarget();
                        MiningDronesTargetID = Asteroid.ID;
                        Program.DaedalusUI.NewConsoleMessage("Mining drones assigned to targetID " + Asteroid.ID.ToString());
                        break;
                    }
                }
            }
            else if (GetAsteroidByID(MiningDronesTargetID) == null)
            {
                MiningDronesTargetID = 0;
                Program.DaedalusUI.NewConsoleMessage("Mining drones have lost targetID " + MiningDronesTargetID.ToString());
            }
        }

        public static void Activation()
        {
            if (Daedalus.me.GetActiveDrones().Count == 0)
            {
                Daedalus.myShip.LaunchAllDrones();
            }
            else if (Daedalus.me.GetActiveDrones().Count > 0 && !ActiveOnTarget)
            {
                Entity Target = GetAsteroidByID(MiningDronesTargetID);
                if (Target != null)
                {
                    if (Target.IsLockedTarget)
                    {
                        ActiveOnTarget = true;
                        Target.MakeActiveTarget();
                        Daedalus.eve.DronesMineRepeatedly(Daedalus.me.GetActiveDroneIDs());
                    }
                }
            }
        }

        public static Entity GetAsteroidByID(long ID)
        {
            foreach (Entity Asteroid in r_Mine.AsteroidsInRange)
            {
                if (Asteroid.ID == ID) return Asteroid;
            }
            return null;
        }
    }
}
