using System;
using ns10;
using ns3;

namespace ns2
{
	public class Class29 : Class28
	{
		private static int int_0 = 140;

		private static int int_1 = 63;

		private static readonly float[] float_0 = {
			1.06498632E-07f,
			1.1341951E-07f,
			1.20790148E-07f,
			1.28639783E-07f,
			1.369995E-07f,
			1.459025E-07f,
			1.55384086E-07f,
			1.65481808E-07f,
			1.76235744E-07f,
			1.87688556E-07f,
			1.998856E-07f,
			2.128753E-07f,
			2.26709133E-07f,
			2.41441967E-07f,
			2.57132228E-07f,
			2.73842119E-07f,
			2.91637917E-07f,
			3.10590224E-07f,
			3.307741E-07f,
			3.52269666E-07f,
			3.75162131E-07f,
			3.995423E-07f,
			4.255068E-07f,
			4.53158634E-07f,
			4.82607447E-07f,
			5.1397E-07f,
			5.47370632E-07f,
			5.829419E-07f,
			6.208247E-07f,
			6.611694E-07f,
			7.041359E-07f,
			7.49894639E-07f,
			7.98627E-07f,
			8.505263E-07f,
			9.057983E-07f,
			9.646621E-07f,
			1.02735135E-06f,
			1.0941144E-06f,
			1.16521608E-06f,
			1.24093845E-06f,
			1.32158164E-06f,
			1.40746545E-06f,
			1.49893049E-06f,
			1.59633942E-06f,
			1.70007854E-06f,
			1.81055918E-06f,
			1.92821949E-06f,
			2.053526E-06f,
			2.18697573E-06f,
			2.3290977E-06f,
			2.48045581E-06f,
			2.64164964E-06f,
			2.813319E-06f,
			2.9961443E-06f,
			3.19085052E-06f,
			3.39821E-06f,
			3.619045E-06f,
			3.85423073E-06f,
			4.10470057E-06f,
			4.371447E-06f,
			4.6555283E-06f,
			4.958071E-06f,
			5.280274E-06f,
			5.623416E-06f,
			5.988857E-06f,
			6.37804669E-06f,
			6.79252844E-06f,
			7.23394533E-06f,
			7.704048E-06f,
			8.2047E-06f,
			8.737888E-06f,
			9.305725E-06f,
			9.910464E-06f,
			1.05545014E-05f,
			1.12403923E-05f,
			1.19708557E-05f,
			1.27487892E-05f,
			1.3577278E-05f,
			1.44596061E-05f,
			1.53992714E-05f,
			1.64000048E-05f,
			1.74657689E-05f,
			1.86007928E-05f,
			1.98095768E-05f,
			2.10969138E-05f,
			2.24679115E-05f,
			2.39280016E-05f,
			2.54829774E-05f,
			2.71390054E-05f,
			2.890265E-05f,
			3.078091E-05f,
			3.27812268E-05f,
			3.49115326E-05f,
			3.718028E-05f,
			3.95964671E-05f,
			4.21696677E-05f,
			4.491009E-05f,
			4.7828602E-05f,
			5.09367746E-05f,
			5.424693E-05f,
			5.77722021E-05f,
			6.152657E-05f,
			6.552491E-05f,
			6.97830837E-05f,
			7.43179844E-05f,
			7.914758E-05f,
			8.429104E-05f,
			8.976875E-05f,
			9.560242E-05f,
			0.000101815211f,
			0.000108431741f,
			0.000115478237f,
			0.000122982674f,
			0.000130974775f,
			0.000139486248f,
			0.000148550855f,
			0.000158204537f,
			0.000168485552f,
			0.00017943469f,
			0.000191095358f,
			0.000203513817f,
			0.0002167393f,
			0.000230824226f,
			0.000245824485f,
			0.000261799549f,
			0.000278812746f,
			0.000296931568f,
			0.000316227874f,
			0.000336778146f,
			0.000358663878f,
			0.000381971884f,
			0.00040679457f,
			0.000433230365f,
			0.0004613841f,
			0.0004913675f,
			0.00052329927f,
			0.0005573062f,
			0.0005935231f,
			0.0006320936f,
			0.0006731706f,
			0.000716917f,
			0.0007635063f,
			0.000813123246f,
			0.000865964568f,
			0.000922239851f,
			0.0009821722f,
			0.00104599923f,
			0.00111397426f,
			0.00118636654f,
			0.00126346329f,
			0.0013455702f,
			0.00143301289f,
			0.00152613816f,
			0.00162531529f,
			0.00173093739f,
			0.00184342347f,
			0.00196321961f,
			0.00209080055f,
			0.0022266726f,
			0.00237137428f,
			0.00252547953f,
			0.00268959929f,
			0.00286438479f,
			0.0030505287f,
			0.003248769f,
			0.00345989247f,
			0.00368473586f,
			0.00392419053f,
			0.00417920668f,
			0.004450795f,
			0.004740033f,
			0.005048067f,
			0.0053761187f,
			0.005725489f,
			0.00609756354f,
			0.00649381755f,
			0.00691582263f,
			0.00736525143f,
			0.007843887f,
			0.008353627f,
			0.008896492f,
			0.009474637f,
			0.010090352f,
			0.01074608f,
			0.0114444206f,
			0.012188144f,
			0.0129801976f,
			0.0138237253f,
			0.0147220679f,
			0.0156787913f,
			0.0166976862f,
			0.0177827962f,
			0.0189384222f,
			0.0201691482f,
			0.0214798544f,
			0.0228757355f,
			0.02436233f,
			0.0259455312f,
			0.0276316181f,
			0.0294272769f,
			0.0313396268f,
			0.03337625f,
			0.0355452262f,
			0.0378551558f,
			0.0403152f,
			0.0429351069f,
			0.0457252748f,
			0.0486967564f,
			0.05186135f,
			0.05523159f,
			0.05882085f,
			0.0626433641f,
			0.06671428f,
			0.07104975f,
			0.0756669641f,
			0.08058423f,
			0.08582105f,
			0.09139818f,
			0.0973377451f,
			0.1036633f,
			0.110399932f,
			0.117574342f,
			0.125214979f,
			0.133352146f,
			0.142018124f,
			0.151247263f,
			0.161076173f,
			0.1715438f,
			0.182691678f,
			0.194564015f,
			0.207207873f,
			0.220673427f,
			0.235014021f,
			0.250286549f,
			0.266551584f,
			0.283873618f,
			0.3023213f,
			0.32196787f,
			0.342891127f,
			0.365174145f,
			0.3889052f,
			0.414178461f,
			0.44109413f,
			0.4697589f,
			0.50028646f,
			0.532797933f,
			0.5674221f,
			0.6042964f,
			0.643566966f,
			0.6853896f,
			0.729930043f,
			0.777365f,
			0.8278826f,
			0.881683052f,
			0.9389798f,
			1f
		};

		public override object vmethod_0(OGGClass5 class49_0, OGGClass3 class38_0)
		{
			var num = 0;
			var num2 = -1;
			var @class = new Class31();
			@class.int_0 = class38_0.method_6(5);
			for (var i = 0; i < @class.int_0; i++)
			{
				@class.int_1[i] = class38_0.method_6(4);
				if (num2 < @class.int_1[i])
				{
					num2 = @class.int_1[i];
				}
			}
			for (var j = 0; j < num2 + 1; j++)
			{
				@class.int_2[j] = class38_0.method_6(3) + 1;
				@class.int_3[j] = class38_0.method_6(2);
				if (@class.int_3[j] < 0)
				{
					@class.method_0();
					return null;
				}
				if (@class.int_3[j] != 0)
				{
					@class.int_4[j] = class38_0.method_6(8);
				}
				if (@class.int_4[j] < 0 || @class.int_4[j] >= class49_0.int_19)
				{
					@class.method_0();
					return null;
				}
				for (var k = 0; k < 1 << @class.int_3[j]; k++)
				{
					@class.int_5[j][k] = class38_0.method_6(8) - 1;
					if (@class.int_5[j][k] < -1 || @class.int_5[j][k] >= class49_0.int_19)
					{
						@class.method_0();
						return null;
					}
				}
			}
			@class.int_6 = class38_0.method_6(2) + 1;
			var num3 = class38_0.method_6(4);
			var l = 0;
			var m = 0;
			while (l < @class.int_0)
			{
				num += @class.int_2[@class.int_1[l]];
				while (m < num)
				{
					var num4 = @class.int_7[m + 2] = class38_0.method_6(num3);
					if (num4 < 0 || num4 >= 1 << num3)
					{
						@class.method_0();
						return null;
					}
					m++;
				}
				l++;
			}
			@class.int_7[0] = 0;
			@class.int_7[1] = 1 << num3;
			return @class;
		}

		public override object vmethod_1(OGGClass1 class66_0, Class27 class27_0, object object_0)
		{
			var num = 0;
			var array = new int[int_1 + 2];
			var @class = (Class31)object_0;
			var class2 = new Class32();
			class2.class31_0 = @class;
			class2.int_7 = @class.int_7[1];
			for (var i = 0; i < @class.int_0; i++)
			{
				num += @class.int_2[@class.int_1[i]];
			}
			num += 2;
			class2.int_6 = num;
			for (var j = 0; j < num; j++)
			{
				array[j] = j;
			}
			for (var k = 0; k < num - 1; k++)
			{
				for (var l = k; l < num; l++)
				{
					if (@class.int_7[array[k]] > @class.int_7[array[l]])
					{
						var num2 = array[l];
						array[l] = array[k];
						array[k] = num2;
					}
				}
			}
			for (var m = 0; m < num; m++)
			{
				class2.int_2[m] = array[m];
			}
			for (var n = 0; n < num; n++)
			{
				class2.int_3[class2.int_2[n]] = n;
			}
			for (var num3 = 0; num3 < num; num3++)
			{
				class2.int_1[num3] = @class.int_7[class2.int_2[num3]];
			}
			switch (@class.int_6)
			{
			case 1:
				class2.int_8 = 256;
				break;
			case 2:
				class2.int_8 = 128;
				break;
			case 3:
				class2.int_8 = 86;
				break;
			case 4:
				class2.int_8 = 64;
				break;
			default:
				class2.int_8 = -1;
				break;
			}
			for (var num4 = 0; num4 < num - 2; num4++)
			{
				var num5 = 0;
				var num6 = 1;
				var num7 = 0;
				var num8 = class2.int_7;
				var num9 = @class.int_7[num4 + 2];
				for (var num10 = 0; num10 < num4 + 2; num10++)
				{
					var num11 = @class.int_7[num10];
					if (num11 > num7 && num11 < num9)
					{
						num5 = num10;
						num7 = num11;
					}
					if (num11 < num8 && num11 > num9)
					{
						num6 = num10;
						num8 = num11;
					}
				}
				class2.int_5[num4] = num5;
				class2.int_4[num4] = num6;
			}
			return class2;
		}

		public override void vmethod_2(object object_0)
		{
		}

		public override object vmethod_3(OGGClass6 class71_0, object object_0, object object_1)
		{
			var @class = (Class32)object_0;
			var class31_ = @class.class31_0;
			var class21_ = class71_0.oggClass1.oggClass4;
			if (class71_0.oggClass3.method_6(1) == 1)
			{
				int[] array = null;
				if (object_1 is int[])
				{
					array = (int[])object_1;
				}
				if (array != null && array.Length >= @class.int_6)
				{
					for (var i = 0; i < array.Length; i++)
					{
						array[i] = 0;
					}
				}
				else
				{
					array = new int[@class.int_6];
				}
				array[0] = class71_0.oggClass3.method_6(smethod_2(@class.int_8 - 1));
				array[1] = class71_0.oggClass3.method_6(smethod_2(@class.int_8 - 1));
				var j = 0;
				var num = 2;
				while (j < class31_.int_0)
				{
					var num2 = class31_.int_1[j];
					var num3 = class31_.int_2[num2];
					var num4 = class31_.int_3[num2];
					var num5 = 1 << num4;
					var num6 = 0;
					if (num4 != 0)
					{
						num6 = class21_[class31_.int_4[num2]].method_4(class71_0.oggClass3);
						if (num6 == -1)
						{
							return null;
						}
					}
					for (var k = 0; k < num3; k++)
					{
						var num7 = class31_.int_5[num2][num6 & num5 - 1];
						num6 = (int)((uint)num6 >> num4);
						if (num7 >= 0)
						{
							if ((array[num + k] = class21_[num7].method_4(class71_0.oggClass3)) == -1)
							{
								return null;
							}
						}
						else
						{
							array[num + k] = 0;
						}
					}
					num += num3;
					j++;
				}
				for (var l = 2; l < @class.int_6; l++)
				{
					var num8 = smethod_0(class31_.int_7[@class.int_5[l - 2]], class31_.int_7[@class.int_4[l - 2]], array[@class.int_5[l - 2]], array[@class.int_4[l - 2]], class31_.int_7[l]);
					var num9 = @class.int_8 - num8;
					var num10 = num8;
					var num11 = ((num9 < num10) ? num9 : num10) << 1;
					var num12 = array[l];
					if (num12 != 0)
					{
						if (num12 >= num11)
						{
							if (num9 > num10)
							{
								num12 -= num10;
							}
							else
							{
								num12 = -1 - (num12 - num9);
							}
						}
						else if ((num12 & 1) != 0)
						{
							num12 = -(int)((uint)(num12 + 1) >> 1);
						}
						else
						{
							num12 >>= 1;
						}
						array[l] = num12 + num8;
						array[@class.int_5[l - 2]] &= 32767;
						array[@class.int_4[l - 2]] &= 32767;
					}
					else
					{
						array[l] = (num8 | 32768);
					}
				}
				return array;
			}
			return null;
		}

		private static int smethod_0(int int_2, int int_3, int int_4, int int_5, int int_6)
		{
			int_4 &= 32767;
			int_5 &= 32767;
			var num = int_5 - int_4;
			var num2 = int_3 - int_2;
			var num3 = Math.Abs(num);
			var num4 = num3 * (int_6 - int_2);
			var num5 = num4 / num2;
			if (num < 0)
			{
				return int_4 - num5;
			}
			return int_4 + num5;
		}

		public override int vmethod_4(OGGClass6 class71_0, object object_0, object object_1, float[] float_1)
		{
			var @class = (Class32)object_0;
			var class31_ = @class.class31_0;
			var num = class71_0.oggClass1.oggClass5.int_13[class71_0.int_4] / 2;
			if (object_1 != null)
			{
				var array = (int[])object_1;
				var num2 = 0;
				var int_ = 0;
				var int_2 = array[0] * class31_.int_6;
				for (var i = 1; i < @class.int_6; i++)
				{
					var num3 = @class.int_2[i];
					var num4 = array[num3] & 32767;
					if (num4 == array[num3])
					{
						num4 *= class31_.int_6;
						num2 = class31_.int_7[num3];
						smethod_1(int_, num2, int_2, num4, float_1);
						int_ = num2;
						int_2 = num4;
					}
				}
				for (var j = num2; j < num; j++)
				{
					float_1[j] *= float_1[j - 1];
				}
				return 1;
			}
			for (var k = 0; k < num; k++)
			{
				float_1[k] = 0f;
			}
			return 0;
		}

		private static void smethod_1(int int_2, int int_3, int int_4, int int_5, float[] float_1)
		{
			var num = int_5 - int_4;
			var num2 = int_3 - int_2;
			var num3 = Math.Abs(num);
			var num4 = num / num2;
			var num5 = (num < 0) ? (num4 - 1) : (num4 + 1);
			var num6 = int_2;
			var num7 = int_4;
			var num8 = 0;
			num3 -= Math.Abs(num4 * num2);
			float_1[num6] *= float_0[num7];
			while (++num6 < int_3)
			{
				num8 += num3;
				if (num8 >= num2)
				{
					num8 -= num2;
					num7 += num5;
				}
				else
				{
					num7 += num4;
				}
				float_1[num6] *= float_0[num7];
			}
		}

		private static int smethod_2(int int_2)
		{
			var num = 0;
			while (int_2 != 0)
			{
				num++;
				int_2 = (int)((uint)int_2 >> 1);
			}
			return num;
		}
	}
}
