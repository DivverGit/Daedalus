﻿using Daedalus.Controllers;

namespace Daedalus.Behaviours
{
    static class b_Combat
    {
        public static bool InitComplete = false;
        public static void Pulse()
        {
            if (!InitComplete)
            {
                InitComplete = true;
            }
            c_Routines.Pulse();
        }
    }
}