using System;
using System.Runtime.InteropServices;

namespace ns0
{
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	public struct Struct8
	{
		public const int Int0 = 8388607;

		public const int Int1 = -8388608;

		[FieldOffset(0)]
		private byte byte_0;

		[FieldOffset(1)]
		private byte byte_1;

		[FieldOffset(2)]
		private byte byte_2;

		public static int smethod_0(Struct8 struct80)
		{
			return BitConverter.ToInt32(new[]
			{
				struct80.byte_0,
				struct80.byte_1,
				struct80.byte_2,
				(struct80.byte_2 > 127) ? (byte)255 : (byte)0
			}, 0);
		}

		public static Struct8 smethod_1(int int2)
		{
			var result = default(Struct8);
			var bytes = BitConverter.GetBytes(int2);
			result.byte_0 = bytes[0];
			result.byte_1 = bytes[1];
			result.byte_2 = bytes[2];
			return result;
		}

		public static Struct8 smethod_2(byte[] byte3, int int2)
		{
			return smethod_3(byte3, int2, false);
		}

		public static Struct8 smethod_3(byte[] byte3, int int2, bool bool0)
		{
			if (byte3 == null)
			{
				throw new ArgumentNullException();
			}
			if ((ulong)int2 >= (ulong)byte3.Length)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (int2 > byte3.Length - 3)
			{
				throw new ArgumentException("ToInt24: offseted size is too small.");
			}
			var result = default(Struct8);
			if (bool0)
			{
				result.byte_0 = byte3[int2 + 2];
				result.byte_1 = byte3[int2 + 1];
				result.byte_2 = byte3[int2];
			}
			else
			{
				result.byte_0 = byte3[int2];
				result.byte_1 = byte3[int2 + 1];
				result.byte_2 = byte3[int2 + 2];
			}
			return result;
		}

		public static byte[] smethod_4(Struct8 struct80)
		{
			return new[]
			{
				struct80.byte_0,
				struct80.byte_1,
				struct80.byte_2
			};
		}

		public static Struct8 smethod_5(Struct8 struct80, int int2)
		{
			var array = new byte[4];
			array[0] = struct80.byte_0;
			array[1] = struct80.byte_1;
			array[2] = struct80.byte_2;
			var num = BitConverter.ToInt32(array, 0);
			num >>= int2;
			return smethod_1(num);
		}

		public static Struct8 smethod_6(Struct8 struct80, int int2)
		{
			var array = new byte[4];
			array[0] = struct80.byte_0;
			array[1] = struct80.byte_1;
			array[2] = struct80.byte_2;
			var num = BitConverter.ToInt32(array, 0);
			num <<= int2;
			return smethod_1(num);
		}
	}
}
