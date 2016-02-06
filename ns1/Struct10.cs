using System;

namespace ns1
{
	public struct Struct10 : IComparable, ICloneable
	{
		public float float_0;

		public float float_1;

		public Struct10(Struct10 struct10_0)
		{
			this.float_0 = struct10_0.float_0;
			this.float_1 = struct10_0.float_1;
		}

		object ICloneable.Clone()
		{
			return new Struct10(this);
		}

		public float method_0()
		{
			float num = this.float_0;
			float num2 = this.float_1;
			return (float)Math.Sqrt((double)(num * num + num2 * num2));
		}

		public static bool smethod_0(Struct10 struct10_0, Struct10 struct10_1)
		{
			return struct10_0.float_0 == struct10_1.float_0 && struct10_0.float_1 == struct10_1.float_1;
		}

		public override int GetHashCode()
		{
			return this.float_0.GetHashCode() ^ this.float_1.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Struct10)
			{
				Struct10 struct10_ = (Struct10)obj;
				return Struct10.smethod_0(this, struct10_);
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
				return this.method_0().CompareTo(((Struct10)target).method_0());
			}
			if (target is float)
			{
				return this.method_0().CompareTo((float)target);
			}
			if (target is Struct12)
			{
				return this.method_0().CompareTo(((Struct12)target).method_0());
			}
			if (!(target is double))
			{
				throw new ArgumentException();
			}
			return this.method_0().CompareTo((double)target);
		}

		public override string ToString()
		{
			return string.Format("( {0}, {1}i )", this.float_0, this.float_1);
		}
	}
}
