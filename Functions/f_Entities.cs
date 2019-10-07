using Daedalus.Data;
using EVE.ISXEVE;
using System.Collections.Generic;

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
        public static List<Entity> AllEntities()
        {
            List<Entity> toReturn = Daedalus.eve.QueryEntities();
            if (toReturn == null) if (toReturn == null) return new List<Entity>();
            return toReturn;
        }
        public static double GetDistanceBetween(Entity entity)
        {
            if (!entity.IsValid) return 0;
            return Daedalus.eve.DistanceBetween(Daedalus.me.ToEntity.ID, entity.ID);
        }
        public static double GetDistanceBetween(Entity entityA, Entity entityB)
        {
            return Daedalus.eve.DistanceBetween(entityA.ID, entityB.ID);
        }
        public static List<Entity> GetEntitiesWithinDistance(List<Entity> entitiesList, double distance)
        {
            List<Entity> toReturn = new List<Entity>();
            foreach (Entity entity in entitiesList)
            {
                if (f_Entities.GetDistanceBetween(entity) < distance) toReturn.Add(entity);
            }
            return toReturn;
        }
        public static List<Entity> GetEntitiesWithinDistance(List<Entity> entitiesList, double distance, List<string> filteredByList)
        {
            List<Entity> toReturn = new List<Entity>();
            foreach (Entity entity in entitiesList)
            {
                if (f_Entities.GetDistanceBetween(entity) < distance &&
                    d_Priority_Targets.All.Contains(entity.Name))
                    toReturn.Add(entity);
            }
            return toReturn;
        }
        public static Entity GetEntityByID(long id)
        {
            foreach (Entity entity in f_Entities.AllEntities())
            {
                if (entity.ID == id) return entity;
            }
            return null;
        }
        public static bool GetEntityExistsByID(List<Entity> entities, long id)
        {
            foreach (Entity entity in entities)
            {
                if (entity.ID == id) return true;
            }
            return false;
        }
        public static EntityMode GetEntityMode(Entity entity)
        {
            int mode = entity.Mode;
            switch (mode)
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
        public static List<Entity> GetNpcEntities(List<Entity> entitiesList)
        {
            List<Entity> toReturn = new List<Entity>();
            foreach (Entity entity in entitiesList)
            {
                if (d_NPC_Types.All.Contains(entity.GroupID)) toReturn.Add(entity);
            }
            if (toReturn == null) return new List<Entity>();
            return toReturn;
        }
    }
}
