using ns10;
using System;
using System.Runtime.CompilerServices;

namespace ns2
{
	public class Class21
	{
		public int int_0;

		public int int_1;

		public Class65 class65_0 = new Class65();

		public float[] float_0;

		public Class22 class22_0;

		public int[] int_2 = new int[15];

		[MethodImpl(MethodImplOptions.Synchronized)]
		public int method_0(float[] float_1, int int_3, Class38 class38_0, int int_4)
		{
			int num = int_4 / this.int_0;
			if (this.int_2.Length < num)
			{
				this.int_2 = new int[num];
			}
			int i;
			for (i = 0; i < num; i++)
			{
				int num2 = this.method_4(class38_0);
				if (num2 == -1)
				{
					return -1;
				}
				this.int_2[i] = num2 * this.int_0;
			}
			i = 0;
			int num3 = 0;
			while (i < this.int_0)
			{
				for (int j = 0; j < num; j++)
				{
					float_1[int_3 + num3 + j] += this.float_0[this.int_2[j] + i];
				}
				i++;
				num3 += num;
			}
			return 0;
		}

		public int method_1(float[] float_1, int int_3, Class38 class38_0, int int_4)
		{
			if (this.int_0 > 8)
			{
				int i = 0;
				while (i < int_4)
				{
					int num = this.method_4(class38_0);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.int_0;
					int j = 0;
					while (j < this.int_0)
					{
						float_1[int_3 + i++] += this.float_0[num2 + j++];
					}
				}
			}
			else
			{
				int i = 0;
				while (i < int_4)
				{
					int num = this.method_4(class38_0);
					if (num == -1)
					{
						return -1;
					}
					int num2 = num * this.int_0;
					int j = 0;
					for (int k = 0; k < this.int_0; k++)
					{
						float_1[int_3 + i++] += this.float_0[num2 + j++];
					}
				}
			}
			return 0;
		}

		public int method_2(float[] float_1, int int_3, Class38 class38_0, int int_4)
		{
			int i = 0;
			while (i < int_4)
			{
				int num = this.method_4(class38_0);
				if (num == -1)
				{
					return -1;
				}
				int num2 = num * this.int_0;
				int j = 0;
				while (j < this.int_0)
				{
					float_1[int_3 + i++] = this.float_0[num2 + j++];
				}
			}
			return 0;
		}

		public int method_3(float[][] float_1, int int_3, int int_4, Class38 class38_0, int int_5)
		{
			int num = 0;
			int i = int_3 / int_4;
			while (i < (int_3 + int_5) / int_4)
			{
				int num2 = this.method_4(class38_0);
				if (num2 == -1)
				{
					return -1;
				}
				int num3 = num2 * this.int_0;
				for (int j = 0; j < this.int_0; j++)
				{
					float_1[num][i] += this.float_0[num3 + j];
					num++;
					if (num == int_4)
					{
						num = 0;
						i++;
					}
				}
			}
			return 0;
		}

		public int method_4(Class38 class38_0)
		{
			int num = 0;
			Class22 @class = this.class22_0;
			if (@class == null)
			{
				return num;
			}
			int num2 = class38_0.method_2(@class.int_2);
			if (num2 >= 0)
			{
				num = @class.int_0[num2];
				class38_0.method_3(@class.int_1[num2]);
				if (num <= 0)
				{
					return -num;
				}
			}
			do
			{
				switch (class38_0.method_7())
				{
				case 0:
					num = @class.int_3[num];
					goto IL_46;
				case 1:
					num = @class.int_4[num];
					goto IL_46;
				}
				return -1;
				IL_46:;
			}
			while (num > 0);
			return -num;
		}

		public void method_5()
		{
		}

		public int method_6(Class65 class65_1)
		{
			this.class65_0 = class65_1;
			this.int_1 = class65_1.int_1;
			this.int_0 = class65_1.int_0;
			this.float_0 = class65_1.method_3();
			this.class22_0 = this.method_7();
			if (this.class22_0 == null)
			{
				this.method_5();
				return -1;
			}
			return 0;
		}

		public static int[] smethod_0(int[] int_3, int int_4)
		{
			int[] array = new int[33];
			int[] array2 = new int[int_4];

			for (int i = 0; i < int_4; i++)
			{
				int num = int_3[i];
				if (num > 0)
				{
					int num2 = array[num];
					if (num >= 32 || (uint)num2 >> num == 0u)
					{
						array2[i] = num2;
                        for (int j = num; j > 0; j--)
                        {
                            if (!((array[j] & 1) != 0))
                                goto SKIPIT;
                            
                                if (j == 1)
                                {
                                    array[1]++;
                                }
                                else
                                {
                                    array[j] = array[j - 1] << 1;
                                }
                            IL_92:
                                int num3 = num + 1;
                                while (num3 < 33 && (ulong)((uint)array[num3] >> 1) == (ulong)((long)num2))
                                {
                                    num2 = array[num3];
                                    array[num3] = array[num3 - 1] << 1;
                                    num3++;
                                }
                                goto IL_C3;
                            
                        SKIPIT:
                            array[j]++;

                            j--;
                            if (j > 0)
                                goto IL_92;
                        }
					}
					return null;
				}
				IL_C3:;
			}
			for (int k = 0; k < int_4; k++)
			{
				int num4 = 0;
				for (int l = 0; l < int_3[k]; l++)
				{
					num4 <<= 1;
					num4 |= (int)((uint)array2[k] >> l & 1u);
				}
				array2[k] = num4;
			}
			return array2;
		}

		public Class22 method_7()
		{
			int num = 0;
			Class22 @class = new Class22();
			int[] array = @class.int_3 = new int[this.int_1 * 2];
			int[] array2 = @class.int_4 = new int[this.int_1 * 2];
			int[] array3 = Class21.smethod_0(this.class65_0.int_2, this.class65_0.int_1);
			if (array3 == null)
			{
				return null;
			}
			@class.int_5 = this.int_1 * 2;
			for (int i = 0; i < this.int_1; i++)
			{
				if (this.class65_0.int_2[i] > 0)
				{
					int num2 = 0;
					int j;
					for (j = 0; j < this.class65_0.int_2[i] - 1; j++)
					{
						if (((uint)array3[i] >> j & 1u) == 0u)
						{
							if (array[num2] == 0)
							{
								num = (array[num2] = num + 1);
							}
							num2 = array[num2];
						}
						else
						{
							if (array2[num2] == 0)
							{
								num = (array2[num2] = num + 1);
							}
							num2 = array2[num2];
						}
					}
					if (((uint)array3[i] >> j & 1u) == 0u)
					{
						array[num2] = -i;
					}
					else
					{
						array2[num2] = -i;
					}
				}
			}
			@class.int_2 = Class21.smethod_1(this.int_1) - 4;
			if (@class.int_2 < 5)
			{
				@class.int_2 = 5;
			}
			int num3 = 1 << @class.int_2;
			@class.int_0 = new int[num3];
			@class.int_1 = new int[num3];
			for (int k = 0; k < num3; k++)
			{
				int num4 = 0;
				int num5 = 0;
				while (num5 < @class.int_2 && (num4 > 0 || num5 == 0))
				{
					if ((k & 1 << num5) != 0)
					{
						num4 = array2[num4];
					}
					else
					{
						num4 = array[num4];
					}
					num5++;
				}
				@class.int_0[k] = num4;
				@class.int_1[k] = num5;
			}
			return @class;
		}

		public static int smethod_1(int int_3)
		{
			int num = 0;
			while (int_3 != 0)
			{
				num++;
				int_3 = (int)((uint)int_3 >> 1);
			}
			return num;
		}
	}
}
