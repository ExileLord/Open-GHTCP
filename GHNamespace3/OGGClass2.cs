using System;
using GHNamespaceD;

namespace GHNamespace3
{
	public class OggClass2
	{
		public int Int0;

		public int Int1;

		public int[] Int2;

		public int Int3;

		public int Int4;

		public int Int5;

		public int Int6;

		public int Int7;

		public int[] Int8;

		private static readonly int Int9 = 21;

		private static readonly int Int10 = 768;

	    public int method_0(OggClass3 oggClass3)
		{
			if (oggClass3.method_6(24) != 5653314)
			{
				method_2();
				return -1;
			}
			Int0 = oggClass3.method_6(16);
			Int1 = oggClass3.method_6(24);
			if (Int1 == -1)
			{
				method_2();
				return -1;
			}
			switch (oggClass3.method_6(1))
			{
			case 0:
				Int2 = new int[Int1];
				if (oggClass3.method_6(1) != 0)
				{
					for (var i = 0; i < Int1; i++)
					{
						if (oggClass3.method_6(1) != 0)
						{
							var num = oggClass3.method_6(5);
							if (num == -1)
							{
								method_2();
								return -1;
							}
							Int2[i] = num + 1;
						}
						else
						{
							Int2[i] = 0;
						}
					}
				}
				else
				{
					for (var i = 0; i < Int1; i++)
					{
						var num2 = oggClass3.method_6(5);
						if (num2 == -1)
						{
							method_2();
							return -1;
						}
						Int2[i] = num2 + 1;
					}
				}
				break;
			case 1:
			{
				var num3 = oggClass3.method_6(5) + 1;
				Int2 = new int[Int1];
				var i = 0;
				while (i < Int1)
				{
					var num4 = oggClass3.method_6(smethod_0(Int1 - i));
					if (num4 == -1)
					{
						method_2();
						return -1;
					}
					var j = 0;
					while (j < num4)
					{
						Int2[i] = num3;
						j++;
						i++;
					}
					num3++;
				}
				break;
			}
			default:
				return -1;
			}
			switch (Int3 = oggClass3.method_6(4))
			{
			case 0:
				break;
			case 1:
			case 2:
			{
				Int4 = oggClass3.method_6(32);
				Int5 = oggClass3.method_6(32);
				Int6 = oggClass3.method_6(4) + 1;
				Int7 = oggClass3.method_6(1);
				var num5 = 0;
				switch (Int3)
				{
				case 1:
					num5 = method_1();
					break;
				case 2:
					num5 = Int1 * Int0;
					break;
				}
				Int8 = new int[num5];
				for (var i = 0; i < num5; i++)
				{
					Int8[i] = oggClass3.method_6(Int6);
				}
				if (Int8[num5 - 1] == -1)
				{
					method_2();
					return -1;
				}
				break;
			}
			default:
				method_2();
				return -1;
			}
			return 0;
		}

		public int method_1()
		{
			var num = (int)Math.Floor(Math.Pow(Int1, 1.0 / Int0));
			while (true)
			{
				var num2 = 1;
				var num3 = 1;
				for (var i = 0; i < Int0; i++)
				{
					num2 *= num;
					num3 *= num + 1;
				}
				if (num2 <= Int1 && num3 > Int1)
				{
					break;
				}
                if (num2 > Int1)
				{
					num--;
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		public void method_2()
		{
		}

		public float[] method_3()
		{
			if (Int3 != 1)
			{
				if (Int3 != 2)
				{
					return null;
				}
			}
			var num = smethod_1(Int4);
			var num2 = smethod_1(Int5);
			var array = new float[Int1 * Int0];
			switch (Int3)
			{
			case 1:
			{
				var num3 = method_1();
				for (var i = 0; i < Int1; i++)
				{
					var num4 = 0f;
					var num5 = 1;
					for (var j = 0; j < Int0; j++)
					{
						var num6 = i / num5 % num3;
						float num7 = Int8[num6];
						num7 = Math.Abs(num7) * num2 + num + num4;
						if (Int7 != 0)
						{
							num4 = num7;
						}
						array[i * Int0 + j] = num7;
						num5 *= num3;
					}
				}
				break;
			}
			case 2:
				for (var k = 0; k < Int1; k++)
				{
					var num8 = 0f;
					for (var l = 0; l < Int0; l++)
					{
						float num9 = Int8[k * Int0 + l];
						num9 = Math.Abs(num9) * num2 + num + num8;
						if (Int7 != 0)
						{
							num8 = num9;
						}
						array[k * Int0 + l] = num9;
					}
				}
				break;
			}
			return array;
		}

		public static int smethod_0(int int11)
		{
			var num = 0;
			while (int11 != 0)
			{
				num++;
				int11 = (int)((uint)int11 >> 1);
			}
			return num;
		}

		public static float smethod_1(int int11)
		{
			float num = int11 & 2097151;
			float num2 = (uint)(int11 & 2145386496) >> Int9;
			if ((int11 & 2147483648L) != 0L)
			{
				num = -num;
			}
			return smethod_2(num, (int)num2 - (Int9 - 1) - Int10);
		}

		public static float smethod_2(float float0, int int11)
		{
			return (float)(float0 * Math.Pow(2.0, int11));
		}
	}
}
