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
		private readonly byte[] byte_0;

		[FieldOffset(4)]
		private float[] float_0;

		[FieldOffset(4)]
		private short[] short_0;

		[FieldOffset(4)]
		private int[] int_1;

		public Class17(int int2)
		{
			var num = int2 & 3;
			int2 = ((num == 0) ? int2 : (int2 + 4 - num));
			byte_0 = new byte[int2];
			int_0 = 0;
		}

		public static short[] smethod_0(Class17 class170)
		{
			return class170.short_0;
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

		public void method_4(int int2)
		{
			int_0 = method_9("ByteBufferCount", int2, 0);
		}

		public int method_5()
		{
			return int_0 >> 2;
		}

		public void method_6(int int2)
		{
			int_0 = method_9("FloatBufferCount", int2, 2);
		}

		public int method_7()
		{
			return int_0 >> 1;
		}

		public void method_8(int int2)
		{
			int_0 = method_9("ShortBufferCount", int2, 1);
		}

		private int method_9(string string0, int int2, int int3)
		{
			var num = int2 << int3;
			if ((num & 3) != 0)
			{
				throw new ArgumentOutOfRangeException(string0, string.Format("{0} cannot set a count ({1}) that is not 4 bytes aligned ", string0, num));
			}
			if (int2 < 0 || int2 > byte_0.Length >> int3)
			{
				throw new ArgumentOutOfRangeException(string0, string.Format("{0} cannot set a count that exceed max count {1}", string0, byte_0.Length >> int3));
			}
			return num;
		}
	}
}
