using EVE.ISXEVE;

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
}
