using Daedalus.Behaviours;
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
            // Init
        }

        public static void Pulse()
        {
            refreshModules();
            refreshShipData();
        }

        public static void refreshModules()
        {
            List<IModule> Modules = new List<IModule>();
            int i;

            // Refresh hi slot modules
            Modules = f_Modules.GetHiSlotModules();

            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot1, Modules[0].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot2, Modules[1].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot3, Modules[2].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot4, Modules[3].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot5, Modules[4].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot6, Modules[5].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot7, Modules[6].ToItem.Name);
            Daedalus.DaedalusUI.changeStationLabel(UI.statusLabels.hiSlot8, Modules[7].ToItem.Name);
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
