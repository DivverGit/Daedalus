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
            f_Modules.GetAfterburnerModules();
            f_Modules.GetArmorRepairModules();
            f_Modules.GetShieldBoosterModules();
            f_Modules.GetShieldHardenerModules();
            f_Modules.GetWeaponModules();
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
            modules = f_Modules.GetHighPowerModules();

            if (modules[0].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot1, modules[0].ToItem.Name);
            if (modules[1].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot2, modules[1].ToItem.Name);
            if (modules[2].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot3, modules[2].ToItem.Name);
            if (modules[3].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot4, modules[3].ToItem.Name);
            if (modules[4].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot5, modules[4].ToItem.Name);
            if (modules[5].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot6, modules[5].ToItem.Name);
            if (modules[6].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot7, modules[6].ToItem.Name);
            if (modules[7].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hiSlot8, modules[7].ToItem.Name);

            IModule module;
            module = modules[0];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot1, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot1, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot1, Color.DarkGray);

            module = modules[1];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot2, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot2, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot2, Color.DarkGray);

            module = modules[2];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot3, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot3, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot3, Color.DarkGray);

            module = modules[3];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot4, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot4, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot4, Color.DarkGray);

            module = modules[4];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot5, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot5, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot5, Color.DarkGray);

            module = modules[5];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot6, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot6, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot6, Color.DarkGray);

            module = modules[6];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot7, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot7, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot7, Color.DarkGray);

            module = modules[7];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot8, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot8, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.hiSlot8, Color.DarkGray);
        }
        public static void ui_refreshMediumPowerModules()
        {
            List<IModule> modules = new List<IModule>();
            modules = f_Modules.GetMediumPowerModules();

            if (modules[0].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot1, modules[0].ToItem.Name);
            if (modules[1].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot2, modules[1].ToItem.Name);
            if (modules[2].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot3, modules[2].ToItem.Name);
            if (modules[3].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot4, modules[3].ToItem.Name);
            if (modules[4].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot5, modules[4].ToItem.Name);
            if (modules[5].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot6, modules[5].ToItem.Name);
            if (modules[6].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot7, modules[6].ToItem.Name);
            if (modules[7].IsValid) Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.medSlot8, modules[7].ToItem.Name);

            IModule module;
            module = modules[0];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot1, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot1, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot1, Color.DarkGray);

            module = modules[1];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot2, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot2, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot2, Color.DarkGray);

            module = modules[2];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot3, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot3, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot3, Color.DarkGray);

            module = modules[3];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot4, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot4, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot4, Color.DarkGray);

            module = modules[4];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot5, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot5, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot5, Color.DarkGray);

            module = modules[5];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot6, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot6, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot6, Color.DarkGray);

            module = modules[6];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot7, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot7, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot7, Color.DarkGray);

            module = modules[7];
            if (module.IsValid && module.IsActivatable)
            {
                if (module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot8, Color.Green);
                else if (!module.IsActive) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot8, Color.Black);
            }
            else if (!module.IsValid) Daedalus.DaedalusUI.changeStatusLabelColour(UI.statusLabels.medSlot8, Color.DarkGray);
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

            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.shipName, myShipName);
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.shield, shieldCurrent.ToString("#") + " / " + shieldMaximum.ToString("#") + " (" + shieldPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.armor, armorCurrent.ToString("#") + " / " + armorMaximum.ToString("#") + " (" + armorPercent.ToString("#") + "%)");
            Daedalus.DaedalusUI.changeStatusLabel(UI.statusLabels.hull, structureCurrent.ToString("#") + " / " + structureMaximum.ToString("#") + " (" + structurePercent.ToString("#") + "%)");
        }
    }
}
