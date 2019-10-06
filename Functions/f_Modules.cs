using Daedalus.Controllers;
using Daedalus.Data;
using Daedalus.Modules;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Modules
    {
        public static List<IModule> GetAllModules()
        {
            List<IModule> modulesFitted = new List<IModule>();

            // Get hi slot modules
            for(int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
            }

            // Get med slot modules
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }

            // Get lo slot modules
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.LoSlot, i));
            }

            return modulesFitted;
        }
        public static List<IModule> GetHighPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
            }
            return modulesFitted;
        }
        public static List<IModule> GetMediumPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }
            return modulesFitted;
        }
        public static List<IModule> GetLowPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.LoSlot, i));
            }
            return modulesFitted;
        }
        public static float GetModuleOptimalRange(SlotType slotType, int slotIndex)
        {
            IModule module = Daedalus.myShip.Module(slotType, slotIndex);
            if (GetWeaponInfo(slotType, slotIndex).weaponType == WeaponType.Missile_Launcher)
            {
                ModuleCharge missile = module.Charge;
                return ((float)missile.MaxFlightTime * (float)missile.MaxVelocity);
            }
            else
            {
                return (float)module.OptimalRange;
            }
        }
        public static float GetModuleFalloffRange(SlotType slotType, int slotIndex)
        {
            IModule module = Daedalus.myShip.Module(slotType, slotIndex);
            if (GetWeaponInfo(slotType, slotIndex).weaponType != WeaponType.Missile_Launcher)   return (float)module.AccuracyFalloff;
            else
            {
                return 0.0f;
            }
        }
        public static void GetAfterburnerModules()
        {
            List<IModule> modules = f_Modules.GetMediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 46)    c_Modules.afterburners.Add(new Modules.Afterburner(module.ToItem.Name, i));
            }
        }
        public static void GetArmorRepairModules()
        {
            List<IModule> modules = f_Modules.GetLowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 62)    c_Modules.armorRepairers.Add(new Modules.ArmorRepairer(module.ToItem.Name, i, Convert.ToDouble(module.ArmorHPRepaired)));
            }
        }
        public static void GetShieldBoosterModules()
        {
            List<IModule> modules = f_Modules.GetMediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 40)    c_Modules.shieldBoosters.Add(new Modules.ShieldBooster(module.ToItem.Name, i, Convert.ToDouble(module.ShieldBonus)));
            }
        }
        public static void GetShieldHardenerModules()
        {
            List<IModule> modules = f_Modules.GetMediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 77)    c_Modules.shieldHardeners.Add(new Modules.ShieldHardener(module.ToItem.Name, i));
            }
        }
        public static void GetArmorHardenerModules()
        {
            List<IModule> modules = f_Modules.GetLowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 328)   c_Modules.armorHardeners.Add(new Modules.ArmorHardener(module.ToItem.Name, i));
            }
        }
        public static void GetWeaponModules()
        {
            List<IModule> modules = f_Modules.GetHighPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if(module.IsValid)
                {
                    WeaponModule toAdd = GetWeaponInfo(SlotType.HiSlot, i);
                    if (toAdd != null)  c_Modules.weaponModules.Add(toAdd);
                }
            }
        }
        public static WeaponModule GetWeaponInfo(SlotType slotType, int slotIndex)
        {
            IModule module = Daedalus.myShip.Module(slotType, slotIndex);
            if (d_Weapon_Types.EnergyTurrets.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Energy_Turret, slotType, slotIndex);
            }
            else if (d_Weapon_Types.HybridTurrets.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Hybrid_Turret, slotType, slotIndex);
            }
            else if (d_Weapon_Types.MissileLaunchers.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Missile_Launcher, slotType, slotIndex);
            }
            else if (d_Weapon_Types.ProjectileTurret.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Projectile_Turret, slotType, slotIndex);
            }
            else
            {
                return null;
            }
        }
    }
}
