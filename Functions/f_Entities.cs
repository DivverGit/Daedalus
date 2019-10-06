using Daedalus.Data;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Functions
{
    public enum EntityMode
    {
        undefined,
        Aligned,
        Approaching,
        Stopped,
        Warping,
        Orbiting
    }
    public static class f_Entities
    {
        public static EntityMode GetEntityMode(Entity entity)
        {
            int mode = entity.Mode;
            switch(mode)
            {
                case 0:
                    return EntityMode.Aligned;
                case 1:
                    return EntityMode.Approaching;
                case 2:
                    return EntityMode.Stopped;
                case 3:
                    return EntityMode.Warping;
                case 4:
                    return EntityMode.Orbiting;
                default:
                    return EntityMode.undefined;
            }
        }
        public static Entity GetEntityByID(long id)
        {
            foreach(Entity entity in Cache.allEntities())
            {
                if (entity.ID == id) return entity;
            }
            return null;
        }
        public static double GetDistanceBetween(Entity entity)
        {
            if (!entity.IsValid) return 0;
            return Daedalus.eve.DistanceBetween(Daedalus.me.ToEntity.ID, entity.ID);
        }
        public static double DistanceBetween(Entity entityA, Entity entityB)
        {
            return Daedalus.eve.DistanceBetween(entityA.ID, entityB.ID);
        }
        public static List<Entity> GetNpcEntities()
        {
            List<Entity> toReturn = new List<Entity>();
            // Get all enemy npcs from NPC_Types.xml list
            foreach (Entity entity in Cache.allEntities())
            {
                if (d_NPC_Types.All.Contains(entity.GroupID)) toReturn.Add(entity);
            }
            return toReturn;
        }
    }
}
