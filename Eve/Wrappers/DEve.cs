using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Eve.Wrappers
{
    public class DEve
    {
        private static DEve instance;
        public static DEve Instance => instance ??= new DEve();

        private Dictionary<long, Entity> EntityCache = new Dictionary<long, Entity>(100);
        private bool RepopulateCache = true;

        public void InvalidateCache()
        {
            RepopulateCache = true;
        }

        public void CheckCache(bool forceRepopulate = false)
        {
            if (RepopulateCache || forceRepopulate)
            {
                EntityCache.Clear();

                EVE.ISXEVE.EVE eve = new EVE.ISXEVE.EVE();
                List<Entity> entities = eve.QueryEntities();

                foreach (Entity e in entities)
                {
                    EntityCache.Add(e.ID, e);
                }
            }
            RepopulateCache = false;
        }

        public List<DEntity> GetEntities()
        {
            CheckCache();
            return EntityCache.Select((entry) => new DEntity { EntityID = entry.Key, TypeID = entry.Value.TypeID }).ToList();
        }

        public DEntity GetDEntity(long id)
        {
            Entity e = GetEntity(id);
            if (e is null)
                return new DEntity { EntityID = id, TypeID = -1 };

            return new DEntity {EntityID = id, TypeID = e.TypeID};
        }

        public Entity GetEntity(long id)
        {
            CheckCache();
            if (EntityCache.TryGetValue(id, out Entity e))
                return e;
            return null;
        }
    }
}
