using Daedalus;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Daedalus.Modules
{
    public class ArmorHardener
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public ArmorHardener(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
    public class ArmorRepairer
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public double Repair_Amount { get; set; }
        public ArmorRepairer(string name, int slot, double repairAmount)
        {
            Name = name;
            Slot_Index = slot;
            Repair_Amount = repairAmount;
        }
    }

    public static class m_Armor
    {
        static m_Armor()
        {
            // Init
        }

    }
}
