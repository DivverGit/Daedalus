using Daedalus.Controllers;
using Daedalus.Functions;

namespace Daedalus.Behaviours
{
    static class b_Space
    {
        public static bool InitComplete = false;
        public static void Pulse()
        {
            if (!InitComplete)
            {
                if (c_Behaviours.previousBehaviour == Behaviour.Combat)
                {
                    f_Modules.DeactivateAllModules();
                    f_EVECommands.ReloadAll();
                }
                InitComplete = true;
            }
            c_Routines.Pulse();
        }
    }
}