using Daedalus.Eve.Bot.Controllers;
using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.States
{
    public abstract class State
    {
        public event StateAction PreState;
        public event StateAction PostState;
        public event StateAction OnError;
        public event StateAction OnPanic;

        public Controller Controller;

        public bool FirstPulse = true;
        public void StartState()
        {
            
            PreState.Invoke(this);
            FirstPulse = false;
        }

        public void EndState()
        {
            PostState?.Invoke(this);
            FirstPulse = true;
        }


        public bool Pulse()
        {
            if (FirstPulse)
                StartState();

            bool result = DoWork();
            if (result)
                EndState();

            return result;
        }

        private void SetState(string state)
        {
            Controller.SetState(state);
        }
        public abstract bool DoWork();

        public delegate void StateAction(State state);
    }
}
