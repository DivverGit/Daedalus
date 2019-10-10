using Daedalus.Eve.ESI.Data;
using Daedalus.Resources;
using Daedalus.Resources.Structures;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;

namespace Daedalus.Eve.ESI
{
    class ESICache
    {
        private ConcurrentDictionary<Type, ConcurrentDictionary<int, ESIData>> Cache = new ConcurrentDictionary<Type, ConcurrentDictionary<int, ESIData>>();
        private ConcurrentDictionary<Type, BlockingCollection<int>> FinishedRequests = new ConcurrentDictionary<Type, BlockingCollection<int>>();

        public bool TryGetCachedData<T>(int identifier, out T esidata, bool fetchnow = false) where T : ESIData
        {
            esidata = null;
            if (Cache.TryGetValue(typeof(T), out var endpointcache))
            {
                if (endpointcache.TryGetValue(identifier, out var data))
                {
                    esidata = data as T;

                    if (esidata == null)
                        //error occured with laoding cached data as type

                        return esidata != null;
                }
            } else
            {
                if (FinishedRequests.TryGetValue(typeof(T), out var bag))
                {
                    if (bag.Contains(identifier))
                    {
                        return false;
                    }
                        // failed based on previous request
                } else
                {
                    return false;
                    // Failed request based on no endpoint
                }

                FinishedRequests.GetOrAdd(typeof(T), new BlockingCollection<int>()).Add(identifier);
                if (fetchnow)
                {
                    if (TryQueryESI<T>(identifier, out T esiJsonObject))
                    {
                        Cache.GetOrAdd(typeof(T), new ConcurrentDictionary<int, ESIData>())[identifier] = esiJsonObject;
                        esidata = esiJsonObject;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                new Thread(() =>
                {
                    if (TryQueryESI<T>(identifier, out T esiJsonObject))
                    {
                        Cache.GetOrAdd(typeof(T), new ConcurrentDictionary<int, ESIData>())[identifier] = esiJsonObject;
                    } else
                    {
                        // Request failed, dunno what you want to do here
                    }
                }).Start();
                return false;
            }


            esidata = null;
            return false;
        }

        private bool TryQueryESI<T>(int identifier, out T esidata) where T : ESIData
        {
            esidata = null;
            if (EmbeddedJsonResourceCache.Instance.TryGetResource<ESIEndpoints>("ESIEndpints.json", out ESIEndpoints endpoints))
            {
                if (endpoints.Endpoints.TryGetValue(typeof(T).Name, out string endpoint))
                {
                    using (WebClient wc = new WebClient())
                    {
                        string url = string.Format(endpoint, identifier);
                        try
                        {
                            string json = wc.DownloadString(url);
                            esidata = JsonConvert.DeserializeObject<T>(json);
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                    // Error finding endpoint
                }
            }
            else
            {
                return false;
                // Error getting resource, we fucked up
            }
        }
    }
}
