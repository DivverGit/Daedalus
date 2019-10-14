using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public class DModule : Wrapper<int, SlotType>
    {
        private DModuleType ModuleType { get; }

        public DModule(int slotIndex, SlotType slotType, DModuleType moduleType)
        {
            base.Key = slotIndex;
            Initialize(slotType);
            ModuleType = moduleType;
        }

        public bool CanActivate()
        {
            MyShip myShip = new MyShip();
            double? activationCost = myShip.Module(base.Value, base.Key).ActivationCost;
            if (activationCost != null)
            {
                double currrentCapacitor = myShip.Capacitor;
                return activationCost < currrentCapacitor ? true : false;
            }
            else
            {
                return false;
            }
        }

        public void Deconstruct(out DModuleType moduleType)
        {
            moduleType = ModuleType;

            //C# 8.0
            //if (DModule is DModule(Afterburner))
            //{
            //  code executes if ModuleType is Afterburner
            //}
        }

        public override void Initialize(SlotType value)
        {

        }
    }

    public enum DModuleType
    {
        Afterburner,
        ShieldBooster,
        ShieldHardener
    }
}
