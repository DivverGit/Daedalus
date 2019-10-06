using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Daedalus.Data
{
    public static class d_Weapon_Types
    {
        private static List<long> _EnergyTurrets;
        public static List<long> EnergyTurrets
        {
            get
            {
                if (_EnergyTurrets == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Weapon_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _EnergyTurrets = (from a in dataDoc.Descendants("EnergyTurret")
                                          select Convert.ToInt64(a.Value)).ToList();
                    }
                }
                return _EnergyTurrets;
            }
        }

        private static List<long> _HybridTurrets;
        public static List<long> HybridTurrets
        {
            get
            {
                if (_HybridTurrets == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Weapon_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _HybridTurrets = (from a in dataDoc.Descendants("HybridTurret")
                                          select Convert.ToInt64(a.Value)).ToList();
                    }
                }
                return _HybridTurrets;
            }
        }

        private static List<long> _MissileLaunchers;
        public static List<long> MissileLaunchers
        {
            get
            {
                if (_MissileLaunchers == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Weapon_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName)) 
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _MissileLaunchers = (from a in dataDoc.Descendants("MissileLauncher")
                                select Convert.ToInt64(a.Value)).ToList();
                    }
                }
                return _MissileLaunchers;
            }
        }

        private static List<long> _ProjectileTurret;
        public static List<long> ProjectileTurret
        {
            get
            {
                if (_ProjectileTurret == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("Weapon_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _ProjectileTurret = (from a in dataDoc.Descendants("ProjectileTurret")
                                          select Convert.ToInt64(a.Value)).ToList();
                    }
                }
                return _ProjectileTurret;
            }
        }
    }
}