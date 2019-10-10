using Daedalus.Resources.Structures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Daedalus.Resources
{
    class EmbeddedJsonResourceCache
    {
        private Dictionary<string, JsonResource> Cache = new Dictionary<string, JsonResource>();

        private static EmbeddedJsonResourceCache instance;
        public static EmbeddedJsonResourceCache Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmbeddedJsonResourceCache();
                }
                return instance;
            }
        }
        public bool TryGetResource<T>(string resourceName, out T jsonObject) where T : JsonResource
        {
            if (Cache.TryGetValue(resourceName, out JsonResource cachedObject))
            {
                if (cachedObject is T)
                {
                    jsonObject = cachedObject as T;
                    return true;
                } else
                {
                    jsonObject = null;
                    return false;
                }
            }


            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    jsonObject = null;
                    return false;
                }

                using (StreamReader reader = new StreamReader(stream))
                {
                    string resourceString = reader.ReadToEnd();

                    try
                    {
                        jsonObject = JsonConvert.DeserializeObject<T>(resourceString);
                        Cache[resourceName] = jsonObject;
                        return true;
                    } catch (JsonException _)
                    {
                        jsonObject = null;
                        return false;
                    }
                }
            }
        }

    }
}
