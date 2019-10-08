using Daedalus.Functions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Daedalus.Data
{
    public static class d_Drone_Types
    {
        private static Dictionary<string, string> _all;
        public static Dictionary<string, string> all
        {
            get
            {
                if (_all == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Drone_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName)) 
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _all = (from a in dataDoc.Descendants("DroneTypes")
                                select new { DroneType = a.Attribute("DroneType").Value, Name = a.Attribute("Name").Value }).ToDictionary(a => a.DroneType, a => a.Name);
                    }
                }
                return _all;
            }
        }
        public static string GetDroneType(string name)
        {
            List<string> keys = all.Keys.ToList<string>();
            List<string> values = all.Values.ToList<string>();
            for (int i = 0; i < keys.Count; i++)
            {
                if(values[i] == name)  return keys[i];
            }
            return "";
        }

    }
}