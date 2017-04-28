using System;

namespace ns4
{
	public class Class80
	{
		private readonly float[] float_0;

		private readonly float[] float_1;

		private float[] float_2;

		private int int_0;

		private readonly float[] float_3;

		private readonly int int_1;

		private float[] float_4;

		private readonly float[] float_5 = new float[32];

		private static float[] float_6;

		private static float[][] float_7;

		private static readonly float[] float_8 = {
			0f,
			-0.000442505f,
			0.003250122f,
			-0.007003784f,
			0.0310821533f,
			-0.07862854f,
			0.100311279f,
			-0.572036743f,
			1.144989f,
			0.572036743f,
			0.100311279f,
			0.07862854f,
			0.0310821533f,
			0.007003784f,
			0.003250122f,
			0.000442505f,
			-1.5259E-05f,
			-0.000473022f,
			0.003326416f,
			-0.007919312f,
			0.0305175781f,
			-0.08418274f,
			0.090927124f,
			-0.6002197f,
			1.14428711f,
			0.543823242f,
			0.1088562f,
			0.07305908f,
			0.03147888f,
			0.006118774f,
			0.003173828f,
			0.000396729f,
			-1.5259E-05f,
			-0.000534058f,
			0.003387451f,
			-0.008865356f,
			0.0297851563f,
			-0.08970642f,
			0.08068848f,
			-0.6282959f,
			1.14221191f,
			0.515609741f,
			0.116577148f,
			0.06752014f,
			0.03173828f,
			0.0052948f,
			0.003082275f,
			0.000366211f,
			-1.5259E-05f,
			-0.000579834f,
			0.003433228f,
			-0.009841919f,
			0.0288848877f,
			-0.09516907f,
			0.06959534f,
			-0.6562195f,
			1.13876343f,
			0.487472534f,
			0.123474121f,
			0.06199646f,
			0.0318450928f,
			0.004486084f,
			0.002990723f,
			0.000320435f,
			-1.5259E-05f,
			-0.00062561f,
			0.003463745f,
			-0.010848999f,
			0.0278015137f,
			-0.100540161f,
			0.0576171875f,
			-0.6839142f,
			1.13392639f,
			0.459472656f,
			0.129577637f,
			0.0565338135f,
			0.0318145752f,
			0.003723145f,
			0.00289917f,
			0.000289917f,
			-1.5259E-05f,
			-0.000686646f,
			0.003479004f,
			-0.0118865967f,
			0.0265350342f,
			-0.1058197f,
			0.0447845459f,
			-0.71131897f,
			1.12774658f,
			0.431655884f,
			0.1348877f,
			0.0511322021f,
			0.0316619873f,
			0.003005981f,
			0.002792358f,
			0.000259399f,
			-1.5259E-05f,
			-0.000747681f,
			0.003479004f,
			-0.0129394531f,
			0.02508545f,
			-0.110946655f,
			0.0310821533f,
			-0.7383728f,
			1.120224f,
			0.404083252f,
			0.139450073f,
			0.0458374023f,
			0.03138733f,
			0.002334595f,
			0.002685547f,
			0.000244141f,
			-3.0518E-05f,
			-0.000808716f,
			0.003463745f,
			-0.0140228271f,
			0.0234222412f,
			-0.115921021f,
			0.01651001f,
			-0.7650299f,
			1.1113739f,
			0.376800537f,
			0.143264771f,
			0.0406341553f,
			0.03100586f,
			0.001693726f,
			0.002578735f,
			0.000213623f,
			-3.0518E-05f,
			-0.00088501f,
			0.003417969f,
			-0.01512146f,
			0.0215759277f,
			-0.120697021f,
			0.001068115f,
			-0.791214f,
			1.10121155f,
			0.349868774f,
			0.1463623f,
			0.03555298f,
			0.0305328369f,
			0.001098633f,
			0.002456665f,
			0.000198364f,
			-3.0518E-05f,
			-0.000961304f,
			0.003372192f,
			-0.0162353516f,
			0.01953125f,
			-0.1252594f,
			-0.0152282706f,
			-0.816864f,
			1.08978271f,
			0.323318481f,
			0.1487732f,
			0.03060913f,
			0.0299377441f,
			0.000549316f,
			0.002349854f,
			0.000167847f,
			-3.0518E-05f,
			-0.001037598f,
			0.00328064f,
			-0.0173492432f,
			0.01725769f,
			-0.129562378f,
			-0.03237915f,
			-0.841949463f,
			1.07711792f,
			0.2972107f,
			0.150497437f,
			0.0258178711f,
			0.0292816162f,
			3.0518E-05f,
			0.002243042f,
			0.000152588f,
			-4.5776E-05f,
			-0.001113892f,
			0.003173828f,
			-0.0184631348f,
			0.0148010254f,
			-0.1335907f,
			-0.0503540039f,
			-0.8663635f,
			1.06321716f,
			0.2715912f,
			0.151596069f,
			0.0211792f,
			0.0285339355f,
			-0.000442505f,
			0.002120972f,
			0.000137329f,
			-4.5776E-05f,
			-0.001205444f,
			0.003051758f,
			-0.0195770264f,
			0.0121154794f,
			-0.137298584f,
			-0.06916809f,
			-0.890090942f,
			1.04815674f,
			0.246505737f,
			0.152069092f,
			0.016708374f,
			0.02772522f,
			-0.000869751f,
			0.00201416f,
			0.00012207f,
			-6.1035E-05f,
			-0.001296997f,
			0.002883911f,
			-0.020690918f,
			0.009231567f,
			-0.140670776f,
			-0.0887756348f,
			-0.9130554f,
			1.03193665f,
			0.221984863f,
			0.15196228f,
			0.0124206543f,
			0.02684021f,
			-0.001266479f,
			0.001907349f,
			0.000106812f,
			-6.1035E-05f,
			-0.00138855f,
			0.002700806f,
			-0.02178955f,
			0.006134033f,
			-0.143676758f,
			-0.109161377f,
			-0.9351959f,
			1.01461792f,
			0.198059082f,
			0.151306152f,
			0.00831604f,
			0.0259094238f,
			-0.001617432f,
			0.001785278f,
			0.000106812f,
			-7.6294E-05f,
			-0.001480103f,
			0.002487183f,
			-0.022857666f,
			0.002822876f,
			-0.1462555f,
			-0.130310059f,
			-0.956481934f,
			0.996246338f,
			0.174789429f,
			0.150115967f,
			0.004394531f,
			0.0249328613f,
			-0.001937866f,
			0.001693726f,
			9.1553E-05f,
			-7.6294E-05f,
			-0.001586914f,
			0.002227783f,
			-0.0239105225f,
			-0.000686646f,
			-0.148422241f,
			-0.152206421f,
			-0.9768524f,
			0.9768524f,
			0.152206421f,
			0.148422241f,
			0.000686646f,
			0.0239105225f,
			-0.002227783f,
			0.001586914f,
			7.6294E-05f,
			-9.1553E-05f,
			-0.001693726f,
			0.001937866f,
			-0.0249328613f,
			-0.004394531f,
			-0.150115967f,
			-0.174789429f,
			-0.996246338f,
			0.956481934f,
			0.130310059f,
			0.1462555f,
			-0.002822876f,
			0.022857666f,
			-0.002487183f,
			0.001480103f,
			7.6294E-05f,
			-0.000106812f,
			-0.001785278f,
			0.001617432f,
			-0.0259094238f,
			-0.00831604f,
			-0.151306152f,
			-0.198059082f,
			-1.01461792f,
			0.9351959f,
			0.109161377f,
			0.143676758f,
			-0.006134033f,
			0.02178955f,
			-0.002700806f,
			0.00138855f,
			6.1035E-05f,
			-0.000106812f,
			-0.001907349f,
			0.001266479f,
			-0.02684021f,
			-0.0124206543f,
			-0.15196228f,
			-0.221984863f,
			-1.03193665f,
			0.9130554f,
			0.0887756348f,
			0.140670776f,
			-0.009231567f,
			0.020690918f,
			-0.002883911f,
			0.001296997f,
			6.1035E-05f,
			-0.00012207f,
			-0.00201416f,
			0.000869751f,
			-0.02772522f,
			-0.016708374f,
			-0.152069092f,
			-0.246505737f,
			-1.04815674f,
			0.890090942f,
			0.06916809f,
			0.137298584f,
			-0.0121154794f,
			0.0195770264f,
			-0.003051758f,
			0.001205444f,
			4.5776E-05f,
			-0.000137329f,
			-0.002120972f,
			0.000442505f,
			-0.0285339355f,
			-0.0211792f,
			-0.151596069f,
			-0.2715912f,
			-1.06321716f,
			0.8663635f,
			0.0503540039f,
			0.1335907f,
			-0.0148010254f,
			0.0184631348f,
			-0.003173828f,
			0.001113892f,
			4.5776E-05f,
			-0.000152588f,
			-0.002243042f,
			-3.0518E-05f,
			-0.0292816162f,
			-0.0258178711f,
			-0.150497437f,
			-0.2972107f,
			-1.07711792f,
			0.841949463f,
			0.03237915f,
			0.129562378f,
			-0.01725769f,
			0.0173492432f,
			-0.00328064f,
			0.001037598f,
			3.0518E-05f,
			-0.000167847f,
			-0.002349854f,
			-0.000549316f,
			-0.0299377441f,
			-0.03060913f,
			-0.1487732f,
			-0.323318481f,
			-1.08978271f,
			0.816864f,
			0.0152282706f,
			0.1252594f,
			-0.01953125f,
			0.0162353516f,
			-0.003372192f,
			0.000961304f,
			3.0518E-05f,
			-0.000198364f,
			-0.002456665f,
			-0.001098633f,
			-0.0305328369f,
			-0.03555298f,
			-0.1463623f,
			-0.349868774f,
			-1.10121155f,
			0.791214f,
			-0.001068115f,
			0.120697021f,
			-0.0215759277f,
			0.01512146f,
			-0.003417969f,
			0.00088501f,
			3.0518E-05f,
			-0.000213623f,
			-0.002578735f,
			-0.001693726f,
			-0.03100586f,
			-0.0406341553f,
			-0.143264771f,
			-0.376800537f,
			-1.1113739f,
			0.7650299f,
			-0.01651001f,
			0.115921021f,
			-0.0234222412f,
			0.0140228271f,
			-0.003463745f,
			0.000808716f,
			3.0518E-05f,
			-0.000244141f,
			-0.002685547f,
			-0.002334595f,
			-0.03138733f,
			-0.0458374023f,
			-0.139450073f,
			-0.404083252f,
			-1.120224f,
			0.7383728f,
			-0.0310821533f,
			0.110946655f,
			-0.02508545f,
			0.0129394531f,
			-0.003479004f,
			0.000747681f,
			1.5259E-05f,
			-0.000259399f,
			-0.002792358f,
			-0.003005981f,
			-0.0316619873f,
			-0.0511322021f,
			-0.1348877f,
			-0.431655884f,
			-1.12774658f,
			0.71131897f,
			-0.0447845459f,
			0.1058197f,
			-0.0265350342f,
			0.0118865967f,
			-0.003479004f,
			0.000686646f,
			1.5259E-05f,
			-0.000289917f,
			-0.00289917f,
			-0.003723145f,
			-0.0318145752f,
			-0.0565338135f,
			-0.129577637f,
			-0.459472656f,
			-1.13392639f,
			0.6839142f,
			-0.0576171875f,
			0.100540161f,
			-0.0278015137f,
			0.010848999f,
			-0.003463745f,
			0.00062561f,
			1.5259E-05f,
			-0.000320435f,
			-0.002990723f,
			-0.004486084f,
			-0.0318450928f,
			-0.06199646f,
			-0.123474121f,
			-0.487472534f,
			-1.13876343f,
			0.6562195f,
			-0.06959534f,
			0.09516907f,
			-0.0288848877f,
			0.009841919f,
			-0.003433228f,
			0.000579834f,
			1.5259E-05f,
			-0.000366211f,
			-0.003082275f,
			-0.0052948f,
			-0.03173828f,
			-0.06752014f,
			-0.116577148f,
			-0.515609741f,
			-1.14221191f,
			0.6282959f,
			-0.08068848f,
			0.08970642f,
			-0.0297851563f,
			0.008865356f,
			-0.003387451f,
			0.000534058f,
			1.5259E-05f,
			-0.000396729f,
			-0.003173828f,
			-0.006118774f,
			-0.03147888f,
			-0.07305908f,
			-0.1088562f,
			-0.543823242f,
			-1.14428711f,
			0.6002197f,
			-0.090927124f,
			0.08418274f,
			-0.0305175781f,
			0.007919312f,
			-0.003326416f,
			0.000473022f,
			1.5259E-05f
		};

		public void method_0(float[] float_9)
		{
			float_4 = float_9;
			if (float_4 == null)
			{
				float_4 = new float[32];
				for (var i = 0; i < 32; i++)
				{
					float_4[i] = 1f;
				}
			}
			if (float_4.Length < 32)
			{
				throw new ArgumentException("Mp3 Synthesis Filter: EQ length.");
			}
		}

		public Class80(int int_2, float[] float_9)
		{
			if (float_6 == null)
			{
				float_6 = float_8;
				float_7 = smethod_0(float_6, 16);
			}
			float_0 = new float[512];
			float_1 = new float[512];
			float_3 = new float[32];
			int_1 = int_2;
			method_0(float_9);
			method_1();
		}

		public void method_1()
		{
			Array.Clear(float_0, 0, 512);
			Array.Clear(float_1, 0, 512);
			Array.Clear(float_3, 0, 32);
			float_2 = float_0;
			int_0 = 15;
		}

		public void method_2(float float_9, int int_2)
		{
			float_3[int_2] = float_4[int_2] * float_9;
		}

		public void method_3(float[] float_9)
		{
			for (var i = 31; i >= 0; i--)
			{
				float_3[i] = float_9[i] * float_4[i];
			}
		}

		private void method_4()
		{
			var array = float_3;
			var num = array[0];
			var num2 = array[1];
			var num3 = array[2];
			var num4 = array[3];
			var num5 = array[4];
			var num6 = array[5];
			var num7 = array[6];
			var num8 = array[7];
			var num9 = array[8];
			var num10 = array[9];
			var num11 = array[10];
			var num12 = array[11];
			var num13 = array[12];
			var num14 = array[13];
			var num15 = array[14];
			var num16 = array[15];
			var num17 = array[16];
			var num18 = array[17];
			var num19 = array[18];
			var num20 = array[19];
			var num21 = array[20];
			var num22 = array[21];
			var num23 = array[22];
			var num24 = array[23];
			var num25 = array[24];
			var num26 = array[25];
			var num27 = array[26];
			var num28 = array[27];
			var num29 = array[28];
			var num30 = array[29];
			var num31 = array[30];
			var num32 = array[31];
			var num33 = num + num32;
			var num34 = num2 + num31;
			var num35 = num3 + num30;
			var num36 = num4 + num29;
			var num37 = num5 + num28;
			var num38 = num6 + num27;
			var num39 = num7 + num26;
			var num40 = num8 + num25;
			var num41 = num9 + num24;
			var num42 = num10 + num23;
			var num43 = num11 + num22;
			var num44 = num12 + num21;
			var num45 = num13 + num20;
			var num46 = num14 + num19;
			var num47 = num15 + num18;
			var num48 = num16 + num17;
			var num49 = num33 + num48;
			var num50 = num34 + num47;
			var num51 = num35 + num46;
			var num52 = num36 + num45;
			var num53 = num37 + num44;
			var num54 = num38 + num43;
			var num55 = num39 + num42;
			var num56 = num40 + num41;
			var num57 = (num33 - num48) * 0.5024193f;
			var num58 = (num34 - num47) * 0.5224986f;
			var num59 = (num35 - num46) * 0.566944063f;
			var num60 = (num36 - num45) * 0.6468218f;
			var num61 = (num37 - num44) * 0.7881546f;
			var num62 = (num38 - num43) * 1.06067765f;
			var num63 = (num39 - num42) * 1.72244716f;
			var num64 = (num40 - num41) * 5.10114861f;
			num33 = num49 + num56;
			num34 = num50 + num55;
			num35 = num51 + num54;
			num36 = num52 + num53;
			num37 = (num49 - num56) * 0.5097956f;
			num38 = (num50 - num55) * 0.6013449f;
			num39 = (num51 - num54) * 0.8999762f;
			num40 = (num52 - num53) * 2.56291556f;
			num41 = num57 + num64;
			num42 = num58 + num63;
			num43 = num59 + num62;
			num44 = num60 + num61;
			num45 = (num57 - num64) * 0.5097956f;
			num46 = (num58 - num63) * 0.6013449f;
			num47 = (num59 - num62) * 0.8999762f;
			num48 = (num60 - num61) * 2.56291556f;
			num49 = num33 + num36;
			num50 = num34 + num35;
			num51 = (num33 - num36) * 0.5411961f;
			num52 = (num34 - num35) * 1.306563f;
			num53 = num37 + num40;
			num54 = num38 + num39;
			num55 = (num37 - num40) * 0.5411961f;
			num56 = (num38 - num39) * 1.306563f;
			num57 = num41 + num44;
			num58 = num42 + num43;
			num59 = (num41 - num44) * 0.5411961f;
			num60 = (num42 - num43) * 1.306563f;
			num61 = num45 + num48;
			num62 = num46 + num47;
			num63 = (num45 - num48) * 0.5411961f;
			num64 = (num46 - num47) * 1.306563f;
			num33 = num49 + num50;
			num34 = (num49 - num50) * 0.707106769f;
			num35 = num51 + num52;
			num36 = (num51 - num52) * 0.707106769f;
			num37 = num53 + num54;
			num38 = (num53 - num54) * 0.707106769f;
			num39 = num55 + num56;
			num40 = (num55 - num56) * 0.707106769f;
			num41 = num57 + num58;
			num42 = (num57 - num58) * 0.707106769f;
			num43 = num59 + num60;
			num44 = (num59 - num60) * 0.707106769f;
			num45 = num61 + num62;
			num46 = (num61 - num62) * 0.707106769f;
			num47 = num63 + num64;
			num48 = (num63 - num64) * 0.707106769f;
			float num67;
			float num66;
			var num65 = -(num66 = (num67 = num40) + num38) - num39;
			var num68 = -num39 - num40 - num37;
			float num71;
			float num70;
			var num69 = (num70 = (num71 = num48) + num44) + num46;
			float num73;
			var num72 = -(num73 = num48 + num46 + num42) - num47;
			float num75;
			var num74 = (num75 = -num47 - num48 - num43 - num44) - num46;
			var num76 = -num47 - num48 - num45 - num41;
			var num77 = num75 - num45;
			var num78 = -num33;
			var num79 = num34;
			float num81;
			var num80 = -(num81 = num36) - num35;
			num33 = (num - num32) * 0.500603f;
			num34 = (num2 - num31) * 0.505470932f;
			num35 = (num3 - num30) * 0.5154473f;
			num36 = (num4 - num29) * 0.5310426f;
			num37 = (num5 - num28) * 0.5531039f;
			num38 = (num6 - num27) * 0.582935f;
			num39 = (num7 - num26) * 0.6225041f;
			num40 = (num8 - num25) * 0.6748083f;
			num41 = (num9 - num24) * 0.7445363f;
			num42 = (num10 - num23) * 0.8393496f;
			num43 = (num11 - num22) * 0.9725682f;
			num44 = (num12 - num21) * 1.16943991f;
			num45 = (num13 - num20) * 1.4841646f;
			num46 = (num14 - num19) * 2.057781f;
			num47 = (num15 - num18) * 3.40760851f;
			num48 = (num16 - num17) * 10.1900082f;
			num49 = num33 + num48;
			num50 = num34 + num47;
			num51 = num35 + num46;
			num52 = num36 + num45;
			num53 = num37 + num44;
			num54 = num38 + num43;
			num55 = num39 + num42;
			num56 = num40 + num41;
			num57 = (num33 - num48) * 0.5024193f;
			num58 = (num34 - num47) * 0.5224986f;
			num59 = (num35 - num46) * 0.566944063f;
			num60 = (num36 - num45) * 0.6468218f;
			num61 = (num37 - num44) * 0.7881546f;
			num62 = (num38 - num43) * 1.06067765f;
			num63 = (num39 - num42) * 1.72244716f;
			num64 = (num40 - num41) * 5.10114861f;
			num33 = num49 + num56;
			num34 = num50 + num55;
			num35 = num51 + num54;
			num36 = num52 + num53;
			num37 = (num49 - num56) * 0.5097956f;
			num38 = (num50 - num55) * 0.6013449f;
			num39 = (num51 - num54) * 0.8999762f;
			num40 = (num52 - num53) * 2.56291556f;
			num41 = num57 + num64;
			num42 = num58 + num63;
			num43 = num59 + num62;
			num44 = num60 + num61;
			num45 = (num57 - num64) * 0.5097956f;
			num46 = (num58 - num63) * 0.6013449f;
			num47 = (num59 - num62) * 0.8999762f;
			num48 = (num60 - num61) * 2.56291556f;
			num49 = num33 + num36;
			num50 = num34 + num35;
			num51 = (num33 - num36) * 0.5411961f;
			num52 = (num34 - num35) * 1.306563f;
			num53 = num37 + num40;
			num54 = num38 + num39;
			num55 = (num37 - num40) * 0.5411961f;
			num56 = (num38 - num39) * 1.306563f;
			num57 = num41 + num44;
			num58 = num42 + num43;
			num59 = (num41 - num44) * 0.5411961f;
			num60 = (num42 - num43) * 1.306563f;
			num61 = num45 + num48;
			num62 = num46 + num47;
			num63 = (num45 - num48) * 0.5411961f;
			num64 = (num46 - num47) * 1.306563f;
			num33 = num49 + num50;
			num34 = (num49 - num50) * 0.707106769f;
			num35 = num51 + num52;
			num36 = (num51 - num52) * 0.707106769f;
			num37 = num53 + num54;
			num38 = (num53 - num54) * 0.707106769f;
			num39 = num55 + num56;
			num40 = (num55 - num56) * 0.707106769f;
			num41 = num57 + num58;
			num42 = (num57 - num58) * 0.707106769f;
			num43 = num59 + num60;
			num44 = (num59 - num60) * 0.707106769f;
			num45 = num61 + num62;
			num46 = (num61 - num62) * 0.707106769f;
			num47 = num63 + num64;
			num48 = (num63 - num64) * 0.707106769f;
			float num85;
			float num84;
			float num83;
			var num82 = (num83 = (num84 = (num85 = num48) + num40) + num44) + num38 + num46;
			float num87;
			var num86 = (num87 = num48 + num44 + num36) + num46;
			float num89;
			var num88 = -(num89 = (num75 = num46 + num48 + num42) + num34) - num47;
			float num91;
			var num90 = -(num91 = num75 + num38 + num40) - num39 - num47;
			var num92 = (num75 = -num43 - num44 - num47 - num48) - num46 - num35 - num36;
			var num93 = num75 - num46 - num38 - num39 - num40;
			var num94 = num75 - num45 - num35 - num36;
			float num96;
			var num95 = num75 - num45 - (num96 = num37 + num39 + num40);
			var num97 = (num75 = -num41 - num45 - num47 - num48) - num33;
			var num98 = num75 - num96;
			var array2 = float_2;
			var num99 = int_0;
			array2[num99] = num79;
			array2[16 + num99] = num89;
			array2[32 + num99] = num73;
			array2[48 + num99] = num91;
			array2[64 + num99] = num66;
			array2[80 + num99] = num82;
			array2[96 + num99] = num69;
			array2[112 + num99] = num86;
			array2[128 + num99] = num81;
			array2[144 + num99] = num87;
			array2[160 + num99] = num70;
			array2[176 + num99] = num83;
			array2[192 + num99] = num67;
			array2[208 + num99] = num84;
			array2[224 + num99] = num71;
			array2[240 + num99] = num85;
			array2[256 + num99] = 0f;
			array2[272 + num99] = -num85;
			array2[288 + num99] = -num71;
			array2[304 + num99] = -num84;
			array2[320 + num99] = -num67;
			array2[336 + num99] = -num83;
			array2[352 + num99] = -num70;
			array2[368 + num99] = -num87;
			array2[384 + num99] = -num81;
			array2[400 + num99] = -num86;
			array2[416 + num99] = -num69;
			array2[432 + num99] = -num82;
			array2[448 + num99] = -num66;
			array2[464 + num99] = -num91;
			array2[480 + num99] = -num73;
			array2[496 + num99] = -num89;
			array2 = ((float_2 == float_0) ? float_1 : float_0);
			array2[num99] = -num79;
			array2[16 + num99] = num88;
			array2[32 + num99] = num72;
			array2[48 + num99] = num90;
			array2[64 + num99] = num65;
			array2[80 + num99] = num93;
			array2[96 + num99] = num74;
			array2[112 + num99] = num92;
			array2[128 + num99] = num80;
			array2[144 + num99] = num94;
			array2[160 + num99] = num77;
			array2[176 + num99] = num95;
			array2[192 + num99] = num68;
			array2[208 + num99] = num98;
			array2[224 + num99] = num76;
			array2[240 + num99] = num97;
			array2[256 + num99] = num78;
			array2[272 + num99] = num97;
			array2[288 + num99] = num76;
			array2[304 + num99] = num98;
			array2[320 + num99] = num68;
			array2[336 + num99] = num95;
			array2[352 + num99] = num77;
			array2[368 + num99] = num94;
			array2[384 + num99] = num80;
			array2[400 + num99] = num92;
			array2[416 + num99] = num74;
			array2[432 + num99] = num93;
			array2[448 + num99] = num65;
			array2[464 + num99] = num90;
			array2[480 + num99] = num72;
			array2[496 + num99] = num88;
		}

		private void method_5()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[num] * array2[0] + array[15 + num] * array2[1] + array[14 + num] * array2[2] + array[13 + num] * array2[3] + array[12 + num] * array2[4] + array[11 + num] * array2[5] + array[10 + num] * array2[6] + array[9 + num] * array2[7] + array[8 + num] * array2[8] + array[7 + num] * array2[9] + array[6 + num] * array2[10] + array[5 + num] * array2[11] + array[4 + num] * array2[12] + array[3 + num] * array2[13] + array[2 + num] * array2[14] + array[1 + num] * array2[15];
				num += 16;
			}
		}

		private void method_6()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[1 + num] * array2[0] + array[num] * array2[1] + array[15 + num] * array2[2] + array[14 + num] * array2[3] + array[13 + num] * array2[4] + array[12 + num] * array2[5] + array[11 + num] * array2[6] + array[10 + num] * array2[7] + array[9 + num] * array2[8] + array[8 + num] * array2[9] + array[7 + num] * array2[10] + array[6 + num] * array2[11] + array[5 + num] * array2[12] + array[4 + num] * array2[13] + array[3 + num] * array2[14] + array[2 + num] * array2[15];
				num += 16;
			}
		}

		private void method_7()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[2 + num] * array2[0] + array[1 + num] * array2[1] + array[num] * array2[2] + array[15 + num] * array2[3] + array[14 + num] * array2[4] + array[13 + num] * array2[5] + array[12 + num] * array2[6] + array[11 + num] * array2[7] + array[10 + num] * array2[8] + array[9 + num] * array2[9] + array[8 + num] * array2[10] + array[7 + num] * array2[11] + array[6 + num] * array2[12] + array[5 + num] * array2[13] + array[4 + num] * array2[14] + array[3 + num] * array2[15];
				num += 16;
			}
		}

		private void method_8()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[3 + num] * array2[0] + array[2 + num] * array2[1] + array[1 + num] * array2[2] + array[num] * array2[3] + array[15 + num] * array2[4] + array[14 + num] * array2[5] + array[13 + num] * array2[6] + array[12 + num] * array2[7] + array[11 + num] * array2[8] + array[10 + num] * array2[9] + array[9 + num] * array2[10] + array[8 + num] * array2[11] + array[7 + num] * array2[12] + array[6 + num] * array2[13] + array[5 + num] * array2[14] + array[4 + num] * array2[15];
				num += 16;
			}
		}

		private void method_9()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[4 + num] * array2[0] + array[3 + num] * array2[1] + array[2 + num] * array2[2] + array[1 + num] * array2[3] + array[num] * array2[4] + array[15 + num] * array2[5] + array[14 + num] * array2[6] + array[13 + num] * array2[7] + array[12 + num] * array2[8] + array[11 + num] * array2[9] + array[10 + num] * array2[10] + array[9 + num] * array2[11] + array[8 + num] * array2[12] + array[7 + num] * array2[13] + array[6 + num] * array2[14] + array[5 + num] * array2[15];
				num += 16;
			}
		}

		private void method_10()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[5 + num] * array2[0] + array[4 + num] * array2[1] + array[3 + num] * array2[2] + array[2 + num] * array2[3] + array[1 + num] * array2[4] + array[num] * array2[5] + array[15 + num] * array2[6] + array[14 + num] * array2[7] + array[13 + num] * array2[8] + array[12 + num] * array2[9] + array[11 + num] * array2[10] + array[10 + num] * array2[11] + array[9 + num] * array2[12] + array[8 + num] * array2[13] + array[7 + num] * array2[14] + array[6 + num] * array2[15];
				num += 16;
			}
		}

		private void method_11()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[6 + num] * array2[0] + array[5 + num] * array2[1] + array[4 + num] * array2[2] + array[3 + num] * array2[3] + array[2 + num] * array2[4] + array[1 + num] * array2[5] + array[num] * array2[6] + array[15 + num] * array2[7] + array[14 + num] * array2[8] + array[13 + num] * array2[9] + array[12 + num] * array2[10] + array[11 + num] * array2[11] + array[10 + num] * array2[12] + array[9 + num] * array2[13] + array[8 + num] * array2[14] + array[7 + num] * array2[15];
				num += 16;
			}
		}

		private void method_12()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[7 + num] * array2[0] + array[6 + num] * array2[1] + array[5 + num] * array2[2] + array[4 + num] * array2[3] + array[3 + num] * array2[4] + array[2 + num] * array2[5] + array[1 + num] * array2[6] + array[num] * array2[7] + array[15 + num] * array2[8] + array[14 + num] * array2[9] + array[13 + num] * array2[10] + array[12 + num] * array2[11] + array[11 + num] * array2[12] + array[10 + num] * array2[13] + array[9 + num] * array2[14] + array[8 + num] * array2[15];
				num += 16;
			}
		}

		private void method_13()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[8 + num] * array2[0] + array[7 + num] * array2[1] + array[6 + num] * array2[2] + array[5 + num] * array2[3] + array[4 + num] * array2[4] + array[3 + num] * array2[5] + array[2 + num] * array2[6] + array[1 + num] * array2[7] + array[num] * array2[8] + array[15 + num] * array2[9] + array[14 + num] * array2[10] + array[13 + num] * array2[11] + array[12 + num] * array2[12] + array[11 + num] * array2[13] + array[10 + num] * array2[14] + array[9 + num] * array2[15];
				num += 16;
			}
		}

		private void method_14()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[9 + num] * array2[0] + array[8 + num] * array2[1] + array[7 + num] * array2[2] + array[6 + num] * array2[3] + array[5 + num] * array2[4] + array[4 + num] * array2[5] + array[3 + num] * array2[6] + array[2 + num] * array2[7] + array[1 + num] * array2[8] + array[num] * array2[9] + array[15 + num] * array2[10] + array[14 + num] * array2[11] + array[13 + num] * array2[12] + array[12 + num] * array2[13] + array[11 + num] * array2[14] + array[10 + num] * array2[15];
				num += 16;
			}
		}

		private void method_15()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[10 + num] * array2[0] + array[9 + num] * array2[1] + array[8 + num] * array2[2] + array[7 + num] * array2[3] + array[6 + num] * array2[4] + array[5 + num] * array2[5] + array[4 + num] * array2[6] + array[3 + num] * array2[7] + array[2 + num] * array2[8] + array[1 + num] * array2[9] + array[num] * array2[10] + array[15 + num] * array2[11] + array[14 + num] * array2[12] + array[13 + num] * array2[13] + array[12 + num] * array2[14] + array[11 + num] * array2[15];
				num += 16;
			}
		}

		private void method_16()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[11 + num] * array2[0] + array[10 + num] * array2[1] + array[9 + num] * array2[2] + array[8 + num] * array2[3] + array[7 + num] * array2[4] + array[6 + num] * array2[5] + array[5 + num] * array2[6] + array[4 + num] * array2[7] + array[3 + num] * array2[8] + array[2 + num] * array2[9] + array[1 + num] * array2[10] + array[num] * array2[11] + array[15 + num] * array2[12] + array[14 + num] * array2[13] + array[13 + num] * array2[14] + array[12 + num] * array2[15];
				num += 16;
			}
		}

		private void method_17()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[12 + num] * array2[0] + array[11 + num] * array2[1] + array[10 + num] * array2[2] + array[9 + num] * array2[3] + array[8 + num] * array2[4] + array[7 + num] * array2[5] + array[6 + num] * array2[6] + array[5 + num] * array2[7] + array[4 + num] * array2[8] + array[3 + num] * array2[9] + array[2 + num] * array2[10] + array[1 + num] * array2[11] + array[num] * array2[12] + array[15 + num] * array2[13] + array[14 + num] * array2[14] + array[13 + num] * array2[15];
				num += 16;
			}
		}

		private void method_18()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[13 + num] * array2[0] + array[12 + num] * array2[1] + array[11 + num] * array2[2] + array[10 + num] * array2[3] + array[9 + num] * array2[4] + array[8 + num] * array2[5] + array[7 + num] * array2[6] + array[6 + num] * array2[7] + array[5 + num] * array2[8] + array[4 + num] * array2[9] + array[3 + num] * array2[10] + array[2 + num] * array2[11] + array[1 + num] * array2[12] + array[num] * array2[13] + array[15 + num] * array2[14] + array[14 + num] * array2[15];
				num += 16;
			}
		}

		private void method_19()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[14 + num] * array2[0] + array[13 + num] * array2[1] + array[12 + num] * array2[2] + array[11 + num] * array2[3] + array[10 + num] * array2[4] + array[9 + num] * array2[5] + array[8 + num] * array2[6] + array[7 + num] * array2[7] + array[6 + num] * array2[8] + array[5 + num] * array2[9] + array[4 + num] * array2[10] + array[3 + num] * array2[11] + array[2 + num] * array2[12] + array[1 + num] * array2[13] + array[num] * array2[14] + array[15 + num] * array2[15];
				num += 16;
			}
		}

		private void method_20()
		{
			var array = float_2;
			var num = 0;
			for (var i = 0; i < 32; i++)
			{
				var array2 = float_7[i];
				float_5[i] = array[15 + num] * array2[0] + array[14 + num] * array2[1] + array[13 + num] * array2[2] + array[12 + num] * array2[3] + array[11 + num] * array2[4] + array[10 + num] * array2[5] + array[9 + num] * array2[6] + array[8 + num] * array2[7] + array[7 + num] * array2[8] + array[6 + num] * array2[9] + array[5 + num] * array2[10] + array[4 + num] * array2[11] + array[3 + num] * array2[12] + array[2 + num] * array2[13] + array[1 + num] * array2[14] + array[num] * array2[15];
				num += 16;
			}
		}

		private void method_21(Class84 class84_0)
		{
			switch (int_0)
			{
			case 0:
				method_5();
				break;
			case 1:
				method_6();
				break;
			case 2:
				method_7();
				break;
			case 3:
				method_8();
				break;
			case 4:
				method_9();
				break;
			case 5:
				method_10();
				break;
			case 6:
				method_11();
				break;
			case 7:
				method_12();
				break;
			case 8:
				method_13();
				break;
			case 9:
				method_14();
				break;
			case 10:
				method_15();
				break;
			case 11:
				method_16();
				break;
			case 12:
				method_17();
				break;
			case 13:
				method_18();
				break;
			case 14:
				method_19();
				break;
			case 15:
				method_20();
				break;
			}
			if (class84_0 != null)
			{
				class84_0.method_4(int_1, float_5);
			}
		}

		public void method_22(Class84 class84_0)
		{
			method_4();
			method_21(class84_0);
			int_0 = (int_0 + 1 & 15);
			float_2 = ((float_2 == float_0) ? float_1 : float_0);
			Array.Clear(float_3, 0, 32);
		}

		private static float[][] smethod_0(float[] float_9, int int_2)
		{
			var num = float_9.Length / int_2;
			var array = new float[num][];
			for (var i = 0; i < num; i++)
			{
				array[i] = smethod_1(float_9, i * int_2, int_2);
			}
			return array;
		}

		private static float[] smethod_1(float[] float_9, int int_2, int int_3)
		{
			if (int_2 + int_3 > float_9.Length)
			{
				int_3 = float_9.Length - int_2;
			}
			if (int_3 < 0)
			{
				int_3 = 0;
			}
			var array = new float[int_3];
			for (var i = 0; i < int_3; i++)
			{
				array[i] = float_9[int_2 + i];
			}
			return array;
		}
	}
}
