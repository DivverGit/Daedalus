using Daedalus.Controllers;
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
        public static List<IModule> GetAllModules()
        {
            List<IModule> ModulesFitted = new List<IModule>();

            int i;

            // Get hi slot modules
            for(i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
            }

            // Get med slot modules
            for (i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }

            // Get lo slot modules
            for (i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.LoSlot, i));
            }

            return ModulesFitted;
        }
        public static List<IModule> GetHiSlotModules()
        {
            List<IModule> ModulesFitted = new List<IModule>();

            int i;

            // Get hi slot modules
            for (i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
            }

            return ModulesFitted;
        }
        public static List<IModule> GetMedSlotModules()
        {
            List<IModule> ModulesFitted = new List<IModule>();

            int i;

            // Get med slot modules
            for (i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }

            return ModulesFitted;
        }
        public static List<IModule> GetLoSlotModules()
        {
            List<IModule> ModulesFitted = new List<IModule>();

            int i;

            // Get lo slot modules
            for (i = 0; i < 8; i++)
            {
                ModulesFitted.Add(Daedalus.myShip.Module(SlotType.LoSlot, i));
            }

            return ModulesFitted;
        }
        public static float getModuleOptimalRange(SlotType slotType, int slot)
        {
            float optimalRange = 0;

            IModule module = Daedalus.myShip.Module(slotType, slot);

            optimalRange = (float)module.OptimalRange;

            return optimalRange;
        }
        public static float getModuleFalloffRange(SlotType slotType, int slot)
        {
            float falloffRange = 0;

            IModule module = Daedalus.myShip.Module(slotType, slot);

            falloffRange = (float)module.AccuracyFalloff;

            return falloffRange;
        }
        public static void getAfterburnerModules()
        {
            List<IModule> modules = f_Modules.GetMedSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.MaxVelocityBonus > 0 && module.ToItem.Name.Contains("Afterburner"))
                {
                    c_Modules.afterburners.Add(new Modules.Afterburner(module.ToItem.Name, i));
                    Daedalus.DaedalusUI.newConsoleMessage(module.ToItem.Name + " was registered as an afterburner");
                }
            }
        }
    }
}
