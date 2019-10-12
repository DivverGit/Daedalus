using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Daedalus.Eve.ESI.Data
{
    class ESIEntity : ESIType
    {
        public long Capacity { get; set; }
        public string Description { get; set; }
        public Dictionary<long, double> DogmaAttributes { get; set; }
        public Dictionary<long, bool> DogmaEffects { get; set; }
        public long GraphicId { get; set; }
        public long GroupId { get; set; }
        public long Mass { get; set; }
        public string Name { get; set; }
        public long PackagedVolume { get; set; }
        public long PortionSize { get; set; }
        public bool Published { get; set; }
        public long Radius { get; set; }
        public long TypeId { get; set; }
        public long Volume { get; set; }
    }
}
