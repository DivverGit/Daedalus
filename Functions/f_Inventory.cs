using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_Inventory
    {
        static f_Inventory()
        {
            // Init
        }

        public static int OreHoldUsed = 0;
        public static int OreHoldFullThreshold = 97;
        public static double OreHoldCapacitym3 = 0;
        public static double OreHoldUsedm3 = 0;

        public static double GetOreHoldCapacitym3(IEveInvChildWindow OreHoldWindow)
        {
            return OreHoldWindow.Capacity;
        }
        public static double GetOreHoldUsedm3(IEveInvChildWindow OreHoldWindow)
        {
            return OreHoldWindow.UsedCapacity;
        }

        public static void RefreshOreHold()
        {
            IEveInvWindow InvWindow = EVE.ISXEVE.EVEWindow.GetInventoryWindow();
            IEveInvChildWindow ShipOreHold = InvWindow.GetChildWindow("ShipOreHold");
            ShipOreHold.MakeActive();
            OreHoldCapacitym3 = GetOreHoldCapacitym3(ShipOreHold);
            OreHoldUsedm3 = GetOreHoldUsedm3(ShipOreHold);
            if (OreHoldUsedm3 > 0)
            {
                OreHoldUsed = ((int)OreHoldUsedm3 / ((int)OreHoldCapacitym3 / 100));
            }
            else if (OreHoldUsedm3 == 0) OreHoldUsed = 0;
        }

        public static bool IsDeliveryRequired()
        {
            RefreshOreHold();
            if (OreHoldUsed >= OreHoldFullThreshold)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void TransferOreHoldToStation()
        {
            List<IItem> OreHoldItems = Daedalus.myShip.GetOreHoldCargo();
            if (OreHoldItems.Count > 0)
            {
                foreach (IItem OreHoldItem in OreHoldItems)
                {
                    OreHoldItem.MoveTo("MyStationHangar", "Hangar");
                }
                Program.DaedalusUI.newConsoleMessage("Transfer complete.");
            }
        }

        public static bool MiningCrystalsExist()
        {
            List<IItem> CargoItems = Daedalus.myShip.GetCargo();
            if (CargoItems.Count > 0)
            {
                foreach (IItem Item in CargoItems)
                {
                    if (Item.GroupID == 482) return true;
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static string GetDronesGroup()
        {
            List<IItem> Drones = Daedalus.myShip.GetDrones();
            if (Drones.Count == 0)
            {
                List<ActiveDrone> ActiveDrones = Daedalus.me.GetActiveDrones();
                return ActiveDrones[0].ToEntity.Group.ToString();
            }
            else
            {
                return Drones[0].Group.ToString();
            }
        }
    }
}
