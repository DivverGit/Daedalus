using Daedalus.Functions;
using Daedalus.Controllers;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Behaviours
{
    static class b_Space
    {
        public static bool InitComplete = false;

        static b_Space()
        {
            // Init
        }

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