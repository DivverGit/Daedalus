using EVE.ISXEVE;

namespace Daedalus.Functions
{
    static class f_EVECommands
    {
        public static void StopShip()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdStopShip);
        }
        public static void ExitStation()
        {
            Daedalus.eve.Execute(ExecuteCommand.CmdExitStation);
        }
    }
}
