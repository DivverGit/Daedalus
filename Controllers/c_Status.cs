using Daedalus.Behaviours;
using Daedalus.Data;
using Daedalus.Functions;
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
    public static class c_Status
    {

        static c_Status()
        {
            f_Modules.getAfterburnerModules();
            f_Modules.getArmorRepairModules();
            f_Modules.getShieldBoosterModules();
        }

        public static void Pulse()
        {
            updateHighPowerModules();
            updateMediumPowerModules();
            updateShipData();
        }
        public static void updateHighPowerModules()
        {
            List<IModule> Modules = new List<IModule>();

            // Refresh hi slot modules
            Modules = f_Modules.GetHiSlotModules();

            if (Modules[0].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot1, Modules[0].ToItem.Name);
            if (Modules[1].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot2, Modules[1].ToItem.Name);
            if (Modules[2].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot3, Modules[2].ToItem.Name);
            if (Modules[3].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot4, Modules[3].ToItem.Name);
            if (Modules[4].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot5, Modules[4].ToItem.Name);
            if (Modules[5].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot6, Modules[5].ToItem.Name);
            if (Modules[6].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot7, Modules[6].ToItem.Name);
            if (Modules[7].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot8, Modules[7].ToItem.Name);

            IModule module;

            module = Modules[0];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot1, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot1, Color.Black);

            module = Modules[1];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot2, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot2, Color.Black);

            module = Modules[2];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot3, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot3, Color.Black);

            module = Modules[3];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot4, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot4, Color.Black);

            module = Modules[4];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot5, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot5, Color.Black);

            module = Modules[5];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot6, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot6, Color.Black);

            module = Modules[6];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot7, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot7, Color.Black);

            module = Modules[7];
            if (module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot8, Color.Green);
            else if (!module.IsActive && module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot8, Color.Black);
        }
        public static void updateMediumPowerModules()
        {
            List<IModule> Modules = new List<IModule>();

            // Refresh hi slot modules
            Modules = f_Modules.GetMedSlotModules();

            if (Modules[0].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot1, Modules[0].ToItem.Name);
            if (Modules[1].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot2, Modules[1].ToItem.Name);
            if (Modules[2].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot3, Modules[2].ToItem.Name);
            if (Modules[3].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot4, Modules[3].ToItem.Name);
            if (Modules[4].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot5, Modules[4].ToItem.Name);
            if (Modules[5].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot6, Modules[5].ToItem.Name);
            if (Modules[6].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot7, Modules[6].ToItem.Name);
            if (Modules[7].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot8, Modules[7].ToItem.Name);
        }
        public static string myShipName;
        public static double shieldCurrent;
        public static double shieldMaximum;
        public static double shieldPercent;
        public static double armorCurrent;
        public static double armorMaximum;
        public static double armorPercent;
        public static double structureCurrent;
        public static double structureMaximum;
        public static double structurePercent;
        public static void updateShipData()
        {
            // Variables
            myShipName = Daedalus.myShip.Name;
            shieldCurrent = Daedalus.myShip.Shield;
            shieldMaximum = Daedalus.myShip.MaxShield;
            shieldPercent = Daedalus.myShip.ShieldPct;
            armorCurrent = Daedalus.myShip.Armor;
            armorMaximum = Daedalus.myShip.MaxArmor;
            armorPercent = Daedalus.myShip.ArmorPct;
            structureCurrent = Daedalus.myShip.Structure;
            structureMaximum = Daedalus.myShip.MaxStructure;
            structurePercent = Daedalus.myShip.StructurePct;

            // Set all the labels
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.shipName, myShipName);
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.shield, shieldCurrent.ToString("#") + " / " + shieldMaximum.ToString("#") + " (" + shieldPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.armor, armorCurrent.ToString("#") + " / " + armorMaximum.ToString("#") + " (" + armorPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hull, structureCurrent.ToString("#") + " / " + structureMaximum.ToString("#") + " (" + structurePercent.ToString("#") + "%)");
        }
    }
}
