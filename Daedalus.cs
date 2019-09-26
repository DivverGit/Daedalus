using LavishScriptAPI;
using LavishVMAPI;
using System;

namespace Daedalus
{
    using Behaviours;
    using Functions;
    using Modules;

    public class Daedalus
    {
        // EventHandler for Pulse
        private static event EventHandler<LSEventArgs> Frame;

        // ISXEVE Variables
        public static EVE.ISXEVE.EVE eve;
		public static EVE.ISXEVE.Me me;
        public static EVE.ISXEVE.Ship myShip;
        public static EVE.ISXEVE.Station station;

        // Pulse Variables
        private static DateTime nextPulse;
        private static int pulseRate = 1;

        // Misc Variables
        public static bool paused = false;

        public static UI DaedalusUI;

        public Daedalus(UI Arg)
        {
            DaedalusUI = Arg;
            // One time only constructor.
            Frame += new EventHandler<LSEventArgs>(Pulse);
            DaedalusUI.NewConsoleMessage("Daedalus 06/06/2016");
            System.Media.SystemSounds.Asterisk.Play();
            Start();
        }

        public static void Start()
        {
            AttachEvent();
            nextPulse = DateTime.Now.AddSeconds(pulseRate);
        }

        static internal void AttachEvent()
        {
            LavishScript.Events.AttachEventTarget("ISXEVE_OnFrame", Frame);
            DaedalusUI.NewConsoleMessage("Attaching to ISXEVE");
        }

        static internal void AttachEvent(object sender, EventArgs e)
        {
            AttachEvent();
        }
        
        static internal void DetachEvent()
        {
			LavishScript.Events.DetachEventTarget("ISXEVE_OnFrame", Frame);
        }
        
        private static void Pulse(object sender, LSEventArgs e)
        {
            using (new FrameLock(true))
            {
                if (DateTime.Now > nextPulse)
                {
                    nextPulse = DateTime.Now.AddSeconds(pulseRate);
                    eve = new EVE.ISXEVE.EVE();
                    me = new EVE.ISXEVE.Me();
                    myShip = new EVE.ISXEVE.Ship();

                    DaedalusUI.Text = "Daedalus - " + me.Name + " [" + m_RoutineController.ActiveRoutine.ToString() + "]";
                    if (!paused) b_Mining.Pulse();
                }
                return;
            }
        }
    }
}
