using Daedalus.Functions;
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
    static class m_MiningLaserController
    {
        public static List<IModule> MiningLasers = new List<IModule>();
        public static  List<long> MiningLaserTargetIDs = new List<long>();

        static m_MiningLaserController()
        {
            // Init
            MiningLasers = f_Modules.GetMiningLasers();
            PopulateMiningLaserTargetIDsList(MiningLasers.Count);
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                Targets();
                Activation();
            }
        }

        public static void PopulateMiningLaserTargetIDsList(int ids)
        {
            int i;
            for(i=0; i < ids; i++)
            {
                MiningLaserTargetIDs.Add(0);
            }
        }

        public static void Targets()
        {
            int i;
            for (i = 0; i < MiningLaserTargetIDs.Count; i++)
            {
                long TargetID = MiningLaserTargetIDs[i];
                if(TargetID == 0)
                {
                    //This IModule doesn't have a target!
                    foreach(Entity Asteroid in r_Mine.AsteroidsInRange)
                    {
                        if(MiningLaserTargetIDs.IndexOf(Asteroid.ID) == -1)
                        {
                            //We can target this because no other IModules are!
                            Asteroid.LockTarget();
                            LoadCorrectCrystal(MiningLasers[i], Asteroid);
                            MiningLaserTargetIDs[i] = Asteroid.ID;
                            break;
                        }
                    }
                }
                else if(GetAsteroidByID(TargetID) == null)
                {
                    if (MiningLasers[i].IsActive) MiningLasers[i].Deactivate();
                    MiningLaserTargetIDs[i] = 0;
                }
            }
        }

        public static void LoadCorrectCrystal(IModule MiningLaser, Entity Asteroid)
        {
            if(f_Modules.UsesCrystals(MiningLaser))
            {

            }
        }

        public static void Activation()
        {
            int i;
            for(i = 0; i < MiningLaserTargetIDs.Count; i++)
            {
                if (!Daedalus.myShip.Module(SlotType.HiSlot, i).IsActive)
                {
                    Entity Target = GetAsteroidByID(MiningLaserTargetIDs[i]);
                    if(Target != null)
                    {
                        if (Target.IsLockedTarget)
                        {
                            Target.MakeActiveTarget();
                            MiningLasers[i].Activate();
                        }
                    }
                }
            }
        }

        public static Entity GetAsteroidByID(long ID)
        {
            foreach(Entity Asteroid in r_Mine.AsteroidsInRange)
            {
                if (Asteroid.ID == ID) return Asteroid;
            }
            return null;
        }
    }
}
