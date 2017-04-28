using System;

namespace ns6
{
	public struct Struct62 : IEquatable<Struct62>, IComparable<Struct62>
	{
		private IntPtr intptr_0;

		public static readonly Struct62 struct62_0 = new Struct62(IntPtr.Zero);

		public IntPtr method_0()
		{
			return intptr_0;
		}

		public Struct62(IntPtr intptr_1)
		{
			intptr_0 = intptr_1;
		}

		public override string ToString()
		{
			return method_0().ToString();
		}

		public override bool Equals(object obj)
		{
			return obj is Struct62 && Equals((Struct62)obj);
		}

		public override int GetHashCode()
		{
			return method_0().GetHashCode();
		}

		public static IntPtr smethod_0(Struct62 struct62_1)
		{
			if (!smethod_2(struct62_1, struct62_0))
			{
				return IntPtr.Zero;
			}
			return struct62_1.intptr_0;
		}

		public static bool smethod_1(Struct62 struct62_1, Struct62 struct62_2)
		{
			return struct62_1.Equals(struct62_2);
		}

		public static bool smethod_2(Struct62 struct62_1, Struct62 struct62_2)
		{
			return !struct62_1.Equals(struct62_2);
		}

		public int CompareTo(Struct62 other)
		{
			return (int)other.intptr_0 - (int)intptr_0;
		}

		public bool Equals(Struct62 other)
		{
			return method_0() == other.method_0();
		}
	}
}
