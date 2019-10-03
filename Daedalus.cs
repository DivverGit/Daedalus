using LavishScriptAPI;
using LavishVMAPI;
using System;

namespace Daedalus
{
    using Behaviours;
    using Controllers;
    using Functions;

    public class Daedalus
    {
        // EventHandler for pulse
        private static event EventHandler<LSEventArgs> Frame;

        // ISXEVE variables
        public static EVE.ISXEVE.EVE eve;
		public static EVE.ISXEVE.Me me;
        public static EVE.ISXEVE.Ship myShip;
        public static EVE.ISXEVE.Station station;

        // Pulse variables
        private static DateTime nextPulse;
        private static int pulseRate = 1;

        // Misc variables
        public static bool paused = false;

        public static UI DaedalusUI;

        public Daedalus(UI Arg)
        {
            DaedalusUI = Arg;

            // Set the Frame event to call the Pulse function.
            Frame += new EventHandler<LSEventArgs>(Pulse);

            DaedalusUI.newConsoleMessage("Daedalus 03/10/2019");
            System.Media.SystemSounds.Asterisk.Play();
            Start();
        }

        public static void Start()
        {
            // Attach Daedalus to ISXEVE
            AttachEvent();

            // Set the first pulse
            nextPulse = DateTime.Now.AddSeconds(pulseRate);
        }

        static internal void AttachEvent()
        {
            // Attach Daedalus to the ISXEVE_OnFrame event, this event is called every frame so 30 FPS is 30 events per second.
            LavishScript.Events.AttachEventTarget("ISXEVE_OnFrame", Frame);
            DaedalusUI.newConsoleMessage("Attaching to ISXEVE");
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
                //  We don't need to process our code every single frame as it's inefficient, so let's only do it every *pulseRate*
                if (DateTime.Now > nextPulse)
                {
                    nextPulse = DateTime.Now.AddSeconds(pulseRate);

                    // Let's refresh all the data made available by ISXEVE
                    eve = new EVE.ISXEVE.EVE();
                    me = new EVE.ISXEVE.Me();
                    myShip = new EVE.ISXEVE.Ship();

                    DaedalusUI.Text = "Daedalus - " + me.Name + " [Behaviour: " + c_Behaviours.activeBehaviour.ToString() + "] [Routine: " + c_Routines.activeRoutine.ToString() + "]";

                    if (!paused)    c_Behaviours.Pulse();
                }
                return;
            }
        }
    }
}
