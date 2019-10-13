using Daedalus.Eve.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daedalus.Eve.Bot.Controllers
{
    public abstract class Controller : IPulseable
    {
        public void Pulse()
        {
            throw new NotImplementedException();
        }
    }
}
