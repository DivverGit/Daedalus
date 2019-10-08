using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Daedalus.Data
{
    public class Query
    {
        public class byDogmaAttribute
        {
            public int attribute_id { get; set; }
            public string name { get; set; }
            public byDogmaAttribute(int attribute_id_value, string name_value)
            {
                attribute_id = attribute_id_value;
                name = name_value;
            }
        }
        public class byDogmaEffect
        {
            public int effect_id { get; set; }
            public string name { get; set; }
            public byDogmaEffect(int effect_id_value, string name_value)
            {
                effect_id = effect_id_value;
                name = name_value;
            }
        }
        public class byTypeid
        {
            public class dogmaAttribute
            {
                public int attribute_id { get; set; }
                public float value { get; set; }
                public dogmaAttribute(int attribute_id_value, float value_value)
                {
                    attribute_id = attribute_id_value;
                    value = value_value;
                }
            }
            public class dogmaEffect
            {
                public int effect_id { get; set; }
                public bool isDefault { get; set; }
                public dogmaEffect(int effect_id_value, bool isDefault_value)
                {
                    effect_id = effect_id_value;
                    isDefault = isDefault_value;
                }
            }
            public float capacity { get; set; }
            public string description { get; set; }
            public List<dogmaAttribute> dogma_attributes { get; set; }
            public List<dogmaEffect> dogma_effects { get; set; }
            public int group_id { get; set; }
            public string name { get; set; }
            public bool published { get; set; }
            public int type_id { get; set; }

            public byTypeid
            (
                float capacity_value,
                string description_value,
                List<dogmaAttribute> dogma_attributes_values,
                List<dogmaEffect> dogma_effects_values,
                int group_id_value,
                string name_value,
                bool published_value,
                int type_id_value
            )
            {
                capacity = capacity_value;
                description = description_value;
                dogma_attributes = dogma_attributes_values;
                dogma_effects = dogma_effects_values;
                group_id = group_id_value;
                name = name_value;
                published = published_value;
                type_id = type_id_value;
            }
        }
    }

    public static class Cache
    {
        public static List<Query.byDogmaAttribute> dgmAttribute_Queries = new List<Query.byDogmaAttribute>();
        public static List<Query.byDogmaEffect> dgmEffect_Queries = new List<Query.byDogmaEffect>();
        public static List<Query.byTypeid> typeid_Queries = new List<Query.byTypeid>();
    }

    public static class d_ESI
    {
        public static void QueryESI(int id, QueryType type)
        {
            if(type == QueryType.byTypeid)
            {
                WebClient client = new WebClient();
                try
                {
                    Stream stream = client.OpenRead("https://esi.evetech.net/dev/universe/types/" + id);
                    StreamReader streamReader = new StreamReader(stream);
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var returnedObject = serializer.Deserialize<Query.byTypeid>(jsonReader);

                        Daedalus.DaedalusUI.newConsoleMessage("Name: " + returnedObject.name);
                        Daedalus.DaedalusUI.newConsoleMessage("Description: " + returnedObject.description);
                        Daedalus.DaedalusUI.newConsoleMessage("GroupID: " + returnedObject.group_id.ToString());
                        Daedalus.DaedalusUI.newConsoleMessage("TypeID: " + returnedObject.type_id.ToString());

                        Daedalus.DaedalusUI.newConsoleMessage("[dogma_attributes]");
                        foreach (Query.byTypeid.dogmaAttribute dgmAttribute in returnedObject.dogma_attributes)
                        {
                            QueryESI(dgmAttribute.attribute_id, QueryType.byDogmaAttribute);
                        }
                        Daedalus.DaedalusUI.newConsoleMessage("[dogma_effects]");
                        foreach (Query.byTypeid.dogmaEffect dgmEffect in returnedObject.dogma_effects)
                        {
                            QueryESI(dgmEffect.effect_id, QueryType.byDogmaEffect);
                        }
                    }
                }
                catch (WebException exception)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("ESI Error: " + exception.Status.ToString());
                }
            }
            else if(type == QueryType.byDogmaAttribute)
            {
                WebClient client = new WebClient();
                try
                {
                    Stream stream = client.OpenRead("https://esi.evetech.net/dev/dogma/attributes/" + id);
                    StreamReader streamReader = new StreamReader(stream);
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var returnedObject = serializer.Deserialize<Query.byDogmaAttribute>(jsonReader);
                        Daedalus.DaedalusUI.newConsoleMessage(returnedObject.name);
                        Cache.dgmAttribute_Queries.Add(returnedObject);
                    }
                }
                catch (WebException exception)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("ESI Error: " + exception.Status.ToString());
                }
            }
            else if (type == QueryType.byDogmaEffect)
            {
                WebClient client = new WebClient();
                try
                {
                    Stream stream = client.OpenRead("https://esi.evetech.net/dev/dogma/effects/" + id);
                    StreamReader streamReader = new StreamReader(stream);
                    using (JsonReader jsonReader = new JsonTextReader(streamReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        var returnedObject = serializer.Deserialize<Query.byDogmaEffect>(jsonReader);
                        Daedalus.DaedalusUI.newConsoleMessage(returnedObject.name);
                        Cache.dgmEffect_Queries.Add(returnedObject);
                    }
                }
                catch (WebException exception)
                {
                    Daedalus.DaedalusUI.newConsoleMessage("ESI Error: " + exception.Status.ToString());
                }
            }
        }
    }
    public enum QueryType
    {
        byDogmaAttribute,
        byDogmaEffect,
        byTypeid
    }
}