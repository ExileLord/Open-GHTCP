using System;

namespace GHNamespace2
{
    public struct Struct10 : IComparable, ICloneable
    {
        public float Float0;

        public float Float1;

        public Struct10(Struct10 struct100)
        {
            Float0 = struct100.Float0;
            Float1 = struct100.Float1;
        }

        object ICloneable.Clone()
        {
            return new Struct10(this);
        }

        public float method_0()
        {
            float num = Float0;
            float num2 = Float1;
            return (float) Math.Sqrt(num * num + num2 * num2);
        }

        public static bool smethod_0(Struct10 struct100, Struct10 struct101)
        {
            return struct100.Float0 == struct101.Float0 && struct100.Float1 == struct101.Float1;
        }

        public override int GetHashCode()
        {
            return Float0.GetHashCode() ^ Float1.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is Struct10 struct10)
            {
                return smethod_0(this, struct10);
            }
            return false;
        }

        public int CompareTo(object target)
        {
            if (target == null)
            {
                return 1;
            }
            if (target is Struct10)
            {
                return method_0().CompareTo(((Struct10) target).method_0());
            }
            if (target is float)
            {
                return method_0().CompareTo((float) target);
            }
            if (target is Struct12)
            {
                return method_0().CompareTo(((Struct12) target).method_0());
            }
            if (!(target is double))
            {
                throw new ArgumentException();
            }
            return method_0().CompareTo((double) target);
        }

        public override string ToString()
        {
            return string.Format("( {0}, {1}i )", Float0, Float1);
        }
    }
}