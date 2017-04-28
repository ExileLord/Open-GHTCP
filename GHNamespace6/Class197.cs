using System;
using Compression;
using GHNamespace5;

namespace GHNamespace6
{
	public class Class197
	{
		private short[] _short0;

		public static Class197 Class1970;

		public static Class197 Class1971;

		static Class197()
		{
			try
			{
				var array = new byte[288];
				var i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				Class1970 = new Class197(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				Class1971 = new Class197(array);
			}
			catch (Exception)
			{
				throw new SharpZipBaseException("InflaterHuffmanTree: static tree length illegal");
			}
		}

		public Class197(byte[] byte0)
		{
			method_0(byte0);
		}

		private void method_0(byte[] byte0)
		{
			var array = new int[16];
			var array2 = new int[16];
			for (var i = 0; i < byte0.Length; i++)
			{
				int num = byte0[i];
				if (num > 0)
				{
					array[num]++;
				}
			}
			var num2 = 0;
			var num3 = 512;
			for (var j = 1; j <= 15; j++)
			{
				array2[j] = num2;
				num2 += array[j] << 16 - j;
				if (j >= 10)
				{
					var num4 = array2[j] & 130944;
					var num5 = num2 & 130944;
					num3 += num5 - num4 >> 16 - j;
				}
			}
			_short0 = new short[num3];
			var num6 = 512;
			for (var k = 15; k >= 10; k--)
			{
				var num7 = num2 & 130944;
				num2 -= array[k] << 16 - k;
				var num8 = num2 & 130944;
				for (var l = num8; l < num7; l += 128)
				{
					_short0[Class190.smethod_0(l)] = (short)(-num6 << 4 | k);
					num6 += 1 << k - 9;
				}
			}
			for (var m = 0; m < byte0.Length; m++)
			{
				int num9 = byte0[m];
				if (num9 != 0)
				{
					num2 = array2[num9];
					int num10 = Class190.smethod_0(num2);
					if (num9 <= 9)
					{
						do
						{
							_short0[num10] = (short)(m << 4 | num9);
							num10 += 1 << num9;
						}
						while (num10 < 512);
					}
					else
					{
						int num11 = _short0[num10 & 511];
						var num12 = 1 << (num11 & 15);
						num11 = -(num11 >> 4);
						do
						{
							_short0[num11 | num10 >> 9] = (short)(m << 4 | num9);
							num10 += 1 << num9;
						}
						while (num10 < num12);
					}
					array2[num9] = num2 + (1 << 16 - num9);
				}
			}
		}

		public int method_1(Class187 class1870)
		{
			int num;
			if ((num = class1870.method_0(9)) >= 0)
			{
				int num2;
				if ((num2 = _short0[num]) >= 0)
				{
					class1870.method_1(num2 & 15);
					return num2 >> 4;
				}
				var num3 = -(num2 >> 4);
				var int_ = num2 & 15;
				if ((num = class1870.method_0(int_)) >= 0)
				{
					num2 = _short0[num3 | num >> 9];
					class1870.method_1(num2 & 15);
					return num2 >> 4;
				}
				var num4 = class1870.method_2();
				num = class1870.method_0(num4);
				num2 = _short0[num3 | num >> 9];
				if ((num2 & 15) <= num4)
				{
					class1870.method_1(num2 & 15);
					return num2 >> 4;
				}
				return -1;
			}
			else
			{
				var num5 = class1870.method_2();
				num = class1870.method_0(num5);
				int num2 = _short0[num];
				if (num2 >= 0 && (num2 & 15) <= num5)
				{
					class1870.method_1(num2 & 15);
					return num2 >> 4;
				}
				return -1;
			}
		}
	}
}
