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
    static class r_IdleAtBelt
    {
        private static bool InitComplete = false;

        static r_IdleAtBelt()
        {
            if(!InitComplete)
            {
                InitComplete = true;
                f_Asteroids.PopulateAsteroidsList();
                if(f_Asteroids.Asteroids.Count < 5)
                {
                    // Asteroid Belt has left than five asteroids so isn't worth our time.
                    Entity AsteroidBeltToRemove = r_TravelToBelt.NearestAsteroidBelt;
                    f_Asteroids.RemoveAsteroidBelt(AsteroidBeltToRemove);
                    Daedalus.DaedalusUI.newConsoleMessage("This asteroid belt doesn't have enough asteroids, moving on!");
                    InitComplete = false;
                    m_RoutineController.ActiveRoutine = Routine.TravelToBelt;
                }
                else
                {
                    InitComplete = false;
                    f_Asteroids.BestAsteroidCluster(15000);
                    m_RoutineController.ActiveRoutine = Routine.Mine;
                }
            }
        }

        public static void Pulse()
        {
            // Pulse
        }
    }
}
