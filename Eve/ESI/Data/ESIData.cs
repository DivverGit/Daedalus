using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Eve.ESI.Data
{
    public class ESIData
    {
        [JsonIgnore]
        protected string RawJSON = string.Empty;

        [JsonIgnore]
        public static string Endpoint = string.Empty;
    }
}
