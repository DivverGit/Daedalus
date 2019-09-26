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
            Daedalus.Eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
        }

        public static void EngageTarget()
        {
            Daedalus.Eve.Execute(ExecuteCommand.CmdDronesEngage);
        }
    }
}
