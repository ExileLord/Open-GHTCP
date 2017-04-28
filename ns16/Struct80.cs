using System;

namespace ns16
{
	public struct Struct80 : IComparable, IEquatable<Struct80>, IComparable<int>, IEquatable<int>, IComparable<Struct80>, IConvertible, IFormattable
	{
		public const int Int0 = 8388607;

		public const int Int1 = 8388608;

		public int Int2;

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
			if (Int2 == num)
			{
				return 0;
			}
			if (Int2 <= num)
			{
				return -1;
			}
			return 1;
		}

		public override bool Equals(object obj)
		{
			return (obj is Struct80 || obj is int) && (int)obj == Int2;
		}

		public override int GetHashCode()
		{
			return Int2;
		}

		public int CompareTo(int other)
		{
			if (Int2 == other)
			{
				return 0;
			}
			if (Int2 <= other)
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(int other)
		{
			return other == Int2;
		}

		public int CompareTo(Struct80 other)
		{
			if (Int2 == other.Int2)
			{
				return 0;
			}
			if (Int2 <= other.Int2)
			{
				return -1;
			}
			return 1;
		}

		public bool Equals(Struct80 other)
		{
			return other.Int2 == Int2;
		}

		public override string ToString()
		{
			return Int2.ToString();
		}

		public string ToString(IFormatProvider provider)
		{
			return Int2.ToString(provider);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return Int2.ToString(format, provider);
		}

		public TypeCode GetTypeCode()
		{
			return TypeCode.Int32;
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(Int2);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(Int2);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(Int2);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(Int2);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(Int2);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(Int2);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(Int2);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Int2;
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(Int2);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(Int2);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(Int2);
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(Int2, conversionType, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(Int2);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(Int2);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(Int2);
		}
	}
}
