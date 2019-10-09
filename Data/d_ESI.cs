using EVE.ISXEVE;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace Daedalus.Data
{
    public static class d_ESI
    {
        public static void CacheEsiEntities()
        {
            var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\.NET Programs\Data\Cache.csv");
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    ESI_Cache.esiEntities.Add(new ESI_Cache.ESI_Entity(
                        int.Parse(values[0]),
                        int.Parse(values[1]),
                        values[2],
                        float.Parse(values[3]),
                        float.Parse(values[4]),
                        float.Parse(values[5]),
                        float.Parse(values[6]),
                        float.Parse(values[7]),
                        float.Parse(values[8]),
                        float.Parse(values[9]),
                        float.Parse(values[10]),
                        float.Parse(values[11]),
                        float.Parse(values[12]),
                        float.Parse(values[13]),
                        float.Parse(values[14]),
                        float.Parse(values[15]),
                        bool.Parse(values[16]),
                        bool.Parse(values[17]),
                        bool.Parse(values[18]),
                        bool.Parse(values[19]),
                        bool.Parse(values[20]),
                        bool.Parse(values[21])));
                }
            }
            Daedalus.DaedalusUI.newConsoleMessage("d_ESI: " + ESI_Cache.esiEntities.Count.ToString() + " entities cached");
            ESI_Cache.cacheLoaded = true;
        }
        public static void QueryESI(int id)
        {
            WebClient client = new WebClient();
            try
            {
                Stream stream = client.OpenRead("https://esi.evetech.net/dev/universe/types/" + id);
                StreamReader streamReader = new StreamReader(stream);
                using (JsonReader jsonReader = new JsonTextReader(streamReader))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    ESI_Query returnedObject = new ESI_Query();
                    returnedObject = serializer.Deserialize<ESI_Query>(jsonReader);

                    ESI_Cache.ESI_Entity esiEntity = new ESI_Cache.ESI_Entity();
                    esiEntity.type_id = returnedObject.type_id;
                    esiEntity.group_id = returnedObject.group_id;
                    esiEntity.name = returnedObject.name;
                    foreach (ESI_Query.dogmaAttribute dgmAttribute in returnedObject.dogma_attributes)
                    {
                        switch(dgmAttribute.attribute_id)
                        {
                                // Hitpoints
                            case 9:
                                esiEntity.structureHitpoints = dgmAttribute.value;
                                break;
                            case 265:
                                esiEntity.armorHitpoints = dgmAttribute.value;
                                break;
                            case 263:
                                esiEntity.shieldHitpoints = dgmAttribute.value;
                                break;

                                // Armor Resonance
                            case 267:
                                esiEntity.armorEmResonance = dgmAttribute.value;
                                break;
                            case 268:
                                esiEntity.armorExplosiveResonance = dgmAttribute.value;
                                break;
                            case 269:
                                esiEntity.armorKineticResonance = dgmAttribute.value;
                                break;
                            case 270:
                                esiEntity.armorThermalResonance = dgmAttribute.value;
                                break;

                                // Shield Resonance
                            case 271:
                                esiEntity.shieldEmResonance = dgmAttribute.value;
                                break;
                            case 272:
                                esiEntity.shieldExplosiveResonace = dgmAttribute.value;
                                break;
                            case 273:
                                esiEntity.shieldKineticResonance = dgmAttribute.value;
                                break;
                            case 274:
                                esiEntity.shieldThermalResonance = dgmAttribute.value;
                                break;

                            case 798:
                                esiEntity.entityBracketColour = dgmAttribute.value;
                                break;
                            case 1766:
                                esiEntity.entityOverviewShipGroupId = dgmAttribute.value;
                                break;

                            // Priority
                            case 504:
                                if (dgmAttribute.value > 0) esiEntity.canScramble = true;
                                else
                                {
                                    esiEntity.canScramble = false;
                                }
                                break;
                            case 512:
                                if (dgmAttribute.value > 0) esiEntity.canWeb = true;
                                else
                                {
                                    esiEntity.canWeb = false;
                                }
                                break;
                            case 930:
                                if (dgmAttribute.value > 0) esiEntity.canECM = true;
                                else
                                {
                                    esiEntity.canECM = false;
                                }
                                break;
                            case 931:
                                if (dgmAttribute.value > 0) esiEntity.canNeut = true;
                                else
                                {
                                    esiEntity.canNeut = false;
                                }
                                break;
                            case 933:
                                if (dgmAttribute.value > 0) esiEntity.canTrackingDisrupt = true;
                                else
                                {
                                    esiEntity.canTrackingDisrupt = false;
                                }
                                break;
                            case 935:
                                if (dgmAttribute.value > 0) esiEntity.canTargetPaint = true;
                                else
                                {
                                    esiEntity.canTargetPaint = false;
                                }
                                break;
                        }
                    }
                    ESI_Cache.esiEntities.Add(esiEntity);
                    ESI_Cache.SaveQueryToFile(esiEntity);
                    Daedalus.DaedalusUI.newConsoleMessage("d_ESI: " + esiEntity.name + " cached");
                }
            }
            catch (WebException exception)
            {
                Daedalus.DaedalusUI.newConsoleMessage("ESI Error: " + exception.Status.ToString());
            }
        }
    }
    public static class ESI_Cache
    {
        public static bool cacheLoaded = false;
        public class dgmAttribute
        {
            public int attribute_id { get; set; }
            public string name { get; set; }
            public dgmAttribute(int attribute_id_value, string name_value)
            {
                attribute_id = attribute_id_value;
                name = name_value;
            }
        }
        public class dgmEffect
        {
            public int effect_id { get; set; }
            public string name { get; set; }
            public dgmEffect(int effect_id_value, string name_value)
            {
                effect_id = effect_id_value;
                name = name_value;
            }
        }
        public class ESI_Entity
        {
            public int group_id { get; set; }
            public int type_id { get; set; }
            public string name { get; set; }
            public float structureHitpoints { get; set; }
            public float armorHitpoints { get; set; }
            public float shieldHitpoints { get; set; }
            public float armorEmResonance { get; set; }
            public float armorExplosiveResonance { get; set; }
            public float armorKineticResonance { get; set; }
            public float armorThermalResonance { get; set; }
            public float shieldEmResonance { get; set; }
            public float shieldExplosiveResonace { get; set; }
            public float shieldKineticResonance { get; set; }
            public float shieldThermalResonance { get; set; }
            public float entityBracketColour { get; set; }
            public float entityOverviewShipGroupId { get; set; }
            public bool canECM { get; set; }
            public bool canNeut { get; set; }
            public bool canScramble { get; set; }
            public bool canTrackingDisrupt { get; set; }
            public bool canTargetPaint { get; set; }
            public bool canWeb { get; set; }
            public ESI_Entity(
                int group_id_value,
                int type_id_value,
                string name_value,
                float structureHitpoints_value,
                float armorHitpoints_value,
                float shieldHitpoints_value,
                float armorEmRes_value,
                float armorExpRes_value,
                float armorKinRes_value,
                float armor_ThermRes_value,
                float shieldEmRes_value,
                float shieldExpRes_value,
                float shieldKinRes_value,
                float shieldThermRes_value,
                float entityBracketColour_value,
                float entityOverviewShipGroupId_value,
                bool canECM_value,
                bool canNeut_value,
                bool canScramble_value,
                bool canTrackingDisrupt_value,
                bool canTargetPaint_value,
                bool canWeb_value)
            {
                group_id = group_id_value;
                type_id = type_id_value;
                name = name_value;
                structureHitpoints = structureHitpoints_value;
                armorHitpoints = armorHitpoints_value;
                shieldHitpoints = shieldHitpoints_value;
                armorEmResonance = armorEmRes_value;
                armorExplosiveResonance = armorExpRes_value;
                armorKineticResonance = armorKinRes_value;
                armorThermalResonance = armor_ThermRes_value;
                shieldEmResonance = shieldEmRes_value;
                shieldExplosiveResonace = shieldExpRes_value;
                shieldKineticResonance = shieldKinRes_value;
                shieldThermalResonance = shieldThermRes_value;
                entityBracketColour = entityBracketColour_value;
                entityOverviewShipGroupId = entityOverviewShipGroupId_value;
                canECM = canECM_value;
                canNeut = canNeut_value;
                canScramble = canScramble_value;
                canTargetPaint = canTargetPaint_value;
                canTrackingDisrupt = canTrackingDisrupt_value;
                canWeb = canWeb_value;
            }
            public ESI_Entity()
            {
                group_id = 0;
                type_id = 0; ;
                name = "";
                structureHitpoints = 0.0f;
                armorHitpoints = 0.0f; ;
                shieldHitpoints = 0.0f; ;
                armorEmResonance = 0.0f; ;
                armorExplosiveResonance = 0.0f; ;
                armorKineticResonance = 0.0f; ;
                armorThermalResonance = 0.0f; ;
                shieldEmResonance = 0.0f; ;
                shieldExplosiveResonace = 0.0f; ;
                shieldKineticResonance = 0.0f;
                shieldThermalResonance = 0.0f; ;
                entityBracketColour = 0.0f; ;
                entityOverviewShipGroupId = 0.0f; ;
                canECM = false;
                canNeut = false;
                canScramble = false;
                canTargetPaint = false;
                canTrackingDisrupt = false;
                canWeb = false;
            }
        }

        public static List<ESI_Entity> esiEntities = new List<ESI_Entity>();

        public static float GetShipGroup(Entity entity)
        {
            foreach (ESI_Cache.ESI_Entity esiEntity in ESI_Cache.esiEntities)
            {
                if (esiEntity.type_id == entity.TypeID)
                {
                    return esiEntity.entityOverviewShipGroupId;
                }
            }
            return 0.0f;
        }
        public static bool GetIsPriority(Entity entity)
        {
            foreach (ESI_Cache.ESI_Entity esiEntity in ESI_Cache.esiEntities)
            {
                if (esiEntity.type_id == entity.TypeID)
                {
                    if(esiEntity.canECM || esiEntity.canNeut || esiEntity.canScramble || esiEntity.canTargetPaint || esiEntity.canTrackingDisrupt || esiEntity.canWeb)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static void SaveQueryToFile(ESI_Entity esiEntity)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\.NET Programs\Data\Cache.csv";
            if (!File.Exists(path))
            {
                Daedalus.DaedalusUI.newConsoleMessage("d_ESI: Cache.csv is missing!");
            }
            else if (File.Exists(path))
            {
                using (var tw = new StreamWriter(path, true))
                {
                    string toWrite =
                        esiEntity.group_id.ToString() + ", " +
                        esiEntity.type_id.ToString() + ", " +
                        esiEntity.name.ToString() + ", " +
                        esiEntity.structureHitpoints.ToString() + ", " +
                        esiEntity.armorHitpoints.ToString() + ", " +
                        esiEntity.shieldHitpoints.ToString() + ", " +
                        esiEntity.armorEmResonance.ToString() + ", " +
                        esiEntity.armorExplosiveResonance.ToString() + ", " +
                        esiEntity.armorKineticResonance.ToString() + ", " +
                        esiEntity.armorThermalResonance.ToString() + ", " +
                        esiEntity.shieldEmResonance.ToString() + ", " +
                        esiEntity.shieldExplosiveResonace.ToString() + ", " +
                        esiEntity.shieldKineticResonance.ToString() + ", " +
                        esiEntity.shieldThermalResonance.ToString() + ", " +
                        esiEntity.entityBracketColour.ToString() + ", " +
                        esiEntity.entityOverviewShipGroupId.ToString() + ", " +
                        esiEntity.canECM.ToString() + ", " +
                        esiEntity.canNeut.ToString() + ", " +
                        esiEntity.canScramble.ToString() + ", " +
                        esiEntity.canTargetPaint.ToString() + ", " +
                        esiEntity.canTrackingDisrupt.ToString() + ", " +
                        esiEntity.canWeb.ToString();
                    tw.WriteLine(toWrite);
                }
            }
        }
    }
    public class ESI_Query
    {
        public class dogmaAttribute
        {
            public int attribute_id { get; set; }
            public string name { get; set; }
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
            public string name { get; set; }
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

        public ESI_Query
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

        public ESI_Query()
        {
            capacity = 0.0f;
            description = "";
            dogma_attributes = new List<ESI_Query.dogmaAttribute>();
            dogma_effects = new List<ESI_Query.dogmaEffect>();
            group_id = 0;
            name = "";
            published = false;
            type_id = 0;
        }
    }
    public static class ESI_Queue
    {
        private static List<int> queries = new List<int>();
        public static void Add(int typeid)
        {
            if (!queries.Contains(typeid))
            {
                queries.Add(typeid);
            }
        }
        public static void Process()
        {
            if (queries.Count > 0 && ESI_Cache.cacheLoaded)
            {
                foreach (int typeid in queries)
                {
                    d_ESI.QueryESI(typeid);
                }
                queries = new List<int>();
            }
        }
    }
}