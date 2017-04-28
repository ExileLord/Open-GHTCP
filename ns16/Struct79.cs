using System;

namespace ns16
{
	public struct Struct79 : IComparable, ICloneable
	{
		public double double_0;

		public double double_1;

		public Struct79(Struct79 struct79_0)
		{
			double_0 = struct79_0.double_0;
			double_1 = struct79_0.double_1;
		}

		object ICloneable.Clone()
		{
			return new Struct79(this);
		}

		public double method_0()
		{
			double num = double_0;
			double num2 = double_1;
			return Math.Sqrt(num * num + num2 * num2);
		}

		public static bool smethod_0(Struct79 struct79_0, Struct79 struct79_1)
		{
			return struct79_0.double_0 == struct79_1.double_0 && struct79_0.double_1 == struct79_1.double_1;
		}

		public override int GetHashCode()
		{
			return double_0.GetHashCode() ^ double_1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct79)
			{
				Struct79 struct79_ = (Struct79)obj;
				return smethod_0(this, struct79_);
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
			return string.Format("( {0}, {1}i )", double_0, double_1);
		}
	}
}
