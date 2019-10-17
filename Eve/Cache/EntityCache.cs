using Daedalus.Eve.Cache.Base;
using Daedalus.Eve.Wrappers;
using EVE.ISXEVE;
using LavishVMAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Cache
{
    public class EntityCache : WrappedCache<long, Entity, DEntity>
    {
        protected override void PopulateItems(ref Dictionary<long, Entity> cache)
        {
            using (new FrameLock(true))
            {
                EVE.ISXEVE.EVE eve = new EVE.ISXEVE.EVE();
                foreach (Entity e in eve.QueryEntities())
                {
                    cache[e.ID] = e;
                }
            }
        }
    }
}
