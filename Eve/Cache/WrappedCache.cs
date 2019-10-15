using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public abstract class WrappedCache<TKey, TValue, TWrapped>
        where TWrapped : CacheWrapper<TKey, TValue, TWrapped>, new()
    {
        private Dictionary<TKey, TValue> CachedItems = new Dictionary<TKey, TValue>();
        private Dictionary<TKey, TWrapped> CachedWrappers = new Dictionary<TKey, TWrapped>();
        private bool RepopulateItemCache = true;

        public void ClearWrappers()
        {
            CachedWrappers.Clear();
        }

        public void ClearItems()
        {
            CachedItems.Clear();
            RepopulateItemCache = true;
        }

        public void ClearCache()
        {
            ClearItems();
            ClearWrappers();
        }

        /// <summary>
        /// Override to populate CachedItems
        /// </summary>
        protected abstract void PopulateItems(ref Dictionary<TKey, TValue> cache);

        private void CheckCache()
        {
            if (RepopulateItemCache)
            {
                PopulateItems(ref CachedItems);
                CachedWrappers = CachedWrappers.Where(entry => CachedItems.ContainsKey(entry.Key))
                                 .ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
            }
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
                newWrappedInstance.Cache = this;
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
