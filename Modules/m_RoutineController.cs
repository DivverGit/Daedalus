using Daedalus.Routines;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Modules
{
    public static class m_RoutineController
    {
        public static Routine PreviousRoutine;

        static m_RoutineController()
        {

        }

        public static void Pulse()
        {
            if (ActiveRoutine == Routine.Station) r_Station.Pulse();
            else if (ActiveRoutine == Routine.TravelToBelt) r_TravelToBelt.Pulse();
            else if (ActiveRoutine == Routine.IdleAtBelt) r_IdleAtBelt.Pulse();
            else if (ActiveRoutine == Routine.Mine) r_Mine.Pulse();
            else if (ActiveRoutine == Routine.ReturnToStation) r_ReturnToStation.Pulse();
            return;
        }

        public static Routine ActiveRoutine;
    }

    public enum Routine { Idle, Station, ReturnToStation, TravelToBelt, IdleAtBelt, Mine };
}
