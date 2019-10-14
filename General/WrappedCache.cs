using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.General
{
    public abstract class WrappedCache<TKey, TValue, TWrapped>
        where TWrapped : Wrapper<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> CachedItems;
        private Dictionary<TKey, TWrapped> CachedWrappers;
        protected bool RepopulateCache = true;

        public WrappedCache(int startingSize)
        {
            CachedItems = new Dictionary<TKey, TValue>(startingSize);
            CachedWrappers = new Dictionary<TKey, TWrapped>(startingSize);
        }

        public void InvalidateCache()
        {
            CachedItems.Clear();
            RepopulateCache = true;
        }        

        /// <summary>
        /// Override to populate CachedItems
        /// </summary>
        protected abstract void PopulateItems(ref Dictionary<TKey, TValue> cache);

        private void CheckCache()
        {
            if (RepopulateCache)
                PopulateItems(ref CachedItems);
        }

        public bool TryGetItem(TKey key, out TValue value)
        {
            CheckCache();
            if (CachedItems.TryGetValue(key, out TValue cachedValue))
            {
                value = cachedValue;
                return true;
            }
            value = default;
            return false;
        }

        public TValue GetItem(TKey key)
        {
            TryGetItem(key, out TValue value);
            return value;
        }

        public bool TryGetWrappedItem(TKey key, out TWrapped value)
        {
            CheckCache();
            if (CachedWrappers.TryGetValue(key, out TWrapped wrappedValue))
            {
                value = wrappedValue;
                return true;
            }

            if (TryGetItem(key, out TValue rawValue))
            {
                TWrapped newWrappedInstance = Activator.CreateInstance<TWrapped>();
                newWrappedInstance.Key = key;
                newWrappedInstance.Initialize(rawValue);

                CachedWrappers.Add(key, newWrappedInstance);

                value = newWrappedInstance;
                return true;
            }
            value = default;
            return false;
        }

        public TWrapped GetWrappedItem(TKey key)
        {
            TryGetWrappedItem(key, out TWrapped value);
            return value;
        }

        public List<TValue> GetAllItems()
        {
            return CachedItems.Values.ToList();
        }

        public List<TWrapped> GetAllWrappedItems()
        {
            List<TWrapped> wrappedValues = new List<TWrapped>(CachedItems.Count);
            foreach (var entry in CachedItems)
            {
                if (TryGetWrappedItem(entry.Key, out TWrapped wrappedValue))
                    wrappedValues.Add(wrappedValue);
            }
            return wrappedValues;
        }
    }
}
