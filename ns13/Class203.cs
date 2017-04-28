using System;
using ns12;

namespace ns13
{
	public class Class203
	{
		private readonly byte[] byte_0 = new byte[32768];

		private int int_0;

		private int int_1;

		public void method_0(int int_2)
		{
			if (int_1++ == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			byte_0[int_0++] = (byte)int_2;
			int_0 &= 32767;
		}

		private void method_1(int int_2, int int_3, int int_4)
		{
			while (int_3-- > 0)
			{
				byte_0[int_0++] = byte_0[int_2++];
				int_0 &= 32767;
				int_2 &= 32767;
			}
		}

		public void method_2(int int_2, int int_3)
		{
			if ((int_1 += int_2) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			var num = int_0 - int_3 & 32767;
			var num2 = 32768 - int_2;
			if (num > num2 || int_0 >= num2)
			{
				method_1(num, int_2, int_3);
				return;
			}
			if (int_2 <= int_3)
			{
				Array.Copy(byte_0, num, byte_0, int_0, int_2);
				int_0 += int_2;
				return;
			}
			while (int_2-- > 0)
			{
				byte_0[int_0++] = byte_0[num++];
			}
		}

		public int method_3(Class187 class187_0, int int_2)
		{
			int_2 = Math.Min(Math.Min(int_2, 32768 - int_1), class187_0.method_3());
			var num = 32768 - int_0;
			int num2;
			if (int_2 > num)
			{
				num2 = class187_0.method_6(byte_0, int_0, num);
				if (num2 == num)
				{
					num2 += class187_0.method_6(byte_0, 0, int_2 - num);
				}
			}
			else
			{
				num2 = class187_0.method_6(byte_0, int_0, int_2);
			}
			int_0 = (int_0 + num2 & 32767);
			int_1 += num2;
			return num2;
		}

		public int method_4()
		{
			return 32768 - int_1;
		}

		public int method_5()
		{
			return int_1;
		}

		public int method_6(byte[] byte_1, int int_2, int int_3)
		{
			var num = int_0;
			if (int_3 > int_1)
			{
				int_3 = int_1;
			}
			else
			{
				num = (int_0 - int_1 + int_3 & 32767);
			}
			var num2 = int_3;
			var num3 = int_3 - num;
			if (num3 > 0)
			{
				Array.Copy(byte_0, 32768 - num3, byte_1, int_2, num3);
				int_2 += num3;
				int_3 = num;
			}
			Array.Copy(byte_0, num - int_3, byte_1, int_2, int_3);
			int_1 -= num2;
			if (int_1 < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		public void method_7()
		{
			int_0 = 0;
			int_1 = 0;
		}
	}
}
