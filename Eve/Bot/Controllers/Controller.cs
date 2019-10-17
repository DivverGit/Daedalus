using Daedalus.Eve.Bot.States;
using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.Controllers
{
    public abstract class Controller : IPulseable
    {
        public string CurrentStateName { get; private set; } = string.Empty;
        public bool Active { get; private set; } = false;

        private Dictionary<string, State> States = new Dictionary<string, State>();
        private Dictionary<string, string> StateProgression = new Dictionary<string, string>();

        protected Controller()
        {
            RegisterStates();
        }

        protected abstract void RegisterStates();

        public void Start()
        {
            if (States.ContainsKey(CurrentStateName))
                Active = true;
        }

        public void Stop()
        {
            Active = false;
        }

        public void SetState(string stateName)
        {
            if (States.ContainsKey(stateName))
            {
                CurrentStateName = stateName;
            } else
            {
                // unable to find state
            }
        }

        public void AddState(string name, State state, string nextState)
        {
            StateProgression[name] = nextState;
            AddState(name, state);
        }

        public void AddState(string name, State state)
        {
            States[name] = state;
        }

        public void Pulse()
        {
            if (!Active)
                return;

            if (States.TryGetValue(CurrentStateName, out State state))
            {
                if (state.DoWork())
                {
                    // If state returned true for progressing
                    if (StateProgression.TryGetValue(CurrentStateName, out string nextStateName))
                    {
                        CurrentStateName = nextStateName;
                    } else
                    {
                        return;
                        // No progression found
                    }

                }
            }
        }
    }
}
