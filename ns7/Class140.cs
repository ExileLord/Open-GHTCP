using ns11;
using ns6;
using SharpAudio.ASC.Flac.LibFlac.frame;
using System;

namespace ns7
{
	public class Class140
	{
		public int int_0;

		public int int_1;

		public int int_2;

		public int int_3;

		public int int_4;

		public int int_5 = -1;

		public long long_0 = -1L;

		public Class140(Class144 class144_0, byte[] byte_0, Class122 class122_0)
		{
			int num = 0;
			int num2 = 0;
			Class152 @class = new Class152(16);
			bool flag = class122_0 != null && class122_0.vmethod_2() != class122_0.vmethod_1();
			bool flag2 = class122_0 != null && class122_0.vmethod_2() == class122_0.vmethod_1();
			@class.vmethod_1(byte_0[0]);
			@class.vmethod_1(byte_0[1]);
			if ((@class.vmethod_3(1) & 3) != 0)
			{
				throw new BadHeaderException("Bad Magic Number: " + (int)(@class.vmethod_3(1) & 255));
			}
			for (int i = 0; i < 2; i++)
			{
				if (class144_0.vmethod_11(8) == 255)
				{
					throw new BadHeaderException("Found sync byte");
				}
				@class.vmethod_1((byte)class144_0.vmethod_10(8));
			}
			int num3 = @class.vmethod_3(2) >> 4 & 15;
			switch (num3)
			{
			case 0:
				if (!flag2)
				{
					throw new BadHeaderException("Unknown Block Size (0)");
				}
				this.int_0 = class122_0.vmethod_2();
				break;
			case 1:
				this.int_0 = 192;
				break;
			case 2:
			case 3:
			case 4:
			case 5:
				this.int_0 = 576 << num3 - 2;
				break;
			case 6:
			case 7:
				num = num3;
				break;
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
				this.int_0 = 256 << num3 - 8;
				break;
			}
			int num4 = (int)(@class.vmethod_3(2) & 15);
			switch (num4)
			{
			case 0:
				if (class122_0 == null)
				{
					throw new BadHeaderException("Bad Sample Rate (0)");
				}
				this.int_1 = class122_0.vmethod_6();
				break;
			case 1:
			case 2:
			case 3:
				throw new BadHeaderException("Bad Sample Rate (" + num4 + ")");
			case 4:
				this.int_1 = 8000;
				break;
			case 5:
				this.int_1 = 16000;
				break;
			case 6:
				this.int_1 = 22050;
				break;
			case 7:
				this.int_1 = 24000;
				break;
			case 8:
				this.int_1 = 32000;
				break;
			case 9:
				this.int_1 = 44100;
				break;
			case 10:
				this.int_1 = 48000;
				break;
			case 11:
				this.int_1 = 96000;
				break;
			case 12:
			case 13:
			case 14:
				num2 = num4;
				break;
			case 15:
				throw new BadHeaderException("Bad Sample Rate (" + num4 + ")");
			}
			int num5 = @class.vmethod_3(3) >> 4 & 15;
			if ((num5 & 8) != 0)
			{
				this.int_2 = 2;
				switch (num5 & 7)
				{
				case 0:
					this.int_3 = 1;
					break;
				case 1:
					this.int_3 = 2;
					break;
				case 2:
					this.int_3 = 3;
					break;
				default:
					throw new BadHeaderException("Bad Channel Assignment (" + num5 + ")");
				}
			}
			else
			{
				this.int_2 = num5 + 1;
				this.int_3 = 0;
			}
			int num6 = (@class.vmethod_3(3) & 14) >> 1;
			switch (num6)
			{
			case 0:
				if (class122_0 == null)
				{
					throw new BadHeaderException("Bad BPS (" + num6 + ")");
				}
				this.int_4 = class122_0.vmethod_7();
				break;
			case 1:
				this.int_4 = 8;
				break;
			case 2:
				this.int_4 = 12;
				break;
			case 3:
			case 7:
				throw new BadHeaderException("Bad BPS (" + num6 + ")");
			case 4:
				this.int_4 = 16;
				break;
			case 5:
				this.int_4 = 20;
				break;
			case 6:
				this.int_4 = 24;
				break;
			}
			if ((@class.vmethod_3(3) & 1) != 0)
			{
				throw new BadHeaderException("this should be a zero padding bit");
			}
			if (num != 0 && flag)
			{
				this.long_0 = class144_0.vmethod_19(@class);
				if (this.long_0 == -1L)
				{
					throw new BadHeaderException("Bad Sample Number");
				}
			}
			else
			{
				int num7 = class144_0.vmethod_18(@class);
				if ((long)num7 == 4294967295L)
				{
					throw new BadHeaderException("Bad Last Frame");
				}
				this.long_0 = (long)class122_0.vmethod_2() * (long)num7;
			}
			if (num != 0)
			{
				int num8 = class144_0.vmethod_10(8);
				@class.vmethod_1((byte)num8);
				if (num == 7)
				{
					int num9 = class144_0.vmethod_10(8);
					@class.vmethod_1((byte)num9);
					num8 = (num8 << 8 | num9);
				}
				this.int_0 = num8 + 1;
			}
			if (num2 != 0)
			{
				int num10 = class144_0.vmethod_10(8);
				@class.vmethod_1((byte)num10);
				if (num2 != 12)
				{
					int num11 = class144_0.vmethod_10(8);
					@class.vmethod_1((byte)num11);
					num10 = (num10 << 8 | num11);
				}
				if (num2 == 12)
				{
					this.int_1 = num10 * 1000;
				}
				else if (num2 == 13)
				{
					this.int_1 = num10;
				}
				else
				{
					this.int_1 = num10 * 10;
				}
			}
			byte b = (byte)class144_0.vmethod_10(8);
			if (Class149.smethod_0(@class.vmethod_2(), @class.vmethod_0()) != b)
			{
				throw new BadHeaderException("STREAM_DECODER_ERROR_STATUS_BAD_HEADER");
			}
		}

		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"FrameHeader: BlockSize=",
				this.int_0,
				" SampleRate=",
				this.int_1,
				" Channels=",
				this.int_2,
				" ChannelAssignment=",
				this.int_3,
				" BPS=",
				this.int_4,
				" SampleNumber=",
				this.long_0
			});
		}
	}
}
