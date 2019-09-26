using Daedalus.Behaviours;
using Daedalus.Functions;
using Daedalus.Routines;
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
            List<IModule> AllModules = f_Modules.GetAllModules();
            foreach (IModule Module in AllModules)
            {
                Daedalus.DaedalusUI.newConsoleMessage(Module.ToItem.Name);
            }
        }

        public static void refreshShipData()
        {
            Daedalus.DaedalusUI.changeStationLabel(UI.stationLabels.shipName, Daedalus.myShip.ToItem.Name);

            Daedalus.DaedalusUI.changeStationLabel(UI.stationLabels.shield, Daedalus.myShip.Shield.ToString() + " / " + Daedalus.myShip.MaxShield.ToString());
            Daedalus.DaedalusUI.changeStationLabel(UI.stationLabels.armor, Daedalus.myShip.Armor.ToString() + " / " + Daedalus.myShip.MaxArmor.ToString());
            Daedalus.DaedalusUI.changeStationLabel(UI.stationLabels.hull, Daedalus.myShip.Structure.ToString() + " / " + Daedalus.myShip.MaxStructure.ToString());
        }
    }
}
