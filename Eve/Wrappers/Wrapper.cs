using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public abstract class Wrapper<T>
    {
        public abstract T GetRaw();
    }
}
