using ns0;
using ns4;
using SharpAudio.ASC.Mp3.Decoding;
using System;
using System.Text;

namespace ns5
{
	public class zzSoundClass
	{
		public static readonly int[][] int_0 = new int[][]
		{
			new int[]
			{
				22050,
				24000,
				16000,
				1
			},
			new int[]
			{
				44100,
				48000,
				32000,
				1
			},
			new int[]
			{
				11025,
				12000,
				8000,
				1
			}
		};

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private Enum3 enum3_0;

		private Enum5 enum5_0;

		private int int_6;

		private int int_7;

		private int int_8;

		private bool bool_0;

		private bool bool_1;

		private readonly double[] double_0 = new double[]
		{
			-1.0,
			384.0,
			1152.0,
			1152.0
		};

		private bool bool_2;

		private int int_9;

		private int int_10;

		private int int_11;

		private Class83 class83_0;

		private byte byte_0;

		private Class101 class101_0;

		public short short_0;

		public int int_12;

		public int int_13;

		private int int_14 = -1;

		public static readonly int[,,] int_15 = new int[,,]
		{
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

		public static readonly string[][][] string_0 = new string[][][]
		{
			new string[][]
			{
				new string[]
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
				new string[]
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
				new string[]
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
			new string[][]
			{
				new string[]
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
				new string[]
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
				new string[]
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
			new string[][]
			{
				new string[]
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
				new string[]
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
				new string[]
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
			this.byte_0 = Class82.byte_1;
		}

		public zzSoundClass()
		{
			this.method_0();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(200);
			stringBuilder.Append("Layer ");
			stringBuilder.Append(this.method_19());
			stringBuilder.Append(" frame ");
			stringBuilder.Append(this.method_23());
			stringBuilder.Append(' ');
			stringBuilder.Append(this.method_24());
			if (!this.method_9())
			{
				stringBuilder.Append(" no");
			}
			stringBuilder.Append(" checksums");
			stringBuilder.Append(' ');
			stringBuilder.Append(this.method_22());
			stringBuilder.Append(',');
			stringBuilder.Append(' ');
			stringBuilder.Append(this.method_20());
			return stringBuilder.ToString();
		}

		public void method_1(Class82 class82_0, Class101[] class101_1)
		{
			bool flag = false;
			while (true)
			{
				int num = class82_0.method_9(this.byte_0);
				this.int_14 = num;
				if (this.byte_0 == Class82.byte_1)
				{
					this.enum3_0 = (Enum3)(num >> 19 & 1);
					if ((num >> 20 & 1) == 0)
					{
						if (this.enum3_0 != Enum3.const_0)
						{
							goto IL_1EE;
						}
						this.enum3_0 = Enum3.const_2;
					}
					if ((this.int_6 = (num >> 10 & 3)) == 3)
					{
						goto Block_20;
					}
				}
				this.int_1 = (4 - (num >> 17) & 3);
				this.int_2 = (num >> 16 & 1);
				this.int_3 = (num >> 12 & 15);
				this.int_4 = (num >> 9 & 1);
				this.enum5_0 = (Enum5)(num >> 6 & 3);
				this.int_5 = (num >> 4 & 3);
				if (this.enum5_0 == Enum5.const_1)
				{
					this.int_8 = (this.int_5 << 2) + 4;
				}
				else
				{
					this.int_8 = 0;
				}
				if ((num >> 3 & 1) == 1)
				{
					this.bool_0 = true;
				}
				if ((num >> 2 & 1) == 1)
				{
					this.bool_1 = true;
				}
				if (this.int_1 == 1)
				{
					this.int_7 = 32;
				}
				else
				{
					int num2 = this.int_3;
					if (this.enum5_0 != Enum5.const_3)
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
							if (this.int_6 != 1 && (num2 < 3 || num2 > 5))
							{
								this.int_7 = 30;
								goto IL_102;
							}
							this.int_7 = 27;
							goto IL_102;
						}
					}
					this.int_7 = ((this.int_6 == 2) ? 12 : 8);
				}
				IL_102:
				if (this.int_8 > this.int_7)
				{
					this.int_8 = this.int_7;
				}
				this.method_15();
				int num3 = class82_0.method_11(this.int_12);
				if (this.int_12 >= 0 && num3 != this.int_12)
				{
					break;
				}
				if (class82_0.method_8((int)this.byte_0))
				{
					if (this.byte_0 == Class82.byte_1)
					{
						this.byte_0 = Class82.byte_2;
						class82_0.method_14(num & -521024);
					}
					flag = true;
				}
				else
				{
					class82_0.method_6();
				}
				if (flag)
				{
					goto Block_17;
				}
			}
			throw new BitstreamException(BitstreamError.InvalidFrame);
			Block_17:
			class82_0.method_12();
			if (this.int_2 == 0)
			{
				this.short_0 = (short)class82_0.method_13(16);
				if (this.class101_0 == null)
				{
					this.class101_0 = new Class101();
				}
				int num=0;
				this.class101_0.method_0(num, 16);
				class101_1[0] = this.class101_0;
			}
			else
			{
				class101_1[0] = null;
			}
			return;
			Block_20:
			throw new BitstreamException(BitstreamError.UnknownError);
			IL_1EE:
			throw new BitstreamException(BitstreamError.UnknownError);
		}

		public void method_2(byte[] byte_1)
		{
			int num;
			if (this.enum3_0 == Enum3.const_1)
			{
				num = ((this.enum5_0 == Enum5.const_3) ? 17 : 32);
			}
			else
			{
				num = ((this.enum5_0 == Enum5.const_3) ? 9 : 17);
			}
			try
			{
				string @string = Encoding.UTF8.GetString(byte_1, num, 4);
				if (@string.Equals("Xing") || @string.Equals("Info"))
				{
					this.bool_2 = true;
					this.int_9 = -1;
					this.int_11 = -1;
					this.int_10 = -1;
					byte[] array = new byte[100];
					int num2 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + 4));
					int num3 = 8;
					if ((num2 & 1) != 0)
					{
						this.int_9 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + num3));
						num3 += 4;
					}
					if ((num2 & 2) != 0)
					{
						this.int_11 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + num3));
						num3 += 4;
					}
					if ((num2 & 4) != 0)
					{
						Buffer.BlockCopy(byte_1, num + num3, array, 0, array.Length);
						num3 += array.Length;
						this.class83_0 = new Class83(array, this.int_11);
					}
					if ((num2 & 8) != 0)
					{
						this.int_10 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + num3));
						num3 += 4;
					}
				}
			}
			catch (IndexOutOfRangeException exception_)
			{
				throw new BitstreamException("Xing Header Corrupted", exception_);
			}
			num = 32;
			try
			{
				if (Encoding.UTF8.GetString(byte_1, num, 4).Equals("VBRI"))
				{
					this.bool_2 = true;
					this.int_9 = -1;
					this.int_11 = -1;
					this.int_10 = -1;
					this.int_10 = (int)zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + 8));
					this.int_11 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + 10));
					this.int_9 = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + 14));
					int[] array2 = new int[(int)zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + 18))];
					short num4 = zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + 20));
					short num5 = zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + 22));
					short num6 = zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + 24));
					int num7 = 26;
					switch (num5)
					{
					case 1:
					{
						int i = 0;
						while (i < array2.Length)
						{
							array2[i] = (int)((short)byte_1[num + num7] * num4);
							i++;
							num7++;
						}
						break;
					}
					case 2:
					{
						int j = 0;
						while (j < array2.Length)
						{
							array2[j] = (int)(zzSoundClass.smethod_1(BitConverter.ToInt16(byte_1, num + num7)) * num4);
							j++;
							num7 += 2;
						}
						break;
					}
					case 3:
					{
						int k = 0;
						while (k < array2.Length)
						{
							array2[k] = Struct8.smethod_0(Struct8.smethod_3(byte_1, num + num7, true)) * (int)num4;
							k++;
							num7 += 3;
						}
						break;
					}
					case 4:
					{
						int l = 0;
						while (l < array2.Length)
						{
							array2[l] = zzSoundClass.smethod_0(BitConverter.ToInt32(byte_1, num + num7)) * (int)num4;
							l++;
							num7 += 4;
						}
						break;
					}
					default:
						throw new Exception("Size per table entry in bytes - is bigger then 4: " + num5);
					}
					this.class83_0 = new Class83(array2, num6);
				}
			}
			catch (IndexOutOfRangeException exception_2)
			{
				throw new BitstreamException("VBRI Header Corrupted", exception_2);
			}
		}

		private static int smethod_0(int int_16)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return int_16;
			}
			return ((int)zzSoundClass.smethod_1((short)int_16) & 65535) << 16 | ((int)zzSoundClass.smethod_1((short)(int_16 >> 16)) & 65535);
		}

		private static short smethod_1(short short_1)
		{
			if (!BitConverter.IsLittleEndian)
			{
				return short_1;
			}
			return (short)((int)(short_1 & 255) << 8 | (short_1 >> 8 & 255));
		}

		public Enum3 method_3()
		{
			return this.enum3_0;
		}

		public int method_4()
		{
			return this.int_1;
		}

		public int method_5()
		{
			return this.int_3;
		}

		public int method_6()
		{
			return this.int_6;
		}

		public int method_7()
		{
			return zzSoundClass.int_0[(int)this.enum3_0][this.int_6];
		}

		public Enum5 method_8()
		{
			return this.enum5_0;
		}

		public bool method_9()
		{
			return this.int_2 == 0;
		}

		public bool method_10()
		{
			return this.bool_2;
		}

		public Class83 method_11()
		{
			return this.class83_0;
		}

		public bool method_12()
		{
			return this.short_0 == this.class101_0.method_1();
		}

		public int method_13()
		{
			return this.int_13;
		}

		public int method_14()
		{
			return this.int_5;
		}

		public int method_15()
		{
			if (this.int_1 == 1)
			{
				this.int_12 = 12 * zzSoundClass.int_15[(int)this.enum3_0, 0, this.int_3] / zzSoundClass.int_0[(int)this.enum3_0][this.int_6];
				if (this.int_4 != 0)
				{
					this.int_12++;
				}
				this.int_12 <<= 2;
				this.int_13 = 0;
			}
			else
			{
				this.int_12 = 144 * zzSoundClass.int_15[(int)this.enum3_0, this.int_1 - 1, this.int_3] / zzSoundClass.int_0[(int)this.enum3_0][this.int_6];
				if (this.enum3_0 == Enum3.const_0 || this.enum3_0 == Enum3.const_2)
				{
					this.int_12 >>= 1;
				}
				if (this.int_4 != 0)
				{
					this.int_12++;
				}
				if (this.int_1 == 3)
				{
					if (this.enum3_0 == Enum3.const_1)
					{
						this.int_13 = this.int_12 - ((this.enum5_0 == Enum5.const_3) ? 17 : 32) - ((this.int_2 != 0) ? 0 : 2) - 4;
					}
					else
					{
						this.int_13 = this.int_12 - ((this.enum5_0 == Enum5.const_3) ? 9 : 17) - ((this.int_2 != 0) ? 0 : 2) - 4;
					}
				}
				else
				{
					this.int_13 = 0;
				}
			}
			this.int_12 -= 4;
			return this.int_12;
		}

		public int method_16(int int_16)
		{
			if (this.bool_2)
			{
				return this.int_9;
			}
			if (this.int_12 + 4 - this.int_4 == 0)
			{
				return 0;
			}
			return int_16 / (this.int_12 + 4 - this.int_4);
		}

		public double method_17()
		{
			if (this.bool_2)
			{
				double num = this.double_0[this.method_4()] / (double)this.method_7();
				if (this.enum3_0 == Enum3.const_0 || this.enum3_0 == Enum3.const_2)
				{
					num /= 2.0;
				}
				return num * 1000.0;
			}
			float[,] array = new float[,]
			{
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
			return (double)array[this.int_1 - 1, this.int_6];
		}

		public double method_18(int int_16)
		{
			return (double)this.method_16(int_16) * this.method_17();
		}

		public string method_19()
		{
			switch (this.int_1)
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
			if (this.bool_2)
			{
				return Convert.ToString(this.method_21() / 1000) + " kb/s";
			}
			return zzSoundClass.string_0[(int)this.enum3_0][this.int_1 - 1][this.int_3];
		}

		public int method_21()
		{
			if (this.bool_2)
			{
				return (int)((double)(this.int_11 * 8) / (this.method_17() * (double)this.int_9)) * 1000;
			}
			return zzSoundClass.int_15[(int)this.enum3_0, this.int_1 - 1, this.int_3];
		}

		public string method_22()
		{
			switch (this.int_6)
			{
			case 0:
				if (this.enum3_0 == Enum3.const_1)
				{
					return "44.1 kHz";
				}
				if (this.enum3_0 == Enum3.const_0)
				{
					return "22.05 kHz";
				}
				return "11.025 kHz";
			case 1:
				if (this.enum3_0 == Enum3.const_1)
				{
					return "48 kHz";
				}
				if (this.enum3_0 == Enum3.const_0)
				{
					return "24 kHz";
				}
				return "12 kHz";
			case 2:
				if (this.enum3_0 == Enum3.const_1)
				{
					return "32 kHz";
				}
				if (this.enum3_0 == Enum3.const_0)
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
			switch (this.enum5_0)
			{
			case Enum5.const_0:
				return "Stereo";
			case Enum5.const_1:
				return "Joint stereo";
			case Enum5.const_2:
				return "Dual channel";
			case Enum5.const_3:
				return "Single channel";
			default:
				return null;
			}
		}

		public string method_24()
		{
			switch (this.enum3_0)
			{
			case Enum3.const_0:
				return "MPEG-2 LSF";
			case Enum3.const_1:
				return "MPEG-1";
			case Enum3.const_2:
				return "MPEG-2.5 LSF";
			default:
				return null;
			}
		}

		public int method_25()
		{
			return this.int_7;
		}

		public int method_26()
		{
			return this.int_8;
		}
	}
}
