using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_Drones
    {
        static f_Drones()
        {
            // Init
        }

        public static void ReturnAllDronesToBay()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
        }

        public static void EngageTarget()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdDronesEngage);
        }
    }
}
