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
    public enum WeaponType
    {
        Energy_Turret,
        Hybrid_Turret,
        Missile_Launcher,
        Projectile_Turret
    }
    public class WeaponModule
    {
        public string name { get; set; }
        public WeaponType weaponType { get; set; }
        public SlotType slotType { get; set; }
        public int slotIndex { get; set; }
        public WeaponModule(string aName, WeaponType aWeaponType, SlotType aSlotType, int aSlotIndex)
        {
            name = aName;
            weaponType = aWeaponType;
            slotType = aSlotType;
            slotIndex = aSlotIndex;
        }
    }

    public static class m_Weapons
    {
        static m_Weapons()
        {
            // Init
        }

    }
}
