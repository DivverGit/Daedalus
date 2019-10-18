using Daedalus.Eve.Bot.Controllers;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.States
{
    class UndockState : State
    {
        private bool Undocked = false;
        public override bool DoWork()
        {
            using (new FrameLock(true))
            {
                Me me = new Me();
                EVE.ISXEVE.EVE eve = new EVE.ISXEVE.EVE();
                
                if (!me.InSpace && me.InStation && !Undocked)
                {
                    eve.Execute(ExecuteCommand.CmdExitStation);
                    Undocked = true;

                } else if (Undocked && me.InSpace && !me.InStation)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
