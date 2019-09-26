using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_Modules
    {
        static f_Modules()
        {
            // Init
        }

        public static List<IModule> GetMiningLasers()
        {
            List<IModule> MiningLasers = new List<IModule>();
            List<IModule> ModulesFitted = Daedalus.myShip.GetModules();
            foreach (IModule Module in ModulesFitted)
            {
                if (Module.MiningAmount > 0)
                {
                    MiningLasers.Add(Module);
                }
            }
            return MiningLasers;
        }
        
        public static bool UsesCrystals(IModule MiningLaser)
        {
            if (MiningLaser.ChargeSize > 0) return true;
            else
            {
                return false;
            }
        }
    }
}
