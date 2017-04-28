using System;
using ns2;
using ns3;

namespace ns10
{
	public class OGGClass1
	{
		private static float float_0 = 3.14159274f;

		private static int int_0 = 1;

		private static int int_1 = 1;

		public int int_2;

		public OGGClass5 oggClass5;

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

		public OGGClass4[] oggClass4;

		public object[] object_1;

		public OGGClass1()
		{
			object_0 = new object[2][];
			float_2 = new float[2][][][][];
			float_2[0] = new float[2][][][];
			float_2[0][0] = new float[2][][];
			float_2[0][1] = new float[2][][];
			float_2[0][0][0] = new float[2][];
			float_2[0][0][1] = new float[2][];
			float_2[0][1][0] = new float[2][];
			float_2[0][1][1] = new float[2][];
			float_2[1] = new float[2][][][];
			float_2[1][0] = new float[2][][];
			float_2[1][1] = new float[2][][];
			float_2[1][0][0] = new float[2][];
			float_2[1][0][1] = new float[2][];
			float_2[1][1][0] = new float[2][];
			float_2[1][1][1] = new float[2][];
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
					float num3 = (float)((i + 0.5) / int_14 * float_0 / 2.0);
					num3 = (float)Math.Sin(num3);
					num3 *= num3;
					num3 *= (float)(float_0 / 2.0);
					num3 = (float)Math.Sin(num3);
					array[i + num] = num3;
				}
				for (int j = num + int_14; j < num2; j++)
				{
					array[j] = 1f;
				}
				for (int k = 0; k < int_15; k++)
				{
					float num4 = (float)((int_15 - k - 0.5) / int_15 * float_0 / 2.0);
					num4 = (float)Math.Sin(num4);
					num4 *= num4;
					num4 *= (float)(float_0 / 2.0);
					num4 = (float)Math.Sin(num4);
					array[k + num2] = num4;
				}
				return array;
			}
			return null;
		}

		private int method_0(OGGClass5 oggClass5, bool bool_0)
		{
			this.oggClass5 = oggClass5;
			int_3 = smethod_0(oggClass5.int_14);
			object_0[0] = new object[int_0];
			object_0[1] = new object[int_0];
			object_0[0][0] = new Class68();
			object_0[1][0] = new Class68();
            ((Class68)object_0[0][0]).method_0(oggClass5.int_13[0]);
			((Class68)object_0[1][0]).method_0(oggClass5.int_13[1]);
			float_2[0][0][0] = new float[int_1][];
			float_2[0][0][1] = float_2[0][0][0];
			float_2[0][1][0] = float_2[0][0][0];
			float_2[0][1][1] = float_2[0][0][0];
			float_2[1][0][0] = new float[int_1][];
			float_2[1][0][1] = new float[int_1][];
			float_2[1][1][0] = new float[int_1][];
			float_2[1][1][1] = new float[int_1][];
            for (int i = 0; i < int_1; i++)
			{
				float_2[0][0][0][i] = smethod_1(i, oggClass5.int_13[0], oggClass5.int_13[0] >> 1, oggClass5.int_13[0] >> 1);
				float_2[1][0][0][i] = smethod_1(i, oggClass5.int_13[1], oggClass5.int_13[0] >> 1, oggClass5.int_13[0] >> 1);
				float_2[1][0][1][i] = smethod_1(i, oggClass5.int_13[1], oggClass5.int_13[0] >> 1, oggClass5.int_13[1] >> 1);
				float_2[1][1][0][i] = smethod_1(i, oggClass5.int_13[1], oggClass5.int_13[1] >> 1, oggClass5.int_13[0] >> 1);
				float_2[1][1][1][i] = smethod_1(i, oggClass5.int_13[1], oggClass5.int_13[1] >> 1, oggClass5.int_13[1] >> 1);
			}
            oggClass4 = new OGGClass4[oggClass5.int_19];
            for (int j = 0; j < oggClass5.int_19; j++)
			{
                oggClass4[j] = new OGGClass4();
                oggClass4[j].method_6(oggClass5.oggClass2[j]);
            }
            int_4 = 8192;
			float_1 = new float[oggClass5.int_8][];
			for (int k = 0; k < oggClass5.int_8; k++)
			{
				float_1[k] = new float[int_4];
			}
            int_8 = 0;
			int_9 = 0;
			int_11 = oggClass5.int_13[1] >> 1;
			int_5 = int_11;
			object_1 = new object[oggClass5.int_14];
            for (int l = 0; l < oggClass5.int_14; l++)
			{
				int num = oggClass5.class27_0[l].int_3;
				int num2 = oggClass5.int_21[num];
				object_1[l] = Class34.class34_0[num2].vmethod_1(this, oggClass5.class27_0[l], oggClass5.object_0[num]);
			}
            return 0;
		}

		public int method_1(OGGClass5 oggClass5)
		{
            method_0(oggClass5, false);
            int_6 = int_11;
            int_11 -= (oggClass5.int_13[int_9] >> 2) + (oggClass5.int_13[int_8] >> 2);
			long_0 = -1L;
			long_1 = -1L;
            return 0;
		}

		public int method_2(OGGClass6 class71_0)
		{
			if (int_11 > oggClass5.int_13[1] >> 1 && int_6 > 8192)
			{
				int num = int_11 - (oggClass5.int_13[1] >> 1);
				num = ((int_6 < num) ? int_6 : num);
				int_5 -= num;
				int_11 -= num;
				int_6 -= num;
				if (num != 0)
				{
					for (int i = 0; i < oggClass5.int_8; i++)
					{
						Buffer.BlockCopy(float_1[i], num << 2, float_1[i], 0, int_5 << 2);
					}
				}
			}
			int_8 = int_9;
			int_9 = class71_0.int_1;
			int_10 = -1;
			long_2 += class71_0.int_6;
			long_3 += class71_0.int_7;
			long_4 += class71_0.int_8;
			long_5 += class71_0.int_9;
			if (long_1 + 1L != class71_0.long_1)
			{
				long_0 = -1L;
			}
			long_1 = class71_0.long_1;
			int num2 = oggClass5.int_13[int_9];
			int num3 = int_11 + (oggClass5.int_13[int_8] >> 2) + (num2 >> 2);
			int num4 = num3 - (num2 >> 1);
			int num5 = num4 + num2;
			int num6 = 0;
			int num7 = 0;
			if (num5 > int_4)
			{
				int_4 = num5 + oggClass5.int_13[1];
				for (int j = 0; j < oggClass5.int_8; j++)
				{
					float[] array = new float[int_4];
					Buffer.BlockCopy(float_1[j], 0, array, 0, float_1[j].Length << 2);
					float_1[j] = array;
				}
			}
			switch (int_9)
			{
			case 0:
				num6 = 0;
				num7 = oggClass5.int_13[0] >> 1;
				break;
			case 1:
				num6 = (oggClass5.int_13[1] >> 2) - (oggClass5.int_13[int_8] >> 2);
				num7 = num6 + (oggClass5.int_13[int_8] >> 1);
				break;
			}
			for (int k = 0; k < oggClass5.int_8; k++)
			{
				int num8 = num4;
				int l;
				for (l = num6; l < num7; l++)
				{
					float_1[k][num8 + l] += class71_0.float_0[k][l];
				}
				while (l < num2)
				{
					float_1[k][num8 + l] = class71_0.float_0[k][l];
					l++;
				}
			}
			if (long_0 == -1L)
			{
				long_0 = class71_0.long_0;
			}
			else
			{
				long_0 += num3 - int_11;
				if (class71_0.long_0 != -1L && long_0 != class71_0.long_0)
				{
					if (long_0 > class71_0.long_0 && class71_0.int_5 != 0)
					{
						num3 -= (int)(long_0 - class71_0.long_0);
					}
					long_0 = class71_0.long_0;
				}
			}
			int_11 = num3;
			int_5 = num5;
			if (class71_0.int_5 != 0)
			{
				int_7 = 1;
			}
			return 0;
		}

		public int method_3()
		{
			if (int_6 < int_11)
			{
				return int_11 - int_6;
			}
			return 0;
		}

		public int method_4(float[] float_3, int int_12, int int_13)
		{
			if (int_6 < int_11)
			{
				int num = float_1.Length;
				int num2 = int_11 - int_6;
				int num3 = (int_13 - int_12) / num;
				if (num2 > num3)
				{
					num2 = num3;
				}
				int num4 = int_6 + num2;
				for (int i = 0; i < float_1.Length; i++)
				{
					float[] array = float_1[i];
					int j = int_6;
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
			if (int_6 < int_11)
			{
				int num = int_11 - int_6;
				if (num > int_13 - int_12)
				{
					num = int_13 - int_12;
				}
				for (int i = 0; i < oggClass5.int_8; i++)
				{
					Buffer.BlockCopy(float_1[i], int_6 << 2, float_3[i], int_12 << 2, num << 2);
				}
				return num;
			}
			return 0;
		}

		public int method_6(int int_12)
		{
			if (int_12 != 0 && int_6 + int_12 > int_11)
			{
				return -1;
			}
			int_6 += int_12;
			return 0;
		}

		public void method_7()
		{
		}
	}
}
