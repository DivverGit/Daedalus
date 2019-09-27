using Daedalus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Daedalus.Data
{
    public class chargeObject
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public float EMDamage { get; set; }
        public float ThermalDamage { get; set; }
        public float KineticDamage { get; set; }
        public float ExplosiveDamage { get; set; }
        public chargeObject(string name, int typeId, float emDamage, float thermalDamage, float kineticDamage, float explosiveDamage)
        {
            Name = name;
            TypeId = typeId;
            EMDamage = emDamage;
            ThermalDamage = thermalDamage;
            KineticDamage = kineticDamage;
            ExplosiveDamage = explosiveDamage;
        }
    }

    public static class d_ChargeData
    {
        public static List<chargeObject> chargeObjects = new List<chargeObject>();

        static d_ChargeData()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("chargeData.csv"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                List<string> listA = new List<string>();
                List<string> listB = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    string name = values[0];
                    int typeId = Convert.ToInt32(values[1]);
                    float em = float.Parse(values[2]);
                    float thermal = float.Parse(values[3]);
                    float kinetic = float.Parse(values[4]);
                    float explosive = float.Parse(values[5]);

                    chargeObjects.Add(new chargeObject(name, typeId, em, thermal, kinetic, explosive));
                }
            }
        }

        public static void Init()
        {
            // Init
        }

    }
}
