using Daedalus.Behaviours;
using Daedalus.Data;
using Daedalus.Functions;
using Daedalus.Modules;
using Daedalus.Routines;
using EVE.ISXEVE;
using EVE.ISXEVE.Interfaces;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Daedalus.Controllers
{
    public static class c_Modules
    {
        public static List<Afterburner> afterburners = new List<Afterburner>();

        static c_Modules()
        {
            
        }

        public static void PropulsionPulse()
        {
            foreach(Afterburner afterburner in afterburners)
            {
                IModule module = Daedalus.myShip.Module(SlotType.MedSlot, afterburner.Slot_Index);
                if (!module.IsActive) module.Activate();
            }
        }
    }
}