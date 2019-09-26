using Daedalus.Functions;
using Daedalus.Modules;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Routines
{
    static class r_TravelToBelt
    {
        private static bool InitComplete = false;
        public static Entity NearestAsteroidBelt;

        static r_TravelToBelt()
        {
            if(!InitComplete)
            {
                InitComplete = true;
                f_Asteroids.PopulateAsteroidBeltsList();
                NearestAsteroidBelt = f_Asteroids.AsteroidBelts[0];
                f_WarpTo.Belt(NearestAsteroidBelt);
            }
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                if(InitComplete)
                {
                    string OurStatus = f_Entities.GetEntityMode(Daedalus.me.ToEntity);
                    double Distance = f_Entities.DistanceFromPlayerToEntity(NearestAsteroidBelt);
                    if (OurStatus == "Warping" && Distance < 200000) return;
                    else if (OurStatus != "Warping" && Distance < 200000)
                    {
                        InitComplete = false;
                        m_RoutineController.ActiveRoutine = Routine.IdleAtBelt;
                    }
                }
            }
        }
    }
}
