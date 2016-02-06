using ns2;
using ns3;
using System;

namespace ns10
{
	public class Class66
	{
		private static float float_0 = 3.14159274f;

		private static int int_0 = 1;

		private static int int_1 = 1;

		public int int_2;

		public Class49 class49_0;

		public int int_3;

		private float[][] float_1;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8;

		private int int_9;

		private int int_10;

		private int int_11;

		private long long_0;

		public long long_1;

		private long long_2;

		private long long_3;

		private long long_4;

		private long long_5;

		public float[][][][][] float_2;

		public object[][] object_0;

		public Class21[] class21_0;

		public object[] object_1;

		public Class66()
		{
			this.object_0 = new object[2][];
			this.float_2 = new float[2][][][][];
			this.float_2[0] = new float[2][][][];
			this.float_2[0][0] = new float[2][][];
			this.float_2[0][1] = new float[2][][];
			this.float_2[0][0][0] = new float[2][];
			this.float_2[0][0][1] = new float[2][];
			this.float_2[0][1][0] = new float[2][];
			this.float_2[0][1][1] = new float[2][];
			this.float_2[1] = new float[2][][][];
			this.float_2[1][0] = new float[2][][];
			this.float_2[1][1] = new float[2][][];
			this.float_2[1][0][0] = new float[2][];
			this.float_2[1][0][1] = new float[2][];
			this.float_2[1][1][0] = new float[2][];
			this.float_2[1][1][1] = new float[2][];
		}

		private static int smethod_0(int int_12)
		{
			int num = 0;
			while (int_12 > 1)
			{
				num++;
				int_12 = (int)((uint)int_12 >> 1);
			}
			return num;
		}

		public static float[] smethod_1(int int_12, int int_13, int int_14, int int_15)
		{
			float[] array = new float[int_13];
			if (int_12 == 0)
			{
				int num = (int_13 >> 2) - (int_14 >> 1);
				int num2 = int_13 - (int_13 >> 2) - (int_15 >> 1);
				for (int i = 0; i < int_14; i++)
				{
					float num3 = (float)(((double)i + 0.5) / (double)int_14 * (double)Class66.float_0 / 2.0);
					num3 = (float)Math.Sin((double)num3);
					num3 *= num3;
					num3 *= (float)((double)Class66.float_0 / 2.0);
					num3 = (float)Math.Sin((double)num3);
					array[i + num] = num3;
				}
				for (int j = num + int_14; j < num2; j++)
				{
					array[j] = 1f;
				}
				for (int k = 0; k < int_15; k++)
				{
					float num4 = (float)(((double)(int_15 - k) - 0.5) / (double)int_15 * (double)Class66.float_0 / 2.0);
					num4 = (float)Math.Sin((double)num4);
					num4 *= num4;
					num4 *= (float)((double)Class66.float_0 / 2.0);
					num4 = (float)Math.Sin((double)num4);
					array[k + num2] = num4;
				}
				return array;
			}
			return null;
		}

		private int method_0(Class49 class49_1, bool bool_0)
		{
			this.class49_0 = class49_1;
			this.int_3 = Class66.smethod_0(class49_1.int_14);
			this.object_0[0] = new object[Class66.int_0];
			this.object_0[1] = new object[Class66.int_0];
			this.object_0[0][0] = new Class68();
			this.object_0[1][0] = new Class68();
			((Class68)this.object_0[0][0]).method_0(class49_1.int_13[0]);
			((Class68)this.object_0[1][0]).method_0(class49_1.int_13[1]);
			this.float_2[0][0][0] = new float[Class66.int_1][];
			this.float_2[0][0][1] = this.float_2[0][0][0];
			this.float_2[0][1][0] = this.float_2[0][0][0];
			this.float_2[0][1][1] = this.float_2[0][0][0];
			this.float_2[1][0][0] = new float[Class66.int_1][];
			this.float_2[1][0][1] = new float[Class66.int_1][];
			this.float_2[1][1][0] = new float[Class66.int_1][];
			this.float_2[1][1][1] = new float[Class66.int_1][];
			for (int i = 0; i < Class66.int_1; i++)
			{
				this.float_2[0][0][0][i] = Class66.smethod_1(i, class49_1.int_13[0], class49_1.int_13[0] >> 1, class49_1.int_13[0] >> 1);
				this.float_2[1][0][0][i] = Class66.smethod_1(i, class49_1.int_13[1], class49_1.int_13[0] >> 1, class49_1.int_13[0] >> 1);
				this.float_2[1][0][1][i] = Class66.smethod_1(i, class49_1.int_13[1], class49_1.int_13[0] >> 1, class49_1.int_13[1] >> 1);
				this.float_2[1][1][0][i] = Class66.smethod_1(i, class49_1.int_13[1], class49_1.int_13[1] >> 1, class49_1.int_13[0] >> 1);
				this.float_2[1][1][1][i] = Class66.smethod_1(i, class49_1.int_13[1], class49_1.int_13[1] >> 1, class49_1.int_13[1] >> 1);
			}
			this.class21_0 = new Class21[class49_1.int_19];
			for (int j = 0; j < class49_1.int_19; j++)
			{
				this.class21_0[j] = new Class21();
				this.class21_0[j].method_6(class49_1.class65_0[j]);
			}
			this.int_4 = 8192;
			this.float_1 = new float[class49_1.int_8][];
			for (int k = 0; k < class49_1.int_8; k++)
			{
				this.float_1[k] = new float[this.int_4];
			}
			this.int_8 = 0;
			this.int_9 = 0;
			this.int_11 = class49_1.int_13[1] >> 1;
			this.int_5 = this.int_11;
			this.object_1 = new object[class49_1.int_14];
			for (int l = 0; l < class49_1.int_14; l++)
			{
				int num = class49_1.class27_0[l].int_3;
				int num2 = class49_1.int_21[num];
				this.object_1[l] = Class34.class34_0[num2].vmethod_1(this, class49_1.class27_0[l], class49_1.object_0[num]);
			}
			return 0;
		}

		public int method_1(Class49 class49_1)
		{
			this.method_0(class49_1, false);
			this.int_6 = this.int_11;
			this.int_11 -= (class49_1.int_13[this.int_9] >> 2) + (class49_1.int_13[this.int_8] >> 2);
			this.long_0 = -1L;
			this.long_1 = -1L;
			return 0;
		}

		public int method_2(Class71 class71_0)
		{
			if (this.int_11 > this.class49_0.int_13[1] >> 1 && this.int_6 > 8192)
			{
				int num = this.int_11 - (this.class49_0.int_13[1] >> 1);
				num = ((this.int_6 < num) ? this.int_6 : num);
				this.int_5 -= num;
				this.int_11 -= num;
				this.int_6 -= num;
				if (num != 0)
				{
					for (int i = 0; i < this.class49_0.int_8; i++)
					{
						Buffer.BlockCopy(this.float_1[i], num << 2, this.float_1[i], 0, this.int_5 << 2);
					}
				}
			}
			this.int_8 = this.int_9;
			this.int_9 = class71_0.int_1;
			this.int_10 = -1;
			this.long_2 += (long)class71_0.int_6;
			this.long_3 += (long)class71_0.int_7;
			this.long_4 += (long)class71_0.int_8;
			this.long_5 += (long)class71_0.int_9;
			if (this.long_1 + 1L != class71_0.long_1)
			{
				this.long_0 = -1L;
			}
			this.long_1 = class71_0.long_1;
			int num2 = this.class49_0.int_13[this.int_9];
			int num3 = this.int_11 + (this.class49_0.int_13[this.int_8] >> 2) + (num2 >> 2);
			int num4 = num3 - (num2 >> 1);
			int num5 = num4 + num2;
			int num6 = 0;
			int num7 = 0;
			if (num5 > this.int_4)
			{
				this.int_4 = num5 + this.class49_0.int_13[1];
				for (int j = 0; j < this.class49_0.int_8; j++)
				{
					float[] array = new float[this.int_4];
					Buffer.BlockCopy(this.float_1[j], 0, array, 0, this.float_1[j].Length << 2);
					this.float_1[j] = array;
				}
			}
			switch (this.int_9)
			{
			case 0:
				num6 = 0;
				num7 = this.class49_0.int_13[0] >> 1;
				break;
			case 1:
				num6 = (this.class49_0.int_13[1] >> 2) - (this.class49_0.int_13[this.int_8] >> 2);
				num7 = num6 + (this.class49_0.int_13[this.int_8] >> 1);
				break;
			}
			for (int k = 0; k < this.class49_0.int_8; k++)
			{
				int num8 = num4;
				int l;
				for (l = num6; l < num7; l++)
				{
					this.float_1[k][num8 + l] += class71_0.float_0[k][l];
				}
				while (l < num2)
				{
					this.float_1[k][num8 + l] = class71_0.float_0[k][l];
					l++;
				}
			}
			if (this.long_0 == -1L)
			{
				this.long_0 = class71_0.long_0;
			}
			else
			{
				this.long_0 += (long)(num3 - this.int_11);
				if (class71_0.long_0 != -1L && this.long_0 != class71_0.long_0)
				{
					if (this.long_0 > class71_0.long_0 && class71_0.int_5 != 0)
					{
						num3 -= (int)(this.long_0 - class71_0.long_0);
					}
					this.long_0 = class71_0.long_0;
				}
			}
			this.int_11 = num3;
			this.int_5 = num5;
			if (class71_0.int_5 != 0)
			{
				this.int_7 = 1;
			}
			return 0;
		}

		public int method_3()
		{
			if (this.int_6 < this.int_11)
			{
				return this.int_11 - this.int_6;
			}
			return 0;
		}

		public int method_4(float[] float_3, int int_12, int int_13)
		{
			if (this.int_6 < this.int_11)
			{
				int num = this.float_1.Length;
				int num2 = this.int_11 - this.int_6;
				int num3 = (int_13 - int_12) / num;
				if (num2 > num3)
				{
					num2 = num3;
				}
				int num4 = this.int_6 + num2;
				for (int i = 0; i < this.float_1.Length; i++)
				{
					float[] array = this.float_1[i];
					int j = this.int_6;
					int num5 = int_12 + i;
					while (j < num4)
					{
						float_3[num5] = array[j];
						j++;
						num5 += num;
					}
				}
				return num2;
			}
			return 0;
		}

		public int method_5(float[][] float_3, int int_12, int int_13)
		{
			if (this.int_6 < this.int_11)
			{
				int num = this.int_11 - this.int_6;
				if (num > int_13 - int_12)
				{
					num = int_13 - int_12;
				}
				for (int i = 0; i < this.class49_0.int_8; i++)
				{
					Buffer.BlockCopy(this.float_1[i], this.int_6 << 2, float_3[i], int_12 << 2, num << 2);
				}
				return num;
			}
			return 0;
		}

		public int method_6(int int_12)
		{
			if (int_12 != 0 && this.int_6 + int_12 > this.int_11)
			{
				return -1;
			}
			this.int_6 += int_12;
			return 0;
		}

		public void method_7()
		{
		}
	}
}
