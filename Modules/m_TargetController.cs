using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EVE.ISXEVE;
using LavishVMAPI;
using Daedalus.Data;
using Daedalus.Functions;

namespace Daedalus.Modules
{
    static class m_TargetController
    {
        // Variables
        private static List<Entity> allEntities = new List<Entity>();
        public static List<Entity> enemyNpcEntities = new List<Entity>();

        public static List<Entity> targets = new List<Entity>();

        public static bool redAlert = false;

        static m_TargetController()
        {
            // Init
        }

        public static void Pulse()
        {
            using (new FrameLock(true))
            {
                allEntities = Daedalus.eve.QueryEntities();
                enemyNpcEntities = new List<Entity>();

                int entitiesCount = allEntities.Count;

                if (entitiesCount == 0) return;
                else if (entitiesCount > 0)
                {
                    foreach(Entity entity in allEntities)
                    {
                        long GroupID = entity.GroupID;
                        if (d_NPC_Types.All.Contains(GroupID))
                        {
                            enemyNpcEntities.Add(entity);
                        }
                    }
                }

                if (enemyNpcEntities.Count > 0) redAlert = true;
                else
                {
                    redAlert = false;
                }
            }
        }
    }
}
