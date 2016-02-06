using System;
using System.IO;

namespace ns5
{
	public class Class110
	{
		public static readonly double double_0 = 16384.0 * Math.Sqrt(2.0);

		private static readonly int[] int_0 = new int[]
		{
			0,
			64,
			32,
			96,
			16,
			80,
			48,
			112,
			8,
			72,
			40,
			104,
			24,
			88,
			56,
			120,
			4,
			68,
			36,
			100,
			20,
			84,
			52,
			116,
			12,
			76,
			44,
			108,
			28,
			92,
			60,
			124,
			2,
			66,
			34,
			98,
			18,
			82,
			50,
			114,
			10,
			74,
			42,
			106,
			26,
			90,
			58,
			122,
			6,
			70,
			38,
			102,
			22,
			86,
			54,
			118,
			14,
			78,
			46,
			110,
			30,
			94,
			62,
			126,
			1,
			65,
			33,
			97,
			17,
			81,
			49,
			113,
			9,
			73,
			41,
			105,
			25,
			89,
			57,
			121,
			5,
			69,
			37,
			101,
			21,
			85,
			53,
			117,
			13,
			77,
			45,
			109,
			29,
			93,
			61,
			125,
			3,
			67,
			35,
			99,
			19,
			83,
			51,
			115,
			11,
			75,
			43,
			107,
			27,
			91,
			59,
			123,
			7,
			71,
			39,
			103,
			23,
			87,
			55,
			119,
			15,
			79,
			47,
			111,
			31,
			95,
			63,
			127
		};

		private static readonly int[] int_1 = new int[]
		{
			0,
			32,
			16,
			48,
			8,
			40,
			24,
			56,
			4,
			36,
			20,
			52,
			12,
			44,
			28,
			60,
			2,
			34,
			18,
			50,
			10,
			42,
			26,
			58,
			6,
			38,
			22,
			54,
			14,
			46,
			30,
			62,
			1,
			33,
			17,
			49,
			9,
			41,
			25,
			57,
			5,
			37,
			21,
			53,
			13,
			45,
			29,
			61,
			3,
			35,
			19,
			51,
			11,
			43,
			27,
			59,
			7,
			39,
			23,
			55,
			15,
			47,
			31,
			63
		};

		private static readonly double[] double_1 = new double[]
		{
			0.00014,
			0.00024,
			0.00037,
			0.00051,
			0.00067,
			0.00086,
			0.00107,
			0.0013,
			0.00157,
			0.00187,
			0.0022,
			0.00256,
			0.00297,
			0.00341,
			0.0039,
			0.00443,
			0.00501,
			0.00564,
			0.00632,
			0.00706,
			0.00785,
			0.00871,
			0.00962,
			0.01061,
			0.01166,
			0.01279,
			0.01399,
			0.01526,
			0.01662,
			0.01806,
			0.01959,
			0.02121,
			0.02292,
			0.02472,
			0.02662,
			0.02863,
			0.03073,
			0.03294,
			0.03527,
			0.0377,
			0.04025,
			0.04292,
			0.04571,
			0.04862,
			0.05165,
			0.05481,
			0.0581,
			0.06153,
			0.06508,
			0.06878,
			0.07261,
			0.07658,
			0.08069,
			0.08495,
			0.08935,
			0.09389,
			0.09859,
			0.10343,
			0.10842,
			0.11356,
			0.11885,
			0.12429,
			0.12988,
			0.13563,
			0.14152,
			0.14757,
			0.15376,
			0.16011,
			0.16661,
			0.17325,
			0.18005,
			0.18699,
			0.19407,
			0.2013,
			0.20867,
			0.21618,
			0.22382,
			0.23161,
			0.23952,
			0.24757,
			0.25574,
			0.26404,
			0.27246,
			0.281,
			0.28965,
			0.29841,
			0.30729,
			0.31626,
			0.32533,
			0.3345,
			0.34376,
			0.35311,
			0.36253,
			0.37204,
			0.38161,
			0.39126,
			0.40096,
			0.41072,
			0.42054,
			0.4304,
			0.4403,
			0.45023,
			0.4602,
			0.47019,
			0.4802,
			0.49022,
			0.50025,
			0.51028,
			0.52031,
			0.53033,
			0.54033,
			0.55031,
			0.56026,
			0.57019,
			0.58007,
			0.58991,
			0.5997,
			0.60944,
			0.61912,
			0.62873,
			0.63827,
			0.64774,
			0.65713,
			0.66643,
			0.67564,
			0.68476,
			0.69377,
			0.70269,
			0.7115,
			0.72019,
			0.72877,
			0.73723,
			0.74557,
			0.75378,
			0.76186,
			0.76981,
			0.77762,
			0.7853,
			0.79283,
			0.80022,
			0.80747,
			0.81457,
			0.82151,
			0.82831,
			0.83496,
			0.84145,
			0.84779,
			0.85398,
			0.86001,
			0.86588,
			0.8716,
			0.87716,
			0.88257,
			0.88782,
			0.89291,
			0.89785,
			0.90264,
			0.90728,
			0.91176,
			0.9161,
			0.92028,
			0.92432,
			0.92822,
			0.93197,
			0.93558,
			0.93906,
			0.9424,
			0.9456,
			0.94867,
			0.95162,
			0.95444,
			0.95713,
			0.95971,
			0.96217,
			0.96451,
			0.96674,
			0.96887,
			0.97089,
			0.97281,
			0.97463,
			0.97635,
			0.97799,
			0.97953,
			0.98099,
			0.98236,
			0.98366,
			0.98488,
			0.98602,
			0.9871,
			0.98811,
			0.98905,
			0.98994,
			0.99076,
			0.99153,
			0.99225,
			0.99291,
			0.99353,
			0.99411,
			0.99464,
			0.99513,
			0.99558,
			0.996,
			0.99639,
			0.99674,
			0.99706,
			0.99736,
			0.99763,
			0.99788,
			0.99811,
			0.99831,
			0.9985,
			0.99867,
			0.99882,
			0.99895,
			0.99908,
			0.99919,
			0.99929,
			0.99938,
			0.99946,
			0.99953,
			0.99959,
			0.99965,
			0.99969,
			0.99974,
			0.99978,
			0.99981,
			0.99984,
			0.99986,
			0.99988,
			0.9999,
			0.99992,
			0.99993,
			0.99994,
			0.99995,
			0.99996,
			0.99997,
			0.99998,
			0.99998,
			0.99998,
			0.99999,
			0.99999,
			0.99999,
			0.99999,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0,
			1.0
		};

		private readonly double[] double_2 = new double[128];

		private readonly double[] double_3 = new double[128];

		private readonly double[] double_4 = new double[64];

		private readonly double[] double_5 = new double[64];

		private readonly double[] double_6 = new double[64];

		private readonly double[] double_7 = new double[64];

		private readonly double[] double_8 = new double[128];

		private readonly double[] double_9 = new double[128];

		private readonly double[] double_10 = new double[64];

		private readonly double[] double_11 = new double[64];

		private readonly double[][] double_12 = new double[8][];

		private readonly double[][] double_13 = new double[8][];

		private void method_0()
		{
			for (int i = 0; i < 8; i++)
			{
				this.double_12[i] = new double[256];
			}
			for (int j = 0; j < 8; j++)
			{
				this.double_13[j] = new double[256];
			}
		}

		private void method_1(double[] double_14, double[] double_15, int int_2, int int_3)
		{
			double num = double_14[int_2];
			double num2 = double_15[int_2];
			double_14[int_2] = double_14[int_3];
			double_15[int_2] = double_15[int_3];
			double_14[int_3] = num;
			double_15[int_3] = num2;
		}

		public virtual void vmethod_0(double[] double_14, int int_2, int int_3, double double_15)
		{
			for (int i = 0; i < 128; i++)
			{
				this.double_2[i] = double_14[int_2 + 256 - 2 * i - 1] * this.double_8[i] - double_14[int_2 + 2 * i] * this.double_9[i];
				this.double_3[i] = -1.0 * (double_14[int_2 + 2 * i] * this.double_8[i] + double_14[int_2 + 256 - 2 * i - 1] * this.double_9[i]);
			}
			for (int j = 0; j < 128; j++)
			{
				int num = Class110.int_0[j];
				if (num < j)
				{
					this.method_1(this.double_2, this.double_3, j, num);
				}
			}
			for (int k = 0; k < 7; k++)
			{
				int num2;
				if (k != 0)
				{
					num2 = 1 << k;
				}
				else
				{
					num2 = 1;
				}
				int num3 = 1 << k + 1;
				for (int l = 0; l < num2; l++)
				{
					for (int m = 0; m < 128; m += num3)
					{
						int num4 = l + m;
						int num5 = num4 + num2;
						double num6 = this.double_2[num4];
						double num7 = this.double_3[num4];
						double num8 = this.double_2[num5] * this.double_12[k][l] - this.double_3[num5] * this.double_13[k][l];
						double num9 = this.double_3[num5] * this.double_12[k][l] + this.double_2[num5] * this.double_13[k][l];
						this.double_2[num4] = num6 + num8;
						this.double_3[num4] = num7 + num9;
						this.double_2[num5] = num6 - num8;
						this.double_3[num5] = num7 - num9;
					}
				}
			}
			for (int n = 0; n < 128; n++)
			{
				double num6 = this.double_2[n];
				double num7 = -1.0 * this.double_3[n];
				this.double_2[n] = num6 * this.double_8[n] - num7 * this.double_9[n];
				this.double_3[n] = num6 * this.double_9[n] + num7 * this.double_8[n];
			}
			int num10 = int_2;
			int num11 = int_3;
			int num12 = 0;
			for (int num13 = 0; num13 < 64; num13++)
			{
				double_14[num10++] = -this.double_3[64 + num13] * Class110.double_1[num12++] + double_14[num11++] + double_15;
				double_14[num10++] = this.double_2[64 - num13 - 1] * Class110.double_1[num12++] + double_14[num11++] + double_15;
			}
			for (int num14 = 0; num14 < 64; num14++)
			{
				double_14[num10++] = -this.double_2[num14] * Class110.double_1[num12++] + double_14[num11++] + double_15;
				double_14[num10++] = this.double_3[128 - num14 - 1] * Class110.double_1[num12++] + double_14[num11++] + double_15;
			}
			num11 = int_3;
			for (int num15 = 0; num15 < 64; num15++)
			{
				double_14[num11++] = -this.double_2[64 + num15] * Class110.double_1[--num12];
				double_14[num11++] = this.double_3[64 - num15 - 1] * Class110.double_1[--num12];
			}
			for (int num16 = 0; num16 < 64; num16++)
			{
				double_14[num11++] = this.double_3[num16] * Class110.double_1[--num12];
				double_14[num11++] = -this.double_2[128 - num16 - 1] * Class110.double_1[--num12];
			}
		}

		public virtual void vmethod_1(double[] double_14, int int_2, int int_3, double double_15)
		{
			for (int i = 0; i < 64; i++)
			{
				int num = 2 * (128 - 2 * i - 1);
				int num2 = 2 * (2 * i);
				this.double_4[i] = double_14[num] * this.double_10[i] - double_14[num2] * this.double_11[i];
				this.double_5[i] = -1.0 * (double_14[num2] * this.double_10[i] + double_14[num] * this.double_11[i]);
				this.double_6[i] = double_14[num + 1] * this.double_10[i] - double_14[num2 + 1] * this.double_11[i];
				this.double_7[i] = -1.0 * (double_14[num2 + 1] * this.double_10[i] + double_14[num + 1] * this.double_11[i]);
			}
			for (int j = 0; j < 64; j++)
			{
				int num3 = Class110.int_1[j];
				if (num3 < j)
				{
					this.method_1(this.double_4, this.double_5, j, num3);
					this.method_1(this.double_6, this.double_7, j, num3);
				}
			}
			for (int k = 0; k < 6; k++)
			{
				int num4 = 1 << k;
				int num5 = 1 << k + 1;
				if (k != 0)
				{
					num4 = 1 << k;
				}
				else
				{
					num4 = 1;
				}
				for (int l = 0; l < num4; l++)
				{
					for (int m = 0; m < 64; m += num5)
					{
						int num6 = l + m;
						int num7 = num6 + num4;
						double num8 = this.double_4[num6];
						double num9 = this.double_5[num6];
						double num10 = this.double_4[num7] * this.double_12[k][l] - this.double_5[num7] * this.double_13[k][l];
						double num11 = this.double_5[num7] * this.double_12[k][l] + this.double_4[num7] * this.double_13[k][l];
						this.double_4[num6] = num8 + num10;
						this.double_5[num6] = num9 + num11;
						this.double_4[num7] = num8 - num10;
						this.double_5[num7] = num9 - num11;
						num8 = this.double_6[num6];
						num9 = this.double_7[num6];
						num10 = this.double_6[num7] * this.double_12[k][l] - this.double_7[num7] * this.double_13[k][l];
						num11 = this.double_7[num7] * this.double_12[k][l] + this.double_6[num7] * this.double_13[k][l];
						this.double_6[num6] = num8 + num10;
						this.double_7[num6] = num9 + num11;
						this.double_6[num7] = num8 - num10;
						this.double_7[num7] = num9 - num11;
					}
				}
			}
			for (int n = 0; n < 64; n++)
			{
				double num8 = this.double_4[n];
				double num9 = -this.double_5[n];
				this.double_4[n] = num8 * this.double_10[n] - num9 * this.double_11[n];
				this.double_5[n] = num8 * this.double_11[n] + num9 * this.double_10[n];
				num8 = this.double_6[n];
				num9 = -this.double_7[n];
				this.double_6[n] = num8 * this.double_10[n] - num9 * this.double_11[n];
				this.double_7[n] = num8 * this.double_11[n] + num9 * this.double_10[n];
			}
			int num12 = int_2;
			int num13 = int_3;
			int num14 = 0;
			for (int num15 = 0; num15 < 64; num15++)
			{
				double_14[num12++] = -this.double_5[num15] * Class110.double_1[num14++] + double_14[num13++] + double_15;
				double_14[num12++] = this.double_4[64 - num15 - 1] * Class110.double_1[num14++] + double_14[num13++] + double_15;
			}
			for (int num16 = 0; num16 < 64; num16++)
			{
				double_14[num12++] = -this.double_4[num16] * Class110.double_1[num14++] + double_14[num13++] + double_15;
				double_14[num12++] = this.double_5[64 - num16 - 1] * Class110.double_1[num14++] + double_14[num13++] + double_15;
			}
			num13 = int_3;
			for (int num17 = 0; num17 < 64; num17++)
			{
				double_14[num13++] = -this.double_6[num17] * Class110.double_1[--num14];
				double_14[num13++] = this.double_7[64 - num17 - 1] * Class110.double_1[--num14];
			}
			for (int num18 = 0; num18 < 64; num18++)
			{
				double_14[num13++] = this.double_7[num18] * Class110.double_1[--num14];
				double_14[num13++] = -this.double_6[64 - num18 - 1] * Class110.double_1[--num14];
			}
		}

		public Class110()
		{
			this.method_0();
			for (int i = 0; i < 128; i++)
			{
				this.double_8[i] = -Math.Cos(0.0015339807878856412 * (double)(8 * i + 1));
				this.double_9[i] = -Math.Sin(0.0015339807878856412 * (double)(8 * i + 1));
			}
			for (int i = 0; i < 64; i++)
			{
				this.double_10[i] = -Math.Cos(0.0030679615757712823 * (double)(8 * i + 1));
				this.double_11[i] = -Math.Sin(0.0030679615757712823 * (double)(8 * i + 1));
			}
			for (int i = 0; i < 7; i++)
			{
				int num = 1 << i;
				for (int j = 0; j < num; j++)
				{
					this.double_12[i][j] = Math.Cos(-3.1415926535897931 * (double)j / (double)num);
					this.double_13[i][j] = Math.Sin(-3.1415926535897931 * (double)j / (double)num);
				}
			}
		}

		public virtual void vmethod_2(double[] double_14, int int_2, Stream stream_0)
		{
			if (int_2 > 2)
			{
				int_2 = 2;
			}
			int num = 0;
			byte[] array = new byte[int_2 * 256 * 2];
			for (int i = 0; i < 256; i++)
			{
				for (int j = 0; j < int_2; j++)
				{
					int num2 = (int)(Class110.double_0 * double_14[i + 256 * j + 256]);
					if (num2 > 32767)
					{
						num2 = 32767;
					}
					if (num2 < -32768)
					{
						num2 = -32768;
					}
					array[num++] = (byte)(num2 & 255);
					array[num++] = (byte)(num2 >> 8 & 255);
				}
			}
			stream_0.Write(array, 0, array.Length);
		}
	}
}
