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
    public class Afterburner
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public Afterburner(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }

    public static class m_Propulsion
    {
        static m_Propulsion()
        {
            // Init
        }

    }
}
