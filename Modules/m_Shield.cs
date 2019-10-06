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
    public class ShieldHardener
    {
        public string Name { get; set; }
        public int Slot_Index { get; set; }
        public ShieldHardener(string name, int slot)
        {
            Name = name;
            Slot_Index = slot;
        }
    }
}
