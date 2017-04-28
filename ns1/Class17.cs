using System;
using System.Runtime.InteropServices;

namespace ns1
{
	[StructLayout(LayoutKind.Explicit)]
	public class Class17
	{
		[FieldOffset(0)]
		private int int_0;

		[FieldOffset(4)]
		private byte[] byte_0;

		[FieldOffset(4)]
		private float[] float_0;

		[FieldOffset(4)]
		private short[] short_0;

		[FieldOffset(4)]
		private int[] int_1;

		public Class17(int int_2)
		{
			int num = int_2 & 3;
			int_2 = ((num == 0) ? int_2 : (int_2 + 4 - num));
			byte_0 = new byte[int_2];
			int_0 = 0;
		}

		public static short[] smethod_0(Class17 class17_0)
		{
			return class17_0.short_0;
		}

		public byte[] method_0()
		{
			return byte_0;
		}

		public float[] method_1()
		{
			return float_0;
		}

		public short[] method_2()
		{
			return short_0;
		}

		public int method_3()
		{
			return int_0;
		}

		public void method_4(int int_2)
		{
			int_0 = method_9("ByteBufferCount", int_2, 0);
		}

		public int method_5()
		{
			return int_0 >> 2;
		}

		public void method_6(int int_2)
		{
			int_0 = method_9("FloatBufferCount", int_2, 2);
		}

		public int method_7()
		{
			return int_0 >> 1;
		}

		public void method_8(int int_2)
		{
			int_0 = method_9("ShortBufferCount", int_2, 1);
		}

		private int method_9(string string_0, int int_2, int int_3)
		{
			int num = int_2 << int_3;
			if ((num & 3) != 0)
			{
				throw new ArgumentOutOfRangeException(string_0, string.Format("{0} cannot set a count ({1}) that is not 4 bytes aligned ", string_0, num));
			}
			if (int_2 < 0 || int_2 > byte_0.Length >> int_3)
			{
				throw new ArgumentOutOfRangeException(string_0, string.Format("{0} cannot set a count that exceed max count {1}", string_0, byte_0.Length >> int_3));
			}
			return num;
		}
	}
}
