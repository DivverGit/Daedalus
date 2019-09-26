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
    static class r_ReturnToStation
    {
        // Variables
        private static bool InitComplete = false;
        private static DateTime TimeToWarp;
        private static bool EnRoute = false;
        private static Entity DeliveryStation;
        private static bool WaitingToDock = false;

        static r_ReturnToStation()
        {
            if(!InitComplete)
            {
                InitComplete = true;
                EnRoute = false;
                WaitingToDock = false;
                f_Drones.ReturnAllDronesToBay();
                f_EVECommands.StopShip();
                TimeToWarp = DateTime.Now.AddSeconds(5);
            }
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                if(!EnRoute && DateTime.Now > TimeToWarp)
                {
                    DeliveryStation = f_Entities.GetStations()[0];
                    f_WarpTo.Station(DeliveryStation);
                    EnRoute = true;
                }
                else if(EnRoute && !WaitingToDock)
                {
                    string OurStatus = f_Entities.GetEntityMode(Daedalus.Me.ToEntity);
                    double Distance = f_Entities.DistanceFromPlayerToEntity(DeliveryStation);
                    if (OurStatus != "Warping" && Distance < 10000)
                    {
                        DeliveryStation.Dock();
                        InitComplete = false;
                        WaitingToDock = true;
                    }
                }
            }
        }
    }
}
