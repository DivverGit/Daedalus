using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.General
{
    public abstract class Wrapper<TKey, TValue>
    {
        public TKey Key { get; set; }
        public abstract void Initialize(TValue value);
    }
}
