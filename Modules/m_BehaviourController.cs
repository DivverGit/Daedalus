using Daedalus.Behaviours;
using Daedalus.Functions;
using Daedalus.Modules;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Modules
{
    public static class m_BehaviourController
    {
        public static bool InitComplete = false;
        private static bool inTransition = false;
        private static DateTime transitionEndTime;

        static m_BehaviourController()
        {
            if (!InitComplete)
            {
                InitComplete = true;
            }
        }

        public enum Behaviour { Mining, Space, Station, undefined };
        public static Behaviour previousBehaviour = Behaviour.undefined;
        public static Behaviour activeBehaviour = Behaviour.undefined;

        public static void Pulse()
        {
            if (inTransition) checkInTransition();
            checkActiveBehaviour();
            pulseActiveBehaviour();
        }

        private static void checkActiveBehaviour()
        {
            // If we're in station and not in space then we're in station! duh!
            if (Daedalus.me.InStation && !Daedalus.me.InSpace)
            {
                if(activeBehaviour != Behaviour.Station && !inTransition)
                {
                    previousBehaviour = activeBehaviour;
                    activeBehaviour = Behaviour.Station;
                    m_RoutineController.activeRoutine = Routine.Station_Idle;
                    b_Station.InitComplete = false;
                    setInTransition();
                }
            }
            // Else if we're not in station and we're in space then we're in space! duh!
            else if (!Daedalus.me.InStation && Daedalus.me.InSpace)
            {
                if (activeBehaviour != Behaviour.Space && !inTransition)
                {
                    previousBehaviour = activeBehaviour;
                    activeBehaviour = Behaviour.Space;
                    b_Space.InitComplete = false;
                    setInTransition();
                }
            }
        }

        private static void pulseActiveBehaviour()
        {
            if (activeBehaviour == Behaviour.Mining) b_Mining.Pulse();
            else if (activeBehaviour == Behaviour.Space) b_Space.Pulse();
            else if (activeBehaviour == Behaviour.Station) b_Station.Pulse();
        }

        private static void setInTransition()
        {
            inTransition = true;
            transitionEndTime = DateTime.Now.AddSeconds(5.0f);
            Daedalus.DaedalusUI.newConsoleMessage("Transitioning from " + previousBehaviour.ToString() + " to " + activeBehaviour.ToString());
        }

        private static void checkInTransition()
        {
            if(DateTime.Now > transitionEndTime)
            {
                inTransition = false;
            }
        }
    }
}