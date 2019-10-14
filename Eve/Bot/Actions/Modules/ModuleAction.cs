using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.Actions
{
    public abstract class ModuleAction : Action
    {
        protected int SlotIndex;
        protected SlotType SlotType;

        public ModuleAction(int slotIndex, SlotType slotType)
        {
            SlotIndex = slotIndex;
            SlotType = slotType;
        }
    }
}
