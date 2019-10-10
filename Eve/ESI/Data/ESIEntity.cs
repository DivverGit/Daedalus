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
    public class MyObjectManager
    {
        public abstract class ObjectBase
        {
            public int myInt { get; set; }
        }

        public class Object1 : ObjectBase
        {
            
            public string Object1Name { get; set; }
            public Object1(int myint, string object1name)
            {
                myInt = myint;
                Object1Name = object1name;
            }
        }

        public class Object2 : ObjectBase
        {
            public string[] Object2Array { get; set; }
            public Object2(int myint, string[] object2array)
            {
                myInt = myint;
                Object2Array = object2array;
            }
        }

        public bool TryGetFieldValue<T>(object item, string fieldName, out T value)
        {
            try
            {
                FieldInfo fi = item.GetType().GetField(fieldName);
                object o = fi.GetValue(item);

                if (o is T)
                {
                    value = (T) o;
                    return true;
                } else
                {
                    value = default;
                    return false;
                }
            } catch (Exception e)
            {
                value = default;
                return false;
            }
        }
    }
}
