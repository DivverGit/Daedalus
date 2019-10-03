using Daedalus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

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

    public static class d_Charges
    {
        public static List<chargeObject> chargeObjects = new List<chargeObject>();

        static d_Charges()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Charges.xml"));

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                XElement dataDoc = XElement.Load(stream);
                chargeObjects = (from a in dataDoc.Descendants("Charge")
                        select new chargeObject(a.Attribute("Name").Value, Convert.ToInt32(a.Attribute("TypeID").Value), float.Parse(a.Attribute("EM_Damage").Value), float.Parse(a.Attribute("Thermal_Damage").Value), float.Parse(a.Attribute("Kinetic_Damage").Value), float.Parse(a.Attribute("Explosive_Damage").Value))).ToList();
            }

            foreach(chargeObject charge in chargeObjects)
            {
                Daedalus.DaedalusUI.newConsoleMessage(charge.Name);
            }
        }

        public static void Init()
        {
            // Init
        }

    }
}
