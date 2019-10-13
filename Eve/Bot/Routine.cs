using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot
{
    public abstract class Routine : IPulseable
    {
        public void Pulse()
        {
            throw new NotImplementedException();
        }

        public abstract void DoWork();
    }
}
