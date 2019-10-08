using Daedalus.Functions;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System.Collections.Generic;

namespace Daedalus.Controllers
{
    public static class c_Modules
    {
        public static List<Module> modules = new List<Module>();
        public static void Pulse()
        {
            DefensePulse();
            PropulsionPulse();
            UtilityPulse();
        }

        public static void DefensePulse()
        {
            foreach (Module moduleObject in modules)
            {
                if (moduleObject is Module.ArmorHardener)
                {
                    Module.ArmorHardener armorHardenerObject = moduleObject as Module.ArmorHardener;
                    IModule module = Daedalus.myShip.Module(SlotType.LoSlot, armorHardenerObject.Slot_Index);
                    if (!module.IsActive) module.Activate();
                }
                else if (moduleObject is Module.ArmorRepairer)
                {
                    Module.ArmorRepairer armorRepairerObject = moduleObject as Module.ArmorRepairer;
                    IModule module = Daedalus.myShip.Module(SlotType.LoSlot, armorRepairerObject.Slot_Index);
                    double currentArmor = c_Status.armorCurrent;
                    double maximumArmor = c_Status.armorMaximum;
                    double deficit = (maximumArmor - currentArmor);
                    if (deficit > armorRepairerObject.Repair_Amount && !module.IsActive && !module.IsDeactivating) module.Activate();
                    else if (deficit < armorRepairerObject.Repair_Amount && module.IsActive && !module.IsDeactivating) module.Deactivate();
                }
                else if (moduleObject is Module.BastionModule)
                {
                    Module.BastionModule bastionModuleObject = moduleObject as Module.BastionModule;
                    IModule module = Daedalus.myShip.Module(SlotType.HiSlot, bastionModuleObject.Slot_Index);
                    if (!module.IsActive) module.Activate();
                }
                else if (moduleObject is Module.ShieldBooster)
                {
                    Module.ShieldBooster shieldBoosterObject = moduleObject as Module.ShieldBooster;
                    IModule module = Daedalus.myShip.Module(SlotType.MedSlot, shieldBoosterObject.Slot_Index);
                    double currentShield = c_Status.shieldCurrent;
                    double maximumShield = c_Status.shieldMaximum;
                    double deficit = (maximumShield - currentShield);
                    if (deficit > shieldBoosterObject.Boost_Amount && !module.IsActive && !module.IsDeactivating) module.Activate();
                    else if (deficit < shieldBoosterObject.Boost_Amount && module.IsActive && !module.IsDeactivating) module.Deactivate();
                }
                else if (moduleObject is Module.ShieldHardener)
                {
                    Module.ShieldHardener shieldHardenerObject = moduleObject as Module.ShieldHardener;
                    IModule module = Daedalus.myShip.Module(SlotType.MedSlot, shieldHardenerObject.Slot_Index);
                    if (!module.IsActive) module.Activate();
                }
            }
        }

        public static void OffensePulse(Entity target)
        {
            foreach (Module moduleObject in modules)
            {
                if (moduleObject is Module.MissileLauncher)
                {
                    Module.MissileLauncher missileLauncherObject = moduleObject as Module.MissileLauncher;
                    IModule module = Daedalus.myShip.Module(missileLauncherObject.slotType, missileLauncherObject.slotIndex);
                    if (module.IsValid && !module.IsActive && !module.IsReloadingAmmo)
                    {
                        double engageRange = missileLauncherObject.maxFlightRange;
                        double distanceToTarget = f_Entities.GetDistanceBetween(target);
                        if (distanceToTarget < engageRange) module.Activate();
                    }
                }
                else if (moduleObject is Module.Turret)
                {
                    Module.Turret turretObject = moduleObject as Module.Turret;
                    IModule module = Daedalus.myShip.Module(turretObject.slotType, turretObject.slotIndex);
                    if (module.IsValid && !module.IsActive && !module.IsReloadingAmmo)
                    {
                        double? falloffRange = turretObject.falloffRange;
                        double? optimalRange = turretObject.optimalRange;
                        double? engageRange = (falloffRange + optimalRange);
                        double distanceToTarget = f_Entities.GetDistanceBetween(target);
                        if (distanceToTarget < engageRange) module.Activate();
                    }
                }
            }
        }

        public static void PropulsionPulse()
        {
            foreach (Module moduleObject in modules)
            {
                if(moduleObject is Module.Afterburner)
                {
                    Module.Afterburner afterburnerObject = moduleObject as Module.Afterburner;
                    IModule module = Daedalus.myShip.Module(SlotType.MedSlot, afterburnerObject.Slot_Index);
                    if (!module.IsActive) module.Activate();
                }
            }
        }

        public static void UtilityPulse()
        {
            foreach (Module moduleObject in modules)
            {
                if (moduleObject is Module.TrackingComputer)
                {
                    Module.TrackingComputer trackingComputerObject = moduleObject as Module.TrackingComputer;
                    IModule module = Daedalus.myShip.Module(SlotType.MedSlot, trackingComputerObject.Slot_Index);
                    if (!module.IsActive) module.Activate();
                }
            }
        }
    }

    public class Module
    {
        public class Afterburner : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public Afterburner(string name_value, int slotIndex_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
            }
        }
        public class ArmorHardener : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public ArmorHardener(string name_value, int slotIndex_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
            }
        }
        public class ArmorRepairer : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public double Repair_Amount { get; set; }
            public ArmorRepairer(string name_value, int slotIndex_value, double repairAmount_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
                Repair_Amount = repairAmount_value;
            }
        }
        public class BastionModule : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public BastionModule(string name_value, int slotIndex_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
            }
        }
        public class MissileLauncher : Module
        {
            public string name { get; set; }
            public int slotIndex { get; set; }
            public SlotType slotType { get; set; }
            public double maxFlightRange { get; set; }
            public MissileLauncher(string name_value, int slotIndex_value, SlotType slotType_value, double maxFlightRange_value)
            {
                name = name_value;
                slotIndex = slotIndex_value;
                slotType = slotType_value;
                maxFlightRange = maxFlightRange_value;
            }
        }
        public class ShieldBooster : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public double Boost_Amount { get; set; }
            public ShieldBooster(string name_value, int slotIndex_value, double boostAmount_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
                Boost_Amount = boostAmount_value;
            }
        }
        public class ShieldHardener : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public ShieldHardener(string name_value, int slotIndex_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
            }
        }
        public class TrackingComputer : Module
        {
            public string Name { get; set; }
            public int Slot_Index { get; set; }
            public TrackingComputer(string name_value, int slotIndex_value)
            {
                Name = name_value;
                Slot_Index = slotIndex_value;
            }
        }
        public class Turret : Module
        {
            public string name { get; set; }
            public int slotIndex { get; set; }
            public SlotType slotType { get; set; }
            public double? falloffRange { get; set; }
            public double? optimalRange { get; set; }
            public Turret(string name_value, int slotIndex_value, SlotType slotType_value, double? falloffRange_value, double? optimalRange_value)
            {
                name = name_value;
                slotIndex = slotIndex_value;
                slotType = slotType_value;
                falloffRange = falloffRange_value;
                optimalRange = optimalRange_value;
            }
        }
    }
}