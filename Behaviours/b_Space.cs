using Daedalus.Controllers;

namespace Daedalus.Behaviours
{
    static class b_Space
    {
        public static bool InitComplete = false;
        public static void Pulse()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                Daedalus.DaedalusUI.switchTabPage(Daedalus.DaedalusUI.Space);
            }
            c_Routines.Pulse();
        }
    }
}