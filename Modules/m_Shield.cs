using Daedalus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Daedalus.Modules
{
    public class ShieldBooster
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public double Boost_Amount { get; set; }
        public ShieldBooster(string name, int slot, double boostAmount)
        {
            Name = name;
            Slot_Index = slot;
            Boost_Amount = boostAmount;
        }
    }

    public static class m_Shield
    {
        static m_Shield()
        {
            // Init
        }

    }
}
