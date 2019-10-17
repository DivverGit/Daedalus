using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Enums
{
    public class ShipSlot
    {
        public static readonly ShipSlot HighSlot0 = new ShipSlot(SlotType.HiSlot, 0);
        public static readonly ShipSlot HighSlot1 = new ShipSlot(SlotType.HiSlot, 1);
        public static readonly ShipSlot HighSlot2 = new ShipSlot(SlotType.HiSlot, 2);
        public static readonly ShipSlot HighSlot3 = new ShipSlot(SlotType.HiSlot, 3);
        public static readonly ShipSlot HighSlot4 = new ShipSlot(SlotType.HiSlot, 4);
        public static readonly ShipSlot HighSlot5 = new ShipSlot(SlotType.HiSlot, 5);
        public static readonly ShipSlot HighSlot6 = new ShipSlot(SlotType.HiSlot, 6);
        public static readonly ShipSlot HighSlot7 = new ShipSlot(SlotType.HiSlot, 7);

        public static readonly ShipSlot MidSlot0 = new ShipSlot(SlotType.MedSlot, 0);
        public static readonly ShipSlot MidSlot1 = new ShipSlot(SlotType.MedSlot, 1);
        public static readonly ShipSlot MidSlot2 = new ShipSlot(SlotType.MedSlot, 2);
        public static readonly ShipSlot MidSlot3 = new ShipSlot(SlotType.MedSlot, 3);
        public static readonly ShipSlot MidSlot4 = new ShipSlot(SlotType.MedSlot, 4);
        public static readonly ShipSlot MidSlot5 = new ShipSlot(SlotType.MedSlot, 5);
        public static readonly ShipSlot MidSlot6 = new ShipSlot(SlotType.MedSlot, 6);
        public static readonly ShipSlot MidSlot7 = new ShipSlot(SlotType.MedSlot, 7);

        public static readonly ShipSlot LowSlot0 = new ShipSlot(SlotType.LoSlot, 0);
        public static readonly ShipSlot LowSlot1 = new ShipSlot(SlotType.LoSlot, 1);
        public static readonly ShipSlot LowSlot2 = new ShipSlot(SlotType.LoSlot, 2);
        public static readonly ShipSlot LowSlot3 = new ShipSlot(SlotType.LoSlot, 3);
        public static readonly ShipSlot LowSlot4 = new ShipSlot(SlotType.LoSlot, 4);
        public static readonly ShipSlot LowSlot5 = new ShipSlot(SlotType.LoSlot, 5);
        public static readonly ShipSlot LowSlot6 = new ShipSlot(SlotType.LoSlot, 6);
        public static readonly ShipSlot LowSlot7 = new ShipSlot(SlotType.LoSlot, 7);

        public static readonly ShipSlot[] HighSlots = {
            HighSlot0,
            HighSlot1,
            HighSlot2,
            HighSlot3,
            HighSlot4,
            HighSlot5,
            HighSlot6,
            HighSlot7,
        };

        public static readonly ShipSlot[] MidSlots = {
            MidSlot0,
            MidSlot1,
            MidSlot2,
            MidSlot3,
            MidSlot4,
            MidSlot5,
            MidSlot6,
            MidSlot7,
        };

        public static readonly ShipSlot[] LowSlots = {
            LowSlot0,
            LowSlot1,
            LowSlot2,
            LowSlot3,
            LowSlot4,
            LowSlot5,
            LowSlot6,
            LowSlot7,
        };

        public static readonly ShipSlot[] AllSlots = HighSlots.Concat(MidSlots).Concat(LowSlots).ToArray();

        public readonly SlotType SlotType;
        public readonly int SlotNumber;
        private ShipSlot(SlotType slotType, int slotNumber)
        {
            SlotType = slotType;
            slotNumber = slotNumber;
        }

    }
}
