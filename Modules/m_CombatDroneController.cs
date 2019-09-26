using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVE.ISXEVE;
using LavishVMAPI;
using Daedalus.Functions;

namespace Daedalus.Modules
{
    static class m_CombatDroneController
    {
        // Variables
        private static bool DronesLaunched = false;
        private static bool DronesEngaged = false;
        private static bool TargetLocked = false;

        private static Entity Target;

        private static List<Attacker> CurrentAttackers = new List<Attacker>();

        static m_CombatDroneController()
        {
            // Init
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                List<Attacker> Attackers = Daedalus.me.GetAttackers();
                int NumAttackers = Attackers.Count;

                // We're safe!
                if (NumAttackers == 0)
                {
                    if (DronesLaunched)
                    {
                        Daedalus.eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
                        Program.DaedalusUI.newConsoleMessage("We're no longer under attack! Recalling drones!");
                        DronesLaunched = false;
                        TargetLocked = false;
                        DronesEngaged = false;
                    }
                }
                // We're under attack!
                else if (NumAttackers > 0)
                {
                    if (!DronesLaunched)
                    {
                        Daedalus.myShip.LaunchAllDrones();
                        System.Media.SystemSounds.Hand.Play();
                        Program.DaedalusUI.newConsoleMessage("WARNING: We're under attack! Launching drones!");
                        DronesLaunched = true;
                    }
                    else if (DronesLaunched && !TargetLocked)
                    {
                        Target = Attackers[0];
                        Target.LockTarget();
                        TargetLocked = true;
                    }
                    else if (DronesLaunched && TargetLocked && !DronesEngaged && IsTargetLocked(Target))
                    {
                        Target.MakeActiveTarget();
                        f_Drones.EngageTarget();
                        DronesEngaged = true;
                    }
                }
            }
        }

        public static bool IsTargetLocked(Entity e)
        {
            List<Entity> LockedTargets = Daedalus.me.GetTargets();
            foreach(Entity LockedTarget in LockedTargets)
            {
                if (LockedTarget.ID == Target.ID) return true;
            }
            return false;
        }
    }
}
