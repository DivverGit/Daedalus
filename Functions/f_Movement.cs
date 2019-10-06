using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public static class f_Movement
    {
        public static void Approach(Entity entity)
        {
            entity.Approach();
            Program.DaedalusUI.newConsoleMessage("Approaching " + entity.Name);
        }
        public static void KeepAtRange(Entity entity, int distance = 1000)
        {
            entity.KeepAtRange(distance);
            Program.DaedalusUI.newConsoleMessage("Keeping " + entity.Name + " at range of " + distance.ToString() + "m");
        }
        public static void Orbit(Entity entity, int distance = 1000)
        {
            entity.Orbit(distance);
            Program.DaedalusUI.newConsoleMessage("Orbiting " + entity.Name + " at " + distance.ToString() + "m");
        }
        public static void Warp(Entity entity)
        {
            entity.WarpTo();
            Program.DaedalusUI.newConsoleMessage("Warping to " + entity.Name);
        }
    }
}
