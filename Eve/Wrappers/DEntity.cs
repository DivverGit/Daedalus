using Daedalus.Eve.Cache.Base;
using Daedalus.Eve.ESI;
using Daedalus.Eve.ESI.Data;
using EVE.ISXEVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Daedalus.Eve.Wrappers
{
    public class DEntity : CacheWrapper<long, Entity, DEntity>, IEquatable<DEntity>
    {
        public int TypeID;
        public long EntityID => Key;
        public bool ESIDataExists => ESICache.Instance.DataExists<ESIEntity>(TypeID);
        
        // Will return null if doesnt exist yet
        public ESIData ESIData => ESICache.Instance.GetCachedData<ESIEntity>(TypeID);

        public override void Initialize(Entity value)
        {
            TypeID = value.TypeID;
        }

        #region Equals and hashcode 
        public override int GetHashCode() => EntityID.GetHashCode();

        public override bool Equals(object obj) => obj is DEntity other && Equals(other);

        public bool Equals(DEntity other)
        {
            return EntityID == other.EntityID;
        }

        public static bool operator ==(DEntity left, DEntity right) => left.Equals(right);

        public static bool operator !=(DEntity left, DEntity right) => !left.Equals(right);
        #endregion
    }
}
