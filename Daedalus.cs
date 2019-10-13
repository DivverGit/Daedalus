using LavishScriptAPI;
using LavishVMAPI;
using System;

namespace Daedalus
{
    using Data;
    using global::Daedalus.Eve.Bot.Behaviours;
    using global::Daedalus.Eve.Bot.Controllers;
    using global::Daedalus.Eve.Wrappers;
    using global::Daedalus.Functions;
    using global::Daedalus.Properties;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class Daedalus
    {
        public UI DaedalusUI;

        List<Behaviour> Behaviours = new List<Behaviour>();
        List<Controller> Controllers = new List<Controller>();

        public event Action ISXEVEPulse;
        public event Action DaedalusPulse;

        private bool Running = false;
        private DateTime NextPulse = DateTime.MaxValue;
        private TimeSpan PulseTimeSpan = new TimeSpan(0, 0, 0, 1, 0);
        private TimeSpan PulseTimeSpanVariance = new TimeSpan(0, 0, 0, 0, 0);
        private Random Random = new Random();

        public Daedalus(UI Arg)
        {
            System.Media.SystemSounds.Asterisk.Play();

            DaedalusUI = Arg;

            Setup();
            AttachEvents();

            Start();
        }

        public void Start()
        {
            Running = true;
            NextPulse = DateTime.Now;
        }

        public void Stop()
        {
            Running = false;
            NextPulse = DateTime.MaxValue;
        }

        public void Exit()
        {
            Stop();
            Application.Exit(0);
        }

        private void Setup()
        {

        }

        private void AttachEvents()
        {
            LavishScript.Events.AttachEventTarget("ISXEVE_OnFrame", (sender, lsargs) => ISXEVEPulse?.Invoke());
            ISXEVEPulse += (() => FramePulse());
            DaedalusPulse += (() => Pulse());
        }

        private void FramePulse()
        {
            if (!Running)
                return;

            DateTime now = DateTime.Now;

            if (NextPulse > now)
                return;

            DaedalusPulse?.Invoke();

            // Assign next time for pulse
            int millisecondVariance = (int)(Random.NextDouble() * PulseTimeSpanVariance.TotalMilliseconds);
            NextPulse = now.Add(PulseTimeSpan).AddMilliseconds(millisecondVariance);
        }

        private void Pulse()
        {
            // Invalidates entity cache
            DEve.Instance.InvalidateCache();

            Controllers.ForEach(c => c.Pulse());
            Behaviours.ForEach(b => b.Pulse());
        }
    }
}
