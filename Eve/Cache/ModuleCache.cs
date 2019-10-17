using Daedalus.Eve.Cache.Base;
using Daedalus.Eve.Enums;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public class ModuleCache : WrappedCache<ShipSlot, IModule, DModule>
    {
        protected override void PopulateItems(ref Dictionary<ShipSlot, IModule> cache)
        {
            using (new FrameLock(true))
            {
                MyShip myShip = new MyShip();
                foreach (ShipSlot slot in ShipSlot.AllSlots)
                {
                    IModule mod = myShip.Module(slot.SlotType, slot.SlotNumber);
                    cache[slot] = mod;
                }
            }
        }
    }
}
