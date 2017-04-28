using System;

namespace ns16
{
	public struct Struct80 : IComparable, IEquatable<Struct80>, IComparable<int>, IEquatable<int>, IComparable<Struct80>, IConvertible, IFormattable
	{
		public const int int_0 = 8388607;

		public const int int_1 = 8388608;

		public int int_2;

		public int CompareTo(object target)
		{
			if (target == null)
			{
				return 1;
			}
			if (!(target is Struct80) && !(target is int))
			{
				throw new ArgumentException("Value is not a SystemTools.Int24 or System.Int32");
			}
			var num = (int)target;
			if (int_2 == num)
			{
				return 0;
			}
			if (int_2 <= num)
			{
				return -1;
			}
			return 1;
		}

		public override bool Equals(object obj)
		{
			return (obj is Struct80 || obj is int) && (int)obj == int_2;
		}

		public override int GetHashCode()
		{
			return int_2;
		}

		public int CompareTo(int other)
		{
			if (int_2 == other)
			{
				return 0;
			}
			if (int_2 <= other)
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(int other)
		{
			return other == int_2;
		}

		public int CompareTo(Struct80 other)
		{
			if (int_2 == other.int_2)
			{
				return 0;
			}
			if (int_2 <= other.int_2)
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(Struct80 other)
		{
			return other.int_2 == int_2;
		}

		public override string ToString()
		{
			return int_2.ToString();
		}

		public string ToString(IFormatProvider provider)
		{
			return int_2.ToString(provider);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return int_2.ToString(format, provider);
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(int_2);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(int_2);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(int_2);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(int_2);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(int_2);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(int_2);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(int_2);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return int_2;
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(int_2);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(int_2);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(int_2);
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(int_2, conversionType, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(int_2);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(int_2);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(int_2);
		}
	}
}
