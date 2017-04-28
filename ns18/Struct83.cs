using System;

namespace ns18
{
	public struct Struct83 : IComparable, IConvertible, IFormattable
	{
		private object object_0;

		public int CompareTo(object target)
		{
			return ((IComparable)object_0).CompareTo(target);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return ((IFormattable)object_0).ToString(format, provider);
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToUInt64(provider);
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToSByte(provider);
		}

		public double ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToDouble(provider);
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToDateTime(provider);
		}

		public float ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToSingle(provider);
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToBoolean(provider);
		}

		public int ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToInt32(provider);
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToUInt16(provider);
		}

		public short ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToInt16(provider);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToString(provider);
		}

		public byte ToByte(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToByte(provider);
		}

		public char ToChar(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToChar(provider);
		}

		public long ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToInt64(provider);
		}

		public TypeCode GetTypeCode()
		{
			return ((IConvertible)object_0).GetTypeCode();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToDecimal(provider);
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToType(conversionType, provider);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)object_0).ToUInt32(provider);
		}

		public override bool Equals(object obj)
		{
			return (obj is IComparable || obj is IConvertible) && ((IComparable)obj).CompareTo(object_0) == 0;
		}

		public override int GetHashCode()
		{
			return object_0.GetHashCode();
		}

		public override string ToString()
		{
			return object_0.ToString();
		}
	}
}
