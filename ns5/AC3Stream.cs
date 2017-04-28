using System;
using System.IO;
using ns0;
using ns1;
using SharpAudio.ASC;

namespace ns5
{
	public class AC3Stream : GenericAudioStream
	{
		public int int_2;

		public double double_0;

		private bool bool_0;

		private int int_3;

		private readonly object object_0 = new object();

		private readonly AC3Class1 class111_0 = new AC3Class1();

		private int int_4 = -1;

		private int int_5 = -1;

		private short short_0 = -1;

		private MemoryStream memoryStream_0;

		public override bool CanRead
		{
			get
			{
				return fileStream.CanRead;
			}
		}

		public override bool CanSeek
		{
			get
			{
				return fileStream.CanSeek;
			}
		}

		public override bool CanWrite
		{
			get
			{
				return fileStream.CanWrite;
			}
		}

		public override long Length
		{
			get
			{
				return (long)((fileStream.Length - int_2) * double_0);
			}
		}

		public override long Position
		{
			get
			{
				return (long)((fileStream.Position - int_2) * double_0) - memoryStream_0.Length + memoryStream_0.Position;
			}
			set
			{
				fileStream.Position = (long)(value / double_0 + int_2);
				memoryStream_0.Position = memoryStream_0.Length;
			}
		}

		public AC3Stream(string string_0) : this(File.OpenRead(string_0))
		{
		}

		public AC3Stream(Stream stream_1) : this(stream_1, 4096)
		{
		}

		public AC3Stream(Stream stream_1, int int_6) : this(stream_1, int_6, true)
		{
		}

		public AC3Stream(Stream stream_1, int int_6, bool bool_1)
		{
			int_3 = (bool_1 ? 2 : 4);
			fileStream = stream_1;
			bool_0 = bool_1;
			memoryStream_0 = new MemoryStream();
			if (!method_0())
			{
				throw new Exception("Ac3 Decoder: Cannot read header.");
			}
			int_2 = (int)stream_1.Position;
			waveFormat_0 = (bool_1 ? new WaveFormat(int_5, 16, short_0) : new WaveFormat(int_5, short_0));
			double_0 = waveFormat_0.int_0 * waveFormat_0.short_1 / (int_4 / 8.0);
		}

		public override Class16 vmethod_1()
		{
			return new Class16(waveFormat_0, (uint)Position, (uint)Length);
		}

		public override void Flush()
		{
			fileStream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return fileStream.Seek((long)(offset / double_0) + ((origin == SeekOrigin.Begin) ? int_2 : 0), origin);
		}

		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new InvalidOperationException();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int result;
			lock (object_0)
			{
				int num = 0;
				do
				{
					if (memoryStream_0.Position == memoryStream_0.Length)
					{
						if (!method_0())
						{
							break;
						}
					}
					num += memoryStream_0.Read(buffer, offset + num, count - num);
				}
				while (num < count);
				result = num;
			}
			return result;
		}

		public override void Close()
		{
			fileStream.Close();
		}

		public bool method_0()
		{
			byte[] array = new byte[1792];
			fileStream.Read(array, 0, 1792);
			memoryStream_0 = new MemoryStream();
			class111_0.vmethod_0(array, memoryStream_0);
			short_0 = 2;
			int_5 = class111_0.int_2;
			int_4 = class111_0.int_3 / 1000;
			if (memoryStream_0.Length == 0L)
			{
				return false;
			}
			memoryStream_0.Position = 0L;
			return true;
		}

        protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Close();
			}
		}

		public override void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
