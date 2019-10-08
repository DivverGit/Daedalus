using Daedalus.Functions;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System.Collections.Generic;

namespace Daedalus.Controllers
{
    public static class c_Modules
    {
        public static List<Afterburner> afterburners = new List<Afterburner>();
        public static List<ArmorHardener> armorHardeners = new List<ArmorHardener>();
        public static List<ArmorRepairer> armorRepairers = new List<ArmorRepairer>();
        public static List<ShieldBooster> shieldBoosters = new List<ShieldBooster>();
        public static List<ShieldHardener> shieldHardeners = new List<ShieldHardener>();
        public static List<WeaponModule> weaponModules = new List<WeaponModule>();

        private static IModule armorHardenerIModule;
        private static IModule armorRepairerIModule;
        public static void ArmorPulse()
        {
            foreach (ArmorHardener armorHardener in armorHardeners)
            {
                armorHardenerIModule = Daedalus.myShip.Module(SlotType.LoSlot, armorHardener.Slot_Index);
                if (!armorHardenerIModule.IsActive) armorHardenerIModule.Activate();
            }
            foreach (ArmorRepairer armorRepairer in armorRepairers)
            {
                armorRepairerIModule = Daedalus.myShip.Module(SlotType.LoSlot, armorRepairer.Slot_Index);
                double currentArmor = c_Status.armorCurrent;
                double maximumArmor = c_Status.armorMaximum;
                double deficit = (maximumArmor - currentArmor);
                if (deficit > armorRepairer.Repair_Amount && !armorRepairerIModule.IsActive && !armorRepairerIModule.IsDeactivating) armorRepairerIModule.Activate();
                else if (deficit < armorRepairer.Repair_Amount && armorRepairerIModule.IsActive && !armorRepairerIModule.IsDeactivating) armorRepairerIModule.Deactivate();
            }
        }

        private static IModule afterburnerIModule;
        public static void PropulsionPulse()
        {
            foreach (Afterburner afterburner in afterburners)
            {
                afterburnerIModule = Daedalus.myShip.Module(SlotType.MedSlot, afterburner.Slot_Index);
                if (!afterburnerIModule.IsActive) afterburnerIModule.Activate();
            }
        }

        private static IModule shieldBoosterIModule;
        private static IModule shieldHardenerIModule;
        public static void ShieldPulse()
        {
            foreach (ShieldBooster shieldBooster in shieldBoosters)
            {
                shieldBoosterIModule = Daedalus.myShip.Module(SlotType.MedSlot, shieldBooster.Slot_Index);
                double currentShield = c_Status.shieldCurrent;
                double maximumShield = c_Status.shieldMaximum;
                double deficit = (maximumShield - currentShield);
                if (deficit > shieldBooster.Boost_Amount && !shieldBoosterIModule.IsActive && !shieldBoosterIModule.IsDeactivating) shieldBoosterIModule.Activate();
                else if (deficit < shieldBooster.Boost_Amount && shieldBoosterIModule.IsActive && !shieldBoosterIModule.IsDeactivating) shieldBoosterIModule.Deactivate();
            }
            foreach (ShieldHardener shieldHardener in shieldHardeners)
            {
                shieldHardenerIModule = Daedalus.myShip.Module(SlotType.MedSlot, shieldHardener.Slot_Index);
                if (!shieldHardenerIModule.IsActive) shieldHardenerIModule.Activate();
            }
        }

        private static IModule weaponIModule;
        public static void WeaponsPulse(Entity target)
        {
            foreach (WeaponModule weaponModule in weaponModules)
            {
                weaponIModule = Daedalus.myShip.Module(weaponModule.slotType, weaponModule.slotIndex);
                if (weaponIModule.IsValid && !weaponIModule.IsActive && !weaponIModule.IsReloadingAmmo)
                {
                    float falloffRange = f_Modules.GetAttributes.FalloffRange(weaponModule.slotType, weaponModule.slotIndex);
                    float optimalRange = f_Modules.GetAttributes.OptimalRange(weaponModule.slotType, weaponModule.slotIndex);
                    float engageRange = (falloffRange + optimalRange);
                    float distanceToTarget = (float)f_Entities.GetDistanceBetween(target);
                    if (distanceToTarget < engageRange) weaponIModule.Activate();
                }
            }
        }
    }

    public class Afterburner
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public Afterburner(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class ArmorHardener
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public ArmorHardener(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class ArmorRepairer
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public double Repair_Amount { get; set; }
        public ArmorRepairer(string name, int slot, double repairAmount)
        {
            Name = name;
            Slot_Index = slot;
            Repair_Amount = repairAmount;
        }
    }
    public class BastionModule
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public BastionModule(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class ShieldBooster
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public double Boost_Amount { get; set; }
        public ShieldBooster(string name, int slot, double boostAmount)
        {
            Name = name;
            Slot_Index = slot;
            Boost_Amount = boostAmount;
        }
    }
    public class ShieldHardener
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public ShieldHardener(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class TrackingComputer
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public TrackingComputer(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class WeaponModule
    {
        public string name { get; set; }
        public WeaponType weaponType { get; set; }
        public SlotType slotType { get; set; }
        public int slotIndex { get; set; }
        public float hitChance { get; set; }
        public WeaponModule(string aName, WeaponType aWeaponType, SlotType aSlotType, int aSlotIndex)
        {
            name = aName;
            weaponType = aWeaponType;
            slotType = aSlotType;
            slotIndex = aSlotIndex;
        }
    }

    public enum WeaponType
    {
        Energy_Turret,
        Hybrid_Turret,
        Missile_Launcher,
        Projectile_Turret
    }
}