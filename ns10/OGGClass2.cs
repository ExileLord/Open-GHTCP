using ns2;
using System;

namespace ns10
{
	public class OGGClass2
	{
		public int int_0;

		public int int_1;

		public int[] int_2;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public int int_7;

		public int[] int_8;

		private static int int_9 = 21;

		private static int int_10 = 768;

        public OGGClass2()
		{
		}

		public int method_0(OGGClass3 oggClass3)
		{
			if (oggClass3.method_6(24) != 5653314)
			{
				this.method_2();
				return -1;
			}
			this.int_0 = oggClass3.method_6(16);
			this.int_1 = oggClass3.method_6(24);
			if (this.int_1 == -1)
			{
				this.method_2();
				return -1;
			}
			switch (oggClass3.method_6(1))
			{
			case 0:
				this.int_2 = new int[this.int_1];
				if (oggClass3.method_6(1) != 0)
				{
					for (int i = 0; i < this.int_1; i++)
					{
						if (oggClass3.method_6(1) != 0)
						{
							int num = oggClass3.method_6(5);
							if (num == -1)
							{
								this.method_2();
								return -1;
							}
							this.int_2[i] = num + 1;
						}
						else
						{
							this.int_2[i] = 0;
						}
					}
				}
				else
				{
					for (int i = 0; i < this.int_1; i++)
					{
						int num2 = oggClass3.method_6(5);
						if (num2 == -1)
						{
							this.method_2();
							return -1;
						}
						this.int_2[i] = num2 + 1;
					}
				}
				break;
			case 1:
			{
				int num3 = oggClass3.method_6(5) + 1;
				this.int_2 = new int[this.int_1];
				int i = 0;
				while (i < this.int_1)
				{
					int num4 = oggClass3.method_6(OGGClass2.smethod_0(this.int_1 - i));
					if (num4 == -1)
					{
						this.method_2();
						return -1;
					}
					int j = 0;
					while (j < num4)
					{
						this.int_2[i] = num3;
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
			switch (this.int_3 = oggClass3.method_6(4))
			{
			case 0:
				break;
			case 1:
			case 2:
			{
				this.int_4 = oggClass3.method_6(32);
				this.int_5 = oggClass3.method_6(32);
				this.int_6 = oggClass3.method_6(4) + 1;
				this.int_7 = oggClass3.method_6(1);
				int num5 = 0;
				switch (this.int_3)
				{
				case 1:
					num5 = this.method_1();
					break;
				case 2:
					num5 = this.int_1 * this.int_0;
					break;
				}
				this.int_8 = new int[num5];
				for (int i = 0; i < num5; i++)
				{
					this.int_8[i] = oggClass3.method_6(this.int_6);
				}
				if (this.int_8[num5 - 1] == -1)
				{
					this.method_2();
					return -1;
				}
				break;
			}
			default:
				this.method_2();
				return -1;
			}
			return 0;
		}

		public int method_1()
		{
			int num = (int)Math.Floor(Math.Pow((double)this.int_1, 1.0 / (double)this.int_0));
			while (true)
			{
				int num2 = 1;
				int num3 = 1;
				for (int i = 0; i < this.int_0; i++)
				{
					num2 *= num;
					num3 *= num + 1;
				}
				if (num2 <= this.int_1 && num3 > this.int_1)
				{
					break;
				}
                if (num2 > this.int_1)
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
			if (this.int_3 != 1)
			{
				if (this.int_3 != 2)
				{
					return null;
				}
			}
			float num = OGGClass2.smethod_1(this.int_4);
			float num2 = OGGClass2.smethod_1(this.int_5);
			float[] array = new float[this.int_1 * this.int_0];
			switch (this.int_3)
			{
			case 1:
			{
				int num3 = this.method_1();
				for (int i = 0; i < this.int_1; i++)
				{
					float num4 = 0f;
					int num5 = 1;
					for (int j = 0; j < this.int_0; j++)
					{
						int num6 = i / num5 % num3;
						float num7 = (float)this.int_8[num6];
						num7 = Math.Abs(num7) * num2 + num + num4;
						if (this.int_7 != 0)
						{
							num4 = num7;
						}
						array[i * this.int_0 + j] = num7;
						num5 *= num3;
					}
				}
				break;
			}
			case 2:
				for (int k = 0; k < this.int_1; k++)
				{
					float num8 = 0f;
					for (int l = 0; l < this.int_0; l++)
					{
						float num9 = (float)this.int_8[k * this.int_0 + l];
						num9 = Math.Abs(num9) * num2 + num + num8;
						if (this.int_7 != 0)
						{
							num8 = num9;
						}
						array[k * this.int_0 + l] = num9;
					}
				}
				break;
			}
			return array;
		}

		public static int smethod_0(int int_11)
		{
			int num = 0;
			while (int_11 != 0)
			{
				num++;
				int_11 = (int)((uint)int_11 >> 1);
			}
			return num;
		}

		public static float smethod_1(int int_11)
		{
			float num = (float)(int_11 & 2097151);
			float num2 = (uint)(int_11 & 2145386496) >> OGGClass2.int_9;
			if (((long)int_11 & 2147483648L) != 0L)
			{
				num = -num;
			}
			return OGGClass2.smethod_2(num, (int)num2 - (OGGClass2.int_9 - 1) - OGGClass2.int_10);
		}

		public static float smethod_2(float float_0, int int_11)
		{
			return (float)((double)float_0 * Math.Pow(2.0, (double)int_11));
		}
	}
}
