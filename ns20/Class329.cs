using ns1;
using ns8;
using System;
using System.IO;
using System.Text;

namespace ns20
{
	public class Class329
	{
		private static readonly byte[] byte_0 = Encoding.ASCII.GetBytes("5atu6w4zaw");

		public static long smethod_0(string string_0, Stream[] stream_0)
		{
			long length;
			using (FSBClass1 @class = new FSBClass1())
			{
				@class.byte_0 = Class329.byte_0;
				@class.enum20_0 = Enum20.const_3;
				@class.enum21_0 = Enum21.flag_0;
				for (int i = 0; i < stream_0.Length; i++)
				{
					Stream stream = stream_0[i];
					stream.Position = 0L;
					Class16 class2 = AudioManager.smethod_3(stream);
					Class168 class3 = new Class168();
					class3.string_0 = i + ".mp3";
					class3.enum22_0 = (((class2.method_0() == 1) ? Enum22.flag_6 : Enum22.flag_7) | Enum22.flag_10);
					class3.int_0 = class2.method_3();
					class3.ushort_0 = 255;
					class3.short_0 = 0;
					class3.ushort_1 = 255;
					class3.uint_3 = (uint)class2.method_0();
					class3.uint_0 = class2.uint_0;
					class3.uint_1 = 0u;
					class3.uint_2 = class3.uint_0 - 1u;
					class3.float_2 = 1f;
					class3.float_3 = 10000f;
					class3.int_1 = 0;
					class3.short_1 = 0;
					class3.short_2 = -1;
					class3.stream_1 = stream;
					@class.method_33().Add(class3);
				}
				@class.method_16(string_0);
				length = new FileInfo(string_0).Length;
			}
			return length;
		}
	}
}
