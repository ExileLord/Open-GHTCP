using ns12;
using System;

namespace ns13
{
	public class Class203
	{
		private byte[] byte_0 = new byte[32768];

		private int int_0;

		private int int_1;

		public void method_0(int int_2)
		{
			if (this.int_1++ == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			this.byte_0[this.int_0++] = (byte)int_2;
			this.int_0 &= 32767;
		}

		private void method_1(int int_2, int int_3, int int_4)
		{
			while (int_3-- > 0)
			{
				this.byte_0[this.int_0++] = this.byte_0[int_2++];
				this.int_0 &= 32767;
				int_2 &= 32767;
			}
		}

		public void method_2(int int_2, int int_3)
		{
			if ((this.int_1 += int_2) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = this.int_0 - int_3 & 32767;
			int num2 = 32768 - int_2;
			if (num > num2 || this.int_0 >= num2)
			{
				this.method_1(num, int_2, int_3);
				return;
			}
			if (int_2 <= int_3)
			{
				Array.Copy(this.byte_0, num, this.byte_0, this.int_0, int_2);
				this.int_0 += int_2;
				return;
			}
			while (int_2-- > 0)
			{
				this.byte_0[this.int_0++] = this.byte_0[num++];
			}
		}

		public int method_3(Class187 class187_0, int int_2)
		{
			int_2 = Math.Min(Math.Min(int_2, 32768 - this.int_1), class187_0.method_3());
			int num = 32768 - this.int_0;
			int num2;
			if (int_2 > num)
			{
				num2 = class187_0.method_6(this.byte_0, this.int_0, num);
				if (num2 == num)
				{
					num2 += class187_0.method_6(this.byte_0, 0, int_2 - num);
				}
			}
			else
			{
				num2 = class187_0.method_6(this.byte_0, this.int_0, int_2);
			}
			this.int_0 = (this.int_0 + num2 & 32767);
			this.int_1 += num2;
			return num2;
		}

		public int method_4()
		{
			return 32768 - this.int_1;
		}

		public int method_5()
		{
			return this.int_1;
		}

		public int method_6(byte[] byte_1, int int_2, int int_3)
		{
			int num = this.int_0;
			if (int_3 > this.int_1)
			{
				int_3 = this.int_1;
			}
			else
			{
				num = (this.int_0 - this.int_1 + int_3 & 32767);
			}
			int num2 = int_3;
			int num3 = int_3 - num;
			if (num3 > 0)
			{
				Array.Copy(this.byte_0, 32768 - num3, byte_1, int_2, num3);
				int_2 += num3;
				int_3 = num;
			}
			Array.Copy(this.byte_0, num - int_3, byte_1, int_2, int_3);
			this.int_1 -= num2;
			if (this.int_1 < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		public void method_7()
		{
			this.int_0 = 0;
			this.int_1 = 0;
		}
	}
}
