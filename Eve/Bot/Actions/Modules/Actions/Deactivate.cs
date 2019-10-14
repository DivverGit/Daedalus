using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;

namespace Daedalus.Eve.Bot.Actions
{
    public abstract class Deactivate : ModuleAction
    {
        public Deactivate(int slotIndex, SlotType slotType) : base(slotIndex, slotType) { }

        public override bool DoAction()
        {
            IModule module = new MyShip().Module(base.SlotType, base.SlotIndex);
            module?.Deactivate();

            return (module != null);
        }
    }
}
