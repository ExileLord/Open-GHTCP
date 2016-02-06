using System;
using System.Runtime.InteropServices;

namespace ns0
{
	[StructLayout(LayoutKind.Explicit, Size = 3)]
	public struct Struct8
	{
		public const int int_0 = 8388607;

		public const int int_1 = -8388608;

		[FieldOffset(0)]
		private byte byte_0;

		[FieldOffset(1)]
		private byte byte_1;

		[FieldOffset(2)]
		private byte byte_2;

		public static int smethod_0(Struct8 struct8_0)
		{
			return BitConverter.ToInt32(new byte[]
			{
				struct8_0.byte_0,
				struct8_0.byte_1,
				struct8_0.byte_2,
				(struct8_0.byte_2 > 127) ? (byte)255 : (byte)0
			}, 0);
		}

		public static Struct8 smethod_1(int int_2)
		{
			Struct8 result = default(Struct8);
			byte[] bytes = BitConverter.GetBytes(int_2);
			result.byte_0 = bytes[0];
			result.byte_1 = bytes[1];
			result.byte_2 = bytes[2];
			return result;
		}

		public static Struct8 smethod_2(byte[] byte_3, int int_2)
		{
			return Struct8.smethod_3(byte_3, int_2, false);
		}

		public static Struct8 smethod_3(byte[] byte_3, int int_2, bool bool_0)
		{
			if (byte_3 == null)
			{
				throw new ArgumentNullException();
			}
			if ((ulong)int_2 >= (ulong)((long)byte_3.Length))
			{
				throw new ArgumentOutOfRangeException();
			}
			if (int_2 > byte_3.Length - 3)
			{
				throw new ArgumentException("ToInt24: offseted size is too small.");
			}
			Struct8 result = default(Struct8);
			if (bool_0)
			{
				result.byte_0 = byte_3[int_2 + 2];
				result.byte_1 = byte_3[int_2 + 1];
				result.byte_2 = byte_3[int_2];
			}
			else
			{
				result.byte_0 = byte_3[int_2];
				result.byte_1 = byte_3[int_2 + 1];
				result.byte_2 = byte_3[int_2 + 2];
			}
			return result;
		}

		public static byte[] smethod_4(Struct8 struct8_0)
		{
			return new byte[]
			{
				struct8_0.byte_0,
				struct8_0.byte_1,
				struct8_0.byte_2
			};
		}

		public static Struct8 smethod_5(Struct8 struct8_0, int int_2)
		{
			byte[] array = new byte[4];
			array[0] = struct8_0.byte_0;
			array[1] = struct8_0.byte_1;
			array[2] = struct8_0.byte_2;
			int num = BitConverter.ToInt32(array, 0);
			num >>= int_2;
			return Struct8.smethod_1(num);
		}

		public static Struct8 smethod_6(Struct8 struct8_0, int int_2)
		{
			byte[] array = new byte[4];
			array[0] = struct8_0.byte_0;
			array[1] = struct8_0.byte_1;
			array[2] = struct8_0.byte_2;
			int num = BitConverter.ToInt32(array, 0);
			num <<= int_2;
			return Struct8.smethod_1(num);
		}
	}
}
