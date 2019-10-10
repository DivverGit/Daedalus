using Daedalus.Resources.Structures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Daedalus.Resources
{
    class FileJsonCache
    {
        private string BasePath = AppDomain.CurrentDomain.BaseDirectory;
        private Dictionary<string, JsonResource> Cache = new Dictionary<string, JsonResource>();

        public void SaveAll()
        {
            foreach (var resourceEntry in Cache)
            {
                Save(resourceEntry.Key, resourceEntry.Value);
            }
        }
        public void Save(string resourcePath, JsonResource jsonObject)
        {
            string fullPath = Path.Combine(BasePath, resourcePath);

            string json = JsonConvert.SerializeObject(jsonObject);
            File.WriteAllText(fullPath, json);
        }

        public bool TryLoad<T>(string resourcePath, out T jsonObject) where T : JsonResource
        {
            if (Cache.TryGetValue(resourcePath, out JsonResource cachedObject))
            {
                jsonObject = cachedObject as T;
                return true;
            }

            string fullPath = Path.Combine(BasePath, resourcePath);

            if (File.Exists(fullPath))
            {
                string json = File.ReadAllText(resourcePath);

                try 
                {
                    jsonObject = JsonConvert.DeserializeObject<T>(json);
                    Cache[resourcePath] = jsonObject;

                    return true;
                } catch (JsonException _)
                {
                    jsonObject = null;
                    return false;
                }
            } else
            {
                jsonObject = null;
                return false;
            }
        }

        public T LoadOrDefault<T>(string resourcePath) where T : JsonResource
        {
            if (TryLoad<T>(resourcePath, out T jsonObject))
            {
                return jsonObject;
            } else
            {
                T defaultJsonObject = Activator.CreateInstance(typeof(T)) as T;

                Cache[resourcePath] = defaultJsonObject;
                return defaultJsonObject;
            }
        }
    }
}
