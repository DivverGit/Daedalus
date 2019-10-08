using Daedalus.Controllers;
using Daedalus.Data;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;

namespace Daedalus.Functions
{
    public static class f_Modules
    {
        public static List<IModule> HighPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
            }
            return modulesFitted;
        }
        public static List<IModule> MediumPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }
            return modulesFitted;
        }
        public static List<IModule> LowPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.LoSlot, i));
            }
            return modulesFitted;
        }

        public static void GetAllModules()
        {
            GetAfterburnerModules();
            GetArmorHardenerModules();
            GetArmorRepairModules();
            GetBastionModule();
            GetShieldBoosterModules();
            GetShieldHardenerModules();
            GetTrackingComputerModules();
            GetWeaponModules();
        }
        public static void GetAfterburnerModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 46) c_Modules.modules.Add(new Controllers.Module.Afterburner(module.ToItem.Name, i));
            }
        }
        public static void GetArmorHardenerModules()
        {
            List<IModule> modules = f_Modules.LowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 328) c_Modules.modules.Add(new Controllers.Module.ArmorHardener(module.ToItem.Name, i));
            }
        }
        public static void GetArmorRepairModules()
        {
            List<IModule> modules = f_Modules.LowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 62) c_Modules.modules.Add(new Controllers.Module.ArmorRepairer(module.ToItem.Name, i, Convert.ToDouble(module.ArmorHPRepaired)));
            }
        }
        public static void GetBastionModule()
        {
            List<IModule> modules = f_Modules.HighPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 515) c_Modules.modules.Add(new Controllers.Module.BastionModule(module.ToItem.Name, i));
            }
        }
        public static void GetShieldBoosterModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 40)    c_Modules.modules.Add(new Controllers.Module.ShieldBooster(module.ToItem.Name, i, Convert.ToDouble(module.ShieldBonus)));
            }
        }
        public static void GetShieldHardenerModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 77)    c_Modules.modules.Add(new Controllers.Module.ShieldHardener(module.ToItem.Name, i));
            }
        }
        public static void GetTrackingComputerModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 213) c_Modules.modules.Add(new Controllers.Module.TrackingComputer(module.ToItem.Name, i));
            }
        }
        public static void GetWeaponModules()
        {
            List<IModule> modules = f_Modules.HighPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.IsValid)
                {
                    if (d_Weapon_Groups.EnergyTurrets.Contains(module.ToItem.GroupID))
                    {
                        c_Modules.modules.Add(new Controllers.Module.Turret(module.ToItem.Name, i, SlotType.HiSlot, module.AccuracyFalloff, module.OptimalRange));
                    }
                    else if (d_Weapon_Groups.HybridTurrets.Contains(module.ToItem.GroupID))
                    {
                        c_Modules.modules.Add(new Controllers.Module.Turret(module.ToItem.Name, i, SlotType.HiSlot, module.AccuracyFalloff, module.OptimalRange));
                    }
                    else if (d_Weapon_Groups.MissileLaunchers.Contains(module.ToItem.GroupID))
                    {
                        ModuleCharge missile = module.Charge;
                        double maxFlightRange = (missile.MaxFlightTime * missile.MaxVelocity);
                        c_Modules.modules.Add(new Controllers.Module.MissileLauncher(module.ToItem.Name, i, SlotType.HiSlot, maxFlightRange));
                    }
                    else if (d_Weapon_Groups.ProjectileTurret.Contains(module.ToItem.GroupID))
                    {
                        c_Modules.modules.Add(new Controllers.Module.Turret(module.ToItem.Name, i, SlotType.HiSlot, module.AccuracyFalloff, module.OptimalRange));
                    }
                }
            }
        }

        public static void DeactivateAllModules()
        {
            List<IModule> allModules = Daedalus.myShip.GetModules();
            foreach (IModule module in allModules)
            {
                if (module.IsActive) module.Deactivate();
            }
        }
    }
}
