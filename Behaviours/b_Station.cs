﻿using Daedalus.Functions;
using Daedalus.Controllers;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Behaviours
{
    static class b_Station
    {
        public static bool InitComplete = false;
        public static void Pulse()
        {
            if (!InitComplete)
            {
                InitComplete = true;
                Daedalus.DaedalusUI.switchTabPage(Daedalus.DaedalusUI.Station);
            }
            c_Routines.Pulse();
        }
    }
}