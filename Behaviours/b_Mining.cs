using Daedalus.Functions;
using Daedalus.Modules;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Behaviours
{
    public static class b_Mining
    {
        public static bool InitComplete = false;

        static b_Mining()
        {
            if(!InitComplete)
            {
                InitComplete = true;
                f_Bookmarks.GetSafeSpots();
            }
        }

        public static void Pulse()
        {
            if (Daedalus.Me.InStation && !Daedalus.Me.InSpace)
            {
                if (m_RoutineController.ActiveRoutine != Routine.Station)
                {
                    m_RoutineController.ActiveRoutine = Routine.Station;
                }
            }
            else if (!Daedalus.Me.InStation && Daedalus.Me.InSpace)
            {
                if (f_Inventory.IsDeliveryRequired() && m_RoutineController.ActiveRoutine != Routine.ReturnToStation)
                {
                    m_RoutineController.ActiveRoutine = Routine.ReturnToStation;
                }
                else if (m_RoutineController.ActiveRoutine == Routine.Idle)
                {
                    m_RoutineController.ActiveRoutine = Routine.TravelToBelt;
                }
            }
            m_RoutineController.Pulse();
        }
    }
}