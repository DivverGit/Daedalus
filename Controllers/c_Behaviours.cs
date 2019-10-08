using Daedalus.Behaviours;
using System;

namespace Daedalus.Controllers
{
    public enum Behaviour
    {
        Combat,
        Space,
        Station,
        undefined
    };

    public static class c_Behaviours
    {
        private static bool inTransition = false;
        private static DateTime transitionEndTime;

        public static Behaviour previousBehaviour = Behaviour.undefined;
        public static Behaviour activeBehaviour = Behaviour.undefined;

        public static bool InitComplete = false;
        public static void Pulse()
        {
            if(!InitComplete)
            {
                InitComplete = true;
            }

            if (inTransition) CheckInTransition();
            else if (!inTransition)
            {
                CheckActiveBehaviour();
                PulseActiveBehaviour();
            }
        }

        private static void CheckActiveBehaviour()
        {
            // If we're in station and not in space then we're in station! duh!
            if (Daedalus.me.InStation && !Daedalus.me.InSpace)
            {
                if(activeBehaviour != Behaviour.Station)
                {
                    previousBehaviour = activeBehaviour;
                    activeBehaviour = Behaviour.Station;
                    c_Routines.activeRoutine = Routine.Station_Idle;
                    b_Station.InitComplete = false;
                    SetInTransition();
                }
            }
            // Else if we're not in station and we're in space then we're in space! duh!
            else if (!Daedalus.me.InStation && Daedalus.me.InSpace)
            {
                if (activeBehaviour != Behaviour.Space && !c_Targets.redAlert)
                {
                    previousBehaviour = activeBehaviour;
                    activeBehaviour = Behaviour.Space;
                    c_Routines.activeRoutine = Routine.Space_Idle;
                    b_Space.InitComplete = false;
                    SetInTransition();
                }
                else if (activeBehaviour != Behaviour.Combat && c_Targets.redAlert)
                {
                    previousBehaviour = activeBehaviour;
                    activeBehaviour = Behaviour.Combat;
                    c_Routines.activeRoutine = Routine.Combat_Idle;
                    b_Combat.InitComplete = false;
                    SetInTransition();
                }
            }
        }
        private static void CheckInTransition()
        {
            if (DateTime.Now > transitionEndTime) inTransition = false;
        }
        private static void PulseActiveBehaviour()
        {
            if (activeBehaviour == Behaviour.Space) b_Space.Pulse();
            else if (activeBehaviour == Behaviour.Station) b_Station.Pulse();
            else if (activeBehaviour == Behaviour.Combat) b_Combat.Pulse();
        }
        private static void SetInTransition()
        {
            inTransition = true;
            transitionEndTime = DateTime.Now.AddSeconds(5.0f);
            Daedalus.DaedalusUI.newConsoleMessage("Transitioning from Behaviour." + previousBehaviour.ToString() + " to Behaviour." + activeBehaviour.ToString());
        }
    }
}