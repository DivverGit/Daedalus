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
    public static class d_NPC_Types
    {
        private static List<long> _All;
        public static List<long> All
        {
            get
            {
                if (_All == null)
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("NPC_Types.xml"));

                    using (Stream stream = assembly.GetManifestResourceStream(resourceName)) 
                    {
                        XElement dataDoc = XElement.Load(stream);
                        _All = (from a in dataDoc.Descendants("Type")
                                select Convert.ToInt64(a.Value)).ToList();
                    }
                }
                return _All;
            }
        }
    }
}