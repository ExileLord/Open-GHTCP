using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ns0;
using ns1;
using ns3;
using ns4;
using SharpAudio.ASC;

namespace ns8
{
	public class FSBStream : GenericAudioStream
	{
		private readonly GenericAudioStream stream1_0;

		public override bool CanRead
		{
			get
			{
				return stream1_0.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return stream1_0.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return stream1_0.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return stream1_0.Length;
			}
		}

		public override long Position
		{
			get
			{
				return stream1_0.Position;
			}
			set
			{
				stream1_0.Position = value;
			}
		}

		public FSBStream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public FSBStream(Stream stream_1) : this(FSBClass1.smethod_0(stream_1))
		{
		}

		public FSBStream(FSBClass1 class167_0)
		{
			switch (class167_0.method_33().Count)
			{
			case 0:
				throw new Exception5("FSB Stream: No subfiles.");
			case 1:
				fileStream = (stream1_0 = smethod_0(class167_0.method_33()[0]));
				break;
			default:
			{
				var list = new List<GenericAudioStream>();
				foreach (var current in class167_0.method_33())
				{
					list.Add(smethod_0(current));
				}
				fileStream = (stream1_0 = new Stream2(list.ToArray()));
				break;
			}
			}
			waveFormat_0 = stream1_0.vmethod_0();
		}

		private static GenericAudioStream smethod_0(Class168 class168_0)
		{
			var flag = (class168_0.enum22_0 & FSBFlags2.flag_19) != FSBFlags2.flag_0;
			var stream_ = class168_0.stream_1;
			var position = stream_.Position;
			var array = new byte[4];
			stream_.Read(array, 0, 4);
			stream_.Position = position;
			if (array[0] == 255 && array[1] >= 240)
			{
				if ((class168_0.enum22_0 & FSBFlags2.flag_27) != FSBFlags2.flag_0 && class168_0.uint_3 > 2u)
				{
					return new MP3Class(class168_0.stream_1, (int)(class168_0.uint_3 / 2u), flag ? Enum4.const_3 : Enum4.const_0);
				}
				return new MP3Stream(class168_0.stream_1, flag ? Enum4.const_3 : Enum4.const_0);
			}
		    string @string;
		    if ((@string = Encoding.UTF8.GetString(array, 0, 3)) != null && @string == "Ogg")
		    {
		        return new OGGStream(class168_0.stream_1);
		    }
		    if ((class168_0.enum22_0 & FSBFlags2.flag_17) != FSBFlags2.flag_0)
		    {
		        return new Stream5(class168_0.stream_1, new WaveFormat(class168_0.int_0, ((class168_0.enum22_0 & FSBFlags2.flag_4) != FSBFlags2.flag_0) ? 8 : 16, (int)class168_0.uint_3));
		    }
		    throw new Exception5("FSB SubFile: Data not supported.");
		}

		public override int vmethod_3(IntPtr intptr_0, int int_2)
		{
			return stream1_0.vmethod_3(intptr_0, int_2);
		}

		public override int vmethod_4(float[] float_0, int int_2, int int_3)
		{
			return stream1_0.vmethod_4(float_0, int_2, int_3);
		}

		public override float[][] vmethod_5(int int_2)
		{
			return stream1_0.vmethod_5(int_2);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return stream1_0.Read(buffer, offset, count);
		}

		public override void SetLength(long value)
		{
			stream1_0.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}
	}
}
