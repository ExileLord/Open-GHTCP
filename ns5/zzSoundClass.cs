using System;
using System.Text;
using GHNamespace1;
using ns4;
using SharpAudio.ASC.Mp3.Decoding;

namespace ns5
{
	public class ZzSoundClass
	{
		public static readonly int[][] Int0 = {
			new[]
			{
				22050,
				24000,
				16000,
				1
			},
			new[]
			{
				44100,
				48000,
				32000,
				1
			},
			new[]
			{
				11025,
				12000,
				8000,
				1
			}
		};

		private int _int1;

		private int _int2;

		private int _int3;

		private int _int4;

		private int _int5;

		private Enum3 _enum30;

		private Enum5 _enum50;

		private int _int6;

		private int _int7;

		private int _int8;

		private bool _bool0;

		private bool _bool1;

		private readonly double[] _double0 = {
			-1.0,
			384.0,
			1152.0,
			1152.0
		};

		private bool _bool2;

		private int _int9;

		private int _int10;

		private int _int11;

		private Class83 _class830;

		private byte _byte0;

		private Class101 _class1010;

		public short Short0;

		public int Int12;

		public int Int13;

		private int _int14 = -1;

		public static readonly int[,,] Int15 = {
			{
				{
					0,
					32000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					176000,
					192000,
					224000,
					256000,
					0
				},
				{
					0,
					8000,
					16000,
					24000,
					32000,
					40000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					0
				},
				{
					0,
					8000,
					16000,
					24000,
					32000,
					40000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					0
				}
			},
			{
				{
					0,
					32000,
					64000,
					96000,
					128000,
					160000,
					192000,
					224000,
					256000,
					288000,
					320000,
					352000,
					384000,
					416000,
					448000,
					0
				},
				{
					0,
					32000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					160000,
					192000,
					224000,
					256000,
					320000,
					384000,
					0
				},
				{
					0,
					32000,
					40000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					160000,
					192000,
					224000,
					256000,
					320000,
					0
				}
			},
			{
				{
					0,
					32000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					176000,
					192000,
					224000,
					256000,
					0
				},
				{
					0,
					8000,
					16000,
					24000,
					32000,
					40000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					0
				},
				{
					0,
					8000,
					16000,
					24000,
					32000,
					40000,
					48000,
					56000,
					64000,
					80000,
					96000,
					112000,
					128000,
					144000,
					160000,
					0
				}
			}
		};

		public static readonly string[][][] String0 = {
			new[]
			{
				new[]
				{
					"free format",
					"32 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"176 kbit/s",
					"192 kbit/s",
					"224 kbit/s",
					"256 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"8 kbit/s",
					"16 kbit/s",
					"24 kbit/s",
					"32 kbit/s",
					"40 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"8 kbit/s",
					"16 kbit/s",
					"24 kbit/s",
					"32 kbit/s",
					"40 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"forbidden"
				}
			},
			new[]
			{
				new[]
				{
					"free format",
					"32 kbit/s",
					"64 kbit/s",
					"96 kbit/s",
					"128 kbit/s",
					"160 kbit/s",
					"192 kbit/s",
					"224 kbit/s",
					"256 kbit/s",
					"288 kbit/s",
					"320 kbit/s",
					"352 kbit/s",
					"384 kbit/s",
					"416 kbit/s",
					"448 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"32 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"160 kbit/s",
					"192 kbit/s",
					"224 kbit/s",
					"256 kbit/s",
					"320 kbit/s",
					"384 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"32 kbit/s",
					"40 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"160 kbit/s",
					"192 kbit/s",
					"224 kbit/s",
					"256 kbit/s",
					"320 kbit/s",
					"forbidden"
				}
			},
			new[]
			{
				new[]
				{
					"free format",
					"32 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"176 kbit/s",
					"192 kbit/s",
					"224 kbit/s",
					"256 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"8 kbit/s",
					"16 kbit/s",
					"24 kbit/s",
					"32 kbit/s",
					"40 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"forbidden"
				},
				new[]
				{
					"free format",
					"8 kbit/s",
					"16 kbit/s",
					"24 kbit/s",
					"32 kbit/s",
					"40 kbit/s",
					"48 kbit/s",
					"56 kbit/s",
					"64 kbit/s",
					"80 kbit/s",
					"96 kbit/s",
					"112 kbit/s",
					"128 kbit/s",
					"144 kbit/s",
					"160 kbit/s",
					"forbidden"
				}
			}
		};

		private void method_0()
		{
			_byte0 = Class82.Byte1;
		}

		public ZzSoundClass()
		{
			method_0();
		}

		public override string ToString()
		{
			var stringBuilder = new StringBuilder(200);
			stringBuilder.Append("Layer ");
			stringBuilder.Append(method_19());
			stringBuilder.Append(" frame ");
			stringBuilder.Append(method_23());
			stringBuilder.Append(' ');
			stringBuilder.Append(method_24());
			if (!method_9())
			{
				stringBuilder.Append(" no");
			}
			stringBuilder.Append(" checksums");
			stringBuilder.Append(' ');
			stringBuilder.Append(method_22());
			stringBuilder.Append(',');
			stringBuilder.Append(' ');
			stringBuilder.Append(method_20());
			return stringBuilder.ToString();
		}

		public void method_1(Class82 class820, Class101[] class1011)
		{
			var flag = false;
			while (true)
			{
				var num = class820.method_9(_byte0);
				_int14 = num;
				if (_byte0 == Class82.Byte1)
				{
					_enum30 = (Enum3)(num >> 19 & 1);
					if ((num >> 20 & 1) == 0)
					{
						if (_enum30 != Enum3.Const0)
						{
							goto IL_1EE;
						}
						_enum30 = Enum3.Const2;
					}
					if ((_int6 = (num >> 10 & 3)) == 3)
					{
						goto Block_20;
					}
				}
				_int1 = (4 - (num >> 17) & 3);
				_int2 = (num >> 16 & 1);
				_int3 = (num >> 12 & 15);
				_int4 = (num >> 9 & 1);
				_enum50 = (Enum5)(num >> 6 & 3);
				_int5 = (num >> 4 & 3);
				if (_enum50 == Enum5.Const1)
				{
					_int8 = (_int5 << 2) + 4;
				}
				else
				{
					_int8 = 0;
				}
				if ((num >> 3 & 1) == 1)
				{
					_bool0 = true;
				}
				if ((num >> 2 & 1) == 1)
				{
					_bool1 = true;
				}
				if (_int1 == 1)
				{
					_int7 = 32;
				}
				else
				{
					var num2 = _int3;
					if (_enum50 != Enum5.Const3)
					{
						if (num2 == 4)
						{
							num2 = 1;
						}
						else
						{
							num2 -= 4;
						}
					}
					if (num2 != 1)
					{
						if (num2 != 2)
						{
							if (_int6 != 1 && (num2 < 3 || num2 > 5))
							{
								_int7 = 30;
								goto IL_102;
							}
							_int7 = 27;
							goto IL_102;
						}
					}
					_int7 = ((_int6 == 2) ? 12 : 8);
				}
				IL_102:
				if (_int8 > _int7)
				{
					_int8 = _int7;
				}
				method_15();
				var num3 = class820.method_11(Int12);
				if (Int12 >= 0 && num3 != Int12)
				{
					break;
				}
				if (class820.method_8(_byte0))
				{
					if (_byte0 == Class82.Byte1)
					{
						_byte0 = Class82.Byte2;
						class820.method_14(num & -521024);
					}
					flag = true;
				}
				else
				{
					class820.method_6();
				}
				if (flag)
				{
					goto Block_17;
				}
			}
			throw new BitstreamException(BitstreamError.InvalidFrame);
			Block_17:
			class820.method_12();
			if (_int2 == 0)
			{
				Short0 = (short)class820.method_13(16);
				if (_class1010 == null)
				{
					_class1010 = new Class101();
				}
				var num=0;
				_class1010.method_0(num, 16);
				class1011[0] = _class1010;
			}
			else
			{
				class1011[0] = null;
			}
			return;
			Block_20:
			throw new BitstreamException(BitstreamError.UnknownError);
			IL_1EE:
			throw new BitstreamException(BitstreamError.UnknownError);
		}

		public void method_2(byte[] byte1)
		{
			int num;
			if (_enum30 == Enum3.Const1)
			{
				num = ((_enum50 == Enum5.Const3) ? 17 : 32);
			}
			else
			{
				num = ((_enum50 == Enum5.Const3) ? 9 : 17);
			}
			try
			{
				var @string = Encoding.UTF8.GetString(byte1, num, 4);
				if (@string.Equals("Xing") || @string.Equals("Info"))
				{
					_bool2 = true;
					_int9 = -1;
					_int11 = -1;
					_int10 = -1;
					var array = new byte[100];
					var num2 = smethod_0(BitConverter.ToInt32(byte1, num + 4));
					var num3 = 8;
					if ((num2 & 1) != 0)
					{
						_int9 = smethod_0(BitConverter.ToInt32(byte1, num + num3));
						num3 += 4;
					}
					if ((num2 & 2) != 0)
					{
						_int11 = smethod_0(BitConverter.ToInt32(byte1, num + num3));
						num3 += 4;
					}
					if ((num2 & 4) != 0)
					{
						Buffer.BlockCopy(byte1, num + num3, array, 0, array.Length);
						num3 += array.Length;
						_class830 = new Class83(array, _int11);
					}
					if ((num2 & 8) != 0)
					{
						_int10 = smethod_0(BitConverter.ToInt32(byte1, num + num3));
						num3 += 4;
					}
				}
			}
			catch (IndexOutOfRangeException exception)
			{
				throw new BitstreamException("Xing Header Corrupted", exception);
			}
			num = 32;
			try
			{
				if (Encoding.UTF8.GetString(byte1, num, 4).Equals("VBRI"))
				{
					_bool2 = true;
					_int9 = -1;
					_int11 = -1;
					_int10 = -1;
					_int10 = smethod_1(BitConverter.ToInt16(byte1, num + 8));
					_int11 = smethod_0(BitConverter.ToInt32(byte1, num + 10));
					_int9 = smethod_0(BitConverter.ToInt32(byte1, num + 14));
					var array2 = new int[smethod_1(BitConverter.ToInt16(byte1, num + 18))];
					var num4 = smethod_1(BitConverter.ToInt16(byte1, num + 20));
					var num5 = smethod_1(BitConverter.ToInt16(byte1, num + 22));
					var num6 = smethod_1(BitConverter.ToInt16(byte1, num + 24));
					var num7 = 26;
					switch (num5)
					{
					case 1:
					{
						var i = 0;
						while (i < array2.Length)
						{
							array2[i] = byte1[num + num7] * num4;
							i++;
							num7++;
						}
						break;
					}
					case 2:
					{
						var j = 0;
						while (j < array2.Length)
						{
							array2[j] = smethod_1(BitConverter.ToInt16(byte1, num + num7)) * num4;
							j++;
							num7 += 2;
						}
						break;
					}
					case 3:
					{
						var k = 0;
						while (k < array2.Length)
						{
							array2[k] = Struct8.smethod_0(Struct8.smethod_3(byte1, num + num7, true)) * num4;
							k++;
							num7 += 3;
						}
						break;
					}
					case 4:
					{
						var l = 0;
						while (l < array2.Length)
						{
							array2[l] = smethod_0(BitConverter.ToInt32(byte1, num + num7)) * num4;
							l++;
							num7 += 4;
						}
						break;
					}
					default:
						throw new Exception("Size per table entry in bytes - is bigger then 4: " + num5);
					}
					_class830 = new Class83(array2, num6);
				}
			}
			catch (IndexOutOfRangeException exception2)
			{
				throw new BitstreamException("VBRI Header Corrupted", exception2);
			}
		}

		private static int smethod_0(int int16)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return int16;
			}
			return (smethod_1((short)int16) & 65535) << 16 | (smethod_1((short)(int16 >> 16)) & 65535);
		}

		private static short smethod_1(short short1)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return short1;
			}
			return (short)((short1 & 255) << 8 | (short1 >> 8 & 255));
		}

		public Enum3 method_3()
		{
			return _enum30;
		}

		public int method_4()
		{
			return _int1;
		}

		public int method_5()
		{
			return _int3;
		}

		public int method_6()
		{
			return _int6;
		}

		public int method_7()
		{
			return Int0[(int)_enum30][_int6];
		}

		public Enum5 method_8()
		{
			return _enum50;
		}

		public bool method_9()
		{
			return _int2 == 0;
		}

		public bool method_10()
		{
			return _bool2;
		}

		public Class83 method_11()
		{
			return _class830;
		}

		public bool method_12()
		{
			return Short0 == _class1010.method_1();
		}

		public int method_13()
		{
			return Int13;
		}

		public int method_14()
		{
			return _int5;
		}

		public int method_15()
		{
			if (_int1 == 1)
			{
				Int12 = 12 * Int15[(int)_enum30, 0, _int3] / Int0[(int)_enum30][_int6];
				if (_int4 != 0)
				{
					Int12++;
				}
				Int12 <<= 2;
				Int13 = 0;
			}
			else
			{
				Int12 = 144 * Int15[(int)_enum30, _int1 - 1, _int3] / Int0[(int)_enum30][_int6];
				if (_enum30 == Enum3.Const0 || _enum30 == Enum3.Const2)
				{
					Int12 >>= 1;
				}
				if (_int4 != 0)
				{
					Int12++;
				}
				if (_int1 == 3)
				{
					if (_enum30 == Enum3.Const1)
					{
						Int13 = Int12 - ((_enum50 == Enum5.Const3) ? 17 : 32) - ((_int2 != 0) ? 0 : 2) - 4;
					}
					else
					{
						Int13 = Int12 - ((_enum50 == Enum5.Const3) ? 9 : 17) - ((_int2 != 0) ? 0 : 2) - 4;
					}
				}
				else
				{
					Int13 = 0;
				}
			}
			Int12 -= 4;
			return Int12;
		}

		public int method_16(int int16)
		{
			if (_bool2)
			{
				return _int9;
			}
			if (Int12 + 4 - _int4 == 0)
			{
				return 0;
			}
			return int16 / (Int12 + 4 - _int4);
		}

		public double method_17()
		{
			if (_bool2)
			{
				var num = _double0[method_4()] / method_7();
				if (_enum30 == Enum3.Const0 || _enum30 == Enum3.Const2)
				{
					num /= 2.0;
				}
				return num * 1000.0;
			}
			float[,] array = {
				{
					8.707483f,
					8f,
					12f
				},
				{
					26.12245f,
					24f,
					36f
				},
				{
					26.12245f,
					24f,
					36f
				}
			};
			return array[_int1 - 1, _int6];
		}

		public double method_18(int int16)
		{
			return method_16(int16) * method_17();
		}

		public string method_19()
		{
			switch (_int1)
			{
			case 1:
				return "I";
			case 2:
				return "II";
			case 3:
				return "III";
			default:
				return null;
			}
		}

		public string method_20()
		{
			if (_bool2)
			{
				return Convert.ToString(method_21() / 1000) + " kb/s";
			}
			return String0[(int)_enum30][_int1 - 1][_int3];
		}

		public int method_21()
		{
			if (_bool2)
			{
				return (int)(_int11 * 8 / (method_17() * _int9)) * 1000;
			}
			return Int15[(int)_enum30, _int1 - 1, _int3];
		}

		public string method_22()
		{
			switch (_int6)
			{
			case 0:
				if (_enum30 == Enum3.Const1)
				{
					return "44.1 kHz";
				}
				if (_enum30 == Enum3.Const0)
				{
					return "22.05 kHz";
				}
				return "11.025 kHz";
			case 1:
				if (_enum30 == Enum3.Const1)
				{
					return "48 kHz";
				}
				if (_enum30 == Enum3.Const0)
				{
					return "24 kHz";
				}
				return "12 kHz";
			case 2:
				if (_enum30 == Enum3.Const1)
				{
					return "32 kHz";
				}
				if (_enum30 == Enum3.Const0)
				{
					return "16 kHz";
				}
				return "8 kHz";
			default:
				return null;
			}
		}

		public string method_23()
		{
			switch (_enum50)
			{
			case Enum5.Const0:
				return "Stereo";
			case Enum5.Const1:
				return "Joint stereo";
			case Enum5.Const2:
				return "Dual channel";
			case Enum5.Const3:
				return "Single channel";
			default:
				return null;
			}
		}

		public string method_24()
		{
			switch (_enum30)
			{
			case Enum3.Const0:
				return "MPEG-2 LSF";
			case Enum3.Const1:
				return "MPEG-1";
			case Enum3.Const2:
				return "MPEG-2.5 LSF";
			default:
				return null;
			}
		}

		public int method_25()
		{
			return _int7;
		}

		public int method_26()
		{
			return _int8;
		}
	}
}
