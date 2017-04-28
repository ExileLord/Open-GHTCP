using ns11;
using ns6;
using SharpAudio.ASC.Flac.LibFlac.frame;

namespace ns7
{
	public class Class140
	{
		public int Int0;

		public int Int1;

		public int Int2;

		public int Int3;

		public int Int4;

		public int Int5 = -1;

		public long Long0 = -1L;

		public Class140(Class144 class1440, byte[] byte0, Class122 class1220)
		{
			var num = 0;
			var num2 = 0;
			var @class = new Class152(16);
			var flag = class1220 != null && class1220.vmethod_2() != class1220.vmethod_1();
			var flag2 = class1220 != null && class1220.vmethod_2() == class1220.vmethod_1();
			@class.vmethod_1(byte0[0]);
			@class.vmethod_1(byte0[1]);
			if ((@class.vmethod_3(1) & 3) != 0)
			{
				throw new BadHeaderException("Bad Magic Number: " + (@class.vmethod_3(1) & 255));
			}
			for (var i = 0; i < 2; i++)
			{
				if (class1440.vmethod_11(8) == 255)
				{
					throw new BadHeaderException("Found sync byte");
				}
				@class.vmethod_1((byte)class1440.vmethod_10(8));
			}
			var num3 = @class.vmethod_3(2) >> 4 & 15;
			switch (num3)
			{
			case 0:
				if (!flag2)
				{
					throw new BadHeaderException("Unknown Block Size (0)");
				}
				Int0 = class1220.vmethod_2();
				break;
			case 1:
				Int0 = 192;
				break;
			case 2:
			case 3:
			case 4:
			case 5:
				Int0 = 576 << num3 - 2;
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
				Int0 = 256 << num3 - 8;
				break;
			}
			var num4 = @class.vmethod_3(2) & 15;
			switch (num4)
			{
			case 0:
				if (class1220 == null)
				{
					throw new BadHeaderException("Bad Sample Rate (0)");
				}
				Int1 = class1220.vmethod_6();
				break;
			case 1:
			case 2:
			case 3:
				throw new BadHeaderException("Bad Sample Rate (" + num4 + ")");
			case 4:
				Int1 = 8000;
				break;
			case 5:
				Int1 = 16000;
				break;
			case 6:
				Int1 = 22050;
				break;
			case 7:
				Int1 = 24000;
				break;
			case 8:
				Int1 = 32000;
				break;
			case 9:
				Int1 = 44100;
				break;
			case 10:
				Int1 = 48000;
				break;
			case 11:
				Int1 = 96000;
				break;
			case 12:
			case 13:
			case 14:
				num2 = num4;
				break;
			case 15:
				throw new BadHeaderException("Bad Sample Rate (" + num4 + ")");
			}
			var num5 = @class.vmethod_3(3) >> 4 & 15;
			if ((num5 & 8) != 0)
			{
				Int2 = 2;
				switch (num5 & 7)
				{
				case 0:
					Int3 = 1;
					break;
				case 1:
					Int3 = 2;
					break;
				case 2:
					Int3 = 3;
					break;
				default:
					throw new BadHeaderException("Bad Channel Assignment (" + num5 + ")");
				}
			}
			else
			{
				Int2 = num5 + 1;
				Int3 = 0;
			}
			var num6 = (@class.vmethod_3(3) & 14) >> 1;
			switch (num6)
			{
			case 0:
				if (class1220 == null)
				{
					throw new BadHeaderException("Bad BPS (" + num6 + ")");
				}
				Int4 = class1220.vmethod_7();
				break;
			case 1:
				Int4 = 8;
				break;
			case 2:
				Int4 = 12;
				break;
			case 3:
			case 7:
				throw new BadHeaderException("Bad BPS (" + num6 + ")");
			case 4:
				Int4 = 16;
				break;
			case 5:
				Int4 = 20;
				break;
			case 6:
				Int4 = 24;
				break;
			}
			if ((@class.vmethod_3(3) & 1) != 0)
			{
				throw new BadHeaderException("this should be a zero padding bit");
			}
			if (num != 0 && flag)
			{
				Long0 = class1440.vmethod_19(@class);
				if (Long0 == -1L)
				{
					throw new BadHeaderException("Bad Sample Number");
				}
			}
			else
			{
				var num7 = class1440.vmethod_18(@class);
				if (num7 == 4294967295L)
				{
					throw new BadHeaderException("Bad Last Frame");
				}
				Long0 = class1220.vmethod_2() * (long)num7;
			}
			if (num != 0)
			{
				var num8 = class1440.vmethod_10(8);
				@class.vmethod_1((byte)num8);
				if (num == 7)
				{
					var num9 = class1440.vmethod_10(8);
					@class.vmethod_1((byte)num9);
					num8 = (num8 << 8 | num9);
				}
				Int0 = num8 + 1;
			}
			if (num2 != 0)
			{
				var num10 = class1440.vmethod_10(8);
				@class.vmethod_1((byte)num10);
				if (num2 != 12)
				{
					var num11 = class1440.vmethod_10(8);
					@class.vmethod_1((byte)num11);
					num10 = (num10 << 8 | num11);
				}
				if (num2 == 12)
				{
					Int1 = num10 * 1000;
				}
				else if (num2 == 13)
				{
					Int1 = num10;
				}
				else
				{
					Int1 = num10 * 10;
				}
			}
			var b = (byte)class1440.vmethod_10(8);
			if (Class149.smethod_0(@class.vmethod_2(), @class.vmethod_0()) != b)
			{
				throw new BadHeaderException("STREAM_DECODER_ERROR_STATUS_BAD_HEADER");
			}
		}

		public override string ToString()
		{
			return string.Concat("FrameHeader: BlockSize=", Int0, " SampleRate=", Int1, " Channels=", Int2, " ChannelAssignment=", Int3, " BPS=", Int4, " SampleNumber=", Long0);
		}
	}
}
