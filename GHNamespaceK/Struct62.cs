using System;

namespace GHNamespaceK
{
	public struct Struct62 : IEquatable<Struct62>, IComparable<Struct62>
	{
		private readonly IntPtr _intptr0;

		public static readonly Struct62 Struct620 = new Struct62(IntPtr.Zero);

		public IntPtr method_0()
		{
			return _intptr0;
		}

		public Struct62(IntPtr intptr1)
		{
			_intptr0 = intptr1;
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

		public static IntPtr smethod_0(Struct62 struct621)
		{
			if (!smethod_2(struct621, Struct620))
			{
				return IntPtr.Zero;
			}
			return struct621._intptr0;
		}

		public static bool smethod_1(Struct62 struct621, Struct62 struct622)
		{
			return struct621.Equals(struct622);
		}

		public static bool smethod_2(Struct62 struct621, Struct62 struct622)
		{
			return !struct621.Equals(struct622);
		}

		public int CompareTo(Struct62 other)
		{
			return (int)other._intptr0 - (int)_intptr0;
		}

		public bool Equals(Struct62 other)
		{
			return method_0() == other.method_0();
		}
	}
}
