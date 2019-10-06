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
}
