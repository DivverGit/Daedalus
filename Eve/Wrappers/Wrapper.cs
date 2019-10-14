using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Wrappers
{
    public abstract class Wrapper<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public abstract void Initialize(TValue value);
    }
}
