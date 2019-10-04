using Daedalus.Behaviours;
using Daedalus.Data;
using Daedalus.Functions;
using Daedalus.Modules;
using Daedalus.Routines;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daedalus.Controllers
{
    public static class c_Modules
    {
        public static List<Afterburner> afterburners = new List<Afterburner>();
        public static List<ArmorRepairer> armorRepairers = new List<ArmorRepairer>();
        public static List<ShieldBooster> shieldBoosters = new List<ShieldBooster>();
        public static List<ShieldHardener> shieldHardeners = new List<ShieldHardener>();

        static c_Modules()
        {
            
        }

        private static IModule afterburnerModule;
        public static void PropulsionPulse()
        {
            foreach(Afterburner afterburner in afterburners)
            {
                afterburnerModule = Daedalus.myShip.Module(SlotType.MedSlot, afterburner.Slot_Index);
                if (!afterburnerModule.IsActive) afterburnerModule.Activate();
            }
        }

        private static IModule armorRepairerModule;
        public static void ArmorPulse()
        {
            foreach(ArmorRepairer armorRepairer in armorRepairers)
            {
                armorRepairerModule = Daedalus.myShip.Module(SlotType.LoSlot, armorRepairer.Slot_Index);
                double currentArmor = c_Status.armorCurrent;
                double maximumArmor = c_Status.armorMaximum;
                double deficit = (maximumArmor - currentArmor);
                if (deficit > armorRepairer.Repair_Amount && !armorRepairerModule.IsActive && !armorRepairerModule.IsDeactivating) armorRepairerModule.Activate();
                else if (deficit < armorRepairer.Repair_Amount && armorRepairerModule.IsActive && !armorRepairerModule.IsDeactivating) armorRepairerModule.Deactivate();
            }
        }

        private static IModule shieldBoosterModule;
        private static IModule shieldHardenerModule;
        public static void ShieldPulse()
        {
            foreach (ShieldBooster shieldBooster in shieldBoosters)
            {
                shieldBoosterModule = Daedalus.myShip.Module(SlotType.MedSlot, shieldBooster.Slot_Index);
                double currentShield = c_Status.shieldCurrent;
                double maximumShield = c_Status.shieldMaximum;
                double deficit = (maximumShield - currentShield);
                if (deficit > shieldBooster.Boost_Amount && !shieldBoosterModule.IsActive && !shieldBoosterModule.IsDeactivating) shieldBoosterModule.Activate();
                else if (deficit < shieldBooster.Boost_Amount && shieldBoosterModule.IsActive && !shieldBoosterModule.IsDeactivating) shieldBoosterModule.Deactivate();
            }

            foreach(ShieldHardener shieldHardener in shieldHardeners)
            {
                shieldHardenerModule = Daedalus.myShip.Module(SlotType.MedSlot, shieldHardener.Slot_Index);
                if (!shieldHardenerModule.IsActive) shieldHardenerModule.Activate();
            }
        }
    }
}