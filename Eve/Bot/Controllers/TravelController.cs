using Daedalus.Eve.Bot.States;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.Controllers
{
    class TravelController : Controller
    {
        private SolarSystem Destination;

        protected override void RegisterStates()
        {
            AddState("undock", new UndockState(), "travel");

            WarpAndJumpState travel = new WarpAndJumpState();
            travel.PreState += (state) => (state as WarpAndJumpState)?.SetDesto(Destination);

            AddState("travel", travel, "dock");
            AddState("dock", new DockState());
        }
    }
}
