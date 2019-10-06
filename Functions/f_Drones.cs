using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_Drones
    {
        public static void Engage()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdDronesEngage);
        }
        public static void Launch()
        {
            Daedalus.myShip.LaunchAllDrones();
        }
        public static void ReturnToBay()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
        }
    }
}
