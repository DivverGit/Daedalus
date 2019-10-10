using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Resources.Structures
{
    class ESIEndpoints : JsonResource
    {
        public Dictionary<string, string> Endpoints = new Dictionary<string, string>();
    }
}
