using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public class ModuleCache : WrappedCache<int, Module, DModule>
    {
        protected override void PopulateItems(ref Dictionary<int, Module> cache)
        {
            
        }
    }
}
