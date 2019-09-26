using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    static class f_WarpTo
    {
        static f_WarpTo()
        {
            // Init
        }
        
        public static void Station(Entity Station)
        {
            Station.WarpTo();
            Program.DaedalusUI.newConsoleMessage("Warping to " + Station.Name);
        }
        
        public static void Belt(Entity Belt)
        {
            Program.DaedalusUI.newConsoleMessage("Warping to " + Belt.Name);
            Belt.WarpTo();
        }
    }
}
