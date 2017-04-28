using System;

namespace ns16
{
	public struct Struct79 : IComparable, ICloneable
	{
		public double Double0;

		public double Double1;

		public Struct79(Struct79 struct790)
		{
			Double0 = struct790.Double0;
			Double1 = struct790.Double1;
		}

		object ICloneable.Clone()
		{
			return new Struct79(this);
		}

		public double method_0()
		{
			var num = Double0;
			var num2 = Double1;
			return Math.Sqrt(num * num + num2 * num2);
		}

		public static bool smethod_0(Struct79 struct790, Struct79 struct791)
		{
			return struct790.Double0 == struct791.Double0 && struct790.Double1 == struct791.Double1;
		}

		public override int GetHashCode()
		{
			return Double0.GetHashCode() ^ Double1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct79)
			{
				var struct79 = (Struct79)obj;
				return smethod_0(this, struct79);
			}
			return false;
		}

		public int CompareTo(object target)
		{
			if (target == null)
			{
				return 1;
			}
			if (target is Struct79)
			{
				return method_0().CompareTo(((Struct79)target).method_0());
			}
			if (target is double)
			{
				return method_0().CompareTo((double)target);
			}
			if (target is Struct78)
			{
				return method_0().CompareTo(((Struct78)target).method_0());
			}
			if (!(target is float))
			{
				throw new ArgumentException();
			}
			return method_0().CompareTo((float)target);
		}

		public override string ToString()
		{
			return string.Format("( {0}, {1}i )", Double0, Double1);
		}
	}
}
