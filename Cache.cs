using Daedalus;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Daedalus.Data
{
    public static class Cache
    {
        public static List<Entity> allEntities()
        {
            return Daedalus.eve.QueryEntities();
        }
    }
}