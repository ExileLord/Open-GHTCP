using System;

namespace ns1
{
	public struct Struct12 : IComparable, ICloneable
	{
		public double Double0;

		public double Double1;

		public Struct12(Struct12 struct120)
		{
			Double0 = struct120.Double0;
			Double1 = struct120.Double1;
		}

		object ICloneable.Clone()
		{
			return new Struct12(this);
		}

		public double method_0()
		{
			var num = Double0;
			var num2 = Double1;
			return Math.Sqrt(num * num + num2 * num2);
		}

		public static bool smethod_0(Struct12 struct120, Struct12 struct121)
		{
			return struct120.Double0 == struct121.Double0 && struct120.Double1 == struct121.Double1;
		}

		public override int GetHashCode()
		{
			return Double0.GetHashCode() ^ Double1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct12)
			{
				var struct12 = (Struct12)obj;
				return smethod_0(this, struct12);
			}
			return false;
		}

		public int CompareTo(object target)
		{
			if (target == null)
			{
				return 1;
			}
			if (target is Struct12)
			{
				return method_0().CompareTo(((Struct12)target).method_0());
			}
			if (target is double)
			{
				return method_0().CompareTo((double)target);
			}
			if (target is Struct10)
			{
				return method_0().CompareTo(((Struct10)target).method_0());
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
