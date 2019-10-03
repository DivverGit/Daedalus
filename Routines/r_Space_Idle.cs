﻿using Daedalus.Functions;
using Daedalus.Modules;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Routines
{
    static class r_Space_Idle
    {
        // Variables
        private static bool initComplete = false;

        static r_Space_Idle()
        {
            // Init
        }

        public static void Pulse()
        {
            if (!initComplete)
            {
                initComplete = true;
            }
            m_TargetController.Pulse();
            m_StatusController.Pulse();
        }
    }
}
