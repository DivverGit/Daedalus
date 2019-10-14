using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;

namespace Daedalus.Eve.Bot.Actions
{
    public abstract class PutOnline : ModuleAction
    {
        public PutOnline(int slotIndex, SlotType slotType) : base(slotIndex, slotType) { }

        public override bool DoAction()
        {
            IModule module = new MyShip().Module(base.SlotType, base.SlotIndex);
            module?.PutOnline();

            return (module != null);
        }
    }
}
