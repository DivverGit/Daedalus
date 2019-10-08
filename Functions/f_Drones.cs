using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System.Collections.Generic;

namespace Daedalus.Functions
{
    public static class f_Drones
    {
        public class Commands
        {
            public static void Engage()
            {
                Daedalus.eve.Execute(ExecuteCommand.CmdDronesEngage);
                Daedalus.DaedalusUI.newConsoleMessage("f_Drones: Engaging");
            }
            public static void Launch()
            {
                Daedalus.myShip.LaunchAllDrones();
                Daedalus.DaedalusUI.newConsoleMessage("f_Drones: Launching");
            }
            public static void ReturnToBay()
            {
                Daedalus.eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
                Daedalus.DaedalusUI.newConsoleMessage("f_Drones: Returning");
            }
        }
    }
}
