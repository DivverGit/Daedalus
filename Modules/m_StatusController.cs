using Daedalus.Behaviours;
using Daedalus.Data;
using Daedalus.Functions;
using Daedalus.Routines;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Modules
{
    public static class m_StatusController
    {

        static m_StatusController()
        {
            d_Charges.Init();
        }

        public static void Pulse()
        {
            refreshModules();
            refreshShipData();
        }

        public static void refreshModules()
        {
            List<IModule> Modules = new List<IModule>();

            // Refresh hi slot modules
            Modules = f_Modules.GetHiSlotModules();

            if (Modules[0].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot1, Modules[0].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 0).ToString("#.##") + " DPS)");
            if (Modules[1].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot2, Modules[1].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 1).ToString("#.##") + " DPS)");
            if (Modules[2].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[2].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 2).ToString("#.##") + " DPS)");
            if (Modules[3].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[3].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 3).ToString("#.##") + " DPS)");
            if (Modules[4].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[4].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 4).ToString("#.##") + " DPS)");
            if (Modules[5].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[5].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 5).ToString("#.##") + " DPS)");
            if (Modules[6].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[6].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 6).ToString("#.##") + " DPS)");
            if (Modules[7].IsValid) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[7].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 7).ToString("#.##") + " DPS)");
        }

        public static float getChargeDPS(SlotType slotType, int slot)
        {
            float dps = 0;

            IModule module = Daedalus.myShip.Module(slotType, slot);
            ModuleCharge charge = module.Charge;
            int typeId = charge.TypeId;

            foreach(chargeObject chargeObject in d_Charges.chargeObjects)
            {
                if(chargeObject.TypeId == typeId)
                {
                    dps = chargeObject.EMDamage + chargeObject.ExplosiveDamage + chargeObject.KineticDamage + chargeObject.ThermalDamage;
                    dps *= (float)module.DamageModifier;
                    dps /= (float)module.RateOfFire;
                }
            }

            return dps;
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

        public static void refreshShipData()
        {
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.shipName, Daedalus.myShip.Name);

            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.shield, Daedalus.myShip.Shield.ToString("#") + " / " + Daedalus.myShip.MaxShield.ToString("#"));
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.armor, Daedalus.myShip.Armor.ToString("#") + " / " + Daedalus.myShip.MaxArmor.ToString("#"));
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hull, Daedalus.myShip.Structure.ToString("#") + " / " + Daedalus.myShip.MaxStructure.ToString("#"));
        }
    }
}
