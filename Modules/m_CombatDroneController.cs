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
        private static bool dronesLaunched = false;
        private static bool dronesEngaged = false;
        private static bool targetLocked = false;

        private static Entity target;

        private static List<Attacker> currentAttackers = new List<Attacker>();

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
                    if (dronesLaunched)
                    {
                        Daedalus.eve.Execute(ExecuteCommand.CmdDronesReturnToBay);
                        Program.DaedalusUI.newConsoleMessage("We're no longer under attack! Recalling drones!");
                        dronesLaunched = false;
                        targetLocked = false;
                        dronesEngaged = false;
                    }
                }
                // We're under attack!
                else if (NumAttackers > 0)
                {
                    if (!dronesLaunched)
                    {
                        Daedalus.myShip.LaunchAllDrones();
                        System.Media.SystemSounds.Hand.Play();
                        Program.DaedalusUI.newConsoleMessage("We're under attack! Launching drones!");
                        dronesLaunched = true;
                    }
                    else if (dronesLaunched && !targetLocked)
                    {
                        target = Attackers[0];
                        target.LockTarget();
                        targetLocked = true;
                    }
                    else if (dronesLaunched && targetLocked && !dronesEngaged && IsTargetLocked(target))
                    {
                        target.MakeActiveTarget();
                        f_Drones.EngageTarget();
                        dronesEngaged = true;
                    }
                }
            }
        }

        public static bool IsTargetLocked(Entity e)
        {
            List<Entity> LockedTargets = Daedalus.me.GetTargets();
            foreach(Entity LockedTarget in LockedTargets)
            {
                if (LockedTarget.ID == target.ID) return true;
            }
            return false;
        }
    }
}
