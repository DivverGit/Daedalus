﻿using Daedalus.Behaviours;
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
        public static Routine activeRoutine = Routine.undefined;

        static m_RoutineController()
        {
            // Init
        }

        public static void Pulse()
        {
            if (m_BehaviourController.activeBehaviour == m_BehaviourController.Behaviour.Space)
            {
                if (activeRoutine == Routine.Space_Idle) r_Space_Idle.Pulse();
            }
            else if (m_BehaviourController.activeBehaviour == m_BehaviourController.Behaviour.Station)
            {
                if (activeRoutine == Routine.Station_Idle) r_Station_Idle.Pulse();
                else if (activeRoutine == Routine.Station_Leave) r_Station_Leave.Pulse();
            }
        }
    }

    public enum Routine {
        Space_Idle,
        Station_Idle,
        Station_Leave,
        undefined
    };
}
