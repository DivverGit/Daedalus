using Daedalus.Eve.Cache.Base;
using Daedalus.Eve.Enums;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public class DModule : CacheWrapper<ShipSlot, IModule, DModule>
    {
        public ShipSlot ShipSlot => Key;
        public long ItemID;
        public long CategoryID;

        public bool CanActivate()
        {
            IModule mod = GetRaw();
            if (mod == null || !mod.IsValid)
                return false;

            double? activationCost = mod.ActivationCost;
            if (activationCost != null)
            {
                double currrentCapacitor = new MyShip().Capacitor;
                return activationCost < currrentCapacitor ? true : false;
            }
            else
            {
                return false;
            }
        }

        public override void Initialize(IModule value)
        {
            IItem asItem = value.ToItem;
            ItemID = asItem.ID;
            CategoryID = asItem.CategoryID;
        }


    }

    public enum DModuleType
    {
        Afterburner,
        ShieldBooster,
        ShieldHardener
    }
}
