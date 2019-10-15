using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public class DModule : CacheWrapper<int, Module, DModule>
    {
        private DModuleType ModuleType { get; }

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

        public override void Initialize(Module value)
        {
            throw new NotImplementedException();
        }
    }

    public enum DModuleType
    {
        Afterburner,
        ShieldBooster,
        ShieldHardener
    }
}
