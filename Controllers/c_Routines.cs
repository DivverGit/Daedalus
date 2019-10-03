using Daedalus.Behaviours;
using Daedalus.Routines;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Controllers
{
    public static class c_Routines
    {
        public static Routine activeRoutine = Routine.undefined;

        static c_Routines()
        {
            // Init
        }

        public static void Pulse()
        {
            if (c_Behaviours.activeBehaviour == c_Behaviours.Behaviour.Space)
            {
                if (activeRoutine == Routine.Space_Idle) r_Space_Idle.Pulse();
                else if (activeRoutine == Routine.Space_Warp) r_Space_Warp.Pulse();
            }
            else if (c_Behaviours.activeBehaviour == c_Behaviours.Behaviour.Station)
            {
                if (activeRoutine == Routine.Station_Idle) r_Station_Idle.Pulse();
                else if (activeRoutine == Routine.Station_Leave) r_Station_Leave.Pulse();
            }
            else if (c_Behaviours.activeBehaviour == c_Behaviours.Behaviour.Combat)
            {
                if (activeRoutine == Routine.Combat_Idle) r_Combat_Idle.Pulse();
                else if (activeRoutine == Routine.Combat_Brawl) r_Combat_Brawl.Pulse();
            }
        }
    }

    public enum Routine {
        Combat_Idle,
        Combat_Brawl,
        Space_Idle,
        Space_Warp,
        Station_Idle,
        Station_Leave,
        undefined
    };
}
