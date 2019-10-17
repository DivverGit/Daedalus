using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Eve.Bot.Behaviours
{
    public abstract class Behaviour : IPulseable
    {
        public abstract void Pulse();
    }
}
