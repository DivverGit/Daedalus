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
}
