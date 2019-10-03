using Daedalus.Functions;
using Daedalus.Controllers;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Routines
{
    static class r_Station_Leave
    {
        // Variables
        private static bool initComplete = false;

        private static bool leaveStation = false;
        private static bool leaveStationDelayed = false;
        private static bool waitingToLeave = false;

        private static double minWaitTime = 20;
        private static double maxWaitTime = 45;

        private static DateTime exitStationTime;

        static r_Station_Leave()
        {
            // Init
        }

        public static void Pulse()
        {
            if (!initComplete)
            {

            }

            if (leaveStation)
            {
                leaveStation = false;
                Program.DaedalusUI.newConsoleMessage("Leaving " + Daedalus.me.Station.Name.ToString());
                c_Routines.activeRoutine = Routine.undefined;
                f_EVECommands.ExitStation();
            }
            else if(leaveStationDelayed)
            {
                leaveStationDelayed = false;
                double ExitStationDelay = RandWaitTime(minWaitTime, maxWaitTime);
                exitStationTime = DateTime.Now.AddSeconds(ExitStationDelay);
                waitingToLeave = true;
                Program.DaedalusUI.newConsoleMessage("Leaving " + Daedalus.me.Station.Name.ToString() + " in " + ExitStationDelay.ToString("F0") + " seconds");
            }

            if (waitingToLeave && DateTime.Now > exitStationTime)
            {
                leaveStation = true;
                waitingToLeave = false;
            }
        }

        public static void triggerLeaveStation()
        {
            leaveStation = true;
            c_Routines.activeRoutine = Routine.Station_Leave;
        }

        public static void triggerLeaveStationDelayed()
        {
            leaveStationDelayed = true;
        }
        
        private static double RandWaitTime(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}
