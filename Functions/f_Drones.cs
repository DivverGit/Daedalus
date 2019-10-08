using EVE.ISXEVE;
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

    public class Drone
    {
        public Entity entity { get; set; }
        public DroneType droneType { get; set; }
        public Drone(Entity anEntity, DroneType Type)
        {
            entity = anEntity;
            droneType = Type;
        }
    }
    public enum DroneType
    {
        Light,
        Medium,
        Heavy,
        Sentry
    }
}
