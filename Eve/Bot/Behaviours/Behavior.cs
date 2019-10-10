using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Eve.Bot.Behaviours
{
    public abstract class Behavior : IPulseable
    {
        public abstract void Pulse();
        public abstract void DoWork();
    }
}
