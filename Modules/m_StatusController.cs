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
            d_ChargeData.Init();
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

            if (Modules[0].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot1, Modules[0].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 0).ToString("#.##") + " DPS)");
            if (Modules[1].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot2, Modules[1].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 1).ToString("#.##") + " DPS)");
            if (Modules[2].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[2].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 2).ToString("#.##") + " DPS)");
            if (Modules[3].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[3].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 3).ToString("#.##") + " DPS)");
            if (Modules[4].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[4].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 4).ToString("#.##") + " DPS)");
            if (Modules[5].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[5].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 5).ToString("#.##") + " DPS)");
            if (Modules[6].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[6].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 6).ToString("#.##") + " DPS)");
            if (Modules[7].MaxCharges > 0) Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[7].ToItem.Name + " (" + getChargeDPS(SlotType.HiSlot, 7).ToString("#.##") + " DPS)");
        }

        private static float getChargeDPS(SlotType slotType, int slot)
        {
            float dps = 0;

            IModule module = Daedalus.myShip.Module(slotType, slot);
            ModuleCharge charge = module.Charge;
            int typeId = charge.TypeId;

            foreach(chargeObject chargeObject in d_ChargeData.chargeObjects)
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

        public static void refreshShipData()
        {
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.shipName, Daedalus.myShip.Name);

            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.shield, Daedalus.myShip.Shield.ToString() + " / " + Daedalus.myShip.MaxShield.ToString());
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.armor, Daedalus.myShip.Armor.ToString() + " / " + Daedalus.myShip.MaxArmor.ToString());
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hull, Daedalus.myShip.Structure.ToString() + " / " + Daedalus.myShip.MaxStructure.ToString());
        }
    }
}
