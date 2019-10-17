using Daedalus.Eve.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Cache.Base
{
    public abstract class CacheWrapper<TKey, TValue, TWrapped> : Wrapper<TValue>
        where TWrapped : CacheWrapper<TKey, TValue, TWrapped>, new()
    {
        public TKey Key { get; set; }
        public WrappedCache<TKey, TValue, TWrapped> Cache;

        public abstract void Initialize(TValue value);

        public override TValue GetRaw()
        {
            return Cache.GetItem(Key);
        }

        public bool IsCached()
        {
            return Cache.ItemExists(Key);
        }
    }
}
