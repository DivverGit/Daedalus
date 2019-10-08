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
        public class GetAttributes
        {
            public static float FalloffRange(SlotType slotType, int slotIndex)
            {
                IModule module = Daedalus.myShip.Module(slotType, slotIndex);
                if (GetWeaponType(slotType, slotIndex).weaponType != WeaponType.Missile_Launcher) return (float)module.AccuracyFalloff;
                else
                {
                    return 0.0f;
                }
            }
            public static float OptimalRange(SlotType slotType, int slotIndex)
            {
                IModule module = Daedalus.myShip.Module(slotType, slotIndex);
                if (GetWeaponType(slotType, slotIndex).weaponType == WeaponType.Missile_Launcher)
                {
                    ModuleCharge missile = module.Charge;
                    return ((float)missile.MaxFlightTime * (float)missile.MaxVelocity);
                }
                else
                {
                    return (float)module.OptimalRange;
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
        public static void GetAfterburnerModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 46) c_Modules.afterburners.Add(new Afterburner(module.ToItem.Name, i));
            }
        }
        public static List<IModule> AllModules()
        {
            List<IModule> modulesFitted = new List<IModule>();

            // Get hi slot modules
            for (int i = 0; i < 8; i++)
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
        public static void GetArmorHardenerModules()
        {
            List<IModule> modules = f_Modules.LowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 328) c_Modules.armorHardeners.Add(new ArmorHardener(module.ToItem.Name, i));
            }
        }
        public static void GetArmorRepairModules()
        {
            List<IModule> modules = f_Modules.LowPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 62) c_Modules.armorRepairers.Add(new ArmorRepairer(module.ToItem.Name, i, Convert.ToDouble(module.ArmorHPRepaired)));
            }
        }
        public static List<IModule> HighPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.HiSlot, i));
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
        public static List<IModule> MediumPowerModules()
        {
            List<IModule> modulesFitted = new List<IModule>();
            for (int i = 0; i < 8; i++)
            {
                modulesFitted.Add(Daedalus.myShip.Module(SlotType.MedSlot, i));
            }
            return modulesFitted;
        }
        public static void GetShieldBoosterModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 40)    c_Modules.shieldBoosters.Add(new ShieldBooster(module.ToItem.Name, i, Convert.ToDouble(module.ShieldBonus)));
            }
        }
        public static void GetShieldHardenerModules()
        {
            List<IModule> modules = f_Modules.MediumPowerModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 77)    c_Modules.shieldHardeners.Add(new ShieldHardener(module.ToItem.Name, i));
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
                    WeaponModule toAdd = GetWeaponType(SlotType.HiSlot, i);
                    if (toAdd != null) c_Modules.weaponModules.Add(toAdd);
                }
            }
        }
        public static WeaponModule GetWeaponType(SlotType slotType, int slotIndex)
        {
            IModule module = Daedalus.myShip.Module(slotType, slotIndex);
            if (d_Weapon_Groups.EnergyTurrets.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Energy_Turret, slotType, slotIndex);
            }
            else if (d_Weapon_Groups.HybridTurrets.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Hybrid_Turret, slotType, slotIndex);
            }
            else if (d_Weapon_Groups.MissileLaunchers.Contains(module.ToItem.GroupID))
            {
                return new WeaponModule(module.ToItem.Name, WeaponType.Missile_Launcher, slotType, slotIndex);
            }
            else if (d_Weapon_Groups.ProjectileTurret.Contains(module.ToItem.GroupID))
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
