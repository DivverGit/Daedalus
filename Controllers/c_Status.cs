using Daedalus.Functions;
using EVE.ISXEVE.Interfaces;
using System.Collections.Generic;
using System.Drawing;

namespace Daedalus.Controllers
{
    public static class c_Status
    {
        static c_Status()
        {
            f_Modules.GetAllModules();
        }
        public static void Pulse()
        {
            ui_refreshHighPowerModules();
            ui_refreshMediumPowerModules();
            ui_refreshShipData();
        }
        public static void ui_refreshHighPowerModules()
        {
            List<IModule> modules = new List<IModule>();
            modules = f_Modules.HighPowerModules();

            if(c_Behaviours.activeBehaviour == Behaviour.Station)
            {
                foreach (StatusLabel label in StatusLabels.highPowerSlotLabels)
                {
                    Daedalus.DaedalusUI.changeStatusLabel(label, "Inaccessible");
                    Daedalus.DaedalusUI.changeStatusLabelColour(label, Color.DarkGray);
                }
                return;
            }

            for(int i = 0; i < 8; i++)
            {
                if (modules[i].IsValid)
                {
                    Daedalus.DaedalusUI.changeStatusLabel(StatusLabels.highPowerSlotLabels[i], modules[i].ToItem.Name);
                    if (modules[i].IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.highPowerSlotLabels[i], Color.Green);
                    else if (!modules[i].IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.highPowerSlotLabels[i], Color.Black);
                }
                else
                {
                    Daedalus.DaedalusUI.changeStatusLabel(StatusLabels.highPowerSlotLabels[i], "N/A");
                    Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.highPowerSlotLabels[i], Color.DarkGray);
                }
            }
        }
        public static void ui_refreshMediumPowerModules()
        {
            List<IModule> modules = new List<IModule>();
            modules = f_Modules.MediumPowerModules();

            if (c_Behaviours.activeBehaviour == Behaviour.Station)
            {
                foreach (StatusLabel label in StatusLabels.mediumPowerSlotLabels)
                {
                    Daedalus.DaedalusUI.changeStatusLabel(label, "Inaccessible");
                    Daedalus.DaedalusUI.changeStatusLabelColour(label, Color.DarkGray);
                }
                return;
            }

            for (int i = 0; i < 8; i++)
            {
                if (modules[i].IsValid)
                {
                    Daedalus.DaedalusUI.changeStatusLabel(StatusLabels.mediumPowerSlotLabels[i], modules[i].ToItem.Name);
                    if (modules[i].IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.mediumPowerSlotLabels[i], Color.Green);
                    else if (!modules[i].IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.highPowerSlotLabels[i], Color.Black);
                }
                else
                {
                    Daedalus.DaedalusUI.changeStatusLabel(StatusLabels.mediumPowerSlotLabels[i], "N/A");
                    Daedalus.DaedalusUI.changeStatusLabelColour(StatusLabels.mediumPowerSlotLabels[i], Color.DarkGray);
                }
            }
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
        public static void ui_refreshShipData()
        {
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

            Daedalus.DaedalusUI.changeStatusLabel(StatusLabel.shipName, myShipName);
            Daedalus.DaedalusUI.changeStatusLabel(StatusLabel.shield, shieldCurrent.ToString("#") + " / " + shieldMaximum.ToString("#") + " (" + shieldPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(StatusLabel.armor, armorCurrent.ToString("#") + " / " + armorMaximum.ToString("#") + " (" + armorPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(StatusLabel.hull, structureCurrent.ToString("#") + " / " + structureMaximum.ToString("#") + " (" + structurePercent.ToString("#") + "%)");
        }
    }

    public static class StatusLabels
    {
        public static List<StatusLabel> highPowerSlotLabels = new List<StatusLabel>
        {
            StatusLabel.hiSlot1,
            StatusLabel.hiSlot2,
            StatusLabel.hiSlot3,
            StatusLabel.hiSlot4,
            StatusLabel.hiSlot5,
            StatusLabel.hiSlot6,
            StatusLabel.hiSlot7,
            StatusLabel.hiSlot8
        };
        public static List<StatusLabel> mediumPowerSlotLabels = new List<StatusLabel>
        {
            StatusLabel.medSlot1,
            StatusLabel.medSlot2,
            StatusLabel.medSlot3,
            StatusLabel.medSlot4,
            StatusLabel.medSlot5,
            StatusLabel.medSlot6,
            StatusLabel.medSlot7,
            StatusLabel.medSlot8
        };
    }
}
