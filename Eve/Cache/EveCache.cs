using Daedalus.Eve.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Cache
{
    public class EveCache
    {
        private static EveCache _instance;
        public static EveCache Instance => _instance ??= new EveCache();

        public readonly EntityCache EntityCache = new EntityCache();
        public readonly ModuleCache ModuleCache = new ModuleCache();



    }
}
