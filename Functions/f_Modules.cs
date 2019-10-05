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
        public static float getModuleOptimalRange(SlotType slotType, int slotIndex)
        {
            float optimalRange = 0;

            IModule module = Daedalus.myShip.Module(slotType, slotIndex);

            if (GetWeaponInfo(slotType, slotIndex).weaponType == WeaponType.Missile_Launcher)
            {
                ModuleCharge missile = module.Charge;
                optimalRange = ((float)missile.MaxFlightTime * (float)missile.MaxVelocity);
            }
            else
            {
                optimalRange = (float)module.OptimalRange;
            }

            return optimalRange;
        }
        public static float getModuleFalloffRange(SlotType slotType, int slotIndex)
        {
            float falloffRange = 0;

            IModule module = Daedalus.myShip.Module(slotType, slotIndex);

            if (GetWeaponInfo(slotType, slotIndex).weaponType == WeaponType.Missile_Launcher)
            {
                ModuleCharge missile = module.Charge;
                falloffRange = 0;
            }
            else
            {
                falloffRange = (float)module.AccuracyFalloff;
            }

            return falloffRange;
        }
        public static void getAfterburnerModules()
        {
            List<IModule> modules = f_Modules.GetMedSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 46)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("Afterburner enabled");
                    c_Modules.afterburners.Add(new Modules.Afterburner(module.ToItem.Name, i));
                }
            }
        }
        public static void getArmorRepairModules()
        {
            List<IModule> modules = f_Modules.GetLoSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 62)
                {
                    double armorRepaired = Convert.ToDouble(module.ArmorHPRepaired);
                    Daedalus.DaedalusUI.newConsoleMessage("ArmorRepair enabled - " + armorRepaired.ToString("#") + " HP");
                    c_Modules.armorRepairers.Add(new Modules.ArmorRepairer(module.ToItem.Name, i, Convert.ToDouble(module.ArmorHPRepaired)));
                }
            }
        }
        public static void getShieldBoosterModules()
        {
            List<IModule> modules = f_Modules.GetMedSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 40)
                {
                    double shieldBoosted = Convert.ToDouble(module.ShieldBonus);
                    Daedalus.DaedalusUI.newConsoleMessage("ShieldBooster enabled - " + shieldBoosted.ToString("#") + " HP");
                    c_Modules.shieldBoosters.Add(new Modules.ShieldBooster(module.ToItem.Name, i, Convert.ToDouble(module.ShieldBonus)));
                }
            }
        }
        public static void getShieldHardenerModules()
        {
            List<IModule> modules = f_Modules.GetMedSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 77)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("ShieldHardener enabled");
                    c_Modules.shieldHardeners.Add(new Modules.ShieldHardener(module.ToItem.Name, i));
                }
            }
        }
        public static void getArmorHardenerModules()
        {
            List<IModule> modules = f_Modules.GetLoSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if (module.ToItem.GroupID == 328)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("ArmorHardener enabled");
                    c_Modules.armorHardeners.Add(new Modules.ArmorHardener(module.ToItem.Name, i));
                }
            }
        }
        public static void getWeaponModules()
        {
            List<IModule> modules = f_Modules.GetHiSlotModules();
            for (int i = 0; i < modules.Count; i++)
            {
                IModule module = modules[i];
                if(module.IsValid)
                {
                    WeaponModule toAdd = GetWeaponInfo(SlotType.HiSlot, i);
                    if (toAdd != null)
                    {
                        c_Modules.weaponModules.Add(toAdd);
                        Daedalus.DaedalusUI.newConsoleMessage(toAdd.name + " registered");
                    }
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
