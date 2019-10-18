using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.States
{
    class WarpAndJumpState : State
    {
        private SolarSystem Desto;

        public void SetDesto(SolarSystem desto)
        {
            this.Desto = desto;
        }

        public override bool DoWork()
        {
            using (new FrameLock(true))
            {
                if (Desto == null)
                    return false;

                EVE.ISXEVE.EVE eve = new EVE.ISXEVE.EVE();
                Me me = new Me();

                if (me.SolarSystemID == Desto.ID)
                    return true;

                List<int> Waypoints = eve.GetWaypoints();
                if (Waypoints.Count > 1 && Waypoints.Contains(Desto.ID))
                {
                    eve.ClearAllWaypoints();
                    // Wait till next pulse
                    return false;
                } else if (Waypoints.Count == 1 && !Waypoints.Contains(Desto.ID))
                {
                    Desto.SetDestination();
                    return false;
                }

                if (!me.AutoPilotOn)
                {
                    eve.Execute(ExecuteCommand.CmdToggleAutopilot);
                    return false;
                }
                return false;
            }
        }
    }
}
