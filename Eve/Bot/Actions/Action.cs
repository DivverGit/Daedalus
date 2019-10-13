using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.Actions
{
    public abstract class Action : IEquatable<Action>
    {
        private int Priority = 0;
        private bool Concurrent = false;
        private TimeSpan ActionTime = TimeSpan.Zero;


        public abstract bool Equals(Action other);

        public abstract void DoAction();
    }
}
