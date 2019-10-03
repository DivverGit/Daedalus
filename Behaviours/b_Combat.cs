using Daedalus.Functions;
using Daedalus.Modules;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Behaviours
{
    static class b_Combat
    {
        public static bool InitComplete = false;

        static b_Combat()
        {
            // Init
        }

        public static void Pulse()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                Daedalus.DaedalusUI.switchTabPage(Daedalus.DaedalusUI.Combat);
            }
            m_RoutineController.Pulse();
        }
    }
}