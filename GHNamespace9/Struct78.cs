using System;

namespace GHNamespace9
{
	public struct Struct78 : IComparable, ICloneable
	{
		public float Float0;

		public float Float1;

		public Struct78(Struct78 struct780)
		{
			Float0 = struct780.Float0;
			Float1 = struct780.Float1;
		}

		object ICloneable.Clone()
		{
			return new Struct78(this);
		}

		public float method_0()
		{
			var num = Float0;
			var num2 = Float1;
			return (float)Math.Sqrt(num * num + num2 * num2);
		}

		public static bool smethod_0(Struct78 struct780, Struct78 struct781)
		{
			return struct780.Float0 == struct781.Float0 && struct780.Float1 == struct781.Float1;
		}

		public override int GetHashCode()
		{
			return Float0.GetHashCode() ^ Float1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct78)
			{
				var struct78 = (Struct78)obj;
				return smethod_0(this, struct78);
			}
			return false;
		}

		public int CompareTo(object target)
		{
			if (target == null)
			{
				return 1;
			}
			if (target is Struct78)
			{
				return method_0().CompareTo(((Struct78)target).method_0());
			}
			if (target is float)
			{
				return method_0().CompareTo((float)target);
			}
			if (target is Struct79)
			{
				return method_0().CompareTo(((Struct79)target).method_0());
			}
			if (!(target is double))
			{
				throw new ArgumentException();
			}
			return method_0().CompareTo((double)target);
		}

		public override string ToString()
		{
			return string.Format("( {0}, {1}i )", Float0, Float1);
		}
	}
}
