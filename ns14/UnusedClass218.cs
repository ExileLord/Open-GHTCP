using System;

namespace ns14
{
    // Can probably be deleted

	public class UnusedClass218 : IComparable, IConvertible, IFormattable
	{
		private object _object0;

		public int CompareTo(object target)
		{
			return ((IComparable)_object0).CompareTo(target);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			return ((IFormattable)_object0).ToString(format, provider);
		}

		public ulong ToUInt64(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToUInt64(provider);
		}

		public sbyte ToSByte(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToSByte(provider);
		}

		public double ToDouble(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToDouble(provider);
		}

		public DateTime ToDateTime(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToDateTime(provider);
		}

		public float ToSingle(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToSingle(provider);
		}

		public bool ToBoolean(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToBoolean(provider);
		}

		public int ToInt32(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToInt32(provider);
		}

		public ushort ToUInt16(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToUInt16(provider);
		}

		public short ToInt16(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToInt16(provider);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToString(provider);
		}

		public byte ToByte(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToByte(provider);
		}

		public char ToChar(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToChar(provider);
		}

		public long ToInt64(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToInt64(provider);
		}

		public TypeCode GetTypeCode()
		{
			return ((IConvertible)_object0).GetTypeCode();
		}

		public decimal ToDecimal(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToDecimal(provider);
		}

		public object ToType(Type conversionType, IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToType(conversionType, provider);
		}

		public uint ToUInt32(IFormatProvider provider)
		{
			return ((IConvertible)_object0).ToUInt32(provider);
		}

		public override bool Equals(object obj)
		{
			return (obj is IComparable || obj is IConvertible) && ((IComparable)obj).CompareTo(_object0) == 0;
		}

		public override int GetHashCode()
		{
			return _object0.GetHashCode();
		}

		public override string ToString()
		{
			return _object0.ToString();
		}
	}
}
