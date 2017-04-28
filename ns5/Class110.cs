using System;
using System.IO;

namespace ns5
{
	public class Class110
	{
		public static readonly double Double0 = 16384.0 * Math.Sqrt(2.0);

		private static readonly int[] Int0 = {
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

		private static readonly int[] Int1 = {
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

		private static readonly double[] Double1 = {
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

		private readonly double[] _double2 = new double[128];

		private readonly double[] _double3 = new double[128];

		private readonly double[] _double4 = new double[64];

		private readonly double[] _double5 = new double[64];

		private readonly double[] _double6 = new double[64];

		private readonly double[] _double7 = new double[64];

		private readonly double[] _double8 = new double[128];

		private readonly double[] _double9 = new double[128];

		private readonly double[] _double10 = new double[64];

		private readonly double[] _double11 = new double[64];

		private readonly double[][] _double12 = new double[8][];

		private readonly double[][] _double13 = new double[8][];

		private void method_0()
		{
			for (var i = 0; i < 8; i++)
			{
				_double12[i] = new double[256];
			}
			for (var j = 0; j < 8; j++)
			{
				_double13[j] = new double[256];
			}
		}

		private void method_1(double[] double14, double[] double15, int int2, int int3)
		{
			var num = double14[int2];
			var num2 = double15[int2];
			double14[int2] = double14[int3];
			double15[int2] = double15[int3];
			double14[int3] = num;
			double15[int3] = num2;
		}

		public virtual void vmethod_0(double[] double14, int int2, int int3, double double15)
		{
			for (var i = 0; i < 128; i++)
			{
				_double2[i] = double14[int2 + 256 - 2 * i - 1] * _double8[i] - double14[int2 + 2 * i] * _double9[i];
				_double3[i] = -1.0 * (double14[int2 + 2 * i] * _double8[i] + double14[int2 + 256 - 2 * i - 1] * _double9[i]);
			}
			for (var j = 0; j < 128; j++)
			{
				var num = Int0[j];
				if (num < j)
				{
					method_1(_double2, _double3, j, num);
				}
			}
			for (var k = 0; k < 7; k++)
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
				var num3 = 1 << k + 1;
				for (var l = 0; l < num2; l++)
				{
					for (var m = 0; m < 128; m += num3)
					{
						var num4 = l + m;
						var num5 = num4 + num2;
						var num6 = _double2[num4];
						var num7 = _double3[num4];
						var num8 = _double2[num5] * _double12[k][l] - _double3[num5] * _double13[k][l];
						var num9 = _double3[num5] * _double12[k][l] + _double2[num5] * _double13[k][l];
						_double2[num4] = num6 + num8;
						_double3[num4] = num7 + num9;
						_double2[num5] = num6 - num8;
						_double3[num5] = num7 - num9;
					}
				}
			}
			for (var n = 0; n < 128; n++)
			{
				var num6 = _double2[n];
				var num7 = -1.0 * _double3[n];
				_double2[n] = num6 * _double8[n] - num7 * _double9[n];
				_double3[n] = num6 * _double9[n] + num7 * _double8[n];
			}
			var num10 = int2;
			var num11 = int3;
			var num12 = 0;
			for (var num13 = 0; num13 < 64; num13++)
			{
				double14[num10++] = -_double3[64 + num13] * Double1[num12++] + double14[num11++] + double15;
				double14[num10++] = _double2[64 - num13 - 1] * Double1[num12++] + double14[num11++] + double15;
			}
			for (var num14 = 0; num14 < 64; num14++)
			{
				double14[num10++] = -_double2[num14] * Double1[num12++] + double14[num11++] + double15;
				double14[num10++] = _double3[128 - num14 - 1] * Double1[num12++] + double14[num11++] + double15;
			}
			num11 = int3;
			for (var num15 = 0; num15 < 64; num15++)
			{
				double14[num11++] = -_double2[64 + num15] * Double1[--num12];
				double14[num11++] = _double3[64 - num15 - 1] * Double1[--num12];
			}
			for (var num16 = 0; num16 < 64; num16++)
			{
				double14[num11++] = _double3[num16] * Double1[--num12];
				double14[num11++] = -_double2[128 - num16 - 1] * Double1[--num12];
			}
		}

		public virtual void vmethod_1(double[] double14, int int2, int int3, double double15)
		{
			for (var i = 0; i < 64; i++)
			{
				var num = 2 * (128 - 2 * i - 1);
				var num2 = 2 * (2 * i);
				_double4[i] = double14[num] * _double10[i] - double14[num2] * _double11[i];
				_double5[i] = -1.0 * (double14[num2] * _double10[i] + double14[num] * _double11[i]);
				_double6[i] = double14[num + 1] * _double10[i] - double14[num2 + 1] * _double11[i];
				_double7[i] = -1.0 * (double14[num2 + 1] * _double10[i] + double14[num + 1] * _double11[i]);
			}
			for (var j = 0; j < 64; j++)
			{
				var num3 = Int1[j];
				if (num3 < j)
				{
					method_1(_double4, _double5, j, num3);
					method_1(_double6, _double7, j, num3);
				}
			}
			for (var k = 0; k < 6; k++)
			{
				var num4 = 1 << k;
				var num5 = 1 << k + 1;
				if (k != 0)
				{
					num4 = 1 << k;
				}
				else
				{
					num4 = 1;
				}
				for (var l = 0; l < num4; l++)
				{
					for (var m = 0; m < 64; m += num5)
					{
						var num6 = l + m;
						var num7 = num6 + num4;
						var num8 = _double4[num6];
						var num9 = _double5[num6];
						var num10 = _double4[num7] * _double12[k][l] - _double5[num7] * _double13[k][l];
						var num11 = _double5[num7] * _double12[k][l] + _double4[num7] * _double13[k][l];
						_double4[num6] = num8 + num10;
						_double5[num6] = num9 + num11;
						_double4[num7] = num8 - num10;
						_double5[num7] = num9 - num11;
						num8 = _double6[num6];
						num9 = _double7[num6];
						num10 = _double6[num7] * _double12[k][l] - _double7[num7] * _double13[k][l];
						num11 = _double7[num7] * _double12[k][l] + _double6[num7] * _double13[k][l];
						_double6[num6] = num8 + num10;
						_double7[num6] = num9 + num11;
						_double6[num7] = num8 - num10;
						_double7[num7] = num9 - num11;
					}
				}
			}
			for (var n = 0; n < 64; n++)
			{
				var num8 = _double4[n];
				var num9 = -_double5[n];
				_double4[n] = num8 * _double10[n] - num9 * _double11[n];
				_double5[n] = num8 * _double11[n] + num9 * _double10[n];
				num8 = _double6[n];
				num9 = -_double7[n];
				_double6[n] = num8 * _double10[n] - num9 * _double11[n];
				_double7[n] = num8 * _double11[n] + num9 * _double10[n];
			}
			var num12 = int2;
			var num13 = int3;
			var num14 = 0;
			for (var num15 = 0; num15 < 64; num15++)
			{
				double14[num12++] = -_double5[num15] * Double1[num14++] + double14[num13++] + double15;
				double14[num12++] = _double4[64 - num15 - 1] * Double1[num14++] + double14[num13++] + double15;
			}
			for (var num16 = 0; num16 < 64; num16++)
			{
				double14[num12++] = -_double4[num16] * Double1[num14++] + double14[num13++] + double15;
				double14[num12++] = _double5[64 - num16 - 1] * Double1[num14++] + double14[num13++] + double15;
			}
			num13 = int3;
			for (var num17 = 0; num17 < 64; num17++)
			{
				double14[num13++] = -_double6[num17] * Double1[--num14];
				double14[num13++] = _double7[64 - num17 - 1] * Double1[--num14];
			}
			for (var num18 = 0; num18 < 64; num18++)
			{
				double14[num13++] = _double7[num18] * Double1[--num14];
				double14[num13++] = -_double6[64 - num18 - 1] * Double1[--num14];
			}
		}

		public Class110()
		{
			method_0();
			for (var i = 0; i < 128; i++)
			{
				_double8[i] = -Math.Cos(0.0015339807878856412 * (8 * i + 1));
				_double9[i] = -Math.Sin(0.0015339807878856412 * (8 * i + 1));
			}
			for (var i = 0; i < 64; i++)
			{
				_double10[i] = -Math.Cos(0.0030679615757712823 * (8 * i + 1));
				_double11[i] = -Math.Sin(0.0030679615757712823 * (8 * i + 1));
			}
			for (var i = 0; i < 7; i++)
			{
				var num = 1 << i;
				for (var j = 0; j < num; j++)
				{
					_double12[i][j] = Math.Cos(-3.1415926535897931 * j / num);
					_double13[i][j] = Math.Sin(-3.1415926535897931 * j / num);
				}
			}
		}

		public virtual void vmethod_2(double[] double14, int int2, Stream stream0)
		{
			if (int2 > 2)
			{
				int2 = 2;
			}
			var num = 0;
			var array = new byte[int2 * 256 * 2];
			for (var i = 0; i < 256; i++)
			{
				for (var j = 0; j < int2; j++)
				{
					var num2 = (int)(Double0 * double14[i + 256 * j + 256]);
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
			stream0.Write(array, 0, array.Length);
		}
	}
}
