using EVE.ISXEVE;

namespace Daedalus.Functions
{
    public static class f_Drones
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

    public class Drone
    {
        public Entity entity { get; set; }
        public DroneType type { get; set; }
    }
    public enum DroneType
    {

    }
}
